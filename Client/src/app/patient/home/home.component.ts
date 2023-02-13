import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { inject } from '@angular/core/testing';
import { DepartmentsService } from 'src/app/services/departments.service';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  departments: any = [];
  doctors: any = [];
  searchItems: any = [];
  enteredSearchValue: string = '';

  constructor(private DepartmentsService: DepartmentsService, private DoctorService: DoctorService) {

  }

  ngOnInit() {
    this.departments = this.DepartmentsService.getAll();
  }

  searchResult() {
    var result = document.getElementById('result-dept') as HTMLElement;
    result.style.display = 'block';
    result.scrollIntoView();
    this.doctors = this.DoctorService.getAll();
    this.searchItems = [];
    
    for (let i = 0; i < this.doctors.length; i++) {
      if (this.doctors[i].department == this.enteredSearchValue)
        this.searchItems.push(this.DoctorService.getSearchDetails(i));
    }
  }
}