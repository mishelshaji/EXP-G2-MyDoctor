import { Component } from '@angular/core';
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

  constructor(private departmentService: DepartmentsService, private registerationService: RegisterationService) {

  }

  ngOnInit() {
    this.departmentService.getAll().subscribe({
      next: (Data) => {
        this.departments = Data;
      }
    })
  }

  saveData() {
    this.registerationService.registerUser(this.model).subscribe({
      next: (res) => {
        console.log(res);
      }
    })
  }
}
