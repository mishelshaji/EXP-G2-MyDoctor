import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { HomeComponent } from './home/home.component';
import { PatientprofileComponent } from './patientprofile/patientprofile.component';


@NgModule({
  declarations: [
    HomeComponent,
    PatientprofileComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule
  ]
})
export class PatientModule { }
