import { Component } from '@angular/core';
import { AppointmentsService } from 'src/app/services/appointments.service';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})
export class AppointmentDetailsComponent {

  constructor(private appointmentService: AppointmentsService) {

  }
  model = {
    name: '',
    department: '',
    email: '',
    contact: ''
  }
  detail = {
    appointmentno: '',
    date: '',
    time: '',
    status: '',
    fee: ''
  }

  medication = {
    disease: '',
    description1: '',
    description2: '',
    description3: '',
    description4: '',
    medicine1: '',
    medicine2: '',
    medicine3: '',
    prefer1: '',
    prefer2: '',
    pefer3: ''
  }
  ngOnInit() {
    this.model = this.appointmentService.DoctorDetails;
    this.detail = this.appointmentService.AppointmentDetails;
    this.medication = this.appointmentService.Prescription;
  }
}

