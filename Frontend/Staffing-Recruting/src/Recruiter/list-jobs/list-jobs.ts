import { Component, OnInit } from '@angular/core';
import { RecruitersServices } from '../../Services/Recruiters/Recruiters';
import { IGetJobs } from '../../Models/Jobs';
import { SharedModules } from '../../Shared/shared-modules';

@Component({
  selector: 'app-list-jobs',
  imports: [SharedModules],
  templateUrl: './list-jobs.html',
  styleUrl: './list-jobs.css',
})
export class ListJobs implements OnInit {
  constructor(private RecruitersServices: RecruitersServices) { }
  jobs: any[] = [];
  ngOnInit()  {
    this.getJobs();
  }
  getJobs() {
    this.RecruitersServices.retreiveJobs().subscribe({
      next: (respnse: any) => {
        // alert("Fetched Data" + respnse);
        this.jobs = respnse;
        console.log(this.jobs)
      },
      error(ex) {
        // alert("cant reterive data" + ex.message)
        console.log(ex);
      }
    })
  }
}
