using DataAccess.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class EFPlaylistRepositoryTest
    {
        private readonly PlaylistRepository _entity;
        public EFPlaylistRepositoryTest()
        {
            _entity = new PlaylistRepository();
        }

        [TestMethod]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _entity.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Search_Playlist_By_Id()
        {
            var playlist = _entity.GetArtistById(1);
            var expectedPlaylist = new Playlist
            {
                PlaylistId = 1,
                Name = "Music"
            };
            Assert.AreEqual(expectedPlaylist.PlaylistId, playlist.PlaylistId);
            Assert.AreEqual(expectedPlaylist.Name, playlist.Name);
        }

        [TestMethod]
        public void Get_List_Of_Playlist()
        {
            var artistList = _entity.GetListPlaylist();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Playlist()
        {
            var artistId = _entity.InsertArtist("New Playlist EF");
            Assert.AreEqual(artistId > 0, true);
        }
                
        [TestMethod]
        public void Delete_Playlist_By_Id()
        {
            var artistId = _entity.DeleteArtistById(20);
            Assert.AreEqual(20, artistId);
        }
    }
}
