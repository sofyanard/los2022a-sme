using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace CuBES.NET.ParamMaintenance
{
	/// <summary>
	/// Summary description for GeneralParam.
	/// </summary>
	public partial class AreaParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			int divider = 0, counter = 0, column = 0;

			conn.QueryString = "SELECT PARAMNAME,PARAMLINK FROM RFPARAMETER WHERE ISMAKER='1' AND PG_ID='2' ORDER BY PARAMNAME";
			conn.ExecuteQuery();

			divider = conn.GetRowCount() / 3;
			for (int j = 0; j <= divider; j++)
				Table2.Rows.Add(new TableRow());

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				if (counter > divider)
				{
					counter = 0;
					if (column == 2)
						column = 0;
					else
						column++;
				}
			
				HyperLink link = new HyperLink();
				link.Text = conn.GetFieldValue(i,0);
				if (conn.GetFieldValue(i,1).IndexOf("?") < 0)
					link.NavigateUrl = conn.GetFieldValue(i,1) + "?mc=" + Request.QueryString["mc"];
				else
					link.NavigateUrl = conn.GetFieldValue(i,1) + "&mc=" + Request.QueryString["mc"];

				//link.NavigateUrl = conn.GetFieldValue(i,1);
					
				Table2.Rows[counter].Cells.Add(new TableCell());
				if (i % 2 == 1)
					Table2.Rows[counter].Cells[column].CssClass = "TblAlternating";
				Table2.Rows[counter].Cells[column].Controls.Add(link);

				counter++;
			}
			conn.ClearData();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
