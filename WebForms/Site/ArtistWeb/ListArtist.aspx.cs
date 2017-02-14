using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.ArtistWeb
{
    public partial class ListArtist : System.Web.UI.Page
    {
        private UnitOfWork _unit;
        private int rowSize;
        public ListArtist()
        {
            rowSize = 10;
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            artistGridView.DataSource = GetData(1);
            artistGridView.DataBind();
        }

        protected IEnumerable<Artist> GetData(int pageNumber)
        {
            return _unit.Artists.GetListArtistByPage(pageNumber, rowSize).ToList();
        }

        protected void GetPage(object sender, EventArgs e)
        {

        }
    }
}