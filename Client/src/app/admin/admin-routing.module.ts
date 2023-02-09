import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../patient/home/home.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { DepartmentSectionComponent } from './department-section/department-section.component';
import { DoctorSectionComponent } from './doctor-section/doctor-section.component';
import { PatientSectionComponent } from './patient-section/patient-section.component';

const routes: Routes = [
  {
    path: '', component: AdminLayoutComponent, children: [
      { path: 'dashboard', component: AdminDashboardComponent },
      { path: 'patientsection', component: PatientSectionComponent },
      { path: 'doctorsection', component: DoctorSectionComponent },
      { path: 'departmentsection', component: DepartmentSectionComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
