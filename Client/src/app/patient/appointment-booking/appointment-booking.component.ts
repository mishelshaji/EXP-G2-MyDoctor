import { Component } from '@angular/core';
import { faCircleArrowRight } from '@fortawesome/free-solid-svg-icons';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-appointment-booking',
  templateUrl: './appointment-booking.component.html',
  styleUrls: ['./appointment-booking.component.css'],
})
export class AppointmentBookingComponent {
  faRightArrow = faCircleArrowRight;

}
