import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorLayoutComponent } from './doctor-layout/doctor-layout.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '', component: DoctorLayoutComponent, children: [
      { path: 'home', component: HomeComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
