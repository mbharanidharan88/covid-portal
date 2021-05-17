import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from "@modules/main/main.component";
import { LoginComponent } from "@modules/login/login.component";
import { AuthGuard } from '@guards/auth.guard';
import { NonAuthGuard } from '@guards/non-auth.guard';
import { NgModule } from '@angular/core';
import { AuthCallbackComponent } from '@components/auth-callback/auth-callback.component';
import { LogoutComponent } from '@modules/logout/logout.component';
import { RoleGuard } from '@guards/role.guard';
import { AddPatientComponent } from '@modules/add-patient/add-patient.component';
import { AddHospitalComponent } from '@modules/add-hospital/add-hospital.component';
import { AddVendorComponent } from '@modules/add-vendor/add-vendor.component';
import { HomeComponent } from '@components/home/home.component';
import { PatientListComponent } from '@modules/patient-list/patient-list.component';
import { HospitalListComponent } from '@modules/hospital-list/hospital-list.component';
import { VendorListComponent } from '@modules/vendor-list/vendor-list.component';


const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Admin'] },
    children: [
      {
        path: 'home',
        component: HomeComponent
      }
    ]
  },
  {
    path: 'hospitals',
    component: HospitalListComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Patient', 'Vendor'] },
  },
  {
    path: 'add-patient',
    component: AddPatientComponent,
    canActivate: [AuthGuard, RoleGuard],
    // canActivate: [NonAuthGuard],
    data: { roles: ['Patient'] },
  },
  {
    path: 'add-hospital',
    component: AddHospitalComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Doctor'] },
  },
  {
    path: 'patients',
    component: PatientListComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Doctor'] },
  },
  {
    path: 'vendors',
    component: VendorListComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['Doctor'] },
  },
  {
    path: 'add-vendor',
    component: AddVendorComponent,
    canActivate: [NonAuthGuard, RoleGuard],
    data: { roles: ['Vendor'] },
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [NonAuthGuard]
  },
  {
    path: 'logout',
    component: LogoutComponent,
    canActivate: [NonAuthGuard]
  },
  {
    path: 'auth-callback',
    component: AuthCallbackComponent,
    canActivate: [NonAuthGuard]
  },
  { path: '**', redirectTo: '' }
]

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
