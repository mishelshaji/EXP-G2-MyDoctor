import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

   private appointments = [
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    },
    {
      id: 3,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. rashid',
      status: true
    },
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    },
    {
      id: 3,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. rashid',
      status: true
    },
    {
      id: 1,
      date: '12-02-2023',
      time: '09:30 AM',
      doctor: 'Dr. Arjun',
      status: true
    },
    {
      id: 2,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. vicky',
      status: true
    },
    {
      id: 3,
      date: '12-02-2023',
      time: '10:30 AM',
      doctor: 'Dr. rashid',
      status: true
    }
  ]
   constructor(){

   }
   getall(){
    return this.appointments
   }
}