export interface IJobs {
    id: number;
    Title: string;
    Description: string;
    Location: string;
    Recruiter_ID: string;
    From_Salary: number;
    To_salary: number;
    SalaryType: number;
    Status: string;
    CreatedAt: string;
}

export interface IAddJobs {
    Title: string;
    Description: string;
    Location: string;
    From_Salary: number;
    To_salary: number;
    SalaryType: number;
    Status: string;
}

export interface IGetJobs {
    Id:number;
    Title: string;
    Description: string;
    Location: string;
    Recruiter_ID: string;
    From_Salary: number;
    To_Salary: number;
    SalaryType: number;
    Status: string;
    CreatedAt: string;
}