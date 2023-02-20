import { Component } from '@angular/core';
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
              private tokenHandler: TokenHandler) {

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
    this.upcomingAppointments = this.AppointmentsService.getUpcomingAppointmentsForDoctor(masterId);
    this.completedAppointments = this.AppointmentsService.getCompletedAppointments();
    this.cancelledAppointments = this.AppointmentsService.getCancelledAppointments();
  }
}
