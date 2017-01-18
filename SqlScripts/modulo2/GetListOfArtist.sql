USE Chinook
GO


CREATE PROCEDURE dbo.GetListOfArtist	
AS
BEGIN
	SELECT ArtistId, Name FROM dbo.Artist
END
GO
