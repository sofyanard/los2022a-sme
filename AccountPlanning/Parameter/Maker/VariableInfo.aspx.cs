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

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for VariableInfo.
	/// </summary>
	public partial class VariableInfo : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		private string theForm, theObj, var_name="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			theForm = Request.QueryString["targetFormID"].Trim();
			theObj = Request.QueryString["targetObjectID"].Trim();
			
			setTableItem();
		}

		private void setTableItem()
		{
			System.Web.UI.HtmlControls.HtmlTableRow tr;
			System.Web.UI.HtmlControls.HtmlTableCell td;
			System.Web.UI.HtmlControls.HtmlTableCell td2;
			System.Web.UI.HtmlControls.HtmlTableCell td3;
			System.Web.UI.HtmlControls.HtmlTableCell td4;
			System.Web.UI.WebControls.Label label;
			System.Web.UI.HtmlControls.HtmlInputCheckBox chk;
			System.Web.UI.WebControls.Button btn;

			try
			{
				conn.QueryString = "SELECT VARIABLE_ID, VARIABLE_NM, CASE VARIABLE_LINKID WHEN '1' THEN 'UP_CPA' WHEN '2' THEN 'UP_FUNDING' WHEN '3' THEN 'UP_PAYROLL' WHEN '4' THEN 'UP_SUBSIDIARY' END VARIABLE_LINKID, VARIABLE_LINK FROM AP_RF_VARIABLE WHERE STATUS='1'";
				conn.ExecuteQuery();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
			}

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				//main TR
				tr = new HtmlTableRow();
				td = new HtmlTableCell();

				td.Attributes["class"] = "TDBGColor1";
				td.Attributes["width"] = "10%";
				
				//Main CheckBox
				chk = new HtmlInputCheckBox();
				chk.Name = "chk";
				chk.Value = conn.GetFieldValue(i,0).ToString();
				td.Controls.Add(chk);
				
				td2 = new HtmlTableCell();
				td2.Attributes["class"] = "TDBGColorValue";
				label = new Label();
				label.Text = conn.GetFieldValue(i,1).ToString();
				td2.Controls.Add(label);

				td3 = new HtmlTableCell();
				td3.Attributes["class"] = "TDBGColorValue";
				label = new Label();
				label.Text = conn.GetFieldValue(i,2).ToString();
				td3.Controls.Add(label);

				td4 = new HtmlTableCell();
				td4.Attributes["class"] = "TDBGColorValue";
				label = new Label();
				label.Text = conn.GetFieldValue(i,3).ToString();
				td4.Controls.Add(label);

				tr.Controls.Add(td);
				tr.Controls.Add(td2);
				tr.Controls.Add(td3);
				tr.Controls.Add(td4);

				TBL_MainTable.Controls.Add(tr);
			}

			/*set TR and button below*/
			tr = new HtmlTableRow();
			tr.Attributes["class"] = "TDBGColor2";
			td = new HtmlTableCell();
			td.Align = "center";
			td.Attributes["colspan"] = "4";
			btn = new Button();
			btn.Attributes["class"] = "button1";
			btn.Text = "    INSERT    ";
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
			foreach (Control ctrl in Page.Controls)
			{
				if(ctrl is HtmlInputCheckBox)
				{
					HtmlInputCheckBox ctrlfix = (HtmlInputCheckBox)ctrl;
					if(ctrlfix.Checked)
					{
						try
						{
							//conn.QueryString = "SELECT BM_VARIABLE_ID, BM_VARIABLE_NM FROM AP_RF_BENCHMARK WHERE BM_VARIABLE_ID='" + ctrlfix.Value.ToString() + "' AND BM_STATUS='1'";
							conn.QueryString = "SELECT VARIABLE_LINK FROM AP_RF_VARIABLE WHERE VARIABLE_ID='" + ctrlfix.Value.ToString() + "' AND STATUS='1'";
							conn.ExecuteQuery();

							var_name += (conn.GetFieldValue("VARIABLE_LINK") + "; ");
						}
						catch(Exception e)
						{
							string a = e.Message.ToString();
						}
					}
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						CheckingClicked(ctrl);
					}
				}
			}

			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj + ".value='" + var_name + "'; " +
				"window.opener.document." + theForm + ".submit(); window.close();</script>");
		}
	}
}
