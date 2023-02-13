import { Component } from '@angular/core';
import { AppointmentsService } from 'src/app/services/appointments.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  appointments: any = [];
  constructor(private AppointmentService: AppointmentsService) {

  }
  ngOnInit() {
    this.appointments = this.AppointmentService.getCancelledAppointments();
  }

}
