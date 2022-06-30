using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineWorker.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }
        public static string OperName="";
        public static int OperKey;
        //Add this Method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        Models.Functions Con;
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
          
            if (AdminRadio.Checked)
            {
                if(EmailId.Value == "Admin@gmail.com" && UserPasswordTb.Value == "Admin")
                {
                    Response.Redirect("Admin/Dashboard.aspx");
                }else
                {
                    InfoMsg.InnerText = "Invalid Admin!";
                }
            }else
            {
                string Query = "select OperId,OperName,OperEmail,OperPassword from OperatorTbl where OperEmail = '{0}' and OperPassword = '{1}'";
                Query = string.Format(Query, EmailId.Value, UserPasswordTb.Value);
                DataTable dt = Con.getData(Query);
                if(dt.Rows.Count == 0)
                {
                    InfoMsg.InnerText = "Invalid User!";

                }else
                {
                    OperName = EmailId.Value;
                    OperKey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Operator/Billing.aspx");
                }
            }
    
        }
    }
}