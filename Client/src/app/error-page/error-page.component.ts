import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TokenHandler } from 'src/helpers/tokenHandler';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.css']
})
export class ErrorPageComponent {
 
  error: any;

  constructor(private route: ActivatedRoute,
              private tokenHandler: TokenHandler) {
    
  }

  ngOnInit(){
    this.tokenHandler.removeToken()
  }
}
