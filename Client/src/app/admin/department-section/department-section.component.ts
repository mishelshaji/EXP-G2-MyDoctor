import { Component } from '@angular/core';
import { window } from 'rxjs';
import { DepartmentsService } from 'src/app/services/departments.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-department-section',
  templateUrl: './department-section.component.html',
  styleUrls: ['./department-section.component.css']
})
export class DepartmentSectionComponent {
  masterId: number;
  model = {
    departmentName: '',
    description: ''
  }
  departments: any = [];
  addedItems: any = [];

  constructor(private departmentService: DepartmentsService) {

  }

  ngOnInit() {
    this.departmentService.getDepartmentDetails().subscribe({
      next: (res: any) => {
        this.departments = res.result;
      }
    })
  }

  addDepartment() {
    this.departmentService.addNewDepartment(this.model).subscribe({
      next: () => {
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Department added successfully!',
          showConfirmButton: false,
          timer: 1500
        }).then(()=>{
          location.reload();
        })
      },
      error: () => {
        Swal.fire("Adding department failed!");
      }
    });
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
