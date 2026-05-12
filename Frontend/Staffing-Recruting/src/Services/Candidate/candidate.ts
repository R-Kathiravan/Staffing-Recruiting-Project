import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckUser, InsertUsers, UserDetails } from '../../Models/Users';
import { IAddJobs, IGetJobs } from '../../Models/Jobs';
import { IAddJobApplications } from '../../Models/JobApplications';
import { IAddCandidateProfile } from '../../Models/CandidateProfile';
@Injectable({
    providedIn: 'root'
})

export class CandidateServices {

    constructor(private http: HttpClient) { }
    private baseURL = 'https://localhost:7141/api/Jobs'

    getAllJobs(): Observable<IGetJobs[]> {
        return this.http.get<IGetJobs[]>(`${this.baseURL}/GetAllJobs`)
    }

    ApplyJob(data: IAddJobApplications[]): Observable<any[]> {
        return this.http.post<IAddJobApplications[]>(`${this.baseURL}/ApplyJob`, data);
    }
    // 
    private userURL = 'https://localhost:7141/api/User';
    GetUserDetails(): Observable<UserDetails[]> {
        return this.http.get<UserDetails[]>(`${this.userURL}/GetUserDetails`)
    }

    private candidateURL = 'https://localhost:7141/api/CandidateProfile'

    GetCandidateProfile(): Observable<any[]> {
        return this.http.get<any[]>(`${this.userURL}/GetCandidateProfile`)
    }

    CreateCandidateProfile(data: IAddCandidateProfile): Observable<any[]> {
        return this.http.post<any[]>(`${this.candidateURL}/CreateCandidateProfile`, data);
    }
}