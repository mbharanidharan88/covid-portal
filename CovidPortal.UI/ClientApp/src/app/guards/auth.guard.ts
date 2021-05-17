import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AppService } from '@services/app.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild {

  // https://fullstackmark.com/post/21/user-authentication-and-identity-with-angular-aspnet-core-and-identityserver
  constructor(private router: Router, private appService: AppService) {

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {

    if (this.appService.isAuthenticated()) {
      return true;
    }

    this.appService.startAuthentication();
    return false;
  }

  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    return this.canActivate(next, state);
  }

  async getProfile() {
    console.log('getProfile');
    console.log(this.appService.user)

    if (this.appService.user) {
      return true;
    }

    try {
      var user = await this.appService.getProfile();

      console.info('user');
      console.info(user);
      //return true;

      if (user == null) {
        this.router.navigate(['/login']);
      }

      return true;
    } catch (error) {
      this.router.navigate(['/login']);
      return false;
    }
  }

}
