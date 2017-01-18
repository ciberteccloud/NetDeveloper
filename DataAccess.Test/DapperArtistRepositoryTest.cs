using DataAccess.DapperRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class DapperArtistRepositoryTest
    {
        private readonly ArtistRepository _dapperRepository;
        public DapperArtistRepositoryTest()
        {
            _dapperRepository = new ArtistRepository(ConfigurationManager.ConnectionStrings["ChinookConnection"].ConnectionString);
        }

        [TestMethod]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _dapperRepository.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Search_Artist_By_Id()
        {
            var artist = _dapperRepository.GetArtistById(1);
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
            var artistList = _dapperRepository.GetListArtist();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Artist()
        {
            var artistId = _dapperRepository.InsertArtist("New Artist Dapper");
            Assert.AreEqual(artistId > 0, true);
        }

        [TestMethod]
        public void Delete_Artist_By_Id()
        {
            var artistId = _dapperRepository.DeleteArtistById(279);
            Assert.AreEqual(279, artistId);
        }
    }
}
