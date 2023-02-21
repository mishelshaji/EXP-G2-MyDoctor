import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.css']
})
export class ErrorPageComponent {
 
  error: any;

  constructor(private route: ActivatedRoute) {
   console.log(this.route.params)
    this.error = route.snapshot.params['error'];
    console.log(this.error);
    
  }
}
