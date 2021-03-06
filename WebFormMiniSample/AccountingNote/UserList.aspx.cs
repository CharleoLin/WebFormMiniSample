using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var cUser = AccountingNote.Auth.AuthManager.GetCurrenUser();

            this.GridView1.DataSource = AccountingNote.DBSource.AccountingManager.GetAccountingList(cUser.ID);
            this.GridView1.DataBind();
        }
    }
}