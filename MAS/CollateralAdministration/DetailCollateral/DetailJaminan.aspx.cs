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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for DetailJaminan.
	/// </summary>
	public partial class DetailJaminan : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{				
				Reset();
			}
		}

		private void PopulateGrid()
		{
			if (LBL_TC.Text=="M1.8")
			{
				conn.QueryString="select * from MAS_RFNOTARIS_ASURANSI where type='1'";
			}
			else
			{
				conn.QueryString="select * from MAS_RFNOTARIS_ASURANSI where type='2'";
			}

			
			conn.ExecuteQuery();

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

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			string aa="";string mode="";
			if (CHB_is_rekanan.Checked==true)
			{
				aa="1";
			}
			else
			{
				aa="0";
			}

			if (LBL_CL_SEQ.Text=="")
			{
				mode="insert";
			}
			else
			{
				mode="update";
			}


			if (TXT_name.Text=="")
			{
				GlobalTools.popMessage(this, Label2.Text + " tidak boleh kosong");
				return;					
			}
			else
			{
				ManipulasiData(mode,LBL_CL_SEQ.Text,TXT_name.Text,Textbox1.Text,aa,DDL_UNIT_CABANG.SelectedValue);
				Reset();
			}
			
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			Reset();
		}

		private void Reset()
		{
			LBL_TC.Text=Request.QueryString["tc"];
			if (LBL_TC.Text=="M1.8")
			{
				Label1.Text="Parameter Notaris";
				Label2.Text="Nama Notaris";
			}
			else
			{
				Label1.Text="Parameter Asuransi";
				Label2.Text="Nama Asuransi";
			}
			
			DDL_UNIT_CABANG.Items.Clear();
			DDL_UNIT_CABANG.Items.Add(new ListItem("--Pilih--",""));
			
			conn.QueryString ="select branchid as branch, branchname from VW_MAS_HIRARKI_CLUSTER where ccobranch='" +Session["BranchID"].ToString()+ "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_UNIT_CABANG.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));	
		

			DDL_UNIT_CABANG.SelectedValue="";
			TXT_name.Text="";
			Textbox1.Text="";
			CHB_is_rekanan.Checked=false;
			LBL_CL_SEQ.Text="";
			PopulateGrid();


		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					ManipulasiData("delete",e.Item.Cells[0].Text.Trim(),"","","","");					
					Reset();
					break;
				case "edit":
					LBL_CL_SEQ.Text=e.Item.Cells[0].Text.Trim();
					ManipulasiData("select",e.Item.Cells[0].Text.Trim(),"","","","");
					break;

			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			PopulateGrid();
		}

		private void ManipulasiData(string mode, string seq,string name, string alamat,string rekanan, string branch)
		{
			
			string type="";
			if (LBL_TC.Text=="M1.8")
			{
				type="1";				
			}
			else
			{
				type="2";				
			}

			conn.QueryString="exec MAS_Manipulate_Param_Notaris '"+ mode +"','" + seq + "','" +
							name + "','" + alamat + "','" + type + "','" + rekanan + "','" + branch + "'";
			conn.ExecuteQuery();

			if (mode=="select")
			{
				Textbox1.Text=conn.GetFieldValue("alamat");
				TXT_name.Text=conn.GetFieldValue("name");
				
				if (conn.GetFieldValue("rekanan")=="1")
				{
					CHB_is_rekanan.Checked=true;
				}
				else
				{
					CHB_is_rekanan.Checked=false;
				}
				DDL_UNIT_CABANG.SelectedValue=conn.GetFieldValue("branch");

			}

		}

		private void DatGrd_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.CheckBox rekan=(System.Web.UI.WebControls.CheckBox)e.Item.FindControl("CHB_REKAN");
				if(e.Item.Cells[4].Text.Trim()=="1")
				{
					rekan.Checked=true;
				}
				else
				{
					rekan.Checked=false;
				}
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete_data");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
				
			}
		}

		
	}
}
