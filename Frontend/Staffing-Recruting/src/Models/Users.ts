export interface Users {
    id: number;
    UserName: string;
    Password: string;
    Email: string;
    Role: string;
    CreatedAt: string;
}

export interface InsertUsers {
    UserName: string;
    FullName:string;
    Password: string;
    Email: string;
    Role: string;
}

export interface CheckUser {
    UserName: string;
    Password: string;
    role:string;
}

export interface UserRoles{
    value:string;
    viewValue:string;
}