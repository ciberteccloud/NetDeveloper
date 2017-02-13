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
    public partial class CreateArtist : System.Web.UI.Page
    {
        private UnitOfWork _unit;
        public CreateArtist()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var artist = new Artist { Name=txtName.Text };
            _unit.Artists.Add(artist);
            if(_unit.Complete()>0)
            {
                Response.Redirect("ListArtist.aspx");
            }
        }
    }
}