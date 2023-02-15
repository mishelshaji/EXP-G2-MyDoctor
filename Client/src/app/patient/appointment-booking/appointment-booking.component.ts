import { Component } from '@angular/core';
import { faCircleArrowLeft, faCircleArrowRight } from '@fortawesome/free-solid-svg-icons';
import { NgbDatepicker, NgbDatepickerI18n, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ViewChild, ViewEncapsulation } from '@angular/core';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-appointment-booking',
  templateUrl: './appointment-booking.component.html',
  styleUrls: ['./appointment-booking.component.css'],
  styles: [
		`
			.custom-datepicker .ngb-dp-header {
				padding: 0;
			}
			.custom-datepicker .ngb-dp-content {
				display: grid;
				grid-template-columns: auto auto;
				grid-column-gap: 1rem;
				grid-row-gap: 0.5rem;
			}
		`,
	],
})
export class AppointmentBookingComponent {
  @ViewChild(NgbDatepicker, { static: true }) datepicker: NgbDatepicker;
  faRightArrow = faCircleArrowRight;
  faLeftArrow = faCircleArrowLeft;  
  todayDate = {
    year: new Date().getFullYear(),
    month: new Date().getMonth() + 1,
    day: new Date().getDate()
  };
  timeSlot:number = 0;

  DisplayTimeSlots(value:any)
  {
    this.timeSlot = value;
  }

  constructor(public i18n: NgbDatepickerI18n) {  }

  navigate(number: number) {
		const { state, calendar } = this.datepicker;
		this.datepicker.navigateTo(calendar.getNext(state.firstDate, 'm', number));
	}

	today() {
		const { calendar } = this.datepicker;
		this.datepicker.navigateTo(calendar.getToday());
	}
}
