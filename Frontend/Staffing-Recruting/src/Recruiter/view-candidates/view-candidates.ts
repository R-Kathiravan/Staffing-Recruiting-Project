import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecruitersServices } from '../../Services/Recruiters/Recruiters';
import { Applicants } from '../../Models/Applicants';
import { SharedModules } from '../../Shared/shared-modules';

@Component({
  selector: 'app-view-candidates',
  imports: [SharedModules],
  templateUrl: './view-candidates.html',
  styleUrl: './view-candidates.css',
})
export class ViewCandidates implements OnInit {
  currentJobId = 0;
  constructor(private route: ActivatedRoute, private recruiterServices: RecruitersServices) { }
  backendUrl = 'https://localhost:7141/'
  ngOnInit(): void {
    const idString = this.route.snapshot.paramMap.get('id');

    if (idString) {
      this.currentJobId = Number(idString);

      // Now instantly fetch the applicants for this specific job!
      this.loadApplicants(this.currentJobId);
    }


  }

  applicantsList: Applicants[] = []

  loadApplicants(Id: number) {
    this.recruiterServices.getApplicantsPerJob(Id).subscribe({
      next: (resp: any) => {
        this.applicantsList = resp;
        console.log(resp);
      },
      error(err) {
        console.log("Error: ", err);
      },
    })
  }
  getSkillsArray(skillsString: string): string[] {
    if (!skillsString) return [];
    return skillsString.split(',').map(skill => skill.trim());
  }

  formatUrl(url: string): string {
    if (!url) return '#i';
    return url.startsWith('http') ? url : `https://${url}`;
  }
}
