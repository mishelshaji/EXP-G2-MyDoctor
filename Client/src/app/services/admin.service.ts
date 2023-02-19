import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  url = 'https://localhost:7238/api/Admin/Dashboard'

  constructor(private http: HttpClient) {

  }

  getPatientsCount() {
    return this.http.get(this.url + '/PatientsCount');
  }

  getDoctorsCount() {
    return this.http.get(this.url + '/DoctorsCount');
  }

  getUpcomingBookingsCount() {
    return this.http.get(this.url + '/UpcomingBookingsCount');
  }

  getCompletedBookingsCount() {
    return this.http.get(this.url + '/CompletedBookingsCount');
  }

  getRegistrationApprovalsCount() {
    return this.http.get(this.url + '/RegistrationApprovalsCount');
  }
}
