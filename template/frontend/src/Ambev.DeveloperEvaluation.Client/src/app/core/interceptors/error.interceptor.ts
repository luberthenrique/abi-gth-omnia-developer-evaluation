import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AlertService } from '../../shared/services/alert/alert.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private readonly alertService: AlertService,
    private readonly router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      if (err.status === 400) {
        let errors: any[];
        if (err.error.errors) {
          errors = err.error.errors;
        }
        else {
          errors = err.error;
        }
        errors.forEach(error => {
          this.alertService.error(error.errorMessage);
        });
      }
      else if (err.status === 401) {

        // TODO - Redirect to login page
      }
      if (err.status === 403) {
        // TODO - Redirect to forbidden page
      }
      else if (err.status === 404) {
        // TODO - Redirect to notfound page
      }

      // Erro validação bad request
      return throwError(err);

    }));
  }
}
