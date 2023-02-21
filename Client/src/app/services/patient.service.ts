import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PatientHomeSearchDto } from 'src/types/patienthomesearch.dto';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  url = "https://localhost:7238/api/Patient/Home";

  constructor(private http: HttpClient) {

  }

  updateProfile(model: object) {
    return this.http.put('https://localhost:7238/api/Patient/Home/PatientProfileUpdate',model)
  }

  searchResult(searchValue: string) {
    return this.http.get<PatientHomeSearchDto>(this.url + '?searchValue=' + searchValue);
  }

  doctorDetailsAppointmentDetails(doctorId: number) {
    return this.http.get(`https://localhost:7238/api/Patient/Home/DoctorDetails?id=${doctorId}`)
  }

  consultationAppointmentDetails(appointmentId: number) {
    return this.http.get(`https://localhost:7238/api/Patient/Home/AppointmentDetails?id=${appointmentId}`)
  }

  getPatientProfile() {
    return this.http.get('https://localhost:7238/api/Patient/Home/GetPatientProfile')
  }
}
