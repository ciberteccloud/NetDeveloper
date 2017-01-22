USE [Chinook]
GO

CREATE PROCEDURE dbo.GetListOfPlaylist		
AS
BEGIN
	SELECT PlaylistId,Name FROM dbo.Playlist
END
GO