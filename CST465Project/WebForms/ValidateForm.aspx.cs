using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465Project.WebForms
{
    public partial class ValidateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder queryString = new StringBuilder();

            queryString.Append("?name=");
            queryString.Append(uxName.Value);
            queryString.Append("&favoritecolor=");
            queryString.Append(uxFavoriteColor.Value);
            queryString.Append("&city=");
            queryString.Append(uxCity.Value);

            Response.Redirect("ValidatedFormOutput.aspx" + queryString);
        }
    }
}