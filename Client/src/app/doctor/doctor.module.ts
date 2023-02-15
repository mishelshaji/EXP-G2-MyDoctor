import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './home/home.component';
import { DoctorLayoutComponent } from './doctor-layout/doctor-layout.component';
import { NavbarDoctorComponent } from './navbar-doctor/navbar-doctor.component';
import { LeaveComponent } from './leave/leave.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';


@NgModule({
  declarations: [
    HomeComponent,
    DoctorLayoutComponent,
    NavbarDoctorComponent,
    LeaveComponent,
    AppointmentsComponent,
    DoctorProfileComponent
  ],
  imports: [
    CommonModule,
    DoctorRoutingModule,
    RouterModule,
    FormsModule,
    FontAwesomeModule
  ]
})
export class DoctorModule { }
