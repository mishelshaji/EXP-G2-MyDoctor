import { Component } from '@angular/core';
import { DepartmentsService } from '../services/departments.service';
import { RegisterationService } from '../services/registeration.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  public userRole: string;
  public userSpec: string;
  public departments: any = [];

  model = {
    fname: '',
    lname: '',
    email: '',
    password: '',
    cpassword: '',
  }

  constructor(private DepartmentService: DepartmentsService, private registerationService: RegisterationService) {

  }

  ngOnInit() {
    this.departments = this.DepartmentService.getAll();
  }
  
  saveData() {
    this.registerationService.registerUser(this.model)
  }
}
