import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminSidebarComponent } from './admin-sidebar/admin-sidebar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PatientSectionComponent } from './patient-section/patient-section.component';
import { DoctorSectionComponent } from './doctor-section/doctor-section.component';
import { DepartmentSectionComponent } from './department-section/department-section.component';
import { RegistrationApprovalComponent } from './registration-approval/registration-approval.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    AdminDashboardComponent,
    AdminSidebarComponent,
    PatientSectionComponent,
    DoctorSectionComponent,
    DepartmentSectionComponent,
    RegistrationApprovalComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FontAwesomeModule,
    FormsModule
  ]
})
export class AdminModule { }
