export interface IJobApplications {
    ID: number;
    JobID: number;
    CandidateID: number;
    CoverLetterURL?: string;
    AppliedAt: string;
    ApplicationUpdateDate: string;
}

export interface IAddJobApplications {
    JobID: number;
    CoverLetterURL: string;
}