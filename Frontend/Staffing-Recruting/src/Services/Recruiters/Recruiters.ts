import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckUser, InsertUsers } from '../../Models/Users';
import { IAddJobs, IGetJobs } from '../../Models/Jobs';
@Injectable({
    providedIn: 'root'
})

export class RecruitersServices {
    constructor(private http: HttpClient) { }
    private baseURL = 'https://localhost:7141/api/Jobs'
    retreiveJobs(): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseURL}/GetJobs`);
    }


    // Add Jobs

    addJobs(data: any): Observable<any[]> {
        return this.http.post<any>(`${this.baseURL}/InsertJobs`, data)
    }
}   