using DataAccess;
using Models;
using System;
using System.Web.Services;
using WebForms.App_Code;

namespace WebForms.Site.ArtistWeb
{
    public partial class CreateArtist : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerifyUser();
                IsUserInRole("ADMIN");
            }
        }

        [WebMethod(EnableSession = true)]
        public static bool InsertArtist(string name)
        {
            var artist = new Artist { Name = name };
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                unit.Artists.Add(artist);
                return unit.Complete() > 0;
            }
        }
    }
}

