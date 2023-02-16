import { Component } from '@angular/core';
import { RegisterationService } from '../services/registeration.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  modal = {
    email: '',
    password: ''
  }

  constructor(private registerationService: RegisterationService) {
    
  }

  saveData(){
    this.registerationService.loginUser(this.modal).subscribe({
      next: res => {
        console.log(res);
      }
    })
  }
}
