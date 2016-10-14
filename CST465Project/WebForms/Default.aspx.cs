using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465Project.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            uxEventOutput.Text = "OnInit<br />";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            uxEventOutput.Text = "OnLoad<br />";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            uxEventOutput.Text = "OnPreRender<br />";
        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(uxName.Text);
            sb.Append("<br />");
            sb.Append(uxPriority.SelectedValue);
            sb.Append("<br />");
            sb.Append(uxSubject.Text);
            sb.Append("<br />");
            sb.Append(uxDescription.Text);
            sb.Append("<br />");
            uxFormOutput.Text = sb.ToString();
        }
    }
}