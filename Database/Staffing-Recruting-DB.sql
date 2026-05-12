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
ID int Identity(1,1) Primary Key,
UserName Nvarchar(200) Unique,
FullName Nvarchar(200),
Email Nvarchar(300),
Password Nvarchar(200),
Role Nvarchar(50),
CreatedAt DateTime
)

Create Table JobApplications(
ID int Identity(1,1),
JobID int,
CandidateID int,
FirstName Nvarchar(200),
LastName Nvarchar(100),
Email Nvarchar(100),
Phone Nvarchar(100),
ResumeURL Nvarchar(max),
CoverLetterURL Nvarchar(max),
Status NVARCHAR(50) DEFAULT 'Applied',
AppliedAt DATETIME DEFAULT GETUTCDATE(),
ApplicationUpdateDate DateTime,
CONSTRAINT FK_JobApplications_Jobs FOREIGN KEY (JobId) REFERENCES Jobs(Id) ON DELETE CASCADE,
CONSTRAINT CHK_Application_Status CHECK (Status IN ('Applied', 'Reviewed', 'Interviewing', 'Offered', 'Rejected'))
)

Create Table CandidateProfile
(ID int Identity(1,1) Primary Key,
UserID int,
FirstName Nvarchar(200),
LastName Nvarchar(100),
ProfessionalTitle Nvarchar(200),
Bio Nvarchar(Max),
Skills Nvarchar(max),
Experience Nvarchar(Max),
LinkedInUrl Nvarchar(200),
GithubUrl Nvarchar(200),
ResumeURL Nvarchar(300),
LastUpdatedAt DateTime,
CONSTRAINT FK_USERID_CANPROFILE FOREIGN KEY (UserID) REFERENCES Users(ID) ON DELETE CASCADE
)

ALTER TABLE Users ADD CONSTRAINT PK_Users PRIMARY KEY (ID);

Alter table CandidateProfile Add  Experience Nvarchar(Max);

Select * From Jobs
 
Select * From Compainies 

Select * From Users

Select * From JobApplications

Select * From CandidateProfile

--Drop table  JobApplication

ALTER TABLE Jobs
DROP Column Company_ID;

update Users Set Role = 'Admin' where Role = 'admin'

Delete From Users Where ID=4