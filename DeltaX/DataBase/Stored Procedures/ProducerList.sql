CREATE PROCEDURE dbo.ProducerList
AS   
BEGIN    
	SELECT Id, Name, Bio, DateOfBirth, Gender,Company, IsActive, IsDeleted FROM Producer WHERE IsDeleted=0 and IsActive=1
END;
