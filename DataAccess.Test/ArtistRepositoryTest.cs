using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccess.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly UnitOfWork _unitOfWork;
        public ArtistRepositoryTest()
        {
            _unitOfWork = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _unitOfWork.Artists.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Search_Artist_By_Id()
        {
            var artist = _unitOfWork.Artists.GetById(1);
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
            var artistList = _unitOfWork.Artists.GetAll();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Get_List_Of_Artist_by_Store()
        {
            var artistList = _unitOfWork.Artists.GetListArtistByStore();
            Assert.AreEqual(artistList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Artist()
        {
            var newArtist = new Artist
            {                
                Name = "Test Unit Of Work"
            };
            _unitOfWork.Artists.Add(newArtist);
            _unitOfWork.Complete();
            var expectedArtist = _unitOfWork.Artists.GetByName("Test Unit Of Work");
            Assert.AreEqual(expectedArtist.ArtistId > 0, true);
            Assert.AreEqual(expectedArtist.Name, "Test Unit Of Work");
        }

        [TestMethod]
        public void Delete_Artist_By_Id()
        {
            var removeArtist = _unitOfWork.Artists.GetByName("Test Unit Of Work");
            _unitOfWork.Artists.Remove(removeArtist);            
            Assert.AreEqual(_unitOfWork.Complete()> 0, true);
        }
    }
}
