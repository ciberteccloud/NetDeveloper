using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EF
{
    public class PlaylistRepository
    {
        private ChinookContext _context;
        public PlaylistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Playlist.Count();
        }

        public Playlist GetArtistById(int id)
        {
            return _context.Playlist.FirstOrDefault(x => x.PlaylistId == id);
        }

        public IEnumerable<Playlist> GetListPlaylist()
        {
            return _context.Playlist;
        }

        public int InsertArtist(string name)
        {
            var playlist = new Playlist { Name = name };
            _context.Playlist.Add(playlist);
            return _context.SaveChanges();
        }
        public int DeleteArtistById(int id)
        {
            var playlist = new Playlist { PlaylistId = id };
            _context.Playlist.Remove(playlist);
            return _context.SaveChanges();
        }
    }
}
