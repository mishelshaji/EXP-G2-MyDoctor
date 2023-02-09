import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
    doctors = [
      {
        id:1,
        name: 'Arjun',
        department: 'Department',
        photo: '../../../assets/images/doctorpng.jfif'
      },
      {
        id:2,
        name: 'Asok',
        department: 'Department',
        photo: '../../../assets/images/doctor1png.png'
      },
      {
        id:3,
        name: 'vicky',
        department: 'Department',
        photo: '../../../assets/images/doctor5png.png'
      },
      {
        id:4,
        name: 'sulthana',
        department: 'Department',
        photo: '../../../assets/images/doctor3png.png'
      },
      {
        id:5,
        name: 'Rashis',
        department: 'Department',
        photo: '../../../assets/images/doctor4png.png'
      },
      {
        id:6,
        name: 'Arjun',
        department: 'Department',
        photo: '../../../assets/images/doctor5png.png'
      }
    ]
}
