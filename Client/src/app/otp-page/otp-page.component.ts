import { Component } from '@angular/core';
import { Router } from '@angular/router';
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
          alert("Your OTP Verification has been successful. Please login using your credentials.")
          this.Router.navigateByUrl("")
        }
        else
          alert("Error in OTP Verification!");
        console.log(res);
      }
    })

  }
}
