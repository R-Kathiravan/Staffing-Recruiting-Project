import { J } from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedModules } from '../../Shared/shared-modules';
import { IAddJobApplications } from '../../Models/JobApplications';
import { CandidateServices } from '../../Services/Candidate/candidate';
import { response } from 'express';
import { IJobApplyDetails } from '../../Models/Jobs';

@Component({
  selector: 'app-apply-job',
  imports: [SharedModules],
  templateUrl: './apply-job.html',
  styleUrl: './apply-job.css',
})
export class ApplyJob implements OnInit {

  jobID: number = 0;
  isSubmitting: boolean = false;
  displayResumeName: string = 'Resume.pdf';

  constructor(private route: ActivatedRoute, private candidateService: CandidateServices, private router : Router) { }
  ngOnInit(): void {
    const JobID = this.route.snapshot.paramMap.get('id');
    this.jobID = Number(JobID);
    console.log(this.jobID);
    this.applyDetails.JobID = this.jobID;
    this.GetJobDetails();
    this.GetResumeDetails();
  }

  applyDetails: IAddJobApplications = {
    JobID: this.jobID,
    CoverLetterURL: ''
  };

  ApplyJobDetails:IJobApplyDetails[]=[];

  ApplyJob() {
    this.candidateService.ApplyJob(this.applyDetails).subscribe({
      next: (response: any) => {
        alert("Applied to Job Successfully: ");
        this.router.navigate(['/candidate-home']);
      },
      error(err) {
        alert("Error While Applying to this Job, Check console");
        console.log("Job Apply error: ", err);
      }
    })
  }

  GetResumeDetails(){
    this.candidateService.GetResumeDetails().subscribe({
      next:(response:any)=>{
        let resp = response.ResumeUrl.split('/').pop();
        this.displayResumeName = resp.substring(resp.indexOf('_') + 1)
        console.log(this.displayResumeName)
      },
      error(err){
        console.log("error: " , err)
      }
    })

  }

  GetJobDetails(){
    this.candidateService.GetJobDetails(this.jobID).subscribe({
      next:(Res:any)=>{
        this.ApplyJobDetails =Res;
        console.log("Details: ", this.ApplyJobDetails)
      }
    })
  }
}
