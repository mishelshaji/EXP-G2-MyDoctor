import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {
  private departments = [];

  constructor() {

  }
  
  getAll() {
    return this.departments;
  }
}