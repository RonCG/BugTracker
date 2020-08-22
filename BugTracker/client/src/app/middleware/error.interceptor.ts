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

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(

            catchError((error: HttpErrorResponse) => {
                console.log(error);
                let errorMessage = error.message;
                if (error.error instanceof ErrorEvent) {
                    //console.error('Client-Side error: ', error.error.message);
                } else {
                    //console.error('Server-Side error: ', error);
                    switch (error.status) {
                        case 400:
                            errorMessage = 'Username or password are invalid';
                            break;
                        case 401:
                            errorMessage = 'Not authorized!!!';
                            break;
                        case 404:
                            break;
                        default:
                            break;
                    }
                }

                return throwError(errorMessage);
            })
        );
    }
}