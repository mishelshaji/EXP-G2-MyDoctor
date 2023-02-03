import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  specilization = [
    {
      id: 1,
      spec: 'Eyes'
    },
    {
      id: 2,
      spec: 'Cardio'
    },
    {
      id: 3,
      spec: 'Physician'
    }
  ]
}
