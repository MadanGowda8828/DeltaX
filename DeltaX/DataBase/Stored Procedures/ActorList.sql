CREATE PROCEDURE dbo.ActorList
AS   
BEGIN    
	SELECT Id, Name, Bio, DateOfBirth, Gender, IsActive, IsDeleted FROM Actor WHERE IsDeleted=0 and IsActive=1
END;