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
            
            rptBorrow.DataSource = Borrower.getBorrowerId(Transfer.UserName);
            rptBorrow.DataBind();
        }
        protected void rptBorrowerBooks_itembound(object sender, RepeaterItemEventArgs e)
        {
            /*
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptBorrowerBooks = (Repeater)item.FindControl("rptBorrowerBooks");
                rptBorrowerBooks.DataSource = Borrow.findBorrowDTO(name);
                rptBorrowerBooks.DataBind();
            }
             * */
        }

    }
}