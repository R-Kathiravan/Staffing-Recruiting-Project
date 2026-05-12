import { Component, OnInit } from '@angular/core';
import { CandidateServices } from '../../Services/Candidate/candidate';
import { IGetJobs } from '../../Models/Jobs';
import { response } from 'express';
import { SharedModules } from '../../Shared/shared-modules';
import { Router } from '@angular/router';
import { UserDetails } from '../../Models/Users';

@Component({
  selector: 'app-candidate-home',
  imports: [SharedModules],
  templateUrl: './candidate-home.html',
  styleUrl: './candidate-home.css',
})
export class CandidateHome implements OnInit {

  constructor(private candidateServices: CandidateServices, private router: Router) { }

  Jobs: IGetJobs[] = [];
  ngOnInit() {
    this.getAllJobs();
    this.getUserDetails();
  }

  getAllJobs() {
    this.candidateServices.getAllJobs().subscribe({
      next: (response: IGetJobs[]) => {
        this.Jobs = response;
        console.log(this.Jobs);
      },
      error(err) {
        console.log(err);
      }
    })
  }

  UserDetails : UserDetails[] = [];

  getUserDetails() {
    this.candidateServices.GetUserDetails().subscribe({
      next: (response: UserDetails[]) => {
        this.UserDetails = response;
        console.log("User Details", response);
      },
      error(err) {
        console.log(err);
      }
    })
  }
  apply() {
    this.router.navigate(['/apply-job']);
  }
}
