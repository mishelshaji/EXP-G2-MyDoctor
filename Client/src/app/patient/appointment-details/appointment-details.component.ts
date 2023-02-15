import { Component, OnInit } from '@angular/core';
import { AppointmentsService } from 'src/app/services/appointments.service';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})

export class AppointmentDetailsComponent implements OnInit {

  model = {
    name: '',
    department: '',
    email: '',
    phone: ''
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

  constructor(private appointmentService: AppointmentsService) {

  }

  ngOnInit() {
    this.model = this.appointmentService.doctorDetails;
    this.detail = this.appointmentService.appointmentDetails;
    this.medication = this.appointmentService.prescription;
  }
}

