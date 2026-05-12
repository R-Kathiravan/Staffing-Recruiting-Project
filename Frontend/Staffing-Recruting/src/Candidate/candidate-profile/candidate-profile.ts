import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-candidate-profile',
  imports: [],
  templateUrl: './candidate-profile.html',
  styleUrl: './candidate-profile.css',
})
export class CandidateProfile implements OnInit {
  ngOnInit(): void {

  }

  profileForm = new FormGroup(
    {
      FirstName: new FormControl('', Validators.required),
      LastName: new FormControl('', Validators.required),
      ProfessionalTitle: new FormControl('', Validators.required),
      Bio: new FormControl('', Validators.required),
      Skills: new FormControl('', Validators.required),
      Education: new FormControl('', Validators.required),
      LinkedInUrl: new FormControl('', Validators.required),
      GitHubUrl: new FormControl(''),
      ResumeUrl: new FormControl('', Validators.required)
    }
  )

}
