import { Component, OnInit } from '@angular/core';
import { SharedModules } from '../../Shared/shared-modules';
import { RecruiterComponent } from '../recruiter-component/recruiter-component';
import { RecruitersServices } from '../../Services/Recruiters/Recruiters';
import { IAddJobs } from '../../Models/Jobs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
@Component({
  selector: 'app-add-jobs',
  imports: [SharedModules],
  templateUrl: './add-jobs.html',
  styleUrl: './add-jobs.css',
})
export class AddJobs implements OnInit {
  jobForm = new FormGroup({
    Title: new FormControl('', [Validators.required]),
    Description: new FormControl('', [Validators.required, Validators.minLength(5)]),
    Location: new FormControl('', [Validators.required]),
    From_Salary: new FormControl(0, [Validators.required]),
    To_Salary: new FormControl(0, [Validators.required]),
    RequiredExperience: new FormControl('', Validators.required),
    SalaryType: new FormControl('', [Validators.required]),
    Status: new FormControl('', [Validators.required])
  },
    {
      validators: salaryRangeValidator
    });

  constructor(private jobsServices: RecruitersServices) { }
  ngOnInit(): void {

  }

  onSubmit() {
    if (this.jobForm.valid) {
      this.jobsServices.addJobs(this.jobForm.value).subscribe({
        next: (res: any) => {
          alert("Succesfully Inserted Jobs " + res);
        },
        error(err) {
          alert("Error while Inserting data " + err.message)
          console.log(err.message);
        },
      })
    }    
  }


}
export const salaryRangeValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  const fromSalary = control.get('From_Salary')?.value;
  const toSalary = control.get('To_Salary')?.value;

  if (fromSalary !== null && toSalary !== null && fromSalary > toSalary) {
    return { invalidSalaryRange: true };
  }

  return null;    
};