import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SharedModules } from '../../Shared/shared-modules';
import { CandidateServices } from '../../Services/Candidate/candidate';
import { ICandidateProfile } from '../../Models/CandidateProfile';

@Component({
  selector: 'app-candidate-profile',
  imports: [SharedModules],
  templateUrl: './candidate-profile.html',
  styleUrl: './candidate-profile.css',
})
export class CandidateProfile implements OnInit {
  profileForm = new FormGroup({
    FirstName: new FormControl('', Validators.required),
    LastName: new FormControl('', Validators.required),
    ProfessionalTitle: new FormControl('', Validators.required),
    Bio: new FormControl('', Validators.required),
    Skills: new FormControl('', Validators.required),
    Experience: new FormControl('', Validators.required),
    Education: new FormControl('', Validators.required),
    LinkedInUrl: new FormControl('', Validators.required),
    GithubUrl: new FormControl(''), // Optional
    ResumeUrl: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
    this.getCandidateDetails();
  }
  constructor(private candidateServices: CandidateServices) { }
  selectedFile: File | null = null;
  onFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.profileForm.patchValue({
        ResumeUrl: file.name
      });
      this.selectedFile = file;
    }
  }
  onSubmit() {
    if (this.profileForm.valid) {

      if (this.selectedFile) {
        const formData = new FormData();
        formData.append('file', this.selectedFile);
        const existingFileUrl = this.profileForm.get('ResumeUrl')?.value;
        if (existingFileUrl && existingFileUrl.includes('/uploads/')) {
          formData.append('oldFilePath', existingFileUrl);
        }

        this.candidateServices.uploadResume(formData).subscribe({
          next: (response: any) => {
            this.profileForm.patchValue({
              ResumeUrl: response.Url
            });
            console.log(response)
            this.saveProfileData();
          },
          error: (err: any) => {
            console.error("File upload failed", err);
          }
        });
      }
      else {
        this.saveProfileData();
      }

    } else {
      console.warn("Form is invalid! Please fill out all required fields.");
      this.profileForm.markAllAsTouched();
    }
  }

  private saveProfileData() {
    console.log(this.profileForm.value)
    this.candidateServices.CreateCandidateProfile(this.profileForm.value).subscribe({
      next: (res: any) => {
        console.log("Successfully Created/Updated the user Account!");
      },
      error: (err: any) => {
        console.error("Failed to save profile data", err);
      }
    });
  }
  get displayResumeName(): string {
    const rawPath = this.profileForm.get('ResumeUrl')?.value;

    if (!rawPath) return '';

    let fileName = rawPath.split('/').pop() || rawPath;

    if (fileName.includes('_')) {
      fileName = fileName.substring(fileName.indexOf('_') + 1);
    }

    return fileName;
  }
  userDetails: ICandidateProfile[] = [];
  getCandidateDetails() {
    this.candidateServices.GetCandidateProfile().subscribe({
      next: (response: any) => {
        this.userDetails = response;
        console.log("Candidate Details: ", this.userDetails)
        this.profileForm.patchValue({
          FirstName: response.FirstName,
          LastName: response.LastName,
          ProfessionalTitle: response.ProfessionalTitle,
          Bio: response.Bio,
          Skills: response.Skills,
          Experience: response.Experience,
          Education: response.Education,
          LinkedInUrl: response.LinkedInUrl,
          GithubUrl: response.GithubUrl,
          ResumeUrl: response.ResumeUrl
        })
      },
      error(err) {
        console.log("Error: ", err);
      }
    })
  }
}
