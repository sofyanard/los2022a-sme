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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for ListJaminan.
	/// </summary>
	public partial class ListJaminan : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
		string[] sessionn;

			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				PopulateALL();
				ViewData();
				DDLALL();
				lbl_session.Text="";
				lbl_session2.Text="";
            }
		}

		private void PopulateALL()
		{
			lbl_mc.Text=Request.QueryString["mc"];
			lbl_tc.Text=Request.QueryString["tc"];

			if (lbl_mc.Text=="M0110")
			{
				Label1.Text="Batching Send to CAO";
				Label2.Text="Pilih CAO";				
			}
			else
			{
				Label1.Text="Batching Send to CA";
				Label2.Text="Pilih CA";				
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
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);
			this.DGR_RESULT.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_RESULT_ItemDataBound);

		}
		#endregion
		

		private void ViewData()
		{

			string query1=""; 			
			
			if(TXT_ACC_NUM.Text!="")
			{
				query1 += "and v.acc_number LIKE '%" + TXT_ACC_NUM.Text + "%' ";				
			}
			if(TXT_CUST_NAME.Text!="")
			{
				query1 += "and v.cust_name like '%" + TXT_CUST_NAME.Text + "%' ";				
			}
			if(TXT_COL_ID.Text!="")
			{
				query1 += "and v.collateral_id like '" + TXT_COL_ID.Text + "' ";				
			}
            
			if (lbl_session.Text !="" && lbl_session2.Text!="")
			{
                query1 += "or (v.acc_number in(" + lbl_session.Text + ")and v.collateral_id in (" + lbl_session2.Text + "))";
			}

			if (lbl_mc.Text=="M0110")
			{				
				conn.QueryString = " select distinct * from VW_MAS_INPUT_NEW_COLLATERAL v" +
								   " left join mas_collateral_value vv on v.acc_number=vv.acc_number  and v.collateral_id=vv.collateral_id  " +
								   " WHERE v.ACC_STATUS ='1' and v.unit_code = '" + Session["BranchID"].ToString() + 
								   "' and v.agunan_status <> '6' and v.trackcode = 'M1.2' " + query1 + " order by vv.updatedtime desc "; 
			}
			else
			{				
				conn.QueryString = " select distinct * from VW_MAS_INPUT_NEW_COLLATERAL v" +
								   " left join mas_collateral_value vv on v.acc_number=vv.acc_number  and v.collateral_id=vv.collateral_id " +
								   " where v.trackcode = 'M1.3' and v.CAO_NAME = '" + Session["UserID"].ToString() + 
                                   "' " + query1 + " order by vv.updatedtime desc "; 
			}

			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
			}
		}
		
		private void DDLALL()
		{
			DDL_CAO_NAME.Items.Clear();
			DDL_CAO_NAME.Items.Add(new ListItem("--Pilih--",""));

			if (lbl_mc.Text=="M0110")
			{				
				conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and userid!='"+ Session["UserID"].ToString()+
					"' and groupid='83' and su_branch=(select su_branch from scuser where userid = '"+ Session["UserID"].ToString() +"')" ;
			}
			else
			{				
				conn.QueryString = "select userid, su_fullname from scuser where userid like 'CAdmin%'";
			}

			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CAO_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
		}

		protected void BTN_send_Click(object sender, System.EventArgs e)
		{
			int j;
			j=DGR_RESULT.Items.Count;

		    for(int i=0;i<j;i++)
			{
				CheckBox rb = (CheckBox) DGR_RESULT.Items[i].FindControl("CHB_AT_FIX");										
				if (rb.Checked==true)
				{
					SendBatch( DGR_RESULT.Items[i].Cells[1].Text, DGR_RESULT.Items[i].Cells[3].Text,DGR_RESULT.Items[i].Cells[5].Text);
				}				
			}
			ViewData();
			DDLALL();
			lbl_session.Text ="";			
			lbl_session2.Text="";
		}

		private void SendBatch(string reg, string col, string acc)
		{
			string acc_sta;
			acc_sta=acc;			
			acc_sta=(acc_sta).Substring(0,1);
			string a11="";

			if (lbl_mc.Text=="M0110")
			{				
				a11="CAO Name tidak boleh kosong!";
			}
			else
			{
				a11="CA Name tidak boleh kosong!";
			}

			if (DDL_CAO_NAME.SelectedValue == "")
			{
				GlobalTools.popMessage(this, a11);
				return;	
			}

			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='4' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
					conn.ExecuteQuery();*/
			if (lbl_session.Text !="" && lbl_session2.Text!="")
			{
				if (lbl_mc.Text=="M0110")
				{
					conn.QueryString = "update MAS_COLLATERAL set CAO_NAME = '" + DDL_CAO_NAME.SelectedValue.ToString() + "'," +
						" SEND_CAO_DATE = '" + DateAndTime.Now.ToString() + "'" +
						" where ACC_NUMBER ='" +reg + "' and collateral_id = '" + col + "'";
					conn.ExecuteQuery();

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						reg + "' , '" + 
						col + "' , 'M1.3' , '" + 
						Session["UserID"].ToString() + "' , '', '4', '" + acc_sta +"'";
					conn.ExecuteQuery();
				

				}
				else
				{
					conn.QueryString = "update MAS_COLLATERAL set CA_NAME = '" + DDL_CAO_NAME.SelectedValue.ToString() + "'," +
						" SEND_CA_DATE = '" + DateAndTime.Now.ToString() + "'" +
						" where ACC_NUMBER ='" +reg + "' and collateral_id = '" +col+ "'";
					conn.ExecuteQuery();

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						reg + "' , '" + 
						col + "' , 'M1.4' , '" + 
						Session["UserID"].ToString() + "' , '', '2', '" + acc_sta +"'";
					conn.ExecuteQuery();
				
				}
			}
		}

		private void DGR_RESULT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			LinkButton link=(LinkButton) e.Item.FindControl("link_select");
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allselect":
					SelectAll(true);
					link.CommandName="alldeselect";
					link.Text="Deselect All";
					break;
				case "alldeselect":
					SelectAll(false);
					link.CommandName="allselect";
					link.Text="Select All";
					break;
			}
		}

		private void SelectAll(Boolean chek)
		{			
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{
				try
				{
					CheckBox rbA = (CheckBox) DGR_RESULT.Items[i].FindControl("CHB_AT_FIX");										
					rbA.Checked = chek;
					
				} 
				catch {}
			}
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			lbl_session.Text="";
			lbl_session2.Text="";				
			int j;
			j=DGR_RESULT.Items.Count;

			for(int i=0;i<j;i++)
			{
				CheckBox rb = (CheckBox) DGR_RESULT.Items[i].FindControl("CHB_AT_FIX");										
				if (rb.Checked==true)
				{
					lbl_session.Text= lbl_session.Text + ",'" + DGR_RESULT.Items[i].Cells[1].Text.Trim() + "'" ;
					lbl_session2.Text=lbl_session2.Text + ",'" + DGR_RESULT.Items[i].Cells[3].Text.Trim() + "'" ;					
				}				
			}

			if (lbl_session.Text !="" && lbl_session2.Text!="")
			{
				lbl_session.Text=lbl_session.Text.Remove(0,1);
				lbl_session2.Text=lbl_session2.Text.Remove(0,1);
				
				sessionn=lbl_session2.Text.Replace("'","").Split(',');
			}
			else
			{
				lbl_session.Text="";
				lbl_session2.Text="";				
			}
			
			ViewData();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			TXT_ACC_NUM.Text="";TXT_COL_ID.Text="";TXT_CUST_NAME.Text="";
			lbl_session.Text="";
			lbl_session2.Text="";				
			ViewData();
		}

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DGR_RESULT_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)e.Item.FindControl("CHB_AT_FIX");
                
				
				if (lbl_session.Text !="" && lbl_session2.Text!="")
				{		
					//if (e.Item.Cells[1].Text==lbl_session.Text)
					//cek.Checked=true;					
					for (int i = 0; i <= sessionn.Length - 1; i++)
					{
						if (sessionn[i].ToString() == e.Item.Cells[3].Text.Trim())
						{
							cek.Checked=true;					

						}		
					
					}
				}
			  }
		}

	}
}

