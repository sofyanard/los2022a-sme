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
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.AccountPlanning.Parameter
{
	/// <summary>
	/// Summary description for AccountPlanningParam.
	/// </summary>
	public partial class AccountPlanningParam : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				if(Request.QueryString["mc"].ToString() == "AP0101")
				{
					LBL_PARAM.Text = "PARAMETER MAKER";
					conn.QueryString = "SELECT PARAMNAME,PARAMLINK,MODULEID FROM RFPARAMETERALL WHERE ISMAKER='1' AND PG_ID='5' ORDER BY PARAMID";
					ViewData(conn.QueryString);
				}
				else if(Request.QueryString["mc"].ToString() == "AP0102")
				{
					LBL_PARAM.Text = "PARAMETER APPROVAL";
					conn.QueryString = "SELECT PARAMNAME,PARAMLINK,MODULEID FROM RFPARAMETERALL WHERE ISMAKER='0' AND PG_ID='5' ORDER BY PARAMID";
					ViewData(conn.QueryString);
				}
			}
		}

		private void ViewData(string strconn)
		{
			int divider = 0, counter = 0, column = 0;
			
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

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
					
				string navURL = conn.GetFieldValue(i,1);
				
				HyperLink link = new HyperLink();
				link.Text = conn.GetFieldValue(i,0);
				link.NavigateUrl = navURL;
				
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
