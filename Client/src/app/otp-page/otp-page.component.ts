import { Component } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { RegisterationService } from '../services/registeration.service';

@Component({
  selector: 'app-otp-page',
  templateUrl: './otp-page.component.html',
  styleUrls: ['./otp-page.component.css']
})
export class OtpPageComponent {

  otp: string;

  constructor(private RegisterService: RegisterationService, private Router: Router) {

  }

  saveData() {
    var otp = parseInt(this.otp)
    this.RegisterService.registerUser(otp).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          Swal.fire("Your OTP Verification has been successful. Please login using your credentials.")
          this.Router.navigateByUrl("")
        }
        else
          Swal.fire("Error in OTP Verification!");
        console.log(res);
      }
    })

  }
}
