import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import Swal from 'sweetalert2';

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
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'success',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, approve it!'
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire(
          'success!',
          'Doctor has been approved successfully',
          'success'
        )
        this.adminService.approveDoctor(this.masterId).subscribe({
          next: (res: any) => {
            location.reload();
          },
          error: (res: any) => {
            console.log(res.error);
          }
        })
      }
    })
  }

  declineDoctor(event: any) {
    this.masterId = event.target.getAttribute('data-uid');
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, decline it!'
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire(
          'Deleted!',
          'Your file has been deleted.',
          'success'
        )
        this.adminService.declineDoctor(this.masterId).subscribe({
          next: (res: any) => {
            location.reload();
          },
          error: (res: any) => {
            console.log(res.error);
          }
        })
      }
    })
  }
}
