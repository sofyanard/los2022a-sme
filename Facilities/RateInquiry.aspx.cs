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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for Product Rate Inquiry.fs
	/// </summary>
	public partial class RateInquiry : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			string tc = "";//,mi = "";//, si = "";
			try 
			{
				tc = Request.QueryString["tc"];
				//mi = Request.QueryString["mi"];
				//si = Request.QueryString["si"];
			} 
			catch {}
			
			if (!IsPostBack)
			{	
				bindData(); // tampilkan data
			}
			DTG_RATEINQ.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}		

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// For the DataGrid control to navigate to the correct page when paging is
			// allowed, the CurrentPageIndex property must be programmatically updated.
			// This process is usually accomplished in the event-handling method for the
			// PageIndexChanged event.
			DTG_RATEINQ.CurrentPageIndex = e.NewPageIndex; // Set CurrentPageIndex to the page the user clicked.
			bindData();	// Re-bind the data to refresh the DataGrid control. 
		}

		private void bindData()
		{
			string sqlCON = "AND (";
			string sqlJOIN = RDB_COND.SelectedValue; // kondsi AND atau OR sesuai pilihan user

			if (TXT_PRODUCTID.Text.Trim() != "")
				sqlCON += " A.PRODUCTID LIKE '%" + TXT_PRODUCTID.Text.Trim() + "%' " + sqlJOIN; // memasukkan syarat PRODUCTID
			if (TXT_PRODUCTDESC.Text.Trim() != "")
				sqlCON += " A.PRODUCTDESC LIKE '%" + TXT_PRODUCTDESC.Text.Trim() + "%' " + sqlJOIN; // syarat PRODUCTDESC
			if (TXT_JNSPRODUCT.Text.Trim() != "")
				sqlCON += " A.JNSPRODUCT LIKE '%" + TXT_JNSPRODUCT.Text.Trim() + "%' " + sqlJOIN; // syarat JNSPRODUCT
			if (TXT_TOPRATE.Text.Trim() != "") // syarat TopRate diisi
			{
				try
				{
					string toprate = tool.ConvertFloat(TXT_TOPRATE.Text.Trim());
					string bottomrate = tool.ConvertFloat("0,0");
					if (TXT_BOTTOMRATE.Text.Trim() != "")
					{ // syarat bottom rate diisi
						bottomrate = tool.ConvertFloat(TXT_BOTTOMRATE.Text.Trim());					
						sqlCON += " (B.RATE BETWEEN " + bottomrate;
						sqlCON += " and " + toprate + ") " + sqlJOIN; // syarat currency between
					} 
					else
					{ // syarat bottom rate tidak ada 
						conn.QueryString = "SELECT MIN(B.RATE) AS BOTTOMRATE FROM RFPRODUCT A,RFRATENUMBER B";
						conn.QueryString += " WHERE A.RATENO = B.RATENO";
						try 
						{
							conn.ExecuteQuery();
							bottomrate = tool.ConvertFloat(conn.GetFieldValue("BOTTOMRATE").ToString());
							sqlCON += " (B.RATE BETWEEN " + bottomrate;
							sqlCON += " and " + toprate + ") " + sqlJOIN; // syarat currency between
						} 
						catch(NullReferenceException)
						{
							GlobalTools.popMessage(this, "Connection Error !");
							return;
						}
					}
				}
				catch (Exception) {}
			} 
			else // syarat TopRate tidak diisi
			{
				if (TXT_BOTTOMRATE.Text.Trim() != "")
				{ // jika syarat bottomrate diisi
					try 
					{
						string bottomrate = tool.ConvertFloat(TXT_BOTTOMRATE.Text.Trim());
						sqlCON += " B.RATE = " + bottomrate + sqlJOIN;
						//Double.Parse(TXT_BOTTOMRATE.Text.Trim, System.Globalization.NumberStyles.Float);
					} 
					catch(Exception) {}
				}
			}

			if (sqlCON == "AND (") 
				sqlCON = ""; // kasus tidak terdapat kondisi apapun
			else
			{ // jika terdapat where maka kondisi "AND" atau "OR" paling belakang dihilangkan
				sqlCON = sqlCON.Substring(0,sqlCON.Length - sqlJOIN.Length);
				sqlCON += ")";
			}
			
			// query dasar untuk mendapatkan data
			conn.QueryString = "SELECT A.PRODUCTID,A.PRODUCTDESC,A.JNSPRODUCT, (B.RATE*100) AS RATE";
			conn.QueryString += " FROM RFPRODUCT A,RFRATENUMBER B";
			conn.QueryString += " WHERE A.RATENO = B.RATENO";	
			// proses pencarian dengan kondisi
			conn.QueryString += " " + sqlCON + " ORDER BY " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;
			
			try 
			{ // mengeksekusi query
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			/* jika kolom database sesuai benar dengan kolom data grid:*/
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DTG_RATEINQ.DataSource = data;
			try 
			{
				DTG_RATEINQ.DataBind(); // mengikat data ke datagrid yang disediakan
			} 
			catch 
			{
				DTG_RATEINQ.CurrentPageIndex = 0;
				DTG_RATEINQ.DataBind();
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
			this.DTG_RATEINQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DTG_RATEINQ_ItemCommand);
			this.DTG_RATEINQ.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DTG_RATEINQ_SortCommand);

		}
		#endregion


		private void DTG_RATEINQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					Response.Write("Masuk");
					Response.Redirect("ProductDetail.aspx?productid="+ e.Item.Cells[0].Text +"&tc=" + Request.QueryString["tc"] + "&mc=" +  Request.QueryString["mc"]);
					break;
				default:
					// Do nothing.
					//Response.Write("Nothing");
					break;
			}
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			bindData();
		}

		private void DTG_RATEINQ_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (LBL_SORTTYPE.Text == "ASC")
				LBL_SORTTYPE.Text = "DESC";
			else
				LBL_SORTTYPE.Text = "ASC";
			LBL_SORTEXP.Text = e.SortExpression;
			
			bindData();		
		}
	}
}
