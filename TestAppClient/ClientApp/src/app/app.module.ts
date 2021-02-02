import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { MsalGuard, MsalInterceptor, MsalModule } from '@azure/msal-angular';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule, Routes } from '@angular/router';

export const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;
export const protectedResourceMap: [string, string[]][] = [['https://localhost:44382', ['api://553bb697-339e-4f56-b697-325b0f0981e8/api-access']]];	

const appRoutes: Routes = [
  {
    path: '',
    component: AppComponent,
    canActivate: [MsalGuard]
  }
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    MsalModule.forRoot({
      auth: {
        clientId: '553bb697-339e-4f56-b697-325b0f0981e8',
        authority: 'https://login.microsoftonline.com/58e58092-152d-43b6-8345-cdf46f5c8ed1',
        redirectUri: 'https://localhost:44382',
      },
      cache: {
        cacheLocation: 'localStorage',
        storeAuthStateInCookie: isIE,
      },
    }, {
      popUp: !isIE,
      consentScopes: [
        'user.read',
        'openid',
        'profile',
      ],
      unprotectedResources: [],
      protectedResourceMap: [
        ['https://graph.microsoft.com/v1.0/me', ['user.read']],
        ['https://localhost:44382', ['api://553bb697-339e-4f56-b697-325b0f0981e8/api-access']]
      ],
      extraQueryParameters: {}
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

