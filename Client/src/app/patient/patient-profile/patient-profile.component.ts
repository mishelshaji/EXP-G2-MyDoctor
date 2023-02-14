import { Component } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';

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
    number: ''
  }

  constructor(private patientServices: PatientService) {
    
  }

  saveData(){
    this.patientServices.updateProfile(this.model);
  }
}

