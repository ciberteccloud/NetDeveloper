using DataAccess;
using System;
using System.Linq;
using WebForms.App_Code;

namespace WebForms.Site.ArtistWeb
{
    public partial class ListArtist : BasePage
    {
        protected static UnitOfWork _unit;
        public ListArtist()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerifyUser();
                IsUserInRole("ADMIN");
                Session["pageNumber"] = 1;
            }
        }
              
    }
}