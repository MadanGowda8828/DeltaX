CREATE PROCEDURE [dbo].[Movie_Upd]
(
@Id INT,
@Name VARCHAR(50) = NULL,
@Plot VARCHAR(255) = NULL,
@Actors VARCHAR(MAX)= NULL,
@DateOfRelease DATE = NULL, 
@ProducerId INT = NULL,
@CreatedBy VARCHAR(20) = 'User',
@PosterName VARCHAR(100),
@PosterData VARBINARY(MAX)
)
AS   
BEGIN    
	UPDATE [dbo].[Movie] 
	SET Name=@Name, Plot=@Plot, DateOfRelease=@DateOfRelease, ProducerId=@ProducerId, CreatedBy=@CreatedBy, PosterName=@PosterName, PosterData=@PosterData
	WHERE Id = @Id

	UPDATE [dbo].[MovieCast]
    SET IsDeleted=1
	WHERE MovieId = @Id

WHILE CHARINDEX(',', @Actors) > 0 
BEGIN
    DECLARE @tmpstr VARCHAR(10)
     SET @tmpstr = SUBSTRING(@Actors, 1, ( CHARINDEX(',', @Actors) - 1 ))
	 INSERT  INTO [dbo].[MovieCast]
            ( MovieId,
              ActorId 
            )
    VALUES  ( @Id,
              @tmpstr
            )

    SET @Actors = SUBSTRING(@Actors, CHARINDEX(',', @Actors) + 1, LEN(@Actors))
END
    RETURN  1;
END;