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

namespace SME.MAS.SupervisionManagement.MicroCreditQuality.UnitParameter
{
	/// <summary>
	/// Summary description for ParameterUnit.
	/// </summary>
	public partial class ParameterUnit : System.Web.UI.Page
	{ 
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_BUKA.Items.Add(new ListItem("--Pilih--",""));
				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_BUKA.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}
				
//				DDL_CLUSTER.Items.Add(new ListItem("--Pilih--",""));
//				conn.QueryString = "select * from rfbranch where active='1' order by branch_name";
//				conn.ExecuteQuery();
//				for (int i = 0; i < conn.GetRowCount(); i++)
//					DDL_CLUSTER.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				
//				DDL_UNIT_CABANG.Items.Add(new ListItem("--Pilih--",""));
//				conn.QueryString = "select * from rfbranch where active='1' order by branch_name";
//				conn.ExecuteQuery();
//				for (int i = 0; i < conn.GetRowCount(); i++)
//					DDL_UNIT_CABANG.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));	

				
				conn3.QueryString = "select * from scuser where userid = '"+ Session["UserID"].ToString() +"' ";
				conn3.ExecuteQuery();
				if (conn3.GetRowCount()!=0)
				{
					if (conn3.GetFieldValue("su_branch")!="")
					{
						FillDDLDistrik();
						TXT_DISTRIK.Text = conn3.GetFieldValue("su_branch");
						try
						{
							ddl_distrik.SelectedValue = conn3.GetFieldValue("su_branch");
							FillDDLCluster(TXT_DISTRIK.Text);
							FillDDLUnit(TXT_DISTRIK.Text);
						}
						catch
						{
							ddl_distrik.SelectedValue = "";
							FillDDLCluster("");
							FillDDLUnit("");
						}					
						
					}
					else
					{
						FillDDLDistrik();
						FillDDLCluster("");
						FillDDLUnit("");
					}				

				}
				else
				{
					FillDDLDistrik();
					FillDDLCluster("");
					FillDDLUnit("");
				}				
			}

			ViewData();
			
		}

		protected void FillDDLDistrik()
		{
			ddl_distrik.Items.Clear();
			ddl_distrik.Items.Add(new ListItem("--Pilih--",""));
			conn2.QueryString = "select * from rfbranch where active='1' and branch_code like 'DC%' order by branch_name";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
				ddl_distrik.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));

		}

		protected void FillDDLCluster(string distcode)
		{	
			DDL_CLUSTER.Items.Clear();
			DDL_CLUSTER.Items.Add(new ListItem("--Pilih--",""));

			string queri;

			if (distcode=="")
			{
				queri="select * from rfbranch where active='1' and branch_code not like 'DC%'order by branch_name";
			}
			else
			{
				queri="select * from rfbranch where active='1' and right(left(branch_code,4),2)=right(left('"+ distcode +"',4),2)" +
					" and branch_code not like 'DC%' order by branch_name";
			}

			conn2.QueryString = queri;
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
				DDL_CLUSTER.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
		}

		protected void FillDDLUnit(string distcode)
		{
			DDL_UNIT_CABANG.Items.Clear();
			DDL_UNIT_CABANG.Items.Add(new ListItem("--Pilih--",""));
			
			string queri;

			if (distcode=="")
			{
				queri="select * from rfbranch where active='1' and branch_code not like 'DC%'  " +
					" order by branch_name";
			}
			else
			{
				queri="select * from rfbranch where active='1' and branch_code not like 'DC%'  " +
					"and branch_code not in (select branch_code from rfbranch where active='1' " +
					"and right(left(branch_code,4),2)=right(left('"+ distcode +"',4),2)) order by branch_name";
			}

			conn2.QueryString =queri;
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
				DDL_UNIT_CABANG.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));	
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
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
				DatGrd.Items[i].Cells[4].Text = tool.FormatDate(DatGrd.Items[i].Cells[4].Text, true);
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
			this.DatGrd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DatGrd_ItemDataBound);

		}
		#endregion

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{			
			FillDDLDistrik();
			FillDDLCluster("");
			FillDDLUnit("");
			ddl_distrik.SelectedValue = "";
			DDL_CLUSTER.SelectedValue = "";
			DDL_UNIT_CABANG.SelectedValue = "";
			TXT_TGL_BUKA.Text = "";
			DDL_BLN_BUKA.SelectedValue = "";
			TXT_THN_BUKA.Text = "";
			TXT_JUM_SALES.Text = "";
			TXT_SEQ.Text = "";
			txt_unit_code.Text="";
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
//					string js = "function konfirmasi(){return confirm('Are you sure to delete this item?')};";
//					ClientScript.RegisterClientScriptBlock(this.GetType(), "test", js ,true);
//					RegisterClientScriptBlock("showMessage", "<script language=\"JavaScript\"> confirm('Do you really want to \ndelete the item?'); </script>");

//					if (System.Windows.Forms.MessageBox.Show
//						("Do you want to delete it?.", "Delete COnfirm",
//						System.Windows.Forms.MessageBoxButtons.OKCancel,
//						System.Windows.Forms.MessageBoxIcon.Asterisk, 
//						System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
//
//					{
//
//						//System.Console.WriteLine("OK Clicked");
//
//						Exist = 3;

						conn.QueryString = "delete from mas_rf_unit_review where UNIT_SEQ#=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
						conn.ExecuteQuery();					
						ClearData();					
						ViewData();

					//}
					
					break;

				case "edit_data":					
					conn.QueryString = "select * from mas_rf_unit_review where UNIT_SEQ#=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					
					TXT_SEQ.Text = conn.GetFieldValue("unit_seq#");
					TXT_DISTRIK.Text = conn.GetFieldValue("distrik_code");
					FillDDLDistrik();
					try{ddl_distrik.SelectedValue = conn.GetFieldValue("distrik_code");}
					catch{ddl_distrik.SelectedValue = "";}					

					FillDDLCluster(TXT_DISTRIK.Text);
					FillDDLUnit(TXT_DISTRIK.Text);

					try{txt_unit_code.Text = conn.GetFieldValue("unit_code");}
					catch{txt_unit_code.Text = "";}

					try{DDL_CLUSTER.SelectedValue = conn.GetFieldValue("cluster_code");}
					catch{DDL_CLUSTER.SelectedValue = "";}					
					try{DDL_UNIT_CABANG.SelectedValue = conn.GetFieldValue("unit_code");}
					catch{DDL_UNIT_CABANG.SelectedValue = "";}
					TXT_TGL_BUKA.Text = tool.FormatDate_Day(conn.GetFieldValue("tahun_pembukaan"));
					try{DDL_BLN_BUKA.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tahun_pembukaan")); }
					catch{DDL_BLN_BUKA.SelectedValue = "";}
					TXT_THN_BUKA.Text = tool.FormatDate_Year(conn.GetFieldValue("tahun_pembukaan"));
					TXT_JUM_SALES.Text = conn.GetFieldValue("jumlah_so");					
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select * from mas_rf_unit_review where pic_input='"+ Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			FillGrid();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			try 
			{
				compEstablish = Int64.Parse(Tools.toISODate(TXT_TGL_BUKA.Text, DDL_BLN_BUKA.SelectedValue, TXT_THN_BUKA.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal buka tidak valid!");
				return;
			}
			if (TXT_SEQ.Text == "")
			{
				conn.QueryString = " exec MAS_RF_UNIT_REVIEW_INSERT '" + 			
					TXT_DISTRIK.Text + "', '" +
					DDL_CLUSTER.SelectedValue + "', '" +
					DDL_UNIT_CABANG.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_BUKA.Text, DDL_BLN_BUKA.SelectedValue, TXT_THN_BUKA.Text) + ", '" +
					TXT_JUM_SALES.Text + "', '" +
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_RF_UNIT_REVIEW_UPDATE " + 
					Convert.ToInt32(TXT_SEQ.Text) + ", '" +					
					TXT_DISTRIK.Text + "', '" +
					DDL_CLUSTER.SelectedValue + "', '" +
					DDL_UNIT_CABANG.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_BUKA.Text, DDL_BLN_BUKA.SelectedValue, TXT_THN_BUKA.Text) + ", '" +
					TXT_JUM_SALES.Text + "', '" +
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();
			}
			ClearData();
			ViewData();
		}

		protected void ddl_distrik_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            TXT_DISTRIK.Text=ddl_distrik.SelectedValue;
            FillDDLCluster(TXT_DISTRIK.Text);		
		}

		protected void DDL_CLUSTER_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit(TXT_DISTRIK.Text);
		}

		protected void btn_search_unit_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchUnitCode.aspx?targetFormID=Form1&targetObjectID=txt_unit_code','SearchUnitCode','status=no,scrollbars=no,width=500,height=700');</script>");
		}

		protected void txt_unit_code_TextChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit("");
			if (txt_unit_code.Text=="")
			{
				DDL_UNIT_CABANG.SelectedValue="";
			}
			else
			{
				DDL_UNIT_CABANG.SelectedValue=txt_unit_code.Text;
			}
		}

		protected void DDL_UNIT_CABANG_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_UNIT_CABANG.SelectedValue=="")
			{
				txt_unit_code.Text="";
			}
			else
			{
				txt_unit_code.Text=DDL_UNIT_CABANG.SelectedValue;
			}
		}

		private void DatGrd_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete_data");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}
		}	
	}
}
