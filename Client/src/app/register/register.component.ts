import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DepartmentsService } from '../services/departments.service';
import { RegisterationService } from '../services/registeration.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  departments:any;

  model = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    cPassword: '',
    role: '',
    Specialization: ''
  }

  constructor(private DepartmentService: DepartmentsService, private registerationService: RegisterationService, private Router: Router) {

  }

  ngOnInit() {
    this.departmentService.getAll().subscribe({
      next: (Data) => {
        this.departments = Data;
      }
    })
  }

  saveData() {
    this.registerationService.getOtp(this.model).subscribe({
      next: (res) => {
        if (res)
          this.Router.navigateByUrl('/otp');
        else
          alert("error occured")
      }
    })
  }
}
