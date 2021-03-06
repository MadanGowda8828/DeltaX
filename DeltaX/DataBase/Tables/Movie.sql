CREATE TABLE Movie ( 
Id INT NOT NULL IDENTITY(1,1) ,
Name VARCHAR(50) NOT NULL,
Plot VARCHAR(255),
DateOfRelease DATE,
ProducerId INT,
CreatedDateTime DATETIME,
CreatedBy VARCHAR(20),
UpdatedDateTime DATETIME,
UpdatedBy VARCHAR(20),
IsActive BIT,
IsDeleted BIT,
PosterName VARCHAR(100),
PosterData VARBINARY(MAX)
)

ALTER TABLE Movie ADD CONSTRAINT FK_ProducerId FOREIGN KEY (ProducerId) REFERENCES Producer(Id);
ALTER TABLE Movie ADD CONSTRAINT PK_Movie PRIMARY KEY (Id);
ALTER TABLE Movie ADD CONSTRAINT DF_CbxcDateTime DEFAULT getdate() FOR CreatedDateTime;
ALTER TABLE Movie ADD CONSTRAINT DF_Cxbratedby DEFAULT 'User' FOR CreatedBy;
ALTER TABLE Movie ADD CONSTRAINT DF_ActivateStatus DEFAULT 1 FOR IsActive;
ALTER TABLE Movie ADD CONSTRAINT DF_DeletionStatus DEFAULT 0 FOR IsDeleted;
