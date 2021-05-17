import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { AppService } from '@services/app.service';
import { Observable } from 'rxjs';
import { BaseService } from '@services/base.service';

@Injectable({
  providedIn: 'root'
})
export class HospitalService extends BaseService {
  private _headers;

  constructor(private http: HttpClient,
    appService: AppService,
    @Inject('BASE_URL') private baseUrl: string) {
    super(appService);
  }

  async getAllHospitals(): Promise<Observable<any>> {

    this._headers = await this.getHeaders();

    return this.http.get(this.baseUrl + 'hospital', this._headers)
  }

  async addHospital(hospital): Promise<Observable<any>> {

    console.info(hospital);
    this._headers = await this.getHeaders();

    return this.http.post(this.baseUrl + 'hospital', hospital, this._headers);
  }
}
