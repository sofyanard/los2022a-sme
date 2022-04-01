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

namespace  SME.InitialDataEntry.Channeling
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class InitiationMainPage : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();

			conn.QueryString = "SELECT AP_ACQINFO FROM APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if(conn.GetFieldValue("AP_ACQINFO") != "")
			{
				//GlobalTools.popMessage(this, conn.GetFieldValue("AP_ACQINFO").ToString());
				Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?pesan=" + conn.GetFieldValue("AP_ACQINFO") + "&theForm=Form1', '800','350');</script>");			
			}

			if (!IsPostBack)
			{
				conn2.QueryString = "EXEC CHANNELING_VIEWDATA_INITIATIONMAINPAGE '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["parentregno"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["prodseq"] + "'";
				conn2.ExecuteQuery(); 

				conn.QueryString = "EXEC INSERTAPPTRACK '" + Request.QueryString["regno"] + "','1', '" + conn2.GetFieldValue("PRODUCTID") + "','TCHAN1.0','" + Session["UserID"].ToString() + "','0'";
				conn.ExecuteQuery();

				FillDropDownListDateAndApplicationNumber();


				conn.QueryString = "SELECT MONTH(AP_RECVDATE) as mth, DAY(AP_RECVDATE) as dy,YEAR(AP_RECVDATE) as yr FROM APPLICATION where ap_regno = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				txt_DD_B.Text = conn.GetFieldValue("dy");
				ddl_MM_B.SelectedValue = conn.GetFieldValue("mth");
				txt_YY_B.Text = conn.GetFieldValue("yr");

				conn.QueryString = "select AP_CCOBRANCH from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("AP_CCOBRANCH");
			}
			ViewMenu();
			cekWheterUpdateStatusNeededToBeActived();
			BTN_UPDATE_STATUS.Attributes.Add("onclick","if(!updateMsg('D')){return false;};"); 

		}

		private void cekWheterUpdateStatusNeededToBeActived()
		{
			conn.QueryString = "SELECT * FROM APPLICATION WHERE APREGNO_INDUK = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				BTN_UPDATE_STATUS.Enabled = true;
			}
		}

		private void FillDropDownListDateAndApplicationNumber()
		{
			IsiTanggal();

			conn.QueryString = "select branch_name, branch_code from rfbranch where active='1' order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default booking branch
			DDL_AP_BOOKINGBRANCH.SelectedValue = conn2.GetFieldValue("SU_BRANCH");

			conn.QueryString = "select branch_name, branch_code from vw_ccobranch order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default cco branch
			conn.QueryString = "select br_ccobranch from rfbranch where branch_code = '" + Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();
			DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("br_ccobranch");

			//isi default tanggal
			txt_DD_B.Text = conn2.GetFieldValue("dy");
			ddl_MM_B.SelectedValue = conn2.GetFieldValue("mth");
			txt_YY_B.Text = conn2.GetFieldValue("yr");

			LBL_PLAFOND_OWNER.Text = conn2.GetFieldValue("CU_NAME");
			LBL_REMAINING_EMAS.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("REMAINING_EMAS_LIMIT"));
			LBL_PENDING_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("PENDING_LIMIT"));
			LBL_AVAILBALE_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("AVAILABLE_LIMIT"));
			TXT_APPLICATION.Text = Request.QueryString["regno"];
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"]+"&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"]+"&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
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

		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B, ddl_MM_B, txt_YY_B, true);
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE APPLICATION SET AP_CCOBRANCH = '" + DDL_AP_CCOBRANCH.SelectedValue + "' WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			Tools.popMessage(this, "CO Branch telah terupdate !");
		}

		private void updateRemainingEmasLimit(string regno, string parent)
		{
			conn2.QueryString = "EXEC CHANNELING_UPDATE_REMAINING_EMAS_LIMIT '" + regno + "','" + parent + "'";
			conn2.ExecuteQuery();
		}

		protected void BTN_UPDATE_STATUS_Click(object sender, System.EventArgs e)
		{
			//cek check box dicentang ga (existing opo ora)

			if(CB_EndUser.Checked)
			{
				//create existing bookedprod
				conn.QueryString = "EXEC CHANNELING_CREATE_ENDUSER_BOOKEDPROD '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				//update CP Limit di CUSTPRODUCT
				conn.QueryString = "SELECT AP_REGNO FROM APPLICATION WHERE APREGNO_INDUK = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				for(int i=0; i<conn.GetRowCount(); i++)
				{
					updateRemainingEmasLimit(conn.GetFieldValue(i, "AP_REGNO"), Request.QueryString["parentregno"]);
				}				

				//update semua track ke 5.6
				conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["userid"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','5.6'";
				conn.ExecuteQuery();

				//response redirect ke listinitiation msg
				Response.Redirect("ListInitiation.aspx?msg=existing");
			}
			else
			{
				conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["userid"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN2.0'";
				conn.ExecuteQuery();
			
				Response.Redirect("ListInitiation.aspx?msg=ok");
			}
		}
	}
}
