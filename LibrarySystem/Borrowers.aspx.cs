﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.BL;

namespace LibrarySystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptBorrow.DataSource = Borrower.getBorrowerId(Usr.getUserId(Transfer.UserName));
            rptBorrow.DataBind();
        }

        protected void RenewBook_Click(object sender, EventArgs e)
        {

        }

        protected void rptBorrow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptBorrowBooks = (Repeater)item.FindControl("rptBorrowBooks");
                rptBorrowBooks.DataSource = Borrow.getBorrowerBooks(Usr.getUserId(Transfer.UserName));
                rptBorrowBooks.DataBind();
            }
        }

        protected void rptBorrowBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptBorrowBooksStatus = (Repeater)item.FindControl("rptBorrowBooksStatus");
                rptBorrowBooksStatus.DataSource = Borrow.getBorrowStatus(Usr.getUserId(Transfer.UserName));
                rptBorrowBooksStatus.DataBind();
            }
        }
    }
}