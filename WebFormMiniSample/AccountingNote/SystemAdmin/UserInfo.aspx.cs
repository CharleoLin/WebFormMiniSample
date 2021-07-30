using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AccountingNote.DBSource;
using AccountingNote.Auth;

namespace AccountingNote.SystemAdimin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }
                var currentUser = AuthManager.GetCurrenUser();

                if (currentUser == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                this.ltAccount.Text = currentUser.Account;
                this.ltName.Text = currentUser.Name;
                this.ltEmail.Text = currentUser.Email;
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();
            Response.Redirect("/Login.aspx");
        }
    }
}