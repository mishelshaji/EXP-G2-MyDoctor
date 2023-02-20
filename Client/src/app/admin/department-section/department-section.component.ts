import { Component } from '@angular/core';
import { DepartmentsService } from 'src/app/services/departments.service';

@Component({
  selector: 'app-department-section',
  templateUrl: './department-section.component.html',
  styleUrls: ['./department-section.component.css']
})
export class DepartmentSectionComponent {
  masterId: number;
  i:number = 0;
  model = {
    departmentName: '',
    description: ''
  }
  departments: any = [];
  addedItems: any = [];
  
  constructor(private departmentService: DepartmentsService) {

  }

  ngOnInit(){
    this.departmentService.getDepartmentDetails().subscribe({
      next: (res: any) => {
        this.departments = res.result;
      }
    })
  }

  getNextNumber()
  {
    return this.i++;
  }
  
  addDepartment() {
    this.departmentService.addNewDepartment(this.model);
  }
  deleteDepartment(event: any) {
    this.masterId = event.target.getAttribute('data-uid');
    var confirmation = confirm("Are you sure you want to remove this department?");
    if (confirmation == true)
      this.departmentService.deleteDepartment(this.masterId).subscribe({
        next: (res: any) => {
          location.reload();
        },
        error: (res: any) => {
          console.log(res.error);
        }
      })
  }
}
