import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentsService } from 'src/app/services/appointments.service';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-appointment-details',
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css']
})

export class AppointmentDetailsComponent implements OnInit {

  doctorId: number;
  appointmentId: any;
  doctorDetails = {
    email: "",
    emergencyPhoneNumber: "",
    name: "",
    patientId: "",
    phoneNumber: "",
    userId: "",
    departmentName: ""
  }

  appointmentDetails = {
    appointmentId: '',
    consultationId: '',
    date: '',
    diseases: '',
    elaboration: '',
    fromTime: '',
    medication: '',
    status: '',
    fee: 0
  }

  constructor(private patientService: PatientService,
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient) {

  }

  ngOnInit() {
    this.doctorId = parseInt(this.route.snapshot.params['doctorId']);
    this.patientService.doctorDetailsAppointmentDetails(this.doctorId).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          this.doctorDetails = res.result[0] 
        }
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    });

    this.appointmentId = parseInt(this.route.snapshot.params['appointmentId'])
    this.patientService.consultationAppointmentDetails(this.appointmentId).subscribe({
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

  cancelAppointment(appointmentId: any){
    var id = parseInt(appointmentId)
    this.http.put(`https://localhost:7238/api/Patient/Home/cancelappointments?id=${id}`,0).subscribe({
      next: (res: any) => {
        if(res.isValid){
          alert("Cancel Success")
        }
        console.log(res);
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    })
  }
}

