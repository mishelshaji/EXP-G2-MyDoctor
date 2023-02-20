import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-registration-approval',
  templateUrl: './registration-approval.component.html',
  styleUrls: ['./registration-approval.component.css']
})
export class RegistrationApprovalComponent implements OnInit {
  newDoctors: any = [];
  masterId: number;

  constructor(private adminService: AdminService) {

  }

  ngOnInit(): void {
    this.adminService.getNewDoctors().subscribe({
      next: (res: any) => {
        this.newDoctors = res.result;
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
  }

  approveDoctor(event: any) {
    this.masterId = event.target.getAttribute('data-uid');
    var confirmation = confirm("Are you sure you want to approve this doctor?");
    if (confirmation == true)
      this.adminService.approveDoctor(this.masterId).subscribe({
        next: (res: any) => {
          location.reload();
        },
        error: (res: any) => {
          console.log(res.error);
        }
      })
  }

  declineDoctor(event: any) {
    this.masterId = event.target.getAttribute('data-uid');
    var confirmation = confirm("Are you sure you want to reject this doctor?");
    if (confirmation == true)
      this.adminService.declineDoctor(this.masterId).subscribe({
        next: (res: any) => {
          location.reload();
        },
        error: (res: any) => {
          console.log(res.error);
        }
      })
  }
}
