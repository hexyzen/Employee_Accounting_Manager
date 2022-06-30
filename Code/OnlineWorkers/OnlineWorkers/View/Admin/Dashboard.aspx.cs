using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineWorker.View.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Con = new Models.Functions();
            if (!IsPostBack)
            {
            GetWorkers();
            GetSeats();
            SumSell();
            GetOperators();
            GetOperator();
            }
        }
        private void GetOperator()
        {
            string Query = "Select * from OperatorTbl";
            OperCb.DataTextField = Con.getData(Query).Columns["OperName"].ToString();
            OperCb.DataValueField = Con.getData(Query).Columns["OperId"].ToString();
            OperCb.DataSource = Con.getData(Query);
            OperCb.DataBind();
        }
        private void GetWorkers()
        {
            string Query = "Select Count(*) from WorkerTbl";
            WorkerNumTb.InnerText = Con.getData(Query).Rows[0][0].ToString();
            WorkerNumTb.DataBind();
        }

        private void GetSeats()
        {
            string Query = "Select Count(*) from SeatTbl";
            SeatNumTb.InnerText = Con.getData(Query).Rows[0][0].ToString();
            SeatNumTb.DataBind();
        }
        private void GetOperators()
        {
            string Query = "Select Count(*) from OperatorTbl";
            OperNumTb.InnerText = Con.getData(Query).Rows[0][0].ToString();
            OperNumTb.DataBind();
        }
        private void SumSell()
        {
            string Query = "Select Sum(Amount) from BillTbl";
            FinanceTb.InnerText ="$  " + Con.getData(Query).Rows[0][0].ToString();
            FinanceTb.DataBind();
        }

        private void SumPayByOperator()
        {
            string Query = "Select Sum(Amount) from BillTbl where Operator = " + OperCb.SelectedValue.ToString() + " ";
            TotalTb.InnerText = "$  " + Con.getData(Query).Rows[0][0].ToString();
            TotalTb.DataBind();
            Con.getData(Query);

        }

        private void NumPayByOperator()
        {
            string Query = "Select Count(Amount) from BillTbl where Operator = " + OperCb.SelectedValue.ToString()+ " ";
            AmountSeatTb.InnerText = Con.getData(Query).Rows[0][0].ToString();
            AmountSeatTb.DataBind();
            Con.getData(Query);
            GetOperator();
        }

        protected void MyListDataBound(object sender, EventArgs e)
        {
            OperCb.Items.Insert(0, new ListItem("- Select -", ""));
        }

        protected void OperCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SumPayByOperator();
            NumPayByOperator();


        }
    }
}