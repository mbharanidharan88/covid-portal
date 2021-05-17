import { Component, OnInit } from '@angular/core';
import { VendorService } from '@services/vendor.service';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.css']
})
export class VendorListComponent implements OnInit {
  public vendors: any;

  constructor(private vendorService: VendorService) { }

  ngOnInit(): void {
    this.getAllVendors();
  }

  private async getAllVendors() {
    (await this.vendorService.getAllVendors()).pipe()
      .subscribe(result => {
        this.vendors = result;
      }, error => console.error(error));
  }
}
