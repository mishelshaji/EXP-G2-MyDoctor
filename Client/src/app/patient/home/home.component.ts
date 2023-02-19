import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { inject } from '@angular/core/testing';
import { DepartmentsService } from 'src/app/services/departments.service';
import { DoctorService } from 'src/app/services/doctor.service';
import { PatientService } from 'src/app/services/patient.service';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  departments: any;
  doctors: any = [];
  resultItems: any = [];
  enteredSearchValue: string = '';

  constructor(private departmentsService: DepartmentsService,
    private patientService: PatientService,
    private router: Router) {

  }

  ngOnInit() {
    this.departmentsService.getDepartmentsAuthorized().subscribe({
      next: (res: any) => {
        this.departments = res.result;
      },
      error: (res: any) => {
        alert("Unauthorised");
      }
    })
  }

  searchResult() {
    var result = document.getElementById('result-dept') as HTMLElement;
    result.style.display = 'block';
    result.scrollIntoView();
    this.resultItems = [];
    this.patientService.searchResult(this.enteredSearchValue).subscribe({
      next: (res: any) => {
        this.resultItems = res.result;
        console.log(res.result);
        
      },
      error: (res: any) => {
        alert("Wrong Search!");
      }
    });
  }

  saveData(doctid: any){
    this.router.navigateByUrl(`/patient/booking/${doctid}`);
  }
}