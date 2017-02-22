using System;
using WebForms.App_Code;

namespace WebForms.Site.ArtistWeb
{
    public partial class ListArtist : BasePage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerifyUser();
                IsUserInRole("ADMIN");
            }
        }
    }
}