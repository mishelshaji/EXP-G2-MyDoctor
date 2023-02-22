import { Component, OnInit } from '@angular/core';
import { faCircleArrowLeft, faCircleArrowRight } from '@fortawesome/free-solid-svg-icons';
import { NgbDatepicker, NgbDatepickerI18n, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ViewChild, ViewEncapsulation } from '@angular/core';
import { AppointmentsService } from 'src/app/services/appointments.service';
import { TokenHandler } from 'src/helpers/tokenHandler';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

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
  feeWithTax: number;
  feeInPeekTime: number;
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
    masterId: '',
    fee: 0
  };

  constructor(public i18n: NgbDatepickerI18n,
    private appointmentService: AppointmentsService,
    private router: Router,
    private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    var doctId = parseInt(this.route.snapshot.params['id']);
    this.appointmentService.getBookingData(doctId).subscribe({
      next: (res: any) => {
        this.doctorData = res.result[0]
        this.feeInPeekTime = this.doctorData.fee + (this.doctorData.fee * 0.10) + (this.doctorData.fee * 0.05);
        this.feeWithTax = this.doctorData.fee + (this.doctorData.fee * 0.05);
      },
      error: (res: any) => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Internal server error!',
        })
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
      Swal.fire(
        'Did you selected the date?',
        'Try once more',
        'question'
      )
    else {
      document.querySelector(".radioclass")?.classList.remove("d-none");
      document.querySelector(".appointment-book")?.classList.remove("d-none");
      if (date.month < 10)
        this.dateChoosed = date.year + "-0" + date.month + "-" + date.day;
      else
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
          res.result.forEach((element: any) => {
            var obj: any = document.getElementById(element.fromTime);
            if (obj == null)
              return
            obj.disabled = true;
          });
        },
        error: (res: any) => {
          this.router.navigateByUrl('/error-page');
        }
      });
    }, 500);
  }

  timeSelected(event: any) {
    this.timeChoosed = event.target.value
  }

  AddBookings() {
    try {
      this.postAppointmentBooking.doctorMasterId = this.doctorData.masterId;
      this.postAppointmentBooking.date = this.dateChoosed;
      this.postAppointmentBooking.fromTime = this.timeChoosed;
      this.postAppointmentBooking.toTime = this.timeChoosed;
      if (this.postAppointmentBooking.date != '' && this.postAppointmentBooking.fromTime != '' && this.postAppointmentBooking.doctorMasterId != null) {
        this.appointmentService.AddBookings(this.postAppointmentBooking).subscribe({
          next: (res: any) => {
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Booking successful!',
              showConfirmButton: false,
              timer: 1500
            })
            this.router.navigateByUrl('/patient/home')
          },
          error: (res: any) => {
            Swal.fire(
              'Did you select both Time & date?',
              'Date/time is not selected',
              'question'
            )
          }
        });
      }
      else {
        Swal.fire("select the date and time")
      }
    }
    catch {
      Swal.fire("Date and time is not selected")
    }
  }
}
