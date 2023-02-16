import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { inject } from '@angular/core/testing';
import { DepartmentsService } from 'src/app/services/departments.service';
import { DoctorService } from 'src/app/services/doctor.service';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  departments: any = [];
  doctors: any = [];
  resultItems: any = [];
  enteredSearchValue: string = '';

  constructor(private departmentsService: DepartmentsService, private doctorService: DoctorService, private patientService: PatientService) {

  }

  ngOnInit() {
    this.departments = this.departmentsService.getAll();
  }

  searchResult() {
    var result = document.getElementById('result-dept') as HTMLElement;
    result.style.display = 'block';
    result.scrollIntoView();
    this.resultItems = [];
    this.resultItems = this.patientService.searchResult(this.enteredSearchValue);
  }
}