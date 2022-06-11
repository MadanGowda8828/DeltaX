CREATE TABLE Producer ( 
Id INT NOT NULL IDENTITY(1,1) ,
Name VARCHAR(50) NOT NULL,
Bio VARCHAR(255), 
Company VARCHAR(50), 
DateOfBirth DATE, 
Gender VARCHAR(10), 
CreatedDateTime DATETIME, 
CreatedBy VARCHAR(50),
ModifiedBy VARCHAR(50),
ModifiedDateTime DATETIME,
IsActive BIT,
IsDeleted BIT
) 

ALTER TABLE Producer ADD CONSTRAINT PK_Producer PRIMARY KEY (Id);
ALTER TABLE Producer ADD CONSTRAINT DF_CreatedDateTime DEFAULT getdate() FOR CreatedDateTime;
ALTER TABLE Producer ADD CONSTRAINT DF_CreatedBy DEFAULT 'User' FOR CreatedBy;
ALTER TABLE Producer ADD CONSTRAINT DF_IsActive DEFAULT 1 FOR IsActive;
ALTER TABLE Producer ADD CONSTRAINT DF_IsDeleted DEFAULT 0 FOR IsDeleted;