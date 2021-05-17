import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  public user: User;
  public authNavStatusSource = new BehaviorSubject<string>('');
  private _manager = new UserManager(this.getClientSettings());

  constructor(private router: Router) {
    //this._manager.getUser()
    //  .then(user => {
    //    console.info('this.manager.getUser');
    //    console.info(user);

    //    if (user === null || user === undefined) {
    //      return this._manager.signinRedirectCallback(null);
    //    }
    //    this.user = user;
    //  });

    //this.getUser();
  }

  private async getUser(): Promise<User> {

    const user = await this._manager.getUser();

    console.info('this.manager.getUser');
    console.info(user);

    if (user === null || user === undefined) {
      return this._manager.signinRedirectCallback(null);
    }

    this.user = user;
  }

  startAuthentication(): Promise<void> {

    console.info('login');
    return this._manager.signinRedirect();
  }

  completeAuthentication(): Promise<void> {
    return this._manager.signinRedirectCallback().then(user => {

      console.log('signinRedirectCallback');

      this.user = user;
      this.authNavStatusSource.next(this.getRoles());
    });
  }

  isAuthenticated(): boolean {

    console.info('isAuthenticated');
    console.info(this.user != null && !this.user.expired);
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
  }

  async getUserId(): Promise<any> {
    if (this.user == null || this.user == undefined) {
      {
        this.user = await this._manager.getUser();
      }
    }

    return this.user ? this.user.profile.sub : '';
  }

  async getAccessToken(): Promise<any> {
    console.info('getAccessToken');
    console.info(this.user);

    //if (this.user === null || this.user === undefined) {

    //  console.info('getAccessToken signinRedirectCallback');
    //  const user = await this._manager.signinRedirectCallback();

    //  this.user = user;
    //}

      if (this.user == null || this.user == undefined) {
      {
        this.user = await this._manager.getUser();
      }}

    //const user = await this.getUser();
    console.info(this.user);
    console.info('getAccessToken end');

    return this.user.access_token;
  }

  getRoles(): any {

    console.info('this.user.profile.role');

    return this.user ? this.user.profile?.role : '';
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  async getProfile() {
    console.info('getProfile');
    console.info(this.user);
    //console.info(User.);
    //this.user = { 'username': 'diya' }
    this.user = await this._manager.getUser()
    console.info(this.user);

    return this.user;

  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('gatekeeper_token');
    this.user = null;
    this._manager.signoutRedirect();
    this.router.navigate(['/']);
  }

  getClientSettings(): UserManagerSettings {
    return {
      authority: 'https://localhost:44363',
      client_id: 'covidPortal',
      redirect_uri: 'https://localhost:44364/auth-callback/',
      post_logout_redirect_uri: 'https://localhost:44364/',
      response_type: "id_token token",
      //response_type: "code",
      scope: "openid profile email roles patientAPI hospitalAPI vendorAPI offline_access",
      filterProtocolClaims: true,
      loadUserInfo: true
    };
  }
}
