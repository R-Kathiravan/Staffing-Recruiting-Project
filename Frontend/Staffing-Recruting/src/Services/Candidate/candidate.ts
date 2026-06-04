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

    private baseURL = 'https://localhost:7141/api/Candidate'

    getAllJobs(): Observable<IGetJobs[]> {
        return this.http.get<IGetJobs[]>(`${this.baseURL}/GetAllJobs`)
    }

    ApplyJob(data: IAddJobApplications): Observable<any> {
        return this.http.post<IAddJobApplications>(`${this.baseURL}/ApplyJob`, data);
    }
 
    GetCandidateProfile(): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseURL}/GetCandidateProfile`)
    }

    CreateCandidateProfile(data: any): Observable<any[]> {
        return this.http.post<any>(`${this.baseURL}/CreateCandidateProfile`, data);
    }

    uploadResume(file: any): Observable<any[]> {
        return this.http.post<any[]>(`${this.baseURL}/UploadResume`, file);
    }

    GetResumeDetails():Observable<any>{
        return this.http.get<any>(`${this.baseURL}/GetCandidateResume`)
    }

    GetJobDetails(JobID:number):Observable<any>{
        return this.http.get<any>(`${this.baseURL}/GetJobApplyDetails/${JobID}`)
    }
    // User Controller
    private userURL = 'https://localhost:7141/api/User';
    GetUserDetails(): Observable<UserDetails[]> {
        return this.http.get<UserDetails[]>(`${this.userURL}/GetUserDetails`)
    }
}