import { Component, OnInit, OnDestroy, Renderer2 } from '@angular/core';
import { AppService } from '@services/app.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy  {
  public isAuthLoading = false;

  constructor(private renderer: Renderer2,
    private appService: AppService) { }

  ngOnInit(): void {
    this.renderer.addClass(
      document.querySelector('app-root'),
      'login-page'
    );
  }
  async login() {
    await this.appService.startAuthentication();
  }

  ngOnDestroy() {
    this.renderer.removeClass(
      document.querySelector('app-root'),
      'login-page'
    );
  }
}
