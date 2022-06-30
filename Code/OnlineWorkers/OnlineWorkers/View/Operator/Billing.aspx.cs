using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineWorker.View.Operator
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions Con;
        DataTable dt = new DataTable();
        int Operator = Login.OperKey;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowWorkers();

            if (!this.IsPostBack)
            {


                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                    new DataColumn("ID"),
                    new DataColumn("Worker"),
                    new DataColumn("Price"),
                    new DataColumn("Amount of hours"),
                    new DataColumn("Total")

                });
                ViewState["Bill"] = dt;
                this.BindGrid();

            }
        }

        private void InsertBill()
        {
            try
            {
                string Query = "insert into BillTbl values('{0}','{1}',{2})";
                Query = string.Format(Query, System.DateTime.Today, Operator, Amount);
                Con.SetData(Query);
                ErrMsg.InnerText = "Bill Inserted!";

            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
        }
        int GrdTotal;
        protected void BindGrid()
        {
            BillGV.DataSource = (DataTable)ViewState["Bill"];
            BillGV.DataBind();
        }
        public static int Amount;
        //Add this Method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        private void ShowWorkers()
        {
            string Query = "select WorkerId as Id, WorkerName as Name, WorkerSeat as Seat, WorkerPrice as Price from WorkerTbl";
            WorkerGV.DataSource = Con.getData(Query);
            WorkerGV.DataBind();
        }
        int Key = 0;
        protected void WorkerGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkerNameTb.Value = WorkerGV.SelectedRow.Cells[2].Text;
            WorkerPriceTb.Value = WorkerGV.SelectedRow.Cells[4].Text;
            if (WorkerNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(WorkerGV.SelectedRow.Cells[1].Text);
            }
        }

        // private void UpdateStock()
        //{
        //    int newQty;
        //    newQty = Convert.ToInt32(WorkerQtyTb.Value);
        //    string Query = "update WorkerTbl set WorkerQty = '{0}' where WorkerId = {1}";
        //    Query = string.Format(Query, newQty,WorkerGV.SelectedRow.Cells[1].Text);
        //    Con.SetData(Query);
        //    ShowWorkers();
        //    ErrMsg.InnerText = "Quantity Updated!";
        //}

        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkerNameTb.Value == "" || WorkerPriceTb.Value == "" || WorkerQtyTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";
                }
                else
                {

                    int total = Convert.ToInt32(WorkerQtyTb.Value) * Convert.ToInt32(WorkerPriceTb.Value);

                    DataTable dt = (DataTable)ViewState["Bill"];
                    dt.Rows.Add(BillGV.Rows.Count + 1,
                        WorkerNameTb.Value.Trim(),
                        WorkerPriceTb.Value.Trim(),
                        WorkerQtyTb.Value.Trim(),
                        total
                        );

                    ViewState["Bill"] = dt;
                    this.BindGrid();


                    GrdTotal = 0;
                    for (int i = 0; i <= BillGV.Rows.Count - 1; i++)
                    {
                        GrdTotal = GrdTotal + Int32.Parse(BillGV.Rows[i].Cells[4].Text.ToString());
                    }
                    Amount = GrdTotal;
                    GrdTotTb.InnerHtml = "$" + GrdTotal;
                    WorkerNameTb.Value = string.Empty;
                    WorkerPriceTb.Value = string.Empty;



                }
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }

        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {

            try
            {
               
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Clear();
                ViewState["Bill"] = dt;
                this.BindGrid();
                ViewState["Bill"] = dt;
                this.BindGrid();


                GrdTotal = 0;
                for (int i = 0; i <= BillGV.Rows.Count - 1; i++)
                {
                    GrdTotal = GrdTotal + Int32.Parse(BillGV.Rows[i].Cells[4].Text.ToString());
                }
                Amount = GrdTotal;
                GrdTotTb.InnerHtml = "$" + GrdTotal;
                WorkerNameTb.Value = string.Empty;
                WorkerPriceTb.Value = string.Empty;
            }
            catch (Exception Ex)
            {

                ErrMsg.InnerText = Ex.Message;
            }
            ;
        }
    }
}