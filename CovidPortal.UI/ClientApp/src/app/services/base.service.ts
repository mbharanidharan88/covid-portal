import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService } from '@services/app.service';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  private _token;
  
  constructor(private appService: AppService) {

  }

  protected async getHeaders() {
    this._token = await this.appService.getAccessToken();

    return {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${this._token}`)
        .set('Content-Type', 'application/json')
        .set('Accept', 'application/json')
    }
  }
}
