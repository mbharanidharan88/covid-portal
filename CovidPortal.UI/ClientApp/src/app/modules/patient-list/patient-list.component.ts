import { Component, OnInit } from '@angular/core';
import { PatientService } from '@services/patient.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {
  public patients: any;

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.getAllPatients();
  }

  private async getAllPatients() {
    (await this.patientService.getAllPatients()).pipe()
      .subscribe(result => {
        this.patients = result;
      }, error => console.error(error));
  }
}
