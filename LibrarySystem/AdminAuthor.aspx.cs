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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptAdminAuthor.DataSource = Author.getAllBy20("");
                rptAdminAuthor.DataBind();

            }
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            Session["AuthorId"] = e.CommandArgument;
            Response.Redirect("EditAdminAuthor.aspx");
        }
        protected void PreviousBtn_Click(object sender, EventArgs e)
        {
            disablePrevBtn();
            rptAdminAuthor.DataSource = Author.getAllBy20("previous");
            rptAdminAuthor.DataBind();
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            disablePrevBtn();
            rptAdminAuthor.DataSource = Author.getAllBy20("next");
            rptAdminAuthor.DataBind();
        }
        public void disablePrevBtn()
        {
            if (BL.Author.disableBtn == "previous")
            {
                PreviousBtn.Enabled = false;
            }
            else if (BL.Author.disableBtn == "next")
            {
                NextBtn.Enabled = false;
            }
            else if (BL.Author.disableBtn == "")
            {
                NextBtn.Enabled = true;
                PreviousBtn.Enabled = true;
            }
        }

    }
}