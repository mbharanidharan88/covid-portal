import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from '@components/nav-menu/nav-menu.component';
import { HomeComponent } from '@components/home/home.component';
import { MainComponent } from '@modules/main/main.component';
import { LoginComponent } from '@modules/login/login.component';
import { AppRoutingModule } from './app.routing.module';
import { AuthCallbackComponent } from '@components/auth-callback/auth-callback.component';
import { AppButtonComponent } from './components/app-button/app-button.component';
import { AuthGuard } from '@guards/auth.guard';
import { NonAuthGuard } from '@guards/non-auth.guard';
import { LogoutComponent } from './modules/logout/logout.component';
import { AddPatientComponent } from './modules/add-patient/add-patient.component';
import { AddHospitalComponent } from './modules/add-hospital/add-hospital.component';
import { AddVendorComponent } from './modules/add-vendor/add-vendor.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { PatientListComponent } from './modules/patient-list/patient-list.component';
import { HospitalListComponent } from './modules/hospital-list/hospital-list.component';
import { VendorListComponent } from './modules/vendor-list/vendor-list.component';



@NgModule({
  declarations: [ 
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MainComponent,
    LoginComponent,
    AuthCallbackComponent,
    AppButtonComponent,
    LogoutComponent,
    AddPatientComponent,
    AddHospitalComponent,
    AddVendorComponent,
    PatientListComponent,
    HospitalListComponent,
    VendorListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot()
//    RouterModule.forRoot([
//    { path: '', component: HomeComponent, pathMatch: 'full' },
//    { path: 'counter', component: CounterComponent },
//    { path: 'fetch-data', component: FetchDataComponent },
//], { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    AuthGuard,
    NonAuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
