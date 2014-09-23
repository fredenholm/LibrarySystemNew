using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.BL;
using LibrarySystem.DTO;

namespace LibrarySystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptAuthors.DataSource = Author.getAll();
                rptAuthors.DataBind();

            }
        }

        protected void AuthorFNBtn_Command(object sender, CommandEventArgs e)
        {
            Session["AuthorId"] = e.CommandArgument;
            Response.Redirect("Books.aspx");
        }

        protected void PreviousBtn_Click(object sender, EventArgs e)
        {
            rptAuthors.DataSource = Author.getAllbyCount("previous");
            rptAuthors.DataBind();
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            rptAuthors.DataSource = Author.getAllbyCount("next");
            rptAuthors.DataBind();
        }

    }
}