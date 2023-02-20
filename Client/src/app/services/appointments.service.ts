import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

  url = 'https://localhost:7238/api/Patient/Appointment'
  
  doctorDetails = {
    name: 'Dr.Raj Kumar',
    department: 'Dentistry',
    email: 'rajkumar@gmail.com',
    phone: '8905XXXXXX'
  }

  appointmentDetails = {
    appointmentno: '123',
    date: '24-02-2023',
    time: '2:30',
    status: 'true',
    fee: '300'
  }

  prescription = {
    disease: 'Influenza',
    description1: 'Difficulty breathing',
    description2: 'Chest pain',
    description3: 'Seizures',
    description4: 'Dizziness',
    medicine1: 'Expectorant - 1 tablet',
    medicine2: 'Paracetamol-1 tablet',
    medicine3: 'Vitamin C - 500g',
    prefer1: '2 times per day (after food)',
    prefer2: '2 times per day(after food)',
    pefer3: 'Once per day(after food)'

  }

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
}