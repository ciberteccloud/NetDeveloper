using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EF
{
    public class ArtistRepository
    {
        private ChinookContext _context;
        public ArtistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }

        public Artist GetArtistById(int id)
        {
            return _context.Artist.FirstOrDefault(x => x.ArtistId == id);
        }

        public IEnumerable<Artist> GetListArtist()
        {
            return _context.Artist;
        }

        public IEnumerable<Artist> GetListArtistByStore()
        {
            return _context.Database.SqlQuery<Artist>("GetListOfArtist");
        }
        

        public int InsertArtist(string name)
        {
            var artist = new Artist { Name = name };
            _context.Artist.Add(artist);
            return _context.SaveChanges();
        }
        public int DeleteArtistById(int id)
        {
            var artist = new Artist { ArtistId = id };
            _context.Artist.Remove(artist);
            return _context.SaveChanges();
        }
    }
}
