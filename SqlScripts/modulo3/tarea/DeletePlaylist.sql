USE [Chinook]
GO

CREATE PROCEDURE dbo.DeletePlaylist	
	@playlistId int
AS
BEGIN
	DELETE FROM [dbo].[Playlist]
	OUTPUT deleted.PlaylistId
    WHERE PlaylistId=@playlistId
END
GO