import { Component, OnInit } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { RegisterationService } from '../services/registeration.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2/dist/sweetalert2.js'

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
    localStorage.removeItem('registerData');
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
          else if (role == "Admin") {
            this.Router.navigateByUrl('/admin/dashboard')
          }
        }
        else {
          Swal.fire(
            'Did you entered the correct email ?',
            res.errors[""][0],
            'question'
          )
         
        }
      },
      error: (res: any) => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Internal server error!',
        })
      }
    })
  }
}
