import { Injectable } from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpErrorResponse
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(
        private router: Router
    ){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(

            catchError((error: HttpErrorResponse) => {
                console.log(error);
                let errorMessage = error.error.message || error.message;
                if (error.error instanceof ErrorEvent) { //Client-side error
               
                } else { //Server-side error
                    switch (error.status) {
                        case 401:
                            //show message 'No permissions' with message service
                            this.router.navigate(['/login']);
                            break;
                    }
                }

                return throwError(errorMessage);
            })
        );
    }
}