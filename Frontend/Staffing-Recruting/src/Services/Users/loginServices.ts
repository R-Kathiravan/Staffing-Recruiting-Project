import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckUser, InsertUsers } from '../../Models/Users';
@Injectable({
    providedIn: 'root'
})

export class LoginServices {

    constructor(private http: HttpClient) { }
    private baseURL = 'https://localhost:7141/api/User'

    checkUser(usersData: any): Observable<any> {
        console.log(usersData);
        return this.http.post<CheckUser[]>(`${this.baseURL}/CheckUsers`, usersData)
    }


    // Register Services

    registerUser(data:any):Observable<any>{
        console.log(data);
        return this.http.post<InsertUsers[]>(`${this.baseURL}/InsertUsers`,data)
    }

    
}
