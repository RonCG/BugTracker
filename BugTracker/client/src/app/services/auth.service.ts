import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { UserSessionModel } from '../models/UserSessionModel';
import { Router } from '@angular/router';
import { tap, map } from 'rxjs/operators';

@Injectable({
    providedIn: "root"
})

export class AuthService {

    private currentUserSubject: BehaviorSubject<UserSessionModel>;
    public currentUser: Observable<UserSessionModel>;

    constructor(
        private http: HttpClient,
        private router: Router
    ) {
        this.currentUserSubject = new BehaviorSubject<UserSessionModel>(null);
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public setUserData(): UserSessionModel {
        const token = localStorage.getItem('token');
        if(!token)
            return null;
        
        const payload = JSON.parse(atob(token.split('.')[1]));
        return new UserSessionModel(payload.userid, payload.username, payload.role, token, new Date(payload.exp * 1000));
    }

    public get currentUserValue(): UserSessionModel {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string): Observable<UserSessionModel>{
        return this.http.post<any>(`api/user/authenticate`, { username, password })
            .pipe(
                map(response => {
                    localStorage.setItem('token', response.jwtToken);
                    this.currentUserSubject.next(this.setUserData());
                    return response;
                })
            );
    }

    autoLogin(){
        const user = this.setUserData();
        if(!user || !user.token)
            return;

        this.currentUserSubject.next(user);
    }

    logout() {
        localStorage.removeItem('token');
        this.currentUserSubject.next(null);
        this.router.navigate(['/login']);
    }

}