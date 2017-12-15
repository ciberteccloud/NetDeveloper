using DataAccess.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class EFArtistRepositoryTest
    {
        private readonly ArtistRepository _entity;
        public EFArtistRepositoryTest()
        {
            _entity = new ArtistRepository();
        }

        [TestMethod]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _entity.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Search_Artist_By_Id()
        {
            var artist = _entity.GetArtistById(1);
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
            var artistList = _entity.GetListArtist();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Get_List_Of_Artist_by_Store()
        {
            var artistList = _entity.GetListArtistByStore();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Artist()
        {
            var artistId = _entity.InsertArtist("New Artist EF");
            Assert.AreEqual(artistId > 0, true);
        }

        [TestMethod]
        public void Delete_Artist_By_Id()
        {
            var artistId = _entity.DeleteArtistById(279);
            Assert.AreEqual(279, artistId);
        }
                
        [TestMethod]
        public void Ejecucion_Diferida()
        {
            using (var context = new ChinookContext())
            {
                var result = from artist in context.Artist
                             where artist.Name.StartsWith("A")
                             select artist;

                //La ejecucion se hace aquí
                foreach (var artist in result)
                {
                    Assert.AreEqual(artist.ArtistId > 0, true);
                }
            }            
        }

        [TestMethod]
        public void Ejecucion_Inmediata()
        {
            using (var context = new ChinookContext())
            {
                var result = (from artist in context.Artist
                              where artist.Name.StartsWith("A")
                              select artist).Count();
                
                Assert.AreEqual(result > 0, true);
            }
        }
        
    }
}