using Models;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace DataAccess.Test
{    
    public class ArtistRepositoryTest
    {
        private readonly UnitOfWork _unitOfWork;
        public ArtistRepositoryTest()
        {
            _unitOfWork = new UnitOfWork(new ChinookContext());
        }

        [Fact(DisplayName ="CountGreaterThanZero")]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {
            var count = _unitOfWork.Artists.Count();
            count.Should().BeGreaterThan(0);            
        }

        [Fact]
        public void Search_Artist_By_Id()
        {
            var artist = _unitOfWork.Artists.GetById(1);
            var expectedArtist = new Artist
            {
                ArtistId = 1,
                Name = "AC/DC"
            };
            expectedArtist.ArtistId.Should().Equals(artist.ArtistId);
            expectedArtist.Name.Should().Equals(artist.Name);
        }

        [Fact]
        public void Get_List_Of_Artist()
        {
            var artistList = _unitOfWork.Artists.GetAll();
            artistList.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void Get_List_Of_Artist_by_Store()
        {
            var artistList = _unitOfWork.Artists.GetListArtistByStore();
            artistList.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void Insert_Artist()
        {
            var newArtist = new Artist
            {                
                Name = "Test Unit Of Work"
            };
            _unitOfWork.Artists.Add(newArtist);
            _unitOfWork.Complete();
            var expectedArtist = _unitOfWork.Artists.GetByName("Test Unit Of Work");
            expectedArtist.ArtistId.Should().BeGreaterThan(0);
            expectedArtist.Name.Should().Be("Test Unit Of Work");
        }

        [Fact]
        public void Delete_Artist_By_Id()
        {
            var removeArtist = _unitOfWork.Artists.GetByName("Test Unit Of Work");
            _unitOfWork.Artists.Remove(removeArtist);
            _unitOfWork.Complete().Should().BeGreaterThan(0);
        }

        [Fact]
        public void Get_List_Of_Artist_by_Page()
        {
            var artistListPage1 = _unitOfWork.Artists.GetListArtistByPage(1,10).ToList();
            var artistListPage2 = _unitOfWork.Artists.GetListArtistByPage(2, 10).ToList();

            artistListPage1.Count().Should().Be(artistListPage2.Count());
            for (int i = 0; i < 10; i++)
            {
                artistListPage1[i].ArtistId.Should().NotBe(artistListPage2[i].ArtistId);
            }
        }
    }
}
