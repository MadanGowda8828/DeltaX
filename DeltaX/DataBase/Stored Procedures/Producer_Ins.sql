CREATE PROCEDURE [dbo].[Producer_Ins]
(
@ProducerName VARCHAR(50) = NULL,
@Bio VARCHAR(255) = NULL,
@Company VARCHAR(50) = NULL,
@DateOfBirth DATE = NULL, 
@Gender VARCHAR(10) = NULL,
@CreatedBy VARCHAR(50) = 'User',
@Id int output
)
AS   
BEGIN    
	INSERT INTO [dbo].[Producer] (Name, Bio, Company, DateOfBirth, Gender, CreatedBy)
	VALUES
	(
		@ProducerName, @Bio, @Company, @DateOfBirth, @Gender, @CreatedBy
	)
	SET @id=SCOPE_IDENTITY()
    RETURN  @id
END;