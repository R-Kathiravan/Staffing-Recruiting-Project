export interface IJobApplications {
    ID: number;
    JobID: number;
    CandidateID: number;
    FirstName: string;
    LastName: string;
    Email: string;
    Phone: string;
    ResumeURL: string;
    CoverLetterURL: string;
    Status: string;
    AppliedAt: string;
    ApplicationUpdateDate: string;
}

export interface IAddJobApplications {
    JobID: number;
    CandidateID: number;
    FirstName: string;
    LastName: string;
    Email: string;
    Phone: string;
    ResumeURL: string;
    CoverLetterURL: string;
    Status: string;
}