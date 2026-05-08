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
Title nvarchar(200),
Description nvarchar(Max),
Location Nvarchar(200),
Recruiter_ID nvarchar(300),
From_Salary decimal(18,2),
To_Salary decimal(18,2),
SalaryType Nvarchar(100),
Status nvarchar(100),
CreatedAt DateTime, 
CONSTRAINT CHK_Job_SalaryText CHECK (SalaryType IN ('Hourly', 'Daily', 'Monthly', 'Yearly')),
CONSTRAINT CHK_STATUS CHECK(Status IN('Active','InActive','Closed'))
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

ALTER TABLE Jobs
DROP Column Company_ID;

update Users Set Role = 'Recruiter' where Role = 'recruiter'

Delete From Users Where ID=4