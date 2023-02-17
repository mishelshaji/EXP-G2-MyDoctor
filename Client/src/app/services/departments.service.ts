import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DepartmentSuggestionDto } from 'src/types/Dtos/department.suggestion';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {
  url = "https://localhost:7238/api/Patient/Home/departments";

  constructor(private http: HttpClient) {

  }

  getAll() {
    return this.http.get<DepartmentSuggestionDto[]>(this.url);
  }
}