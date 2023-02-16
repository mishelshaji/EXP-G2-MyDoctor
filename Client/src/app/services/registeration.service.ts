import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Injectable({
  providedIn: 'root'
})
export class RegisterationService {
  url: string = 'https://localhost:7238/api/user/'

  constructor(private http: HttpClient, private TokenHandler: TokenHandler) {

  }

  registerUser(model: any) {
    return this.http.post(this.url + "accounts", model)
  }

  loginUser(model: any) {
    var res = this.http.post(this.url + "accounts/login", model)
    res.subscribe({
      next: (res: any) => {
        this.TokenHandler.setToken(res.result)
      }
    })
  }
}
