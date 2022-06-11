CREATE PROCEDURE [dbo].[Actor_Ins]
(
@ActorName VARCHAR(50) = NULL,
@Bio VARCHAR(255) = NULL,
@DateOfBirth DATE = NULL, 
@Gender VARCHAR(10) = NULL,
@CreatedBy VARCHAR(50) = 'User',
@Id int output
)
AS   
BEGIN    
	INSERT INTO [dbo].[Actor] (Name, Bio, DateOfBirth, Gender, CreatedBy)
	VALUES
	(
		@ActorName, @Bio, @DateOfBirth, @Gender, @CreatedBy
	)
	SET @id=SCOPE_IDENTITY()
    RETURN  @id
END;