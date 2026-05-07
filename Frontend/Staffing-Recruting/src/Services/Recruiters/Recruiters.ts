import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckUser, InsertUsers } from '../../Models/Users';
@Injectable({
    providedIn: 'root'
})

export class RecruitersServices{
    constructor(private http:HttpClient){}

    retreiveJobs():Observable<any[]>{
        return this.http.get<any>("https://localhost:7141/api/Jobs/GetJobs");
    }
}   