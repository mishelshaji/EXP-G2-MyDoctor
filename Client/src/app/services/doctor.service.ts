import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { concatWith } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private doctors = [];

  constructor(private http: HttpClient) {
  }

  getAll() {
    return this.http.get('https://localhost:7238/api/Doctor/DoctorHome/Profile');
  }
  
  getSearchDetails(index: number) {
    return this.doctors[index];
  }

  updateProfile(model: object) {
    return this.http.put('https://localhost:7238/api/Doctor/DoctorHome/Profile', model);
  }

  patientDetailsAppointmentDetails(patientId: number){
    return this.http.get(`https://localhost:7238/api/Doctor/DoctorsConsultation/PatientDetails?id=${patientId}`)
  }

  consultationAppointmentDetails(appointmentId: number){
    return this.http.get(`https://localhost:7238/api/Doctor/DoctorsConsultation/AppointmentDetails?id=${appointmentId}`)
  }

  updateConsultationData(appointmentId: number, appointmentDetails: any){
    return this.http.put(`https://localhost:7238/api/Doctor/DoctorsConsultation/Prescription?id=${appointmentId}`,appointmentDetails);
  }
}
