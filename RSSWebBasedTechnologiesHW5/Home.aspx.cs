using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
namespace RSSWebBasedTechnologiesHW5
{
    public partial class Home : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
            int y = 99;
        }
        private void Display()
        {
            string connectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("App_Data\\NewsDatabase.accdb"));
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = "Select NewsID,Title,ImageUrl from News order by PublishDate asc";
            OleDbDataAdapter odat = new OleDbDataAdapter(command);
            dt = new DataTable();
            odat.Fill(dt);
            NewsDataList.DataSource = dt;
            NewsDataList.DataBind();
            connection.Close();
        }

       

    }
}