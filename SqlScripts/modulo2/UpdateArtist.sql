USE Chinook
GO

CREATE PROCEDURE UpdateArtist
	@artistId int,
	@name nvarchar(120)
AS
BEGIN	
	SET NOCOUNT ON;
	UPDATE [dbo].[Artist]
	SET [Name] = @name
	WHERE ArtistId=@artistId
END
GO
