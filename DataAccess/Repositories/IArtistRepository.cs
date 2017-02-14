using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IArtistRepository: IRepository<Artist>
    {
        IEnumerable<Artist> GetListArtistByStore();
        Artist GetByName(string name);

        IEnumerable<Artist> GetListArtistByPage(int pageNumber, int rowSize);
    }
}
