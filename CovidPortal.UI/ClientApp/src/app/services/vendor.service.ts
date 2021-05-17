import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BaseService } from '@services/base.service';
import { Observable } from 'rxjs';
import { AppService } from '@services/app.service';

@Injectable({
  providedIn: 'root'
})
export class VendorService extends BaseService {
  private _headers;

  constructor(private http: HttpClient,
    appService: AppService,
    @Inject('BASE_URL') private baseUrl: string) {
    super(appService);
  }

  async getAllVendors(): Promise<Observable<any>> {

    this._headers = await this.getHeaders();

    return this.http.get(this.baseUrl + 'vendor', this._headers)
  }

  async addVendor(vendor): Promise<Observable<any>> {

    console.info(vendor);
    this._headers = await this.getHeaders();

    return this.http.post(this.baseUrl + 'vendor', vendor, this._headers);
  }
}
