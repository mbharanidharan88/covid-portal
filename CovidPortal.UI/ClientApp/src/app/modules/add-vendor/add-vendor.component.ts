import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from '@services/app.service';
import { VendorService } from '@services/vendor.service';

@Component({
  selector: 'app-add-vendor',
  templateUrl: './add-vendor.component.html',
  styleUrls: ['./add-vendor.component.css']
})
export class AddVendorComponent implements OnInit {
  public vendorForm: FormGroup;
  public isLoading = false;

  constructor(private appService: AppService,
    private vendorService: VendorService) {

    this.getVendorForm();
  }

  ngOnInit(): void {
  }

  async addVendor() {

    const postData = this.vendorForm.value;
    console.info(postData);

    (await this.vendorService.addVendor(postData)).pipe()
      .subscribe(result => {
        console.info(result)
      }, error => console.error(error))
  }

  private async getVendorForm() {

    const userId = await this.appService.getUserId();

    console.info('getVendorForm', userId);

    this.vendorForm = new FormGroup({
      vendorName: new FormControl(null, Validators.required),
      vendorCity: new FormControl(null, Validators.required),
      product: new FormControl(null, Validators.required),
      email: new FormControl(null, Validators.required),
      mobile: new FormControl(null, Validators.required),
      applicationUserId: new FormControl(userId, Validators.required),
    });
  }
}
