import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})
export class AppointmentDetailsComponent {

  patientId: number;
  appointmentId: number;
  patientDetails = {
    email: "",
    emergencyPhoneNumber: "",
    name: "",
    patientId: "",
    phoneNumber: "",
    userId: ""
  }

  appointmentDetails = {
    appointmentId: '',
    consultationId: '',
    date: '',
    diseases: '',
    elaboration: '',
    fromTime: '',
    medication: '',
    status: ''
  }

  constructor(private doctorService: DoctorService,
    private route: ActivatedRoute,
    private router: Router) {

  }
  ngOnInit() {
    this.patientId = parseInt(this.route.snapshot.params['patientId']);
    this.doctorService.patientDetailsAppointmentDetails(this.patientId).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          this.patientDetails = res.result[0]
        }
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    });

    this.appointmentId = parseInt(this.route.snapshot.params['appointmentId'])
    this.doctorService.consultationAppointmentDetails(this.appointmentId).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          this.appointmentDetails = res.result[0]
          console.log(this.appointmentDetails);
        }
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    })
  }

  saveData() {
    this.doctorService.updateConsultationData(this.appointmentId, this.appointmentDetails).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          alert("BOOking success full");
          this.router.navigateByUrl('/doctor/home')
        }
        else {
          alert(res.errors[""]);
        }
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    });
  }
}
