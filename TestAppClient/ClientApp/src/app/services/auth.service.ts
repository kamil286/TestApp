import { Injectable } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { Client } from '@microsoft/microsoft-graph-client';
import { OAuthSettings } from '../../oauth.settings';
import { User } from '../models';
import * as MicrosoftGraph from '@microsoft/microsoft-graph-types';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  public authenticated: boolean;
  public user: User;

  constructor(
    private msalService: MsalService) {

    this.authenticated = this.msalService.getAccount() != null;
    this.getUser().then((user) => {this.user = user});
  }

  async signIn(): Promise<void> {
    let result = await this.msalService.loginPopup(OAuthSettings)
      .catch((reason) => {
        console.log('Login failed', JSON.stringify(reason, null, 2));
      });

    if (result) {
      this.authenticated = true;
      this.user = await this.getUser();
    }
  }

  signOut(): void {
    this.msalService.logout();
    this.user = null;
    this.authenticated = false;
  }

  async getAccessToken(): Promise<string> {
    let result = await this.msalService.acquireTokenSilent(OAuthSettings)
      .catch((reason) => {
        console.log('Get token failed', JSON.stringify(reason, null, 2));
      });

    if (result) {
      return result.accessToken;
    }

    this.authenticated = false;
    return null;
  }

  private async getUser(): Promise<User> {
    if (!this.authenticated) return null;

    let graphClient = Client.init({
      authProvider: async(done) => {
        let token = await this.getAccessToken()
          .catch((reason) => {
            done(reason, null);
          });

        if (token)
        {
          done(null, token);
        } else {
          done("Could not get an access token", null);
        }
      }
    });

    // Get the user from Graph (GET /me)
    let graphUser: MicrosoftGraph.User = await graphClient
      .api('/me')
      .select('displayName,mail,mailboxSettings,userPrincipalName')
      .get();

    let user = new User();
    user.displayName = graphUser.displayName;
    user.email = graphUser.mail || graphUser.userPrincipalName;
    user.timeZone = graphUser.mailboxSettings.timeZone;

    return user;
  }
}