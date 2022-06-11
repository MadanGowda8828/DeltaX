CREATE PROCEDURE [dbo].[MovieDelete]
(
@Id Int )
AS   
BEGIN    
	UPDATE [dbo].[Movie] 
	SET IsDeleted = 1, IsActive = 0
	WHERE Id = @Id
	RETURN 1;
END;