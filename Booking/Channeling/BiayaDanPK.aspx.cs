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
namespace SME.Booking.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class BiayaDanPK : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.PlaceHolder SubMenu;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				
			}

			ViewMenu();

			BindData("dgListChan","EXEC CHANNELING_VIEWDATA_BIAYADANPK '" + Request.QueryString["regno"] + "'");
			BindDgListChan();
			BindDgListChanDefault();
			PutExistingData();

			LABELKODEAPNO.Visible = false;
		}

		private void BindDgListChanDefault()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				conn.QueryString = "EXEC CHANNELING_VIEWDATA_BIAYADANPK_PERANAK '" + dgListChan.Items[i].Cells[0].Text.ToString() + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
				{
					TextBox TXT_NO_PK = (TextBox) dgListChan.Items[i].Cells[2].FindControl("TXT_NO_PK." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_NO_PK != null)
					{
						TXT_NO_PK.Text= conn.GetFieldValue("NOPK");
						LABELKODEAPNO.Text = conn.GetFieldValue("NOPK");
					}
					
					TextBox TXT_TANGGAL_PK_DD = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_DD." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_TANGGAL_PK_DD != null)
					{
						TXT_TANGGAL_PK_DD.Text = GlobalTools.FormatDate_Day(conn.GetFieldValue("SYSTEMDATE"));
					}
					
					DropDownList DDL_TANGGAL_PK_MM = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_TANGGAL_PK_MM." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(DDL_TANGGAL_PK_MM != null)
					{
						DDL_TANGGAL_PK_MM.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue("SYSTEMDATE"));
					}

					TextBox TXT_TANGGAL_PK_YY = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_YY." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_TANGGAL_PK_YY != null)
					{
						TXT_TANGGAL_PK_YY.Text = GlobalTools.FormatDate_Year(conn.GetFieldValue("SYSTEMDATE"));
					}

					TextBox TXT_PERSEN = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_PERSEN." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_PERSEN != null)
					{
						TXT_PERSEN.Text = conn.GetFieldValue("PROVISI");
					}
					
					TextBox TXT_NUMBER = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_NUMBER." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_NUMBER != null)
					{
						TXT_NUMBER.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("PROVISINUMBER"));
					}
					
					TextBox TXT_ADMINISTRATION = (TextBox) dgListChan.Items[i].Cells[6].FindControl("TXT_ADMINISTRATION." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_ADMINISTRATION != null)
					{
						TXT_ADMINISTRATION.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("ADMINISTRASI"));
					}
				}
			}
		}

		private void PutExistingData()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				conn.QueryString = "EXEC CHANNELING_GETDATA_BIAYADANPK '" + dgListChan.Items[i].Cells[0].Text.ToString() + "'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
				{
					TextBox TXT_NO_PK = (TextBox) dgListChan.Items[i].Cells[2].FindControl("TXT_NO_PK." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_NO_PK != null)
					{
						TXT_NO_PK.Text= conn.GetFieldValue("APL_PKNO");
					}
					
					TextBox TXT_TANGGAL_PK_DD = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_DD." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_TANGGAL_PK_DD != null)
					{
						TXT_TANGGAL_PK_DD.Text = GlobalTools.FormatDate_Day(conn.GetFieldValue("APL_PKDATE"));
					}
					
					DropDownList DDL_TANGGAL_PK_MM = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_TANGGAL_PK_MM." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(DDL_TANGGAL_PK_MM != null)
					{
						DDL_TANGGAL_PK_MM.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue("APL_PKDATE"));
					}

					TextBox TXT_TANGGAL_PK_YY = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_YY." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_TANGGAL_PK_YY != null)
					{
						TXT_TANGGAL_PK_YY.Text = GlobalTools.FormatDate_Year(conn.GetFieldValue("APL_PKDATE"));
					}

					TextBox TXT_PERSEN = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_PERSEN." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_PERSEN != null)
					{
						TXT_PERSEN.Text =  GlobalTools.MoneyFormat(conn.GetFieldValue("APL_BEAPROVISI_PCT"));
					}
					
					TextBox TXT_NUMBER = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_NUMBER." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_NUMBER != null)
					{
						TXT_NUMBER.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("APL_BEAPROVISI"));
					}
					
					TextBox TXT_ADMINISTRATION = (TextBox) dgListChan.Items[i].Cells[6].FindControl("TXT_ADMINISTRATION." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_ADMINISTRATION != null)
					{
						TXT_ADMINISTRATION.Text =  GlobalTools.MoneyFormat(conn.GetFieldValue("APL_BEAADM"));
					}
				}
			}
		}

		private void BindDgListChan()
		{

			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				TextBox TXT_NO_PK = (TextBox) dgListChan.Items[i].Cells[2].FindControl("TXT_NO_PK");
				if(TXT_NO_PK != null)
				{
					TXT_NO_PK.ID = "TXT_NO_PK." + dgListChan.Items[i].Cells[0].Text.ToString();
				}

				/*** Button Process ***/
				TextBox TXT_TANGGAL_PK_DD = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_DD");
				if(TXT_TANGGAL_PK_DD != null)
				{
					TXT_TANGGAL_PK_DD.ID = "TXT_TANGGAL_PK_DD." + dgListChan.Items[i].Cells[0].Text.ToString();
				}

				DropDownList DDL_TANGGAL_PK_MM = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_TANGGAL_PK_MM");
				if(DDL_TANGGAL_PK_MM != null)
				{
					DDL_TANGGAL_PK_MM.ID = "DDL_TANGGAL_PK_MM." + dgListChan.Items[i].Cells[0].Text.ToString();
				}

				TextBox TXT_TANGGAL_PK_YY = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_YY");
				if(TXT_TANGGAL_PK_YY != null)
				{
					TXT_TANGGAL_PK_YY.ID = "TXT_TANGGAL_PK_YY." + dgListChan.Items[i].Cells[0].Text.ToString();
				}

				TextBox TXT_PERSEN = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_PERSEN");
				if(TXT_PERSEN != null)
				{
					TXT_PERSEN.ID = "TXT_PERSEN." + dgListChan.Items[i].Cells[0].Text.ToString();
				}
				
				TextBox TXT_NUMBER = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_NUMBER");
				if(TXT_NUMBER != null)
				{
					TXT_NUMBER.ID = "TXT_NUMBER." + dgListChan.Items[i].Cells[0].Text.ToString();
				}
				
				TextBox TXT_ADMINISTRATION = (TextBox) dgListChan.Items[i].Cells[6].FindControl("TXT_ADMINISTRATION");
				if(TXT_ADMINISTRATION != null)
				{
					TXT_ADMINISTRATION.ID = "TXT_ADMINISTRATION." + dgListChan.Items[i].Cells[0].Text.ToString();
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
			this.dgListChan.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgListChan_ItemCreated);

		}
		#endregion


		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
		}

		private void dgListChan_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgListChan = (DataGrid) e.Item.FindControl("dgListChan");

			TextBox txt_tanggalpkdd= (TextBox) e.Item.FindControl("TXT_TANGGAL_PK_DD");
			if(txt_tanggalpkdd != null)
			{
				DropDownList ddl_tanggalpkmm = (DropDownList) e.Item.FindControl("DDL_TANGGAL_PK_MM");
				if(ddl_tanggalpkmm != null)
				{
					TextBox txt_tanggalpkyy = (TextBox) e.Item.FindControl("TXT_TANGGAL_PK_YY");
					if(txt_tanggalpkyy != null)
					{
						IsiTanggal(txt_tanggalpkdd, ddl_tanggalpkmm, txt_tanggalpkyy);
					}
				}
			}
		}

		private void IsiTanggal(TextBox a, DropDownList ddl, TextBox b)
		{
			GlobalTools.initDateFormINA(a, ddl, b, true);
		}

		protected void BTN_UPDATE_STATUS_Click(object sender, System.EventArgs e)
		{
			try
			{
				for(int i=0; i< dgListChan.Items.Count; i++)
				{
					//bikin date dulu disini
					string day = "";
					string month = "";
					string year = "";

					TextBox TXT_TANGGAL_PK_DD = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_DD." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_TANGGAL_PK_DD != null)
					{
						day = TXT_TANGGAL_PK_DD.Text.ToString();
					}

					DropDownList DDL_TANGGAL_PK_MM = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_TANGGAL_PK_MM." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(DDL_TANGGAL_PK_MM != null)
					{
						month = DDL_TANGGAL_PK_MM.SelectedValue.ToString();
					}

					TextBox TXT_TANGGAL_PK_YY = (TextBox) dgListChan.Items[i].Cells[3].FindControl("TXT_TANGGAL_PK_YY." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_TANGGAL_PK_YY != null)
					{
						year = TXT_TANGGAL_PK_YY.Text.ToString();
					}

					string thedate = GlobalTools.ConvertDate(day, month, year);

					/***************************NO PK******************************************/

					string nopk = "";

					TextBox TXT_NO_PK = (TextBox) dgListChan.Items[i].Cells[2].FindControl("TXT_NO_PK." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_NO_PK != null)
					{
						nopk = TXT_NO_PK.Text.ToString();
					}

					/************************** PROVISIPERCENT ********************************/
					double provisipercent = 0.0;

					TextBox TXT_PERSEN = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_PERSEN." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_PERSEN != null)
					{
						provisipercent = MyConnection.ChannelingOnlyConvertToDouble(TXT_PERSEN.Text.ToString());
					}

					/************************* NUMBER **************************************/
					double numberprovisi = 0.0;

					TextBox TXT_NUMBER = (TextBox) dgListChan.Items[i].Cells[4].FindControl("TXT_NUMBER." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_NUMBER != null)
					{
						numberprovisi = MyConnection.ChannelingOnlyConvertToDouble(TXT_NUMBER.Text.ToString());
					}

					/************************* ADMINISTRATION **************************************/
					double administration = 0.0;

					TextBox TXT_ADMINISTRATION = (TextBox) dgListChan.Items[i].Cells[6].FindControl("TXT_ADMINISTRATION." + dgListChan.Items[i].Cells[0].Text.ToString());
					if(TXT_ADMINISTRATION != null)
					{
						administration = MyConnection.ChannelingOnlyConvertToDouble(TXT_ADMINISTRATION.Text.ToString());
					}

					conn.QueryString = "EXEC CHANNELING_SAVE_BIAYADANPK '" + dgListChan.Items[i].Cells[0].Text.ToString() + "','"
						+ nopk + "'," 
						+ thedate  + "," 
						+ provisipercent + "," 
						+ numberprovisi + ","
						+ administration + "";
					conn.ExecuteNonQuery();
				}

				PutExistingData();
				Tools.popMessage(this, "The data has been saved !");
			}
			catch
			{
				Tools.popMessage(this, "The data is invalid !");
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			int num = int.Parse(txt_nopk.Text.ToString());

			conn.QueryString = "SELECT YEAR(getdate()) as THEYEAR";
			conn.ExecuteQuery();

			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				TextBox TXT_NO_PK = (TextBox) dgListChan.Items[i].Cells[2].FindControl("TXT_NO_PK." + dgListChan.Items[i].Cells[0].Text.ToString());
				TXT_NO_PK.Text = TXT_KODE.Text;
				if(TXT_NO_PK != null)
				{
					TXT_NO_PK.Text = TXT_NO_PK.Text.ToString() + ((int)(num++)).ToString() + "/" + conn.GetFieldValue("THEYEAR");
				}
			}
		}
	}
}
