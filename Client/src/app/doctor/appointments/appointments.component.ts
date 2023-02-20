import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { AppointmentsService } from 'src/app/services/appointments.service';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent {

  upcomingAppointments: any = [];
  completedAppointments: any = [];
  cancelledAppointments: any = [];
  
  constructor(private AppointmentsService: AppointmentsService,
              private tokenHandler: TokenHandler,
              private router: Router) {

  }

  clicked(e: MouseEvent) {
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
    var masterId = this.tokenHandler.getMasterId();
    this.AppointmentsService.getUpcomingAppointmentsForDoctor().subscribe({
      next: (res: any) => {
        for (let index = 0; index < res.result.length; index++) {
          const element = res.result[index];
          if(element.status == 1)
            this.upcomingAppointments.push(element);
            console.log(element);
            
        }
      }
    });

    this.AppointmentsService.getPreviousAppointmentsForDoctor().subscribe({
      next: (res: any) => {
        for (let index = 0; index < res.result.length; index++) {
          const element = res.result[index];
          if(element.status == 2)
            this.previousAppointments.push(element);
        }
      }
    });
    this.AppointmentsService.getCancelledAppointmentsForDoctor().subscribe({
      next: (res: any) => {
        for (let index = 0; index < res.result.length; index++) {
          const element = res.result[index];
          if(element.status == 0)
            this.cancelledAppointments.push(element);
        }
      }
    });;
  }

  saveData(patientId: any, appointmentId: any){
    console.log("hello")
    this.router.navigateByUrl(`/doctor/appointment-details/${appointmentId}/${patientId}`)
  }
}
