import { Injectable } from '@angular/core';
import { concatWith } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private doctors = [
    {
      id: 1,
      name: 'Arjun',
      department: 'Dentistry',
      photo: '../../../assets/images/doctorpng.jfif'
    },
    {
      id: 2,
      name: 'Asok',
      department: 'Cardiology',
      photo: '../../../assets/images/doctor1png.png'
    },
    {
      id: 3,
      name: 'Vicky',
      department: 'Dentistry',
      photo: '../../../assets/images/doctor5png.png'
    },
    {
      id: 4,
      name: 'Sulthana',
      department: 'Paediatrics',
      photo: '../../../assets/images/doctor3png.png'
    },
    {
      id: 5,
      name: 'Rashis',
      department: 'Paediatrics',
      photo: '../../../assets/images/doctor4png.png'
    },
    {
      id: 6,
      name: 'Arjun',
      department: 'Cardiology',
      photo: '../../../assets/images/doctor5png.png'
    }
  ]

  constructor() { 

  }
  getAll() {
    return this.doctors;
  }
  getSearchDetails(index:number) {
    return this.doctors[index];
  }

  updateProfile(model:any){
    console.log(model);
    

  }
}
