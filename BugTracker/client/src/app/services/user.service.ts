import { UserModel } from '../models/UserModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: "root"
})
export class UserService {

    constructor(
        private http: HttpClient
    ) {}

    getUserDetail(userID: number): Observable<UserModel>{
        return this.http.get<UserModel>(`api/user/${userID}`);
    }
}