import { Component, OnInit } from '@angular/core';
import { faCircleArrowLeft, faCircleArrowRight } from '@fortawesome/free-solid-svg-icons';
import { NgbDatepicker, NgbDatepickerI18n, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ViewChild, ViewEncapsulation } from '@angular/core';
import { AppointmentsService } from 'src/app/services/appointments.service';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { Router } from '@angular/router';

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

export class AppointmentBookingComponent implements OnInit {
  @ViewChild(NgbDatepicker, { static: true }) datepicker: NgbDatepicker;
  faRightArrow = faCircleArrowRight;
  faLeftArrow = faCircleArrowLeft;

  todayDate = {
    year: new Date().getFullYear(),
    month: new Date().getMonth() + 1,
    day: new Date().getDate()
  };

  timeSlot: number | null;
  timeChoosed: string;
  dateChoosed: string;
  postAppointmentBooking = {
    doctorMasterId: null,
    date: '',
    fromTime: '',
    toTime: '',
    status: 1
  };
  doctorData: any = {
    name: '',
    departmentName: '',
    email: '',
    id: '',
    masterId: ''
  };

  constructor(public i18n: NgbDatepickerI18n,
    private appointmentService: AppointmentsService,
    private router: Router) {

  }

  ngOnInit(): void {
    var doctId = 2;
    this.appointmentService.getBookingData(doctId).subscribe({
      next: (res: any) => {
        this.doctorData = res.result[0]
        console.log(res);
      },
      error: (res: any) => {
        console.log(res);
      }
    })
  }

  navigate(number: number) {
    const { state, calendar } = this.datepicker;
    this.datepicker.navigateTo(calendar.getNext(state.firstDate, 'm', number));
  }

  today() {
    const { calendar } = this.datepicker;
    this.datepicker.navigateTo(calendar.getToday());
  }

  getDate(date: any) {
    if (date == null)
      alert("Select the date")
    else {
      document.querySelector(".radioclass")?.classList.remove("d-none");
      document.querySelector(".appointment-book")?.classList.remove("d-none");
      this.dateChoosed = date.year + "-" + date.month + "-" + date.day;
    }
  }

  DisplayTimeSlots(value: any) {
    this.timeSlot = value;
    setTimeout(() => {
      var buttons: any = document.querySelectorAll(".time-slot");
      console.log(buttons[0]);
      for (let index = 0; index < buttons.length; index++) {
        buttons[index].disabled = false;
      }
      this.appointmentService.getTimeSlots(this.doctorData.masterId, this.dateChoosed).subscribe({
        next: (res: any) => {
          console.log(res);

          res.result.forEach((element: any) => {
            var obj: any = document.getElementById(element.fromTime);
            if (obj == null)
              return
            obj.disabled = true;
          });
        },
        error: res => {
          console.log(res);
        }
      });
    }, 500);
  }

  timeSelected(event: any) {
    this.timeChoosed = event.target.value
    console.log(typeof (this.timeChoosed));
  }

  AddBookings() {
    this.postAppointmentBooking.doctorMasterId = this.doctorData.masterId;
    this.postAppointmentBooking.date = this.dateChoosed;
    this.postAppointmentBooking.fromTime = this.timeChoosed;
    this.postAppointmentBooking.toTime = this.timeChoosed;
    this.appointmentService.AddBookings(this.postAppointmentBooking).subscribe({
      next: (res: any) => {
        alert("Booking successful. Please return to home page.")
        this.router.navigateByUrl('/patient/home')
      },
      error: (res: any) => {
        console.log(res);
      }
    });
  }
}
