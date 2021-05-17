import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppService } from '@services/app.service';
import { BaseService } from '@services/base.service';

@Injectable({
  providedIn: 'root'
})
export class PatientService extends BaseService {
  private _headers;

  constructor(private http: HttpClient,
    appService: AppService,
    @Inject('BASE_URL') private baseUrl: string) {
    super(appService)
  }

  async getAllPatients(): Promise<Observable<any>> {
    this._headers = await this.getHeaders();

    return this.http.get(this.baseUrl + 'patient', this._headers)
  }

  async addPatient(patient): Promise<Observable<any>> {

    console.info(patient);
    this._headers = await this.getHeaders();

    return this.http.post(this.baseUrl + 'patient', patient, this._headers);
  }
}
