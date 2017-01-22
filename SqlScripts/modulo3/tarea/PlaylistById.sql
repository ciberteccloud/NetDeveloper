CREATE PROCEDURE dbo.PlaylistById
	@playlistId int
AS
BEGIN
	SELECT PlaylistId, Name FROM dbo.Playlist WHERE PlaylistId=@playlistId
END