Create Database Staffing_Recruting_DB

Create Table Company
(
ID int Identity(1,1) PRIMARY KEY,
Name Nvarchar(200),
Industry_Type Nvarchar(200),
Website Nvarchar(300),
Location Nvarchar(200)
)

Create Table Jobs
( 
Id int Identity(1,1) primary Key Not Null,
Title nvarchar(200),
Description nvarchar(Max),
Location Nvarchar(200),
Recruiter_ID nvarchar(300),
CompanyID int,
From_Salary decimal(18,2),
To_Salary decimal(18,2),
 RequiredExperience NVarchar(200),
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

CREATE TABLE JobApplication(
ID INT IDENTITY(1,1) PRIMARY KEY,
JobID INT NOT NULL, 
CandidateID INT NOT NULL,
CoverLetterURL NVARCHAR(MAX),
Status NVARCHAR(100) NOT NULL,
AppliedAt DATETIME DEFAULT GETUTCDATE(),
ApplicationUpdateDate DATETIME,
CONSTRAINT FK_JobApplications_Jobs FOREIGN KEY (JobID) REFERENCES Jobs(ID) ON DELETE CASCADE, 
CONSTRAINT FK_JobApplications_Candidates FOREIGN KEY (CandidateID) REFERENCES Users(ID),  
CONSTRAINT CHK_Application_Status CHECK (Status IN ('Applied', 'Reviewed', 'Interviewing', 'Offered', 'Rejected'))
);

Create Table CandidateProfile
(ID int Identity(1,1) Primary Key,
UserID int,
FirstName Nvarchar(200),
LastName Nvarchar(100),
ProfessionalTitle Nvarchar(200),
Bio Nvarchar(Max),
Skills Nvarchar(max),
Experience Nvarchar(Max),
Education Nvarchar(MAX),
LinkedInUrl Nvarchar(200),
GithubUrl Nvarchar(200),
ResumeURL Nvarchar(300),
LastUpdatedAt DateTime,
CONSTRAINT FK_USERID_CANPROFILE FOREIGN KEY (UserID) REFERENCES Users(ID) ON DELETE CASCADE
)

ALTER TABLE Jobs Drop CONSTRAINT  FK_Jobs_Companies

Alter table Company Add  Location Nvarchar(200);

Select * From Jobs
   
Select * From Company 
 
Select * From Users

Select * From JobApplication

Select * From CandidateProfile

Select * FROM JobApplication

--Drop table  Companies

--ALTER TABLE Company DROP Column Company_City;

update Jobs Set CompanyID =1 where ID=1

Delete From CandidateProfile Where ID=4

Select * From JobApplication Where JobID =1

Insert into Company (Name, Industry_Type, Website, Location) Values('Google', 'Software', 'google.com','India')