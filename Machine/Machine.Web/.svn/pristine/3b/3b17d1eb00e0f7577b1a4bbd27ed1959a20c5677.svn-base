using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using Machine.Web;

namespace Machine.Web.Admin
{
    public partial class ManageChart : AdminBasePage
    {
        string xfile;
        protected void Page_Load(object sender, EventArgs e)
        {
            xfile = Server.MapPath("~/App_Data/chart.xml");
            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {
            if (!File.Exists(xfile))
            {
                XmlTextWriter xw = new XmlTextWriter(xfile, null);
                xw.WriteStartDocument();
                xw.WriteStartElement("Graphs");
                xw.WriteEndElement();
                xw.Close();

                XDocument doc = XDocument.Load(xfile);
                doc.Element("Graphs").Add(new XElement("Graph", new XElement("Id", "1"),
                                                                new XElement("Name", "Avg Waiting Time"),
                                                                new XElement("P1", "0"),
                                                                new XElement("P2", "45"),
                                                                new XElement("P3", "90"),
                                                                new XElement("P4", "145")),
                                                                new XElement("Graph", new XElement("Id", "2"),
                                                                new XElement("Name", "Avg Transaction Time"),
                                                                new XElement("P1", "0"),
                                                                new XElement("P2", "40"),
                                                                new XElement("P3", "75"),
                                                                new XElement("P4", "100")),
                                                                new XElement("Graph", new XElement("Id", "3"),
                                                                new XElement("Name", "Open Counter"),
                                                                new XElement("P1", "0"),
                                                                new XElement("P2", "40"),
                                                                new XElement("P3", "75"),
                                                                new XElement("P4", "100")));

                doc.Save(xfile);
            }            
            
            XDocument xdoc = XDocument.Load(xfile);
            var chts = (from c in xdoc.Descendants("Graphs").Descendants("Graph")
                        select new Machine.Web.App_Code.chart(Convert.ToInt32(c.Element("Id").Value), c.Element("Name").Value, c.Element("P1").Value,
                        c.Element("P2").Value, c.Element("P3").Value, c.Element("P4").Value)).ToList();

            gvChart.DataSource = chts;
            gvChart.DataBind();
        }

        protected void gvChart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChartUpdate")
            {
                int RowId = Convert.ToInt32(e.CommandArgument);
                int Id = Convert.ToInt32(gvChart.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value);

                XDocument xdoc = XDocument.Load(xfile);
                XElement el = (from c in xdoc.Descendants("Graphs").Descendants("Graph")
                               where ((int)c.Element("Id")).Equals(Id)
                               select c).FirstOrDefault();

                el.SetElementValue("P1", ((TextBox)gvChart.Rows[RowId].FindControl("tbP1")).Text);
                el.SetElementValue("P2", ((TextBox)gvChart.Rows[RowId].FindControl("tbP2")).Text);
                el.SetElementValue("P3", ((TextBox)gvChart.Rows[RowId].FindControl("tbP3")).Text);
                el.SetElementValue("P4", ((TextBox)gvChart.Rows[RowId].FindControl("tbP4")).Text);
                xdoc.Save(xfile);

                FillGrid();
            }
        }
    }
}