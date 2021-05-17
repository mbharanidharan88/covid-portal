import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '@services/app.service';

@Component({
  selector: 'app-auth-callback',
  template: '',
  styleUrls: ['./auth-callback.component.css']
})
export class AuthCallbackComponent implements OnInit {

  error: boolean;

  constructor(private appService: AppService, private router: Router, private route: ActivatedRoute) { }

  async ngOnInit() {

    console.info('auth callback');
    await this.appService.completeAuthentication();
    this.router.navigate(['/']);
    //// check for error
    //if (this.route.snapshot.fragment.indexOf('error') >= 0) {

    //  console.info('error auth callback');
    //  this.error = true;
    //  return;
    //}

    //await this.appService.completeAuthentication();
    //this.router.navigate(['/']);
  }

}
