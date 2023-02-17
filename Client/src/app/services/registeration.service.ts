import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Injectable({
  providedIn: 'root'
})
export class RegisterationService {
  url: string = 'https://localhost:7238/api/user/';
  public registerData: any;

  constructor(private http: HttpClient, private TokenHandler: TokenHandler) {

  }

  getOtp(model: any) {
    this.registerData = model.email
    localStorage.setItem('registerData', JSON.stringify(model));
    return this.http.post(this.url + "accounts", model)
  }

  registerUser(otp: string) {
    var data: any = localStorage.getItem('registerData');
    var model: any = JSON.parse(data);
    model.otp = otp.toString();
    console.log(model);
    return this.http.post(this.url + "accounts/register", model);
  }

  getRegisterdata() {
    return this.registerData;
  }

  loginUser(model: any) {
    var res = this.http.post(this.url + "accounts/login", model)
    res.subscribe({
      next: (res: any) => {
        if (res.isValid)
          this.TokenHandler.setToken(res.result);
        else
          this.TokenHandler.removeToken();
      }
    })
    return res;
  }
}
