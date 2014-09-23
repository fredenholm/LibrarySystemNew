﻿using LibrarySystem.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptBooksDetails.DataSource = Book.getBookByTitle(Session["BookDetails"] as string);
            rptBooksDetails.DataBind();
        }
    }
}