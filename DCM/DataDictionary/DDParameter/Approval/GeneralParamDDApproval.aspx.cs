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

namespace SME.DCM.DataDictionary.DDParameter.Approval
{
	/// <summary>
	/// Summary description for GeneralParamDDApproval.
	/// </summary>
	public partial class GeneralParamDDApproval : System.Web.UI.Page
	{	
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Connection conn = new Connection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			int divider = 0, counter = 0, column = 0;
			conn.QueryString = "SELECT PARAMNAME,PARAMLINK,MODULEID FROM RFPARAMETERALL " +
				"WHERE ISMAKER='0' AND PARAMTYPE = 'DATDIC' " +
				"ORDER BY PARAMNAME";
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
					
				string navURL = conn.GetFieldValue(i,1);

				HyperLink link = new HyperLink();
				//link.Text = link_proj + conn.GetFieldValue(i,0);
				link.Text = conn.GetFieldValue(i,0);
				link.NavigateUrl = navURL;
				
				Table2.Rows[counter].Cells.Add(new TableCell());
				if (i % 2 == 1)
					Table2.Rows[counter].Cells[column].CssClass = "TblAlternating";
				Table2.Rows[counter].Cells[column].Controls.Add(link);
								
				counter++;
			}
			conn.ClearData();
			
			if (!IsPostBack)
			{
				SetModuleName();
			}
		}

		private void SetModuleName()
		{

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
