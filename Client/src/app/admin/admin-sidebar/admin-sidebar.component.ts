import { Component } from '@angular/core';
import { faBuilding, faGauge, faHospitalUser, faUserDoctor, faUserSecret } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.css']
})
export class AdminSidebarComponent {
  faDashboard = faGauge
  faDoctor = faUserDoctor
  faPatient = faHospitalUser
  faDepartment = faBuilding
  faAdmin = faUserSecret

  clicked(e: MouseEvent) {
    var targett = e.target as HTMLElement;
    var others = [
      document.getElementById('dashboard'),
      document.getElementById('patients'),
      document.getElementById('doctors'),
      document.getElementById('departments')
    ]
    if (targett.tagName != "BUTTON") {
      console.log('in')
      var targett = targett.parentElement as HTMLElement;
      if (targett.tagName != "BUTTON") {
        console.log('into');
        var targett = targett.parentElement as HTMLElement
        if (targett.tagName != "BUTTON") {
          console.log('into');
          var targett = targett.parentElement as HTMLElement
        }
      }

    }
    console.log(targett);
    others.forEach(element => {
      element?.classList.remove('bg-light');
      element?.classList.remove('w-100');
    });
    targett.classList.add('bg-light', 'w-100')
  }
}
