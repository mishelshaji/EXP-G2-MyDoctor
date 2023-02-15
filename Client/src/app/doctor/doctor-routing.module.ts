import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { DoctorLayoutComponent } from './doctor-layout/doctor-layout.component';
import { HomeComponent } from './home/home.component';
import { LeaveComponent } from './leave/leave.component';

const routes: Routes = [
  {
    path: '', component: DoctorLayoutComponent, children: [
      { path: 'home', component: HomeComponent },
      { path: 'leave', component: LeaveComponent },
      { path: 'appointments', component: AppointmentsComponent},
      {path: 'appointment-details', component: AppointmentDetailsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
