import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {
  private departments = [
    {
      id: 1,
      name: 'Dentistry'
    },
    {
      id: 2,
      name: 'Paediatrics'
    },
    {
      id: 3,
      name: 'Cardiology'
    },
  ]

  constructor() {

  }
  
  getAll() {
    return this.departments;
  }
}