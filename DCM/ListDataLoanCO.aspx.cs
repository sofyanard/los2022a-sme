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

namespace SME.DCM
{
	/// <summary>
	/// Summary description for ListDataLoanCO.
	/// </summary>
	public partial class ListDataLoanCO : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			ViewMenu();
			if (!IsPostBack)
			{	
				LBL_ACCTNO.Text = Request.QueryString["acctno"];
				ViewData();
				ViewAcctOffc();
			}				
			ViewListCollateral(Request.QueryString["acctno"]);	
			
		}

		private void ViewData()
		{			
			conn2.QueryString = "select * from vw_loanco_list_data where acctno='"+ LBL_ACCTNO.Text + "' ";			
			conn2.ExecuteQuery();
			TXT_CIF.Text = conn2.GetFieldValue("NO_CIF");
			TXT_CUST.Text = conn2.GetFieldValue("NAMA");
		}

		private void ViewListCollateral(string acctno)
		{
			conn2.QueryString = "EXEC DCM_LOANCO_CORRECTION '" + 
				acctno + "' "; //, '" +
				//colid + "'";
			conn2.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				/*** Hyperlink Collateral ID ***/
				/*HyperLink HL_COLID = (HyperLink) DatGrd.Items[i].Cells[0].FindControl("HL_COLID");
				HL_COLID.Text = dt.Rows[i][1].ToString();
				HL_COLID.ID = "HL_COLID." + i.ToString();
				HL_COLID.Font.Bold = true;
				HL_COLID.NavigateUrl = dt.Rows[i][6].ToString();
				HL_COLID.Target = "coldetail"; */

				/*** Image Assignment Status ***/
				System.Web.UI.WebControls.Image IMG_STA = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[0].FindControl("IMG_STA");
				IMG_STA.ImageUrl = dt.Rows[i][3].ToString();

				/*** Label Assignment Status ***/
				Label LBL_STA = (Label) DatGrd.Items[i].Cells[0].FindControl("LBL_STA");
				LBL_STA.Text = dt.Rows[i][2].ToString();

				/*** DropDownList Assign To ***/
				DropDownList DDL_OFCR = (DropDownList) DatGrd.Items[i].Cells[1].FindControl("DDL_OFCR");
				DDL_OFCR.ID = "DDL_OFCR." + i.ToString();
				GlobalTools.fillRefList(DDL_OFCR, "EXEC DCM_LOANCO_CORRECTION_DDLOFCR '" + Session["UserID"].ToString() + "'", conn);
				try { DDL_OFCR.SelectedValue = dt.Rows[i][6].ToString().Trim(); }
				catch {}
				if (dt.Rows[i][7].ToString() == "1")
					DDL_OFCR.Enabled = true;
				else
					DDL_OFCR.Enabled = false; 

				/*** Button Process ***/
				Button BTN_PROC = (Button) DatGrd.Items[i].Cells[1].FindControl("BTN_PROC");
				BTN_PROC.ID = "BTN_PROC." + i.ToString();
				BTN_PROC.Text = dt.Rows[i][4].ToString();
				if (dt.Rows[i][5].ToString() == "1")
					BTN_PROC.Enabled = true;
				else
					BTN_PROC.Enabled = false;
				BTN_PROC.Click += new EventHandler(BTN_PROCESS_Click);
			}
		}

		private void BTN_PROCESS_Click(object sender, System.EventArgs e)
		{
			try
			{
				Button b = (Button) sender;
				string idx = b.ID.Replace("BTN_PROC.","");
				string act = b.Text;

				//HyperLink h = (HyperLink) DatGrd.Items[int.Parse(idx)].Cells[11].FindControl("HL_COLID."+idx);
				//string colid = h.Text.Trim();

				DropDownList d = (DropDownList) DatGrd.Items[int.Parse(idx)].Cells[9].FindControl("DDL_OFCR."+idx);
				string ofcr = d.SelectedValue.Trim();
				
				conn2.QueryString  = "EXEC DCM_LOANCO_ASSIGNPROCESS '" + 
					Request.QueryString["acctno"] + "', '" + act + "', '" + ofcr + "', '" + Session["UserID"].ToString() + "'";
				conn2.ExecuteNonQuery();

				ViewListCollateral(Request.QueryString["acctno"]);	
				ViewAcctOffc();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
		
		private void ViewAcctOffc()
		{
			conn2.QueryString = "select * from pending_loan_co where acctno='"+Request.QueryString["acctno"]+"' ";
			conn2.ExecuteQuery();
			string asg_by, asg_to, asg_to_branch;
			asg_by = conn2.GetFieldValue("assign_by");
			asg_to = conn2.GetFieldValue("assign_to");

			conn.QueryString = "select * from scuser where userid='"+asg_to+"' ";
			conn.ExecuteQuery();
			TXT_ACCT.Text = conn.GetFieldValue("su_fullname");
			asg_to_branch = conn.GetFieldValue("su_branch");

			conn.QueryString = "select * from rfbranch where branch_code='"+asg_to_branch+"' ";
			conn.ExecuteQuery();
			TXT_UNIT.Text = conn.GetFieldValue("branch_name");
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"' and sm_id not in ('A010303')";
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
							strtemp = "acctno=" + Request.QueryString["acctno"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&exist=1";
						else	
							strtemp = "acctno=" + Request.QueryString["acctno"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=1";
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("LoanListDataCO.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
