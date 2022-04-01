using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using DMS.DBConnection;

namespace SME
{
    public class Paramater
    {
        public Connection Conn = new Connection(ConfigurationManager.AppSettings["conn"]);
        public DataTable Dt = new DataTable();

        public void FillDropDownParam(DropDownList ddl, string query)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("-- PILIH --", ""));
            if (query != "")
            {
                Conn.QueryString = query;
                Conn.ExecuteQuery();
                for (int i = 0; i < Conn.GetRowCount(); i++)
                    ddl.Items.Add(new ListItem(Conn.GetFieldValue(i, 1), Conn.GetFieldValue(i, 0)));
            }
        }

        public void FillDropDownBulan(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("-- PILIH --", ""));
            for (int i = 1; i <= 12; i++)
                ddl.Items.Add(new ListItem(DateTimeFormatInfo.CurrentInfo.GetMonthName(i), i.ToString()));
        }

        public void PopulateDataGrid(DataGrid dg, string query)
        {
            if (query != "")
            {
                Conn.QueryString = query;
                Conn.ExecuteQuery();
                Dt = Conn.GetDataTable().Copy();
                dg.DataSource = Dt;
                try
                {
                    dg.DataBind();
                }
                catch
                {
                    dg.CurrentPageIndex = 0;
                    dg.DataBind();
                }
            }
        }
    }
}