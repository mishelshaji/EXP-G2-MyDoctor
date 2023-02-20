import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  url = 'https://localhost:7238/api/Admin'

  constructor(private http: HttpClient) {

  }

  getPatientsCount() {
    return this.http.get(this.url + '/Dashboard/PatientsCount');
  }

  getDoctorsCount() {
    return this.http.get(this.url + '/Dashboard/DoctorsCount');
  }

  getUpcomingBookingsCount() {
    return this.http.get(this.url + '/Dashboard/UpcomingBookingsCount');
  }

  getCompletedBookingsCount() {
    return this.http.get(this.url + '/Dashboard/CompletedBookingsCount');
  }

  getRegistrationApprovalsCount() {
    return this.http.get(this.url + '/Dashboard/RegistrationApprovalsCount');
  }

  getNewDoctors() {
    return this.http.get(this.url + '/Approval/Registration');
  }

  approveDoctor(id: number) {
    return this.http.put(this.url + '/Approval/Registration' + `/${id}`, {});
  }

  declineDoctor(id: number) {
    console.log(this.url + '/Approval/Registration' + `/${id}`)

    return this.http.delete(this.url + '/Approval/Registration' + `/${id}`);
  }
}
