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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM.DataCompleteness
{
	/// <summary>
	/// Summary description for ControlAndMonitoring.
	/// </summary>
	public partial class ControlAndMonitoring : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn2"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				
			}
			//setTableItem();
		}

		private void setTableItem()
		{
			System.Web.UI.HtmlControls.HtmlTableRow tr;
			System.Web.UI.HtmlControls.HtmlTableCell td;
			System.Web.UI.HtmlControls.HtmlTableCell td2;
			System.Web.UI.WebControls.Label label;
			System.Web.UI.HtmlControls.HtmlInputRadioButton rdo;
			System.Web.UI.WebControls.Button btn;

			try
			{
				conn.QueryString = "SELECT * FROM VW_DCM_CHOOSE_DATA_CONTROL_MONITORING";
				conn.ExecuteQuery();
			}
			catch(Exception ex)
			{
				string a = ex.Message.ToString();
				//string b = ex.Message.ToString();
			}

			for(int i = 0; i < conn.GetRowCount(); i++)
			{	
				//set colom 1
				td = new HtmlTableCell();
				td.Attributes["class"] = "TDBGColor1";
				td.Attributes["width"] = "40px";
				rdo = new HtmlInputRadioButton();
				rdo.Name = "rdo";
				rdo.Value = conn.GetFieldValue(i,0).ToString();
				td.Controls.Add(rdo);

				//set colom 2
				td2 = new HtmlTableCell();
				td2.Attributes["class"] = "TDBGColorValue";
				label = new Label();
				label.Text = conn.GetFieldValue(i,1).ToString();
				td2.Controls.Add(label);

				//set row
				tr = new HtmlTableRow();
				tr.Controls.Add(td);
				tr.Controls.Add(td2);

				//set table
                TBL_MainTable.Controls.Add(tr);
			}

			//set row button
			tr = new HtmlTableRow();
			tr.Attributes["class"] = "TDBGColor2";
			td = new HtmlTableCell();
			td.Align = "center";
			td.Attributes["colSpan"] = "2";
			btn = new Button();
			btn.Attributes["class"] = "button1";
			btn.Text = "	View	";
			btn.Click += new EventHandler(btn_Click);
			td.Controls.Add(btn);
			tr.Controls.Add(td);

			TBL_MainTable.Controls.Add(tr);
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
	
		private void btn_Click(object sender, EventArgs e)
		{
			CheckingClicked(this);
		}

		private void CheckingClicked(Control Page)
		{
			foreach(Control ctrl in Page.Controls)
			{
				if(ctrl is HtmlInputRadioButton)
				{
					HtmlInputRadioButton ctrlfix = (HtmlInputRadioButton)ctrl;
					if(ctrlfix.Checked)
					{
						try
						{
							conn.QueryString = "SELECT * FROM VW_DCM_CHOOSE_DATA_CONTROL_MONITORING";
							conn.ExecuteQuery();

							string URL = conn.GetFieldValue("URL").ToString();
							Response.Redirect(URL,true);
						}
						catch(Exception ex)
						{
							string a = ex.Message.ToString();
							//string b = "Test";
						}
					}
				}
				else
				{
					if(ctrl.Controls.Count > 0)
					{
						CheckingClicked(ctrl);
					}
				}
			}
		}

		private void VIEW_REPORT_Click(object sender, System.EventArgs e)
		{
		
		}

	}
}
