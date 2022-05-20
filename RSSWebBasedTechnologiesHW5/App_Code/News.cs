using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel.Syndication;
using System.Data.OleDb;
namespace RSSWebBasedTechnologiesHW5
{
    public class News
    {
        //public int NewsID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public string ImageUrl { get; set; }
        private string connectionString;
        public News(string t,string d,string c,string a,string pd,string url)
        {
            this.Title= t;
            this.Description= d;
            this.Category= c;
            this.Author= a;
            this.PublishDate= pd;
            this.ImageUrl = url;
        }

        public void WriteDatabase(string connectionString)
        {
            this.connectionString= connectionString;
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
            List<String> whereTitle = GetAllNews();
            if (whereTitle.Contains(this.Title)) { }
            else
            {
                string insertCommand = "insert into News (Title,Description,Category,Author,PublishDate,ImageUrl) values(@title,@description,@category,@author,@pdate,@url)";
                //string whereCommand = "(Select Title from News where Title =@title);";
                command.CommandText = insertCommand;
                command.Parameters.AddWithValue("@title", this.Title);
                command.Parameters.AddWithValue("@description", this.Description);
                command.Parameters.AddWithValue("@category", this.Category);
                command.Parameters.AddWithValue("@author", this.Author);
                command.Parameters.AddWithValue("@pdate", this.PublishDate);
                command.Parameters.AddWithValue("@url", this.ImageUrl);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        private List<String> GetAllNews()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = "Select * from News";
            OleDbDataReader reader = command.ExecuteReader();
            List<String> titles = new List<String>();
            while (reader.Read())
            {
                string title = reader.GetString(1);
                titles.Add(title);
            }
            connection.Close();
            return titles;
        }
    }
}