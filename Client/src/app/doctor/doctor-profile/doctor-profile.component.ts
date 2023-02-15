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
    dob: '',
    gender: '',
    email: '',
    phone: '',
    address:'',
    Specialization:'',
    licenseNumber:'',
    bloodGroup: '',
    qualification:'',
    AppointmentFee:''
  }

  constructor(private doctorServices: DoctorService) {
    
  }

  saveData(){
    this.doctorServices.updateProfile(this.model);
  }
}
