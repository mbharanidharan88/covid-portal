import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PatientService } from '@services/patient.service';
import { AppService } from '@services/app.service';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {
  public patients: any;
  public patientForm: FormGroup;
  public isLoading = false;

  constructor(http: HttpClient,
    private appService: AppService,
    private patientService: PatientService,) {

    //this.patientService.getAllPatients()
    //  .subscribe(result => {
    //    this.patients = result;
    //  }, error => console.error(error));

    this.getPatientForm();
  }

  ngOnInit(): void {
  }

  async addPatient() {
    

    let dt = this.patientForm.controls.covidTestedDate.value;
    const time = this.patientForm.controls.covidTestedTime.value;

    dt.setHours(time.getHours(), time.getMinutes(), time.getSeconds());

    

    this.patientForm.patchValue({
      covidTestedDate: dt
    });

    const postData = this.patientForm.value;
    console.info(postData);

    (await this.patientService.addPatient(postData)).pipe()
      .subscribe(result => {
        console.info(result)
      }, error => console.error(error))
  }

  private async getPatientForm() {

    const userId = await this.appService.getUserId();

    console.info('getPatientForm', userId);

    this.patientForm = new FormGroup({
      patientName: new FormControl(null, Validators.required),
      email: new FormControl(null, Validators.required),
      mobile: new FormControl(null, Validators.required),
      covidTestedDate: new FormControl(null, Validators.required),
      covidTestedTime: new FormControl(null, Validators.required),
      healthComplications: new FormControl(null, Validators.required),
      daysInQueue: new FormControl(null, Validators.required),
      applicationUserId: new FormControl(userId, Validators.required),
    });
  }

}
