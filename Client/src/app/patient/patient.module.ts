import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { NavbarPatientComponent } from './navbar-patient/navbar-patient.component';
import { PatientLayoutComponent } from './patient-layout/patient-layout.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [
    HomeComponent,
    NavbarPatientComponent,
    PatientLayoutComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule,
    RouterModule
  ]
})
export class PatientModule { }
