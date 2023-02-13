import { Component } from '@angular/core';
import { RegisterationService } from '../services/registeration.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  Specilization = [
    {
      id: 1,
      spec: 'Eyes'
    },
    {
      id: 2,
      spec: 'Cardio'
    },
    {
      id: 3,
      spec: 'Physician'
    }
  ]
  model = {
    firstName: '',
    lastName: '',
    email: '',
    password:'',
    cpassword:'',
    role:'',
    specilization:''
  }
 
  constructor(private service:RegisterationService) {
    
  }

  saveData(){
   
  }
}
