import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PatientProfileDto } from 'src/types/Dtos/patient.profile.dto';

@Injectable({
  providedIn: 'root'
})

export class PatientService {

  url = 'https://localhost:7238/api/Patient/Home';

  constructor(private http: HttpClient) { }

  updateProfile(model: PatientProfileDto) {
      return this.http.put(this.url, model);
  }

  searchResult(searchValue: string) {
    return
  }
}
