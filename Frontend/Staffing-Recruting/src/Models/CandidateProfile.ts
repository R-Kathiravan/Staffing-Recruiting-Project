export interface ICandidateProfile {
    ID: number;
    UserID: number;
    FirstName: string;
    LastName: string;
    ProfessionalTitle: string;
    Bio: string;
    Skills: string;
    Experience: string;
    Education: string;
    LinkedInUrl: string;
    GithubUrl: string;
    ResumeUrl: string;
    LastUpdatedAt: string;
}

export interface IAddCandidateProfile {
    FirstName: string;
    LastName: string;
    ProfessionalTitle: string;
    Bio: string;
    Skills: string;
    Experience: string;
    Education: string;
    LinkedInUrl: string;
    GithubUrl: string;
    ResumeUrl: File;
}