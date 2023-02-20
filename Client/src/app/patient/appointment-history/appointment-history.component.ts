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
      document.getElementById('previous'),
      document.getElementById('cancelled')
    ]
    var divs = [
      document.getElementById('upcomingdiv'),
      document.getElementById('previousdiv'),
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
          if(element.status == 1){
            this.upcomingAppointments.push(element);
            console.log(element);
            
          }
        });
      }
    });

   this.AppointmentsService.getPreviousAppointmentsForPatients().subscribe({
    next: (res: any) => {
      res.result.forEach((element: any) => {
        if(element.status == 2){
          this.previousAppointments.push(element);
        }
      });
    }
  });

   this.AppointmentsService.getCancelledAppointmentsForPatients().subscribe({
      next: (res: any) => {
        res.result.forEach((element: any) => {
          if(element.status == 0){
            this.cancelledAppointments.push(element);
          }
        });
      }
    });
  }

  saveData(patientId: any, appointmentId: any){
    console.log("hello")
    this.router.navigateByUrl(`/patient/appointment-details/${appointmentId}/${patientId}`)
  }
}
