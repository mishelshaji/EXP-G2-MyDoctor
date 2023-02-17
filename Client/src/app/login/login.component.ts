import { Component } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { RegisterationService } from '../services/registeration.service';
import { Router } from '@angular/router';

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

  constructor(private registerationService: RegisterationService, private TokenHandler: TokenHandler, private Router: Router) {
    
  }

  saveData(){
    this.registerationService.loginUser(this.modal).subscribe({
      next: (res: any) =>{
        console.log(res);  
        var role = this.TokenHandler.getRoleFromToken();
        var id = this.TokenHandler.getUserIdFromToken();
        if( role == "Patient"){
          this.Router.navigateByUrl('/patient/home');
        }
        else if( role == "Doctor"){
          this.Router.navigateByUrl('/doctor/home');
        }
      } 
    })
  }
}
