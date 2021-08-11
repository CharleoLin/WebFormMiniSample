using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControls
{
    public partial class usPager : System.Web.UI.UserControl
    {
        /// <summary>頁面url</summary>
        public string Url { get; set; }
        /// <summary>總筆數</summary>
        public int TotalSize { get; set; }
        /// <summary>頁面單數</summary>
        public int PagaSize { get; set; }
        /// <summary>目前頁數</summary>
        public int CurrentPage { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int totalPage = this.GetTotalPages();

            this.ltPager.Text = $"共{this.TotalSize}筆，共{totalPage}頁，目前在第{this.GetCrrentPage()}頁<br/>";

            for (var i = 1; i <= totalPage; i++)
            {
                this.ltPager.Text += $"<a herf='AccountingList.aspx?page={i}' > {i}</a>&nbsp;";
            }
        }

        private int GetCrrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;
            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private int GetTotalPages(DataTable dt)
        {
            int pagers = dt.Rows.Count / 10;

            if ((dt.Rows.Count % 10) > 0)
                pagers += 1;
            return pagers;
        }
    }
}