USE Chinook
GO

CREATE PROCEDURE dbo.InsertArtist	
	@name nvarchar(120)
AS
BEGIN
	INSERT INTO dbo.Artist(Name)
	OUTPUT INSERTED.ArtistId
    VALUES (@name)
END
GO
