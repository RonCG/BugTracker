import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SelectItem } from 'primeng/api/selectitem';

@Injectable({
    providedIn: "root"
})
export class LookupService {

    constructor(
        private http: HttpClient
    ) {}

    getLookUp(lookUpType: string, custom: boolean = false): Observable<SelectItem[]>{
        const data = { 
            lookuptype : lookUpType,
            custom : JSON.stringify(custom)
         }
        return this.http.get<SelectItem[]>(`api/lookup`, { params: data });
    }
}