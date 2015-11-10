using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace URLShortener.WEB
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var code = Request.Params["code"];
            if (!string.IsNullOrEmpty(code))
            {
                var Helper = new URLShortener.BL.Helper();
                var url = Helper.GetUrl(code);
                if(!string.IsNullOrEmpty(url))
                {
                    Response.Redirect(url);
                } else
                {
                    InvalidLink();
                }
                
            } else
            {
                InvalidLink();
            }

        }

        private void InvalidLink()
        {
            Response.Write("The link is invalid.");
        }
    }
}