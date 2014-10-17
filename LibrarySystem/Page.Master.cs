﻿using System;
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

        }

        protected void getBooks_Click(object sender, EventArgs e)
        {
            Session["AuthorId"] = txtAuthorId.Text;
            Response.Redirect("Books.aspx");
        }

        protected void getBookDetails_Click(object sender, EventArgs e)
        {
            Session["BookDetails"] = txtBookTitle.Text;
            Response.Redirect("BookDetails.aspx");
        }

        protected void getAuthorDetails_Click(object sender, EventArgs e)
        {
            Session["Author"] = txtAuthorTitle.Text;
            Response.Redirect("Author.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void getAuthorLink_Click(object sender, EventArgs e)
        {
            Session["Author"] = "";
        }
    }
}