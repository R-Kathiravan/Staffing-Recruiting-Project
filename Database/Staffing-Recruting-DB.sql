Create Database Staffing_Recruting_DB

Create Table Compainies
(
UID int Identity(1,1),
Company_Name Nvarchar(200),
Company_ID Nvarchar(100) primary key Not Null,
Industry_Type Nvarchar(200),
Company_Website Nvarchar(300),
Company_City Nvarchar(200)
)

Create Table Jobs
( 
Id int Identity(1,1) primary Key Not Null,
Name nvarchar(200),
Description nvarchar(500),
Location Nvarchar(200),
Company_ID Nvarchar(100) Not Null,
Recruiter nvarchar(300),
Salary decimal,
Status nvarchar(100),
CreatedAt DateTime,
CONSTRAINT FK_Company_ID
        FOREIGN KEY (Company_ID) REFERENCES Compainies(Company_ID)
        ON UPDATE CASCADE
        ON DELETE CASCADE
)

Create Table Users
(
ID int Identity(1,1),
UserName Nvarchar(200) Unique,
FullName Nvarchar(200),
Email Nvarchar(300),
Password Nvarchar(200),
Role Nvarchar(50),
CreatedAt DateTime
)

Alter table Users Add  CreatedAt DateTime;

Select * From Jobs
 
Select * From Compainies 

Select * From Users

Drop table jobs