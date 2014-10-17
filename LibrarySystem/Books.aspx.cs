using LibrarySystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                rptBooks.DataSource = Book.getAll(Session["AuthorId"] as string);
                rptBooks.DataBind();
            }
        }

        protected void BookDetails_Command(object sender, CommandEventArgs e)
        {
            Session["ISBN"] = e.CommandArgument;
            Response.Redirect("BookDetails.aspx");
        }
    }
}