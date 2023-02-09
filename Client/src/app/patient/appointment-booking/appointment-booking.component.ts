import { Component } from '@angular/core';
import { faCircleArrowLeft, faCircleArrowRight } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-appointment-booking',
  templateUrl: './appointment-booking.component.html',
  styleUrls: ['./appointment-booking.component.css']
})
export class AppointmentBookingComponent {
  faRightArrow = faCircleArrowRight;
  faLeftArrow = faCircleArrowLeft;
}
