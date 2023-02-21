import { Component } from '@angular/core';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-doctor-profile',
  templateUrl: './doctor-profile.component.html',
  styleUrls: ['./doctor-profile.component.css']
})
export class DoctorProfileComponent {
  model = {
    firstName: '',
    lastName: '',
    email: '',
    dob: '',
    gender: '',
    phoneNumber: '',
    doctorLicenseNo: '',
    fee: '',
    departmentName:''
  }

  constructor(private doctorServices: DoctorService) {
  }

  ngOnInit() {
      this.doctorServices.getAll().subscribe({
        next: (res: any) => {
          this.model = res.result[0];
          console.log(this.model);
          
        },
        error: (res: any) => {
          console.log(res.error);
        }
      })
  }

  saveData() {
    this.doctorServices.updateProfile(this.model).subscribe({
      next: (res: any) => {
        console.log(res.result);
        
      },
      error: (res: any) => {
        console.log(res.error);
      }
    })
  }
}
