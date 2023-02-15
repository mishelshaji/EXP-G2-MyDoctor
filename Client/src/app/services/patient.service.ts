import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor() { }

  updateProfile(model: object){
    console.log(model);
  }
}
