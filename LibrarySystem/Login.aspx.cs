using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibrarySystem.BL;

namespace LibrarySystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (UserInput.Text.Length > 0)
            {
                Transfer.UserName = UserInput.Text;
                Response.Redirect("Borrowers.aspx");
            }
            else
            {
                UserInput.BackColor = System.Drawing.Color.Red;
            }
            if (PasswordInput.Text.Length <= 0)
            {
                PasswordInput.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {

        }

        protected void UserInput_TextChanged(object sender, EventArgs e)
        {
            UserInput.BackColor = System.Drawing.Color.White;
        }

        protected void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            PasswordInput.BackColor = System.Drawing.Color.White;
        }
    }
}