using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ChinookContext context) : base(context)
        {
        }
        public IEnumerable<Artist> GetListArtistByStore()
        {
            return ChinookContext.Database.SqlQuery<Artist>("GetListOfArtist");
        }

        public Artist GetByName(string name)
        {
            return ChinookContext.Artist.FirstOrDefault(artist => artist.Name == name);
        }

        public ChinookContext ChinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
