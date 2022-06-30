using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineWorker.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConnString;

        public Functions()
        {          
            ConnString = @"Server=tcp:onlineworkersdbserver.database.windows.net,1433;Initial Catalog=WorkerAsppDb;Persist Security Info=False;User ID=hexyzen;Password=rk2003rk2003!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //DefaultConnection = "Data Source = tcp:workersaspdbdbserver.database.windows.net,1433; Initial Catalog = WorkersAspDb; User Id = hexyzen@workersaspdbdbserver; Password = rk2003rk2003!;";
            Con = new SqlConnection(ConnString); 
            cmd = new SqlCommand();
            cmd.Connection = Con;

            //
        }

        public DataTable getData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConnString);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int Cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }

    }
}