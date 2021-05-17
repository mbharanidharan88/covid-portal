import { Component, OnInit } from '@angular/core';
import { AppService } from '@services/app.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;

  private _roleObs = this.appService.authNavStatusSource.asObservable();
  public role = '';

  constructor(private appService: AppService) {}

  ngOnInit() {
    this._roleObs.subscribe(value => this.role = value);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
