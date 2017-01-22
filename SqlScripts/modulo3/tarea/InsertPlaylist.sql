USE [Chinook]
GO

CREATE PROCEDURE dbo.InsertPlaylist
	@name nvarchar(120)
AS
BEGIN
INSERT INTO dbo.Playlist (Name)
    OUTPUT INSERTED.PlaylistId
    VALUES (@name)
END
GO

