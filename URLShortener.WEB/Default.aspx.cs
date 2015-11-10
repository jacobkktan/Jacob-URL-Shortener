using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace URLShortener.WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            var Helper = new URLShortener.BL.Helper();
            var urlToShorten = txtUrl.Text;
            if(!Uri.IsWellFormedUriString(urlToShorten,UriKind.Absolute))
            {
                lblShortUrl.ForeColor = System.Drawing.Color.Red;
                lblShortUrl.Text = "You have provided an invalid URL";
                return;
            }              
            var code = Helper.InsertRecord(txtUrl.Text);
            var url = string.Format("{0}/v/{1}",Request.Url.GetLeftPart(UriPartial.Authority), code);
            lblShortUrl.ForeColor = System.Drawing.Color.Black;
            lblShortUrl.Text = string.Format("<a href='{0}' target='_blank'>{0}</a>", url);
        }


    }
}