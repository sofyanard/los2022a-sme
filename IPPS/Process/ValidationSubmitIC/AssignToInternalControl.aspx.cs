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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using DMS.BlackList;

namespace SME.IPPS.Process.ValidationSubmitIC
{
	/// <summary>
	/// Summary description for AssignToInternalControl.
	/// </summary>
	public partial class AssignToInternalControl : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		string lastPerson="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			ViewMenu();
			if (!IsPostBack)
			{
				fillField();

				//ambil last_updatePerson
				conn.QueryString="SELECT LAST_UPDATE_BY FROM IPPS_APPLICATION WHERE IPPS_REGNO='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				lastPerson = conn.GetFieldValue("LAST_UPDATE_BY");
				
			}
		}

		private void fillField()
		{
			TXT_reference.Text = Request.QueryString["regno"];
			TXT_request_date.Text = Request.QueryString["initdate"];
			TXT_unit.Text = Request.QueryString["unit"];
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] +  "&tc=" + Request.QueryString["tc"] ;
						else	
							strtemp = "regno=" + Request.QueryString["regno"] +  "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		
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

		protected void BTN_submit_internal_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString= " EXEC IPPS_UPDATE_TRACK '" + Request.QueryString["regno"] + "', '"
					+ "PP9.0" + "', '" + Session["UserID"].ToString() + "', ''";
				conn.ExecuteQuery();

				conn.QueryString="UPDATE IPPS_APPLICATION SET STATUS='0' WHERE IPPS_REGNO='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void btn_back_to_update_Click(object sender, System.EventArgs e)
		{
//			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + Request.QueryString["regno"] + "&nextuser=" + ddl_reassign.SelectedValue + "&tcnext=PP1.1&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
//			
			
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../InitiationValidation/AcqInfo.aspx?regno=" + Request.QueryString["regno"] + "&nextuser=" + lastPerson + "&tcnext=PP7.0&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");

		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = TXT_TEMP.Text;
				Response.Redirect("ValidationList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]
					+"&msg=" + msg);
			}
		}
	}
}
