USE [Chinook]
GO

CREATE PROCEDURE dbo.DeleteArtist	
	@artistId int
AS
BEGIN
	DELETE FROM [dbo].[Artist]
	OUTPUT deleted.ArtistId
    WHERE ArtistId=@artistId
END
GO