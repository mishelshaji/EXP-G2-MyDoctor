import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentsService } from 'src/app/services/appointments.service';
import { DoctorService } from 'src/app/services/doctor.service';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  appointments: any = [];
  constructor(private AppointmentService: AppointmentsService,
              private tokenHandler: TokenHandler,
              private router: Router) {

  }
  ngOnInit() {
    this.AppointmentService.getTodaysAppointmentsForDoctor().subscribe({
      next: (res: any) => {
        console.log(res.result);
        this.appointments = res.result
      }
    });
  }

  saveData(patientId: any, appointmentId: any){
    this.router.navigateByUrl(`/doctor/appointment-details/${appointmentId}/${patientId}`)
  }
}
