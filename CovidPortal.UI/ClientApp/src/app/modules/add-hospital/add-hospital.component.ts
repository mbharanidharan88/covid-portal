import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from '@services/app.service';
import { HospitalService } from '@services/hospital.service';

@Component({
  selector: 'app-add-hospital',
  templateUrl: './add-hospital.component.html',
  styleUrls: ['./add-hospital.component.css']
})
export class AddHospitalComponent implements OnInit {
  public hospitalForm: FormGroup;
  public isLoading = false;

  constructor(private appService: AppService,
              private hospitalService: HospitalService) {

    this.getHospitalForm();
  }

  ngOnInit(): void {
  }

  async addHospital() {

    const postData = this.hospitalForm.value;
    console.info(postData);

    (await this.hospitalService.addHospital(postData)).pipe()
      .subscribe(result => {
        console.info(result)
      }, error => console.error(error))
  }

  private async getHospitalForm() {

    const userId = await this.appService.getUserId();

    console.info('getHospitalForm', userId);

    this.hospitalForm = new FormGroup({
      hospitalName: new FormControl(null, Validators.required),
      hospitalCity: new FormControl(null, Validators.required),
      numberOfBeds: new FormControl(null, Validators.required),
      oxygenCapacityInTonnes: new FormControl(null, Validators.required),
      balanceCapacityInTonnes: new FormControl(null, Validators.required),
      applicationUserId: new FormControl(userId, Validators.required),
    });
  }
}
