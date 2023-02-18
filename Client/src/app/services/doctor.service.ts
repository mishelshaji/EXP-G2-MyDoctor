import { Injectable } from '@angular/core';
import { concatWith } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private doctors = [];

  constructor() {
  }

  getAll() {
    return this.doctors;
  }
  
  getSearchDetails(index: number) {
    return this.doctors[index];
  }

  updateProfile(model: any) {
    console.log(model);
  }
}