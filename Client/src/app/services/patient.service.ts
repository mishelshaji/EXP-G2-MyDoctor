import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PatientHomeSearchDto } from 'src/types/patienthomesearch.dto';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  url = "https://localhost:7238/api/Patient/Home";

  constructor(private http: HttpClient) { }

  updateProfile(model: object) {
    console.log(model);
  }

  searchResult(searchValue: string) {
    return this.http.get<PatientHomeSearchDto>(this.url + '?searchValue=' + searchValue);
  }
}
