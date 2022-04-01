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

namespace SME.TargetCustomer
{
	/// <summary>
	/// Summary description for TargetCustomerInfo.
	/// </summary>
	public partial class TargetCustomerInfo : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();

				if (Request.QueryString["trg"] == "1")
				{
					TR_SAVE.Visible = true;
					TR_APRVBU.Visible = false;
					TR_APRVRISK.Visible = false;
				}
				else if (Request.QueryString["trg"] == "2")
				{
					TR_SAVE.Visible = false;
					TR_APRVBU.Visible = true;
					TR_APRVRISK.Visible = false;
				}
				else if (Request.QueryString["trg"] == "3")
				{
					TR_SAVE.Visible = false;
					TR_APRVBU.Visible = false;
					TR_APRVRISK.Visible = true;
				}
				else
				{
					TR_SAVE.Visible = false;
					TR_APRVBU.Visible = false;
					TR_APRVRISK.Visible = false;
				}
			}

			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "trgcuref="+Request.QueryString["trgcuref"]+"&tc="+Request.QueryString["tc"]+"&trg="+Request.QueryString["trg"];
						else	strtemp = "trgcuref="+Request.QueryString["trgcuref"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&trg="+Request.QueryString["trg"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT ACQINFO FROM TRG_CUSTOMER WHERE TRG_CU_REF = '" + Request.QueryString["trgcuref"] + "'";
			conn.ExecuteQuery();
			TXT_ACQINFO.Text = conn.GetFieldValue("ACQINFO");
		}

		private void SaveData()
		{
			try
			{
				conn.QueryString = "exec TARGETCUST_SAVEINFORMATION '" + 
					Request.QueryString["trgcuref"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					TXT_ACQINFO.Text.Trim() + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				return;
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			SaveData();
		}

		protected void BTN_ACQINFOBU_Click(object sender, System.EventArgs e)
		{
			if (TXT_ACQINFO.Text.Trim().Length <= 1) 
			{
				GlobalTools.popMessage(this, "Informasi tidak boleh kosong!");
				return;
			}

			try
			{
				conn.QueryString = "exec TARGETCUST_ACQINFO 'bu', '" +
					Request.QueryString["trgcuref"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					TXT_ACQINFO.Text.Trim() + "'";
				conn.ExecuteQuery();
				string acquireInfoFrom_NAME = conn.GetFieldValue("ACQINFONAME");

				if (acquireInfoFrom_NAME != "") 
				{
					string msg = "";
					msg = "Application acquire information from " + acquireInfoFrom_NAME + " !";
					Response.Redirect("TargetCustomerAprvList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&trg=" + Request.QueryString["trg"]+"&msg="+msg);
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}

		protected void BTN_ACQINFORISK_Click(object sender, System.EventArgs e)
		{
			if (TXT_ACQINFO.Text.Trim().Length <= 1) 
			{
				GlobalTools.popMessage(this, "Informasi tidak boleh kosong!");
				return;
			}

			try
			{
				conn.QueryString = "exec TARGETCUST_ACQINFO 'risk', '" +
					Request.QueryString["trgcuref"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					TXT_ACQINFO.Text.Trim() + "'";
				conn.ExecuteQuery();
				string acquireInfoFrom_NAME = conn.GetFieldValue("ACQINFONAME");

				if (acquireInfoFrom_NAME != "") 
				{
					string msg = "";
					msg = "Application acquire information from " + acquireInfoFrom_NAME + " !";
					Response.Redirect("TargetCustomerAprvList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&trg=" + Request.QueryString["trg"]+"&msg="+msg);
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				return;
			}
		}
	}
}
