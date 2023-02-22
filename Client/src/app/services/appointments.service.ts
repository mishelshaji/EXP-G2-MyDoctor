import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

  url = 'https://localhost:7238/api/Patient/Appointment'
  
  constructor(private http: HttpClient,
    private tokenHandler: TokenHandler) {

  }

  getTodaysAppointmentsForDoctor(){
    return this.http.get(`https://localhost:7238/api/Doctor/DoctorHome`)
  }

  getUpcomingAppointmentsForDoctor() {
    return this.http.get(`https://localhost:7238/api/Doctor/DoctorHome/history`)
  }

  getPreviousAppointmentsForDoctor() {
    return this.http.get(`https://localhost:7238/api/Doctor/DoctorHome/history`)
  }

  getCancelledAppointmentsForDoctor() {
    return this.http.get(`https://localhost:7238/api/Doctor/DoctorHome/history`)
  }

  getUpcomingAppointmentsForPatients(){
    return this.http.get(`https://localhost:7238/api/Patient/Appointment`);
  }

  getPreviousAppointmentsForPatients() {
    return this.http.get('https://localhost:7238/api/Patient/Appointment');
  }

  getCancelledAppointmentsForPatients() {
    return this.http.get('https://localhost:7238/api/Patient/Appointment');
  }

  getBookingData(id: number) {
    return this.http.get(this.url + `/${id}`);
  }

  getTimeSlots(idsample: string, date: string) {
    var id = parseInt(idsample)
    return this.http.get(this.url + `/${id}/${date}`);
  }

  AddBookings(model: any) {
    model.patientMasterId = parseInt(this.tokenHandler.getMasterId());
    return this.http.post(this.url, model);
  }

  timeConvert (time: any) {
    // Check correct time format and split into components
    time = time.toString ().match (/^([01]\d|2[0-3])(:)([0-5]\d)(:[0-5]\d)?$/) || [time];
  
    if (time.length > 1) { // If time format correct
      time = time.slice (1);  // Remove full string match value
      time[5] = +time[0] < 12 ? 'AM' : 'PM'; // Set AM/PM
      time[0] = +time[0] % 12 || 12; // Adjust hours
    }
    return time.join (''); // return adjusted time or original string
  }
}