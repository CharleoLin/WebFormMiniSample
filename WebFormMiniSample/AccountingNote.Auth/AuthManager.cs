using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using AccountingNote.DBSource;

namespace AccountingNote.Auth
{
    public class AuthManager
    {
        public static bool IsLogined()
        {
            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        public static UserInfoModel GetCurrenUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);

            if (dr == null)
                HttpContext.Current.Session["UserLoginInfo"] = null;
            return null;

            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();

            return model;
        }

        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
        }

        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            errorMsg = "Account / PWD is required. ";
            return false;

            var dr = UserInfoManager.GetUserInfoByAccount(account);

            if(dr == null)
            {
                errorMsg = $"Account {account} doesn't exists. ";
                return false;
            }

            if (string.Compare(dr["Account"].ToString(), account, true) == 0 &&
               string.Compare(dr["PWD"].ToString(), pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString();
                
                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "Login fail. Please check Account / PWD. ";
                return false;
            }
        }

        
    }
}
