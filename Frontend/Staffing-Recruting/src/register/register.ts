import { Component } from '@angular/core';
import { SharedModules } from '../Shared/shared-modules';
import { UserRoles } from '../Models/Users';
import { LoginServices } from '../Services/Users/loginServices';
import { InsertUsers } from '../Models/Users';
@Component({
  selector: 'app-register',
  imports: [SharedModules],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  register : InsertUsers= {
    UserName: '',
    Password: '',
    Role: '',
    Email: '',
    FullName: ''
  }
  
    userRole: UserRoles[] = [
      { viewValue: 'Admin', value: 'Admin' },
      { viewValue: 'Canditate', value: 'Canditate' },
      { viewValue: 'Recruiter', value: 'Recruiter' }
    ]
  
    constructor(private registerServices : LoginServices) { }
  
  registerUser() {
    this.registerServices.registerUser(this.register).subscribe(()=> alert("User Created Successfully"))
  }
}
