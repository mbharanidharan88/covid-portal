import { Component, OnInit } from '@angular/core';
import { HospitalService } from '@services/hospital.service';

@Component({
  selector: 'app-hospital-list',
  templateUrl: './hospital-list.component.html',
  styleUrls: ['./hospital-list.component.css']
})
export class HospitalListComponent implements OnInit {
  public hospitals: any;

  constructor(private hospitalService: HospitalService) { }

  ngOnInit(): void {
    this.getAllHospitals();
  }

  private async getAllHospitals() {
    (await this.hospitalService.getAllHospitals()).pipe()
      .subscribe(result => {
        this.hospitals = result;
      }, error => console.error(error));
  }
}
