import { Component, OnInit } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { RegisterationService } from '../services/registeration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  modal = {
    email: '',
    password: ''
  }

  constructor(private registerationService: RegisterationService, private TokenHandler: TokenHandler, private Router: Router) {

  }

  ngOnInit(): void {
    this.TokenHandler.removeToken();
  }

  saveData() {
    this.registerationService.loginUser(this.modal).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          var role = this.TokenHandler.getRoleFromToken();
          var id = this.TokenHandler.getUserIdFromToken();
          if (role == "Patient") {
            this.Router.navigateByUrl('/patient/home');
          }
          else if (role == "Doctor") {
            this.Router.navigateByUrl('/doctor/home');
          }
        }
        else{
          console.log(res);
          alert(res.errors[""][0])
          
        }
      }
    })
  }
}
