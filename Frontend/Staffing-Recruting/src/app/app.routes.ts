import { Routes } from '@angular/router';
import { AddUsers } from '../admin/add-users/add-users';
import { Home } from '../home/home'; 
import { Login } from '../login/login';
import { Register } from '../register/register';
import { RecruiterComponent } from '../Recruiter/recruiter-component/recruiter-component';
import { AddJobs } from '../Recruiter/add-jobs/add-jobs';
import { ListJobs } from '../Recruiter/list-jobs/list-jobs';
import { CandidateHome } from '../Candidate/candidate-home/candidate-home';
import { ApplyJob } from '../Candidate/apply-job/apply-job';

export const routes: Routes = [
    {
        path: '',
        component: Home
    },
    {
        path: 'login',
        component: Login
    },
    {
        path:'register',
        component:Register
    },
    {
        path: 'add-user',
        component: AddUsers
    },
    {
        path:'recruiter',
        component:RecruiterComponent
    },
    {
        path:'add-jobs',
        component:AddJobs
    },
    {
        path:'List-Jobs',
        component:ListJobs
    },{
        path:'candidate-home',
        component:CandidateHome
    },{
        path:'apply-job/:id',
        component:ApplyJob
    }
];
