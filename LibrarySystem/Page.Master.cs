using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.BL;

namespace LibrarySystem
{
    public partial class Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getBooks.ServerClick += new EventHandler(getBooks_click);
            getBookDetails.ServerClick += new EventHandler(getBookDetails_click);
            getAuthorDetails.ServerClick += new EventHandler(getAuthorDetails_click);
        }

        private void getBooks_click(object sender, EventArgs e)
        {
           // BL.Transfer.AuthorId = txtAuthorId.Text;
            Session["AuthorId"] = txtAuthorId.Text;
        }
        private void getBookDetails_click(object sender, EventArgs e)
        {
            Session["BookDetails"] = txtBookTitle.Text;
        }
        private void getAuthorDetails_click(object sender, EventArgs e)
        {
            Session["AuthorDetails"] = txtAuthorTitle.Text;
        }

        protected void login1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Webform6.aspx");
        }

        //protected void getBooksBtn_Click(object sender, EventArgs e)
        //{
        //    BL.Transfer.AuthorId = txtAuthorId.Text;
        //    Response.Redirect("WebForm2.aspx");
        //}


    }
}