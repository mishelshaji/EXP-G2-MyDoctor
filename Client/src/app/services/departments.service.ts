import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { DepartmentSuggestionDto } from 'src/types/Dtos/department.suggestion';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {
  url = "https://localhost:7238/api/Patient/Departments/";

  constructor(private http: HttpClient, private tokenHandler: TokenHandler) {

  }

  getAll() {
    return this.http.get<DepartmentSuggestionDto[]>(this.url + "register");
  }

  getDepartmentsAuthorized(){
    return this.http.get<DepartmentSuggestionDto[]>(this.url);
  }
}