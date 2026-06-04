import { Component, OnInit } from '@angular/core';
import { SharedModules } from '../Shared/shared-modules';
import { LoginServices } from '../Services/Users/loginServices';
import { UserRoles } from '../Models/Users';
import { Router } from '@angular/router';
// import { response } from 'express';
@Component({
  selector: 'app-login',
  imports: [SharedModules],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login implements OnInit{
  login = {
    userName: '',
    password: '',
    role: ''
  }

  userRole: UserRoles[] = [
    { viewValue: 'Admin', value: 'Admin' },
    { viewValue: 'Candidate', value: 'Candidate' },
    { viewValue: 'Recruiter', value: 'Recruiter' }
  ]

ngOnInit(){
  localStorage.removeItem("user-token")
}

  constructor(private loginservices: LoginServices, private router: Router) { }
  loginUser() {
    console.log(this.login)
    this.login.userName = this.login.userName.trim();
    this.login.password = this.login.password.trim();
    this.loginservices.checkUser(this.login).subscribe({
      next: (repsonse: any) => {
        console.log(repsonse);
        localStorage.setItem("user-token", repsonse.token);
        if (this.login.role == "Admin") {
          this.router.navigate(["/add-user"]);
        }
        else if (this.login.role == "Recruiter") {
          this.router.navigate(["/recruiter"]);
        }
        else if (this.login.role == "Candidate") {
          this.router.navigate(['/candidate-home']);
        }
      },
      error: (err) => {
        alert("Invalid Username, Password, or Role!  '"+err.message);
        console.log(err);
        localStorage.removeItem("user-token");
      }
    })

  }
}
