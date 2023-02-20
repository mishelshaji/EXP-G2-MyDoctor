import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientGuard } from 'src/helpers/guards/patient.guard';
import { DoctorModule } from './doctor/doctor.module';
import { LoginComponent } from './login/login.component';
import { OtpPageComponent } from './otp-page/otp-page.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'patient', canActivate: [PatientGuard], loadChildren: () => import('./patient/patient.module').then(m => m.PatientModule) },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  { path: 'doctor', canActivate: [PatientGuard], loadChildren: () => import('./doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'otp', component: OtpPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
