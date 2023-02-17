import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class PatientService {

  // url = 'https://localhost:7238/api/Patient/Home';

  constructor() { }

  updateProfile(model: object) {
    console.log(model);
  }

  searchResult(searchValue: string) {
    return
  }
  // update(id: number, model: PatientProfileDto) {
  //   return this.http.put(this.url + '/' + id, model);
  // update(id: number, model: Pat) {
  //   return this.http.put(this.url + '/' + id, model);
}
