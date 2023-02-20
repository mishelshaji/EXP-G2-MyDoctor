import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  patientsCount: number;
  doctorsCount: number;
  upcomingBookingsCount: number;
  completedBookingsCount: number;
  registrationApprovalsCount: number;

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.adminService.getPatientsCount().subscribe({
      next: (res: any) => {
        this.patientsCount = res.result;
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
    this.adminService.getDoctorsCount().subscribe({
      next: (res: any) => {
        this.doctorsCount = res.result;
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
    this.adminService.getUpcomingBookingsCount().subscribe({
      next: (res: any) => {
        this.upcomingBookingsCount = res.result;
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
    this.adminService.getCompletedBookingsCount().subscribe({
      next: (res: any) => {
        this.completedBookingsCount = res.result;
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
    this.adminService.getRegistrationApprovalsCount().subscribe({
      next: (res: any) => {
        this.registrationApprovalsCount = res.result;
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
  }
}
