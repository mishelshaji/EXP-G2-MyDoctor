import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentBookingComponent } from './appointment-booking/appointment-booking.component';
import { AppointmentHistoryComponent } from './appointment-history/appointment-history.component';
import { HomeComponent } from './home/home.component';
import { PatientLayoutComponent } from './patient-layout/patient-layout.component';

const routes: Routes = [
  {
    path: '', component: PatientLayoutComponent, children: [
      { path: 'home', component: HomeComponent },
      { path: 'appointment-booking', component: AppointmentBookingComponent },
      { path: 'appointment-history', component: AppointmentHistoryComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
