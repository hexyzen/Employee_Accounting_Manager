using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineWorker.View.Admin
{
    public partial class Seats : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowSeats();
        }
        //Add this Method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        private void ShowSeats()
        {
            string Query = "select * from SeatTbl";
            SeatGV.DataSource = Con.getData(Query);
            SeatGV.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SeatNameTb.Value == "" || SeatRemarkTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string CName = SeatNameTb.Value;
                    string CRem = SeatRemarkTb.Value;
                  

                    string Query = "insert into SeatTbl values('{0}','{1}')";
                    Query = string.Format(Query, CName, CRem);
                    Con.SetData(Query);
                    ShowSeats();
                    ErrMsg.InnerText = "Seat Added!";
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
                if (SeatNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string CName = SeatNameTb.Value;


                    string Query = "delete from  SeatTbl where SeatId = {0}";
                    Query = string.Format(Query, SeatGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowSeats();
                    ErrMsg.InnerText = "Seat Deleted!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
        int Key = 0;
        protected void SeatGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeatNameTb.Value = SeatGV.SelectedRow.Cells[2].Text;
            SeatRemarkTb.Value = SeatGV.SelectedRow.Cells[3].Text;
            
            if (SeatNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SeatGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SeatNameTb.Value == "" || SeatRemarkTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string CName = SeatNameTb.Value;
                    string CRem = SeatRemarkTb.Value;

                    string Query = "update SeatTbl set SeatName = '{0}',SeatDescription='{1}' where SeatId = {2}";
                    Query = string.Format(Query, CName, CRem, SeatGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowSeats();
                    ErrMsg.InnerText = "Seat Updated!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}