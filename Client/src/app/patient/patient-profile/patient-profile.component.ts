import { Component } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-patient-profile',
  templateUrl: './patient-profile.component.html',
  styleUrls: ['./patient-profile.component.css']
})
export class PatientProfileComponent {
  model = {
    firstName: '',
    lastName: '',
    dob: '',
    gender: '',
    email: '',
    phoneNumber: 0,
    address: '',
    phone2: '',
    relationship: '',
    bloodgroup: ''
  }

  constructor(private patientServices: PatientService) {

  }

  ngOnInit() {
    this.patientServices.getPatientProfile().subscribe({
      next: (res: any) => {
        this.model = res.result;
      }
    })
  }

  saveData() {
    this.patientServices.updateProfile(this.model).subscribe({
      next: (res: any) => {
        if (res.isValid) {
          Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Your profile updated successfully',
            showConfirmButton: false,
            timer: 1500
          })
        }
      }
    });
  }
}

