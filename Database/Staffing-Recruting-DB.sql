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
UID int Identity(1,1),
Jobs_Name nvarchar(200),
Job_Id nvarchar(100)  primary Key Not Null,
Job_Description nvarchar(500),
Job_Location Nvarchar(200),
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
UID int Identity(1,1),
UserName Nvarchar(200) Unique,
FullName Nvarchar(200),
Password Nvarchar(200),
Role Nvarchar(50),
)


Select * From Jobs
 
Select * From Compainies 

Drop table Compainies