import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { AuthService } from 'src/app/services';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public isExpanded = false;
  public authenticated = false;
  public user: User;

  constructor(private authService: AuthService) { }
  
  ngOnInit(): void {
    this.authenticated = this.authService.authenticated;
    this.user = this.authService.user;
  }

  public signOut() {
    this.authService.signOut();
  }

  public collapse() {
    this.isExpanded = false;
  }

  public toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
