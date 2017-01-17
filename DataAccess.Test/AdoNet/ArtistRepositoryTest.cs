using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;
using Models;
using DataAccess.AdoNet;

namespace DataAccess.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly ArtistRepository _adonet;
        public ArtistRepositoryTest()
        {
            _adonet = new ArtistRepository(ConfigurationManager.ConnectionStrings["ChinookConnection"].ConnectionString);
        }

        [TestMethod]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _adonet.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Search_Artist_By_Id()
        {
            var artist = _adonet.GetArtistById(1);
            var expectedArtist = new Artist
            {
                ArtistId = 1,
                Name = "AC/DC"
            };
            Assert.AreEqual(expectedArtist.ArtistId, artist.ArtistId);
            Assert.AreEqual(expectedArtist.Name, artist.Name);
        }

        [TestMethod]
        public void Search_Artist_By_Id_From_Store_Procedure()
        {
            var artist = _adonet.GetArtistById_Store_Procedure(1);
            var expectedArtist = new Artist
            {
                ArtistId = 1,
                Name = "AC/DC"
            };
            Assert.AreEqual(expectedArtist.ArtistId, artist.ArtistId);
            Assert.AreEqual(expectedArtist.Name, artist.Name);
        }

        [TestMethod]
        public void Get_List_Of_Artist()
        {
            var artistList = _adonet.GetListArtist();            
            Assert.AreEqual(artistList.Count()>0,true);            
        }

        [TestMethod]
        public void Insert_Artist()
        {
            var artistId = _adonet.InsertArtist("New Artist");
            Assert.AreEqual(artistId > 0, true);
        }
    }
}
