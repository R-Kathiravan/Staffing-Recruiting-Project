import { Component } from '@angular/core';
import { RecruitersServices } from '../../Services/Recruiters/Recruiters';

@Component({
  selector: 'app-list-jobs',
  imports: [],
  templateUrl: './list-jobs.html',
  styleUrl: './list-jobs.css',
})
export class ListJobs {
  constructor(private RecruitersServices:RecruitersServices){}
getJobs(){
let res= this.RecruitersServices.retreiveJobs();
console.log(res);
}
}
