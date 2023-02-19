import { Component } from '@angular/core';
import { AppointmentsService } from 'src/app/services/appointments.service';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  appointments: any = [];
  constructor(private AppointmentService: AppointmentsService,
              private tokenHandler: TokenHandler) {

  }
  ngOnInit() {
    var masterId = this.tokenHandler.getMasterId();
    this.AppointmentService.getTodaysAppointmentsForDoctor(masterId).subscribe({
      next: (res: any) => {
        console.log(res.result);
        this.appointments = res.result
      }
    });
  }

  saveData(){
    
  }
}
