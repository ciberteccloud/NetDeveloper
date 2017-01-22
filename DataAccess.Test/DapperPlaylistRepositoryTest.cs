using DataAccess.DapperRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Configuration;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class DapperPlaylistRepositoryTest
    {
        private readonly PlaylistRepository _dapperRepository;
        public DapperPlaylistRepositoryTest()
        {
            _dapperRepository = new PlaylistRepository(ConfigurationManager.ConnectionStrings["ChinookConnection"].ConnectionString);
        }

        [TestMethod]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _dapperRepository.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Search_Playlist_By_Id()
        {
            var playlist = _dapperRepository.GetPlaylistById(1);
            var expectedArtist = new Artist
            {
                ArtistId = 1,
                Name = "Music"
            };
            Assert.AreEqual(expectedArtist.ArtistId, playlist.PlaylistId);
            Assert.AreEqual(expectedArtist.Name, playlist.Name);
        }

        [TestMethod]
        public void Get_List_Of_Playlist()
        {
            var artistList = _dapperRepository.GetListPlaylist();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Playlist()
        {
            var playlistId = _dapperRepository.InsertArtist("New Playlist Dapper");
            Assert.AreEqual(playlistId > 0, true);
        }

        [TestMethod]
        public void Insert_Playlist_By_Transaction()
        {
            var playlistId = _dapperRepository.InsertArtistByTransaction("New Playlist Dapper Transaction");
            Assert.AreEqual(playlistId > 0, true);
        }

        [TestMethod]
        public void Delete_Playlist_By_Id()
        {
            var playlistId = _dapperRepository.DeletePlaylistById(19);
            Assert.AreEqual(19, playlistId);
        }
    }
}
