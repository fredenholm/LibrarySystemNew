using LibrarySystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptAuthor.DataSource = Author.getAuthorByAid(Session["AuthorId"] as string);
            rptAuthor.DataBind();
        }
        protected void rptAuthorDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            
            if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptAuhtorDetails = (Repeater)item.FindControl("rptAuthorDetails");

            }
        }
        protected void rptBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}