USE Chinook
GO

CREATE PROCEDURE dbo.ArtistById
	@artistId int
AS
BEGIN
	SELECT TOP 1 ArtistId, Name FROM dbo.Artist WHERE ArtistId=@artistId
END
GO
