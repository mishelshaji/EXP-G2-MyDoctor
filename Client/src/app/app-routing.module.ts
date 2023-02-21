import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientGuard } from 'src/helpers/guards/patient.guard';
import { DoctorModule } from './doctor/doctor.module';
import { ErrorPageComponent } from './error-page/error-page.component';
import { LoginComponent } from './login/login.component';
import { OtpPageComponent } from './otp-page/otp-page.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'patient', canActivate: [PatientGuard], loadChildren: () => import('./patient/patient.module').then(m => m.PatientModule) },
  { path: 'admin', canActivate: [PatientGuard], loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  { path: 'doctor', canActivate: [PatientGuard], loadChildren: () => import('./doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'otp', component: OtpPageComponent },
  { path: 'error-page', component: ErrorPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
