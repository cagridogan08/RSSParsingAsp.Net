using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Data.OleDb;
namespace RSSWebBasedTechnologiesHW5
{
    public partial class RSSparsing : System.Web.UI.Page
    {
        List<News> sporhaberler = new List<News>();
        List<News> magazinHaberler = new List<News>();
        List<News> ekonomiHaberler = new List<News>();
        string sporLink = "https://www.hurriyet.com.tr/rss/spor";
        string magazinLink = "https://www.hurriyet.com.tr/rss/magazin";
        string ekonomiLink = "https://www.hurriyet.com.tr/rss/ekonomi";
        protected void Page_Load(object sender, EventArgs e)
        {
            sporhaberler=ParseRSS(sporLink);
            magazinHaberler=ParseRSS(magazinLink);
            ekonomiHaberler = ParseRSS(ekonomiLink);
            WriteDataToDatabase(sporhaberler);
            WriteDataToDatabase(magazinHaberler);
            WriteDataToDatabase(ekonomiHaberler);
            Response.Redirect("Home.aspx");
        }

        private List<News> ParseRSS(string rssLink)
        {
            List<News> haberler = new List<News>();
            
            XmlReader reader = XmlReader.Create(rssLink);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            
            foreach (var item in feed.Items)
            {
                News haber = new News(item.Title.Text, item.Summary.Text, item.Categories.FirstOrDefault().Name.ToString(),
                    "Hurriyet", item.PublishDate.DateTime.ToString(), item.Links[1].Uri.AbsoluteUri.ToString());
                haberler.Add(haber);
                int x = 55;

            }
            return haberler;
        }
        private void WriteDataToDatabase(List<News> haberler)
        {
            string connectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("App_Data\\NewsDatabase.accdb"));
            for (int i = 0; i < haberler.Count; i++)
            {
                haberler[i].WriteDatabase(connectionString);
            }
        }
    }
}