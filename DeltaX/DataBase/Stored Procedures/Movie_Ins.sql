CREATE PROCEDURE [dbo].[Movie_Ins]
(
@Name VARCHAR(50) = NULL,
@Plot VARCHAR(255) = NULL,
@Actors VARCHAR(MAX)= NULL,
@DateOfRelease DATE = NULL, 
@ProducerId INT = NULL,
@CreatedBy VARCHAR(20) = 'User',
@PosterName VARCHAR(100),
@PosterData VARBINARY(MAX),
@Id int output
)
AS   
BEGIN    
	INSERT INTO [dbo].[Movie] (Name, Plot, DateOfRelease, ProducerId, CreatedBy, PosterName, PosterData)
	VALUES
	(
		@Name, @Plot, @DateOfRelease, @ProducerId, @CreatedBy, @PosterName, @PosterData 
	)
	SET @id=SCOPE_IDENTITY()

WHILE CHARINDEX(',', @Actors) > 0 
BEGIN

    DECLARE @tmpstr VARCHAR(10)
     SET @tmpstr = SUBSTRING(@Actors, 1, ( CHARINDEX(',', @Actors) - 1 ))

    INSERT  INTO [dbo].[MovieCast]
            ( MovieId,
              ActorId 
            )
    VALUES  ( @id,
              @tmpstr
            )
    SET @Actors = SUBSTRING(@Actors, CHARINDEX(',', @Actors) + 1, LEN(@Actors))
END
    RETURN  @id
END;