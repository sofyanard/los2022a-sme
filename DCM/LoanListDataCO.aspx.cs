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
	/// Summary description for LoanListDataCO.
	/// </summary>
	public partial class LoanListDataCO : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			

			if (!IsPostBack)
			{					
				fillRCO();				
				conn2.QueryString = "select * from VW_LOANCO_LIST_DATA order by nama";
				conn2.ExecuteQuery();
				FillGrid();	
			}					
		}

		
		private void fillRCO()
		{
			DDL_RCO.Items.Add(new ListItem("--Pilih--",""));						
			conn2.QueryString = "select distinct rco from par_rco ";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_RCO.Items.Add(new ListItem(conn2.GetFieldValue(i,0),conn2.GetFieldValue(i,0)));
			}	
		}	

		private void FillGrid()
		{	
			System.Web.UI.WebControls.Image ImgStat;
			System.Data.DataTable dt = new System.Data.DataTable();			
			//DataTable dt = new DataTable();
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
				LinkButton LbUpdate = (LinkButton) DatGrd.Items[i].Cells[6].FindControl("LB_UPDATE");
				ImgStat	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[5].FindControl("IMG_LA_APPRSTATUS"); 
				Label LblAppr	= (Label) DatGrd.Items[i].Cells[5].FindControl("LBL_LA_APPRSTATUS");				
				if (DatGrd.Items[i].Cells[9].Text.Trim() == "&nbsp;" ||DatGrd.Items[i].Cells[9].Text.Trim() == "0")
				{
					ImgStat.ImageUrl = "../Image/UnComplete.gif";
					LblAppr.Text = "Not Assign";
					LbUpdate.Visible = false;
				}
				else if (DatGrd.Items[i].Cells[9].Text.Trim() == "1")
				{
					ImgStat.ImageUrl = "../Image/UnComplete.gif";						
					LblAppr.Text = "Assign to Officer";
					LbUpdate.Visible = false;
				}
				else if (DatGrd.Items[i].Cells[9].Text.Trim() == "2")
				{
					ImgStat.ImageUrl = "../Image/Complete.gif";						
					LblAppr.Text = "Correction Done";
					LbUpdate.Visible = true;
				}
				else if (DatGrd.Items[i].Cells[9].Text.Trim() == "3")
				{
					ImgStat.ImageUrl = "../Image/Complete.gif";						
					LblAppr.Text = "Approved";
					LbUpdate.Visible = false;
				}
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{	
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{			
			string rco;
			rco=DDL_RCO.SelectedValue;
			if (rco=="")
			{
				conn2.QueryString = " select * from VW_LOANCO_LIST_DATA order by nama";
				conn2.ExecuteQuery();
			}
			if (rco!="")
			{
				conn2.QueryString = "select * from VW_LOANCO_LIST_DATA where rco='"+ rco +"' order by nama";
				conn2.ExecuteQuery();
			}
			FillGrid();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string userid, assign_to;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":		
					conn2.QueryString = "select * from pending_loan_co where acctno='" +e.Item.Cells[1].Text+ "'";
					conn2.ExecuteQuery();
					assign_to = conn2.GetFieldValue("ASSIGN_TO");
					userid = Session["UserID"].ToString();
					
					if (assign_to == userid || assign_to == "")
					{
						//GlobalTools.popMessage(this, e.Item.Cells[1].Text.ToString());
						Response.Redirect("ListDataLoanCO.aspx?sta=exist&acctno=" + e.Item.Cells[1].Text + "&userid=" + Session["UserID"].ToString() + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					}
					else		
					{
						Response.Write("<script language='javascript'>alert('" + "Data ini merupakan data: " + assign_to + "');</script>");
					}
				break;

				case "update":
					string actno = e.Item.Cells[1].Text.Trim();
					try
					{
						conn2.QueryString  = "EXEC DCM_LOANCO_CORRECTION_APPROVAL '" + 
							actno + "', '" + Session["UserID"].ToString() + "'";
						conn2.ExecuteNonQuery();

						conn2.QueryString = "select * from VW_LOANCO_LIST_DATA order by nama";
						conn2.ExecuteQuery();
						FillGrid();							
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
				break;
				
				default:
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
		
	}
}
