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
using System.Configuration;

namespace CuBES_Maintenance.Parameter
{
	/// <summary>
	/// Summary description for JiwaServiceParam.
	/// </summary>
	public partial class JiwaServiceParam : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				if(Request.QueryString["mc"] == "J0601")
				{
					LBL_PARAM_TITLE.Text = "PARAMETER MAKER";
					LBL_PARAM.Text = "General Parameter - Maker";
					conn.QueryString = "SELECT PARAMNAME,PARAMLINK,MODULEID FROM RFPARAMETERALL WHERE ISMAKER='1' AND PG_ID='10' AND MODULEID = '01' ORDER BY PARAMID";
					ViewData(conn.QueryString);
				}
				else if(Request.QueryString["mc"] == "J0602")
				{
					LBL_PARAM_TITLE.Text = "PARAMETER APPROVAL";
					LBL_PARAM.Text = "General Parameter - Approval";
					conn.QueryString = "SELECT PARAMNAME,PARAMLINK,MODULEID FROM RFPARAMETERALL WHERE ISMAKER='0' AND PG_ID='10' AND MODULEID = '01' ORDER BY PARAMID";
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
				TBL_CONTENT.Rows.Add(new TableRow());

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
			
				TBL_CONTENT.Rows[counter].Cells.Add(new TableCell());
				if (i % 2 == 1)
					TBL_CONTENT.Rows[counter].Cells[column].CssClass = "TblAlternating";
				TBL_CONTENT.Rows[counter].Cells[column].Controls.Add(link);
							
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
