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
            rptAuthors.DataSource = Author.getAll();
            rptAuthors.DataBind();

            rptAuthors.ItemCommand += new RepeaterCommandEventHandler(rptAuthors_Click);
        }

        private void rptAuthors_Click(object source, RepeaterCommandEventArgs e)
        {
            Session["rptAuthorArg"] = e;
            
        }
    }
}