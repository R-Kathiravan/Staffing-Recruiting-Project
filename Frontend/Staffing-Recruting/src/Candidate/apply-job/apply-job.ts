import { J } from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-apply-job',
  imports: [],
  templateUrl: './apply-job.html',
  styleUrl: './apply-job.css',
})
export class ApplyJob implements OnInit {

  jonID: number = 0;
  constructor(private route: ActivatedRoute) { }
  ngOnInit(): void {
    const JobID = this.route.snapshot.paramMap.get('id');
    this.jonID = Number(JobID);
    console.log(this.jonID);
  }

}
