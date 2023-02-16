import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tokenHandler } from './tokenHandler';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private tokenHandler: tokenHandler) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.tokenHandler.getToken();
    if(!token){
      return next.handle(request);
    }

    const cloned = request.clone();
    cloned.headers.set('Authorization', 'Bearer $(token)')
    return next.handle(cloned);
  }
}
