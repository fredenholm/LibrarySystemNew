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
                    rptAuthors.DataSource = Author.getAuthorByName(Session["Author"] as string);
                    rptAuthors.DataBind();
            }
        }

        protected void AuthorBooks_Command(object sender, CommandEventArgs e)
        {
            Session["AuthorId"] = e.CommandArgument;
            Response.Redirect("AuthorDetails.aspx");
        }

        protected void PreviousBtn_Click(object sender, EventArgs e)
        {
            rptAuthors.DataSource = Author.getAllBy20("previous");
            rptAuthors.DataBind();
            disablePrevBtn();
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            rptAuthors.DataSource = Author.getAllBy20("next");
            rptAuthors.DataBind();
            disablePrevBtn();
        }
        public void disablePrevBtn()
        {
            if(BL.Author.disableBtn == "previous")
            {
                PreviousBtn.Enabled = false;
            }
            else if(BL.Author.disableBtn == "next")
            {
                NextBtn.Enabled = false;
            }
            else if(BL.Author.disableBtn == "")
            {
                NextBtn.Enabled = true;
                PreviousBtn.Enabled = true;
            }
        }
    }
}