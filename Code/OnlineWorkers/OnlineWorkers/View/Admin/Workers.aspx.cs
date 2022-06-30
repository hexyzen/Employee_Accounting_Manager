using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineWorker.View.Admin
{
    public partial class Workers : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            GetSeats();
            ShowWorkers();
        }
        private void GetSeats()
        {
            string Query = "Select * from SeatTbl";
            SeatCb.DataTextField = Con.getData(Query).Columns["SeatName"].ToString();
            SeatCb.DataValueField = Con.getData(Query).Columns["SeatId"].ToString();
            SeatCb.DataSource = Con.getData(Query);
            SeatCb.DataBind();
        }
        //Add this Method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        private void ShowWorkers()
        {
            string Query = "select * from WorkerTbl";
            WorkerGV.DataSource = Con.getData(Query);
            WorkerGV.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkerNameTb.Value == "" || SeatCb.DataTextField == "" || PriceTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string WorkerName = WorkerNameTb.Value;
                    string WorkerSeat = SeatCb.SelectedValue;
                    string WorkerPrice = PriceTb.Value;
                    string DDate = DOBDate.Value;

                    string Query = "insert into WorkerTbl values('{0}',{1},{2},'{3}')";
                    Query = string.Format(Query, WorkerName, WorkerSeat, WorkerPrice, DDate);
                    Con.SetData(Query);
                    ShowWorkers();
                    ErrMsg.InnerText = "Worker Added!";
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
                if (WorkerNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                  
                    string Query = "delete from  WorkerTbl where WorkerId = {0}";
                    Query = string.Format(Query, WorkerGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowWorkers();
                    ErrMsg.InnerText = "Worker Deleted!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
        int Key = 0;
       

        protected void WorkerGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkerNameTb.Value = WorkerGV.SelectedRow.Cells[2].Text;
            SeatCb.SelectedValue = WorkerGV.SelectedRow.Cells[3].Text;
            PriceTb.Value = WorkerGV.SelectedRow.Cells[4].Text;
            DOBDate.Value = WorkerGV.SelectedRow.Cells[5].Text;
            if (WorkerNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(WorkerGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkerNameTb.Value == "" || SeatCb.DataTextField == "" || PriceTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {
                    string WorkerName = WorkerNameTb.Value;
                    string WorkerSeat = SeatCb.SelectedValue;
                    string Price = PriceTb.Value;
                    string EDate = DOBDate.Value;

                    string Query = "update WorkerTbl set WorkerName = '{0}',WorkerSeat={1},Workerprice={2},WorkerDOB = '{3}' where WorkerId = {4}";
                    Query = string.Format(Query, WorkerName, WorkerSeat, Price, EDate, WorkerGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowWorkers();
                    ErrMsg.InnerText = "Worker Updated!";
                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}