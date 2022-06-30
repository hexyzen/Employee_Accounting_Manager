using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineWorker.View.Admin
{
    public partial class Operators : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowOperators();

        }
        //Add this Method
        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }
        private void ShowOperators()
        {
            string Query = "select * from OperatorTbl";
            OperGV.DataSource = Con.getData(Query);
            OperGV.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(OperPassTb.Value == "" || SEmailTb.Value == "" || SNameTb.Value == "" || PhoneTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string Password = OperPassTb.Value;
                    string Phone = PhoneTb.Value;

                    string Query = "insert into OperatorTbl values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, SName, SEmail, Password, Phone);
                    Con.SetData(Query);
                    ShowOperators();
                    ErrMsg.InnerText = "Operator Added!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
        int Key = 0;
        protected void OperGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SNameTb.Value = OperGV.SelectedRow.Cells[2].Text;
            SEmailTb.Value = OperGV.SelectedRow.Cells[3].Text;
            OperPassTb.Value = OperGV.SelectedRow.Cells[4].Text;
            PhoneTb.Value = OperGV.SelectedRow.Cells[5].Text;
            if(SNameTb.Value == "")
            {
                Key = 0;
            }else
            {
                Key = Convert.ToInt32(OperGV.SelectedRow.Cells[1].Text);
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperPassTb.Value == "" || SEmailTb.Value == "" || SNameTb.Value == "" || PhoneTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string Password = OperPassTb.Value;
                    string Phone = PhoneTb.Value;

                    string Query = "update OperatorTbl set OperName = '{0}',OperEmail='{1}',OperPassword='{2}',OperPhone = '{3}' where OperId = {4}";
                    Query = string.Format(Query, SName, SEmail, Password, Phone, OperGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowOperators();
                    ErrMsg.InnerText = "Operator Updated!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperPassTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string SName = SNameTb.Value;
                   

                    string Query = "delete from  OperatorTbl where OperId = {0}";
                    Query = string.Format(Query,OperGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowOperators();
                    ErrMsg.InnerText = "Operator Deleted!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}