import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentsService } from 'src/app/services/appointments.service';

@Component({
  selector: 'app-appointment-history',
  templateUrl: './appointment-history.component.html',
  styleUrls: ['./appointment-history.component.css']
})
export class AppointmentHistoryComponent {

  upcomingAppointments: any[] = [];
  previousAppointments: any[] = [];
  cancelledAppointments: any[] = [];


  constructor(private AppointmentsService: AppointmentsService,
    private router: Router) {

  }

  clicked(e: any) {
    var targett = e.target as HTMLElement;
    var others = [
      document.getElementById('upcoming'),
      document.getElementById('completed'),
      document.getElementById('cancelled')
    ]
    var divs = [
      document.getElementById('upcomingdiv'),
      document.getElementById('completeddiv'),
      document.getElementById('cancelleddiv')
    ]
    if (targett.tagName != "BUTTON") {
      var targett = targett.parentElement as HTMLElement;
    }
    others.forEach(element => {
      element?.classList.remove('bg-red');
      element?.classList.remove('w-100');
      element?.classList.remove('text-light');
      element?.classList.add('text-success');
    });
    targett.classList.add('bg-red', 'w-100');
    targett.classList.remove('text-success');
    divs.forEach(element => {
      if (targett.id.slice(0, 4) == element?.id.slice(0, 4)) {
        element?.classList.remove('d-none');
      }
      else {
        element?.classList.add('d-none');
      }
    })
  }

  ngOnInit() {
    this.AppointmentsService.getUpcomingAppointmentsForPatients().subscribe({
      next: (res: any) => {
        res.result.forEach((element: any) => {
          if (element.status == 1) {
            this.upcomingAppointments.push(element);
          }
        })
        this.upcomingAppointments.forEach((elemenet: any) => {
          elemenet.time = this.AppointmentsService.timeConvert(elemenet.time)
        })
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    });

    this.AppointmentsService.getPreviousAppointmentsForPatients().subscribe({
      next: (res: any) => {
        res.result.forEach((element: any) => {
          if (element.status == 2) {
            this.previousAppointments.push(element);
          }
        });
        this.previousAppointments.forEach((elemenet: any) => {
          elemenet.time = this.AppointmentsService.timeConvert(elemenet.time)         
        })
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    });

    this.AppointmentsService.getCancelledAppointmentsForPatients().subscribe({
      next: (res: any) => {
        res.result.forEach((element: any) => {
          if (element.status == 0) {
            this.cancelledAppointments.push(element);
          }
        });
        this.cancelledAppointments.forEach((elemenet: any) => {
          elemenet.time = this.AppointmentsService.timeConvert(elemenet.time)          
        })
      },
      error: (res: any) => {
        this.router.navigateByUrl('/error-page');
      }
    });
  }

  saveData(patientId: any, appointmentId: any) {
    console.log("hello")
    this.router.navigateByUrl(`/patient/appointment-details/${appointmentId}/${patientId}`)
  }
}
