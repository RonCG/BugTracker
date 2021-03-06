import { RoleModel } from './../models/RoleModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: "root"
})
export class RoleService {

    constructor(
        private http: HttpClient
    ) {}

    getRoles(): Observable<RoleModel[]>{
        return this.http.get<RoleModel[]>(`api/role`);
    }
}