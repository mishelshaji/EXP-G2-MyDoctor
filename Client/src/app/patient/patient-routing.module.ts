import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PatientModule } from './patient.module';
import { PatientprofileComponent } from './patientprofile/patientprofile.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'patientprofile', component: PatientprofileComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
