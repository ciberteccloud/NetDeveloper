using System;
using System.Linq;
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
                Session["pageNumber"] = 1;
            }
        }
        
        protected void FillData(int pageNumber)
        {            
            artistGridView.DataSource = _unit.Artists.GetListArtistByPage(pageNumber, 10).ToList();
            artistGridView.DataBind();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            var pageNumber = (int)Session["pageNumber"];
            FillData(pageNumber);
            Session["pageNumber"] = pageNumber + 1;
        }
    }
}