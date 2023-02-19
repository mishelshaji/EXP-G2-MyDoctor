import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

  url = 'https://localhost:7238/api/Patient/Appointment'
  private upcomingAppointments = [

  ]

  private previousAppointments = [
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    },
    {
      id: 3,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. rashid',
      status: true
    },
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    }
  ]

  private cancelledAppointments = [
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    },
    {
      id: 3,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. rashid',
      status: true
    },
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    }
  ]

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

  getUpcomingAppointments() {
    return this.upcomingAppointments
  }

  getPreviousAppointments() {
    return this.previousAppointments
  }

  getCancelledAppointments() {
    return this.cancelledAppointments
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