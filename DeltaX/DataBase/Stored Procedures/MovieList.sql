CREATE PROCEDURE [dbo].[MovieList]
AS   
BEGIN    
	SELECT M.Id , 
	M.Name , 
	M.Plot, 
	(SELECT Name,Id From Actor where Id IN (SELECT ActorId from MovieCast where MovieId = M.Id AND IsDeleted=0) For  JSON AUTO ) as Actors,
	M.DateOfRelease,
	(SELECT Name FROM Producer where Id = ProducerId) as Producer,
	M.PosterName,
	M.PosterData
	FROM Movie M
	WHERE IsDeleted = 0 and IsActive = 1
END;