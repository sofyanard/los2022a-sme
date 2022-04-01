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

namespace SME.Maintenance.Parameters.General
{
	/// <summary>
	/// Summary description for RFProduct.
	/// </summary>
	public partial class RFProduct : System.Web.UI.Page
	{

		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//sakdjfskladjfksladjfjks
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				//INTEREST TYPE
				conn.QueryString = "SELECT * FROM RFINTERESTTYPE ";
				conn.ExecuteQuery();
				DDL_INTERESTTYPE.Items.Clear();
				DDL_INTERESTTYPE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_INTERESTTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//INTSTALLMENT TYPE
				conn.QueryString = "SELECT * FROM RFINSTALLMENTTYPE WHERE ACTIVE = '1' ";
				conn.ExecuteQuery();
				DDL_INSTALLMENTTYPE.Items.Clear();
				DDL_INSTALLMENTTYPE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_INSTALLMENTTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//SIBS CURRENCY
				conn.QueryString = "select CURRENCYID, CURRENCYDESC from RFCURRENCY WHERE ACTIVE = '1' ";
				conn.ExecuteQuery();
				DDL_CURRENCY.Items.Clear();
				DDL_CURRENCY.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				fillRateNumber();
				bindData1();
				bindData2();
			}
			Datagrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change1);
			DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change2);
		}

		private void fillRateNumber()
		{
			DDL_RATENO.Items.Clear();
			DDL_RATE.Items.Clear();
			TXT_RATE.Text = "";

			DDL_RATENO.Items.Add(new ListItem("-- Pilih --", ""));
			DDL_RATE.Items.Add(new ListItem("-- Pilih --", ""));

			if (DDL_CURRENCY.SelectedValue == "")//||(TXT_SIBS_PRODCODE.Text.Trim() == ""))
				return;

			/*conn.QueryString = "select RATENO, RATE, CURRENCYID, CURRENCYDESC from rfsibsprodid " +
				"left join rfratenumber on rfratenumber.sibs_prodcode = rfsibsprodid.sibsproddesc " +
				"and rfratenumber.currency = rfsibsprodid.currency " +
				"left join rfcurrency on rfcurrency.currencyid = rfsibsprodid.currency " +
				"where sibsprodid = '" + DDL_SIBS_PRODCODE.SelectedValue.Trim() + "' ";
				*/
			conn.QueryString = "select RATENO, RATE * 100 from rfratenumber " +
				"where CURRENCY = '" + DDL_CURRENCY.SelectedValue.Trim() +
				//"' AND SIBS_PRODCODE = '" + TXT_SIBS_PRODCODE.Text.Trim() +
				"' AND ACTIVE = '1' ";
			conn.ExecuteQuery();
			for (int i=0; i<conn.GetRowCount(); i++)
			{
				DDL_RATENO.Items.Add(new ListItem(conn.GetFieldValue(i, 0), conn.GetFieldValue(i, 0)));
				DDL_RATE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			}
		}

		private void bindData1()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT PRODUCTID, PRODUCTDESC, SIBS_PRODCODE, CURRENCY, CURRENCYDESC, RATENO, RATE * 100, "+
				"CALCMETHOD, INTERESTMODE, case REVOLVING when '1' then 'YES' when '0' then 'NO' end REVOLVING, " +
				"case ISCASHLOAN when '1' then 'YES' when '0' then 'NO' end ISCASHLOAN, " +
				"case IDCFLAG when '1' then 'YES' when '0' then 'NO' end IDCFLAG, VARCODE, VARIANCE, "+
				"case SPK when '1' then 'YES' when '0' then 'NO' end SPK, INTERESTREST, " + 
				"case ISINSTALLMENT when '1' then 'INSTALLMENT' when '0' then 'INTEREST' end ISINSTALLMENT, " +
				"INTERESTTYPE, ITYPEDESC, FIRSTINSTALLDATE, INTERESTTYPERATE, SIBS_PRODID, INSTALMENTTYPE, IN_NAME, "+
				"case CONFIRMKORAN when '1' then 'YES' when '0' then 'NO' end CONFIRMKORAN " +
				"FROM VW_PARAM_GENERAL_RFPRODUCT ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("PRODUCTID"));
			dt.Columns.Add(new DataColumn("PRODUCTDESC"));
			dt.Columns.Add(new DataColumn("SIBS_PRODCODE"));
			dt.Columns.Add(new DataColumn("CURRENCY"));
			dt.Columns.Add(new DataColumn("CURRENCYDESC"));
			dt.Columns.Add(new DataColumn("RATENO"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("CALCMETHOD"));
			dt.Columns.Add(new DataColumn("INTERESTMODE"));
			dt.Columns.Add(new DataColumn("REVOLVING"));
			dt.Columns.Add(new DataColumn("ISCASHLOAN"));
			dt.Columns.Add(new DataColumn("IDCFLAG"));
			dt.Columns.Add(new DataColumn("VARCODE"));
			dt.Columns.Add(new DataColumn("VARIANCE"));
			dt.Columns.Add(new DataColumn("SPK"));
			dt.Columns.Add(new DataColumn("INTERESTREST"));
			dt.Columns.Add(new DataColumn("ISINSTALLMENT"));
			dt.Columns.Add(new DataColumn("INTERESTTYPE"));
			dt.Columns.Add(new DataColumn("ITYPEDESC"));
			dt.Columns.Add(new DataColumn("FIRSTINSTALLDATE"));
			dt.Columns.Add(new DataColumn("INTERESTTYPERATE"));
			dt.Columns.Add(new DataColumn("SIBS_PRODID"));
			dt.Columns.Add(new DataColumn("INSTALMENTTYPE"));
			dt.Columns.Add(new DataColumn("IN_NAME"));
			dt.Columns.Add(new DataColumn("CONFIRMKORAN"));

			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			Datagrid1.DataSource = new DataView(dt);
			try 
			{
				Datagrid1.DataBind();
			}
			catch 
			{
				Datagrid1.CurrentPageIndex = Datagrid1.PageCount - 1;
				Datagrid1.DataBind();
			}
		}

		private void bindData2()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT PRODUCTID, PRODUCTDESC, SIBS_PRODCODE, CURRENCY, CURRENCYDESC, RATENO, RATE * 100, "+
				"CALCMETHOD, INTERESTMODE, case REVOLVING when '1' then 'YES' when '0' then 'NO' end REVOLVING, " +
				"case ISCASHLOAN when '1' then 'YES' when '0' then 'NO' end ISCASHLOAN, " +
				"case IDCFLAG when '1' then 'YES' when '0' then 'NO' end IDCFLAG, VARCODE, VARIANCE, "+
				"case SPK when '1' then 'YES' when '0' then 'NO' end SPK, INTERESTREST, " + 
				"case ISINSTALLMENT when '1' then 'INSTALLMENT' when '0' then 'INTEREST' end ISINSTALLMENT, " +
				"INTERESTTYPE, ITYPEDESC, FIRSTINSTALLDATE, INTERESTTYPERATE, SIBS_PRODID, INSTALMENTTYPE, IN_NAME, "+
				"case CONFIRMKORAN when '1' then 'YES' when '0' then 'NO' end CONFIRMKORAN, STATUSDESC, PENDINGSTATUS " +
				"FROM VW_PARAM_GENERAL_PENDING_RFPRODUCT ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("PRODUCTID"));
			dt.Columns.Add(new DataColumn("PRODUCTDESC"));
			dt.Columns.Add(new DataColumn("SIBS_PRODCODE"));
			dt.Columns.Add(new DataColumn("CURRENCY"));
			dt.Columns.Add(new DataColumn("CURRENCYDESC"));
			dt.Columns.Add(new DataColumn("RATENO"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("CALCMETHOD"));
			dt.Columns.Add(new DataColumn("INTERESTMODE"));
			dt.Columns.Add(new DataColumn("REVOLVING"));
			dt.Columns.Add(new DataColumn("ISCASHLOAN"));
			dt.Columns.Add(new DataColumn("IDCFLAG"));
			dt.Columns.Add(new DataColumn("VARCODE"));
			dt.Columns.Add(new DataColumn("VARIANCE"));
			dt.Columns.Add(new DataColumn("SPK"));
			dt.Columns.Add(new DataColumn("INTERESTREST"));
			dt.Columns.Add(new DataColumn("ISINSTALLMENT"));
			dt.Columns.Add(new DataColumn("INTERESTTYPE"));
			dt.Columns.Add(new DataColumn("ITYPEDESC"));
			dt.Columns.Add(new DataColumn("FIRSTINSTALLDATE"));
			dt.Columns.Add(new DataColumn("INTERESTTYPERATE"));
			dt.Columns.Add(new DataColumn("SIBS_PRODID"));
			dt.Columns.Add(new DataColumn("INSTALMENTTYPE"));
			dt.Columns.Add(new DataColumn("IN_NAME"));
			dt.Columns.Add(new DataColumn("CONFIRMKORAN"));
			dt.Columns.Add(new DataColumn("STATUSDESC"));
			dt.Columns.Add(new DataColumn("PENDINGSTATUS"));
			
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid2.DataSource = new DataView(dt);
			try 
			{
				DataGrid2.DataBind();
			}
			catch 
			{
				DataGrid2.CurrentPageIndex = DataGrid2.PageCount - 1;
				DataGrid2.DataBind();
			}
		}

		private void clearEditBoxes()
		{
			TXT_PRODUCTID.Text = "";
			TXT_PRODUCTDESC.Text = "";
			TXT_SIBS_PRODCODE.Text = "";
			TXT_RATE.Text = "";
			TXT_VARIANCE.Text = "";
			TXT_INTERESTTYPERATE.Text = "";
			TXT_SIBS_PRODID.Text = "";
			try 
			{
				DDL_CURRENCY.SelectedIndex = 0;
			} 
			catch {}
			try 
			{
				DDL_INTERESTREST.SelectedIndex = 0;
			} 
			catch {}
			fillRateNumber();
			try
			{
				RDO_REVOLVING.SelectedIndex = 0;
			} 
			catch {}
			try 
			{
				RDO_ISCASHLOAN.SelectedIndex = 0;
			} 
			catch {}
			try
			{
				RDO_VARCODE.SelectedIndex = 0; 
			} 
			catch {}
			try 
			{
				RDO_SPK.SelectedIndex = 0;
			} 
			catch {}
			try 
			{
				RDO_ISINSTALLMENT.SelectedIndex = 0;
			} 
			catch {}
			try 
			{
				DDL_INTERESTTYPE.SelectedIndex = 0;
			} 
			catch {}
			try 
			{
				DDL_INSTALLMENTTYPE.SelectedIndex = 0;
			} 
			catch {}
			try 
			{
				RDO_CONFIRMKORAN.SelectedIndex = 0;
			} 
			catch {}
			LBL_SAVEMODE.Text = "1";
			activatePostBackControls(true);
		}

		private void activatePostBackControls(bool mode)
		{
			TXT_PRODUCTID.Enabled = mode;
		}

		private void cleansTextBox (TextBox tb)
		{
			if (tb.Text.Trim() == "&nbsp;")
				tb.Text = "";
		}

		private void enInterestVal(string intmode)
		{
			switch(intmode)
			{
				case "01" :
					TXT_INTERESTTYPERATE.Enabled = false;
					TXT_INTERESTTYPERATE.Text = "";
					DDL_RATENO.Enabled = true;
					RDO_VARCODE.Enabled = true;
					TXT_VARIANCE.Enabled = true;
					break;
				case "02" : // Fixed
					TXT_INTERESTTYPERATE.Enabled = true;
					TXT_INTERESTTYPERATE.Text = "";
					DDL_RATENO.Enabled = false;
					RDO_VARCODE.Enabled = false;
					TXT_VARIANCE.Enabled = false;
					TXT_VARIANCE.Text = "";
					break;
				default : // Alternate Rate
					TXT_INTERESTTYPERATE.Enabled = false;
					DDL_RATENO.Enabled = false;
					RDO_VARCODE.Enabled = false;
					TXT_VARIANCE.Enabled = false;
					try
					{
						DDL_RATENO.SelectedIndex = 0;
					} 
					catch {}
					try
					{
						RDO_VARCODE.SelectedIndex = 0;
					} 
					catch {}
					TXT_VARIANCE.Text = "";
					TXT_RATE.Text = "";
					break;
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
			this.Datagrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid1_ItemCommand);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);

		}
		#endregion

		void Grid_Change1(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData1();	
		}

		void Grid_Change2(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid2.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData2();	
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string VARIANCE = TXT_VARIANCE.Text.Trim(), 
				INTERESTTYPERATE = TXT_INTERESTTYPERATE.Text.Trim(),
				varcode = RDO_VARCODE.SelectedValue.Trim(),
				rateno = DDL_RATENO.SelectedValue.Trim();

			if (TXT_PRODUCTID.Text.Trim() == "")
			{
				Tools.popMessage(this, "Product Code has not been set!");
				return;
			}
			if (LBL_SAVEMODE.Text.Trim() == "1")
			{
				conn.QueryString = "SELECT PRODUCTID FROM RFPRODUCT WHERE PRODUCTID = '"+
					TXT_PRODUCTID.Text.Trim() + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					Tools.popMessage(this, "Product Code has already been used! Request canceled!");
					return;
				}
			}
			if (DDL_INTERESTTYPE.SelectedValue.Trim() == "01")	//floating
			{
				rateno = "'" + rateno + "'";
				varcode = "'" + varcode + "'";
				VARIANCE = tool.ConvertFloat(VARIANCE);
				INTERESTTYPERATE = "NULL";
			}
			else
			{
				rateno = "NULL";
				varcode = "NULL";
				VARIANCE = "NULL";
				INTERESTTYPERATE = tool.ConvertFloat(INTERESTTYPERATE);
			}

			conn.QueryString = "PARAM_GENERAL_RFPRODUCT_MAKER '"+ LBL_SAVEMODE.Text.Trim() + "', '" +
				TXT_PRODUCTID.Text.Trim() + "', '" + TXT_PRODUCTDESC.Text.Trim() + "', '" + 
				DDL_CURRENCY.SelectedValue.Trim() + "', NULL, NULL, '" + RDO_REVOLVING.SelectedValue.Trim() +
				"', '" + RDO_ISCASHLOAN.SelectedValue.Trim() + "', NULL, '" + TXT_SIBS_PRODCODE.Text.Trim() +
				"', '1', " + rateno + ", " + varcode + ", " + VARIANCE + ", '" + RDO_SPK.SelectedValue.Trim() +
				"', '" + DDL_INTERESTREST.SelectedValue.Trim() + "', '" + RDO_ISINSTALLMENT.SelectedValue.Trim() +
				"', '" + DDL_INTERESTTYPE.SelectedValue.Trim() + "', NULL, " + INTERESTTYPERATE + ", '" +
				TXT_SIBS_PRODID.Text.Trim() + "', '" + DDL_INSTALLMENTTYPE.SelectedValue.Trim() + "', '" +
				RDO_CONFIRMKORAN.SelectedValue.Trim() + "' ";
			conn.ExecuteQuery();

			// menghapus data preset_rate jika ada dan jika interesttype != alternate rate
			if ((DDL_INTERESTTYPE.SelectedValue != "03") || (RBL_NEGO.SelectedValue != "0"))
			{
				clearAlternateRate();
			}

			bindData2();
			clearEditBoxes();
			//Tools.popMessage(this, "Data added for insertion/modification!");
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearAlternateRate();
			clearEditBoxes();
		}

		private void clearAlternateRate()
		{
			try
			{
				//hapus preset alternaterate jika ada
				conn.QueryString  = "delete * from RFPRODUCT_PRESETRATE ";
				conn.QueryString += "where PRODUCTID = '" + TXT_PRODUCTID.Text.Trim() + "'";
				conn.ExecuteQuery();
			}
			catch(Exception)
			{
				//GlobalTools.popMessage(this, "Server Error when it's trying to delete record from Preset Alternate Rate");
			}
		}

		private void Datagrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					LBL_SAVEMODE.Text = "0";
					TXT_PRODUCTID.Text = e.Item.Cells[0].Text.Trim();
					TXT_PRODUCTDESC.Text = e.Item.Cells[1].Text.Trim();
					TXT_SIBS_PRODID.Text = e.Item.Cells[21].Text.Trim();
					TXT_SIBS_PRODCODE.Text = e.Item.Cells[2].Text.Trim();
					DDL_CURRENCY.SelectedValue = e.Item.Cells[19].Text.Trim();
					fillRateNumber();
					try
					{
						DDL_RATENO.SelectedValue = e.Item.Cells[12].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_RATE.SelectedValue = e.Item.Cells[12].Text.Trim();
						TXT_RATE.Text = DDL_RATE.SelectedItem.Text;
					} 
					catch {}
					try
					{
						DDL_INTERESTREST.SelectedValue = e.Item.Cells[5].Text.Trim();
					} 
					catch {}
					try
					{
						if (e.Item.Cells[8].Text.Trim() == "YES")
							RDO_REVOLVING.SelectedValue = "1";
						else
							RDO_REVOLVING.SelectedValue = "0";
					} 
					catch {}
					try
					{
						if (e.Item.Cells[7].Text.Trim() == "YES")
							RDO_ISCASHLOAN.SelectedValue = "1";
						else
							RDO_ISCASHLOAN.SelectedValue = "0";
					} 
					catch {}
					try
					{
						RDO_VARCODE.SelectedValue = e.Item.Cells[14].Text.Trim();
					} 
					catch {}
					TXT_VARIANCE.Text = e.Item.Cells[15].Text.Trim();
					try
					{
						if (e.Item.Cells[16].Text.Trim() == "YES")
							RDO_SPK.SelectedValue = "1";
						else
							RDO_SPK.SelectedValue = "0";
					} 
					catch {}
					try
					{
						if (e.Item.Cells[17].Text.Trim() == "INSTALLMENT")
							RDO_ISINSTALLMENT.SelectedValue = "1";
						else
							RDO_ISINSTALLMENT.SelectedValue = "0";
					} 
					catch {}
					try 
					{
						DDL_INTERESTTYPE.SelectedValue = e.Item.Cells[20].Text.Trim();
					} 
					catch {}
					try 
					{
						DDL_INSTALLMENTTYPE.SelectedValue = e.Item.Cells[22].Text.Trim();
					} 
					catch {}
					try
					{
						if (e.Item.Cells[24].Text.Trim() == "YES")
							RDO_CONFIRMKORAN.SelectedValue = "1";
						else
							RDO_CONFIRMKORAN.SelectedValue = "0";
					} 
					catch {}
					TXT_INTERESTTYPERATE.Text = e.Item.Cells[11].Text.Trim();
					cleansTextBox(TXT_PRODUCTID);
					cleansTextBox(TXT_PRODUCTDESC);
					cleansTextBox(TXT_SIBS_PRODCODE);
					cleansTextBox(TXT_SIBS_PRODID);
					cleansTextBox(TXT_RATE);
					cleansTextBox(TXT_VARIANCE);
					cleansTextBox(TXT_INTERESTTYPERATE);
					activatePostBackControls(false);
					enInterestVal(DDL_INTERESTTYPE.SelectedValue.Trim());
					break;
				case "delete":
					string prodid = e.Item.Cells[0].Text.Trim();
					conn.QueryString = "PARAM_GENERAL_RFPRODUCT_MAKER '2', '"+ prodid + "' ";
					conn.ExecuteQuery();
					bindData2();
					//Tools.popMessage(this, "Data added for deletion!");
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					LBL_SAVEMODE.Text = e.Item.Cells[24].Text.Trim();
					if (LBL_SAVEMODE.Text.Trim() == "2")
					{
						LBL_SAVEMODE.Text = "1";
						break;
					}
					TXT_PRODUCTID.Text = e.Item.Cells[0].Text.Trim();
					TXT_PRODUCTDESC.Text = e.Item.Cells[1].Text.Trim();
					TXT_SIBS_PRODID.Text = e.Item.Cells[25].Text.Trim();
					TXT_SIBS_PRODCODE.Text = e.Item.Cells[2].Text.Trim();
					DDL_CURRENCY.SelectedValue = e.Item.Cells[22].Text.Trim();
					fillRateNumber();
					try
					{
						DDL_RATENO.SelectedValue = e.Item.Cells[12].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_RATE.SelectedValue = e.Item.Cells[12].Text.Trim();
						TXT_RATE.Text = DDL_RATE.SelectedItem.Text;
					} 
					catch {}
					try
					{
						DDL_INTERESTREST.SelectedValue = e.Item.Cells[5].Text.Trim();
					} 
					catch {}
					try
					{
						if (e.Item.Cells[8].Text.Trim() == "YES")
							RDO_REVOLVING.SelectedValue = "1";
						else
							RDO_REVOLVING.SelectedValue = "0";
					} 
					catch {}
					try
					{
						if (e.Item.Cells[7].Text.Trim() == "YES")
							RDO_ISCASHLOAN.SelectedValue = "1";
						else
							RDO_ISCASHLOAN.SelectedValue = "0";
					} 
					catch {}
					try
					{
						RDO_VARCODE.SelectedValue = e.Item.Cells[14].Text.Trim();
					} 
					catch {}
					TXT_VARIANCE.Text = e.Item.Cells[15].Text.Trim();
					try
					{
						if (e.Item.Cells[16].Text.Trim() == "YES")
							RDO_SPK.SelectedValue = "1";
						else
							RDO_SPK.SelectedValue = "0";
					} 
					catch {}
					try
					{
						if (e.Item.Cells[17].Text.Trim() == "INSTALLMENT")
							RDO_ISINSTALLMENT.SelectedValue = "1";
						else
							RDO_ISINSTALLMENT.SelectedValue = "0";
					} 
					catch {}
					try 
					{
						DDL_INTERESTTYPE.SelectedValue = e.Item.Cells[23].Text.Trim();
					} 
					catch {}
					try
					{
						if (e.Item.Cells[20].Text.Trim() == "YES")
							RDO_CONFIRMKORAN.SelectedValue = "1";
						else
							RDO_CONFIRMKORAN.SelectedValue = "0";
					} 
					catch {}
					TXT_INTERESTTYPERATE.Text = e.Item.Cells[11].Text.Trim();
					cleansTextBox(TXT_PRODUCTID);
					cleansTextBox(TXT_PRODUCTDESC);
					cleansTextBox(TXT_SIBS_PRODCODE);
					cleansTextBox(TXT_SIBS_PRODID);
					cleansTextBox(TXT_RATE);
					cleansTextBox(TXT_VARIANCE);
					cleansTextBox(TXT_INTERESTTYPERATE);
					activatePostBackControls(false);
					enInterestVal(DDL_INTERESTTYPE.SelectedValue.Trim());
					break;
				case "delete":
					string PRODUCTID = e.Item.Cells[0].Text.Trim();
					conn.QueryString = "DELETE FROM PENDING_RFPRODUCT WHERE PRODUCTID = '"+ PRODUCTID + "' ";
					conn.ExecuteQuery();
					bindData2();
					break;
				default:
					// Do nothing.
					break;
			}
		}

		protected void DDL_RATENO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_RATE.SelectedIndex = DDL_RATENO.SelectedIndex;
			TXT_RATE.Text = DDL_RATE.SelectedItem.Text;
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("../GeneralParam.aspx?mc=" + Request.QueryString["mc"]);
			Response.Redirect("../GeneralParam.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void DDL_INTERESTTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_INTERESTTYPE.SelectedValue.Trim() == "03")
			{
				//GlobalTools.popMessage(this, "OK");
				RBL_NEGO.Enabled = true;
				if ((TXT_PRODUCTID.Text.Trim() != "") && (RBL_NEGO.SelectedValue == "0") && (DDL_CURRENCY.SelectedIndex != 0))
					BTN_ALTERNATE_RATE.Visible = true;
			} 
			else
			{
				RBL_NEGO.SelectedValue = "0";
				RBL_NEGO.Enabled = false;
			}
			//GlobalTools.popMessage(this,"Luar");
			enInterestVal(DDL_INTERESTTYPE.SelectedValue.Trim());
		}

		protected void DDL_CURRENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillRateNumber();
			if ( (DDL_INTERESTTYPE.SelectedValue.Trim() == "03") && (RBL_NEGO.SelectedValue == "0") && 
				(TXT_PRODUCTID.Text.Trim() != "") && (DDL_CURRENCY.SelectedIndex != 0))
			{ // jika productid sudah diisi, diset NEGO, currency sudah dipilih, tipenya alt rate
				BTN_ALTERNATE_RATE.Visible = true;
			}
			else
			{
				BTN_ALTERNATE_RATE.Visible = false;
			}
		}

		protected void RBL_NEGO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( (DDL_INTERESTTYPE.SelectedValue.Trim() == "03") && (RBL_NEGO.SelectedValue == "0") && 
				(TXT_PRODUCTID.Text.Trim() != "") && (DDL_CURRENCY.SelectedIndex != 0))
			{ // jika productid sudah diisi, diset NEGO, currency sudah dipilih, tipenya alt rate
				BTN_ALTERNATE_RATE.Visible = true;
			}
			else
			{
				RBL_NEGO.SelectedValue = "1";
				BTN_ALTERNATE_RATE.Visible = false;
			}
		}

		protected void BTN_ALTERNATE_RATE_Click(object sender, System.EventArgs e)
		{
			/*// Pastikan produk yang akan diberi preset rate HARUS sudah disimpan terlebih dahulu
			// Pastikan produkID ada di basis data
			conn.QueryString = "select PRODUCTID, RATENO, CURRENCY from RFPRODUCT where PRODUCTID = '" + TXT_PRODUCTID.Text.Trim();
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 1)
			{ // produk ada di basis data
				// ambil rateno dan currency, jadikan param bersama productid
				//Response.Write("<script language='Javascript'>PopupPage('AlternateRate.aspx?productid=" + TXT_PRODUCTID.Text.Trim() + "','900','350'));</script>"); 
				string prodid = conn.GetFieldValue("PRODUCTID");
				string rateno = conn.GetFieldValue("RATENO");
				string currency = conn.GetFieldValue("CURRENCY");
				Response.Write("<script language='javascript'>window.open('AlternateRate.aspx?productid=" + prodid + "&rateno=" + rateno + "&currency=" + currency + "','PresetAlternateRate','status=no,scrollbars=no,width=800,height=350');</script>");
			}*/
			if (TXT_PRODUCTID.Text.Trim() != "")
			{
				Response.Write("<script language='javascript'>window.open('AlternateRate.aspx?productid=" + TXT_PRODUCTID.Text.Trim() + "&rateno=" + DDL_RATENO.SelectedValue + "&currency=" + DDL_CURRENCY.SelectedValue + "','PresetAlternateRate','status=no,scrollbars=no,width=1000,height=350');</script>");
			}
			else
			{ // tampilkan pesan bahwa data harus di-save terlebih dahulu
				//GlobalTools.popMessage(this, "Data produk harap disimpan terlebih dahulu!");
				GlobalTools.popMessage(this, "PRODUCTID tidak boleh kosong!");
			}
		}
	}
}
