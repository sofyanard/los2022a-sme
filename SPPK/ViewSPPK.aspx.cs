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

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for ViewSPPK.
	/// </summary>
	public partial class ViewSPPK : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.Button btn_viewsppk;
		protected System.Web.UI.WebControls.PlaceHolder Placeolder1;
		protected Tools tool = new Tools();
		protected string szBU = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}
			ViewMenu();

			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);			
			BTN_RECALC_INSTALLMENT.Click += new EventHandler(BTN_RECALC_INSTALLMENT_Click);
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];

			conn.QueryString = "Select AP_BUSINESSUNIT from APPLICATION where ap_regno = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();

			szBU = conn.GetFieldValue("AP_BUSINESSUNIT");

			HyperLink strcre = new HyperLink();
			strcre.Text = "Credit Structure";
			strcre.Font.Bold = true;
			strcre.NavigateUrl = "../dataentry/custproduct.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&sta=view";
			strcre.Target = "if2";

			HyperLink collateral = new HyperLink();
			collateral.Text = "Collateral";
			collateral.Font.Bold = true;
			collateral.NavigateUrl = "../dataentry/jaminan_detail.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&sta=view";
			collateral.Target = "if2";

			HyperLink SPPKExport = new HyperLink();
			SPPKExport.Text = "Export SPPK";
			SPPKExport.Font.Bold = true;
			SPPKExport.NavigateUrl = "SPPKExport.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&sta=view";
			SPPKExport.Target = "if2";


			PlaceHolder1.Controls.Add(strcre);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(collateral);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(SPPKExport);
		}

		private void reCalculateInstallment(string regno)
		{
			/// Get the latest credit status
			/// (Approved credit)
			/// 
			conn.QueryString = "select * from vw_custproduct where ap_regno = '"+ regno +"' and apptype in ('01', '03', '06')";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable();

			double _result = 0;
			double _cp_exlimitval = 0, _interest = 0;;
			int _cp_jangkawkt = 0;
			string _cp_tenorcode = "M";

			try 
			{				
				for(int i=0; i < dt.Rows.Count; i++) 
				{	
					// get limit
					try { _cp_exlimitval = double.Parse(dt.Rows[i]["cp_exlimitval"].ToString()); } 
					catch { _cp_exlimitval = 0; }

					// get tenor
					try { _cp_jangkawkt = int.Parse(dt.Rows[i]["cp_jangkawkt"].ToString()); } 
					catch { _cp_jangkawkt = 0; }

					// get tenorcode
					try { _cp_tenorcode = dt.Rows[i]["cp_tenorcode"].ToString(); } 
					catch {}
					_cp_tenorcode = (_cp_tenorcode==""||_cp_tenorcode==null?"M":_cp_tenorcode);

					/// Get interest value, according chosen product 
					/// 
					conn.QueryString = "select interesttype from rfproduct where productid = '" + dt.Rows[i]["productid"].ToString() + "'";
					conn.ExecuteQuery();
					DataTable dt2 = conn.GetDataTable();

					/// If interest type is Floating (01) or Alternate Rate (03) ...
					/// 
					if (dt2.Rows[0]["interesttype"].ToString() == "01" || dt2.Rows[0]["interesttype"].ToString() == "03")
					{
						conn.QueryString = "select * from vw_floatingrate where productid = '" + dt.Rows[i]["productid"].ToString() + "'";
						conn.ExecuteQuery();
						try { _interest = double.Parse(conn.GetFieldValue("rate")); } 
						catch { _interest = 0; }
					}
					else  // Interest Type is Fixed (02)
					{
						conn.QueryString = "select interesttyperate from rfproduct where productid = '" + dt.Rows[i]["productid"].ToString() + "'";
						conn.ExecuteQuery();
						try { _interest = double.Parse(conn.GetFieldValue("interesttyperate"));	} 
						catch { _interest = 0; }
					}

					try 
					{
						_result = DMS.CuBESCore.Logic.hitungInstalment(_cp_exlimitval, _cp_jangkawkt, _interest, dt.Rows[i]["productid"].ToString(), _cp_tenorcode, conn);
						if (Double.IsInfinity(_result) || Double.IsNaN(_result)) 
						{
							_result = 0;
						}
					} 
					catch 
					{ 
						_result = 0; 
					}

					conn.QueryString = "exec SPPK_RECALC_INSTALLMENT '" + 
						regno + "', '" + 
						dt.Rows[i]["apptype"].ToString() + "', '" + 
						dt.Rows[i]["productid"].ToString() + "', '" + 
						dt.Rows[i]["prod_seq"].ToString() + "', '" + 
						dt.Rows[i]["ket_code"].ToString() + "', " +
						tool.ConvertFloat(_result.ToString()) + "";
					conn.ExecuteNonQuery();
				}
			} 
			catch (Exception exn)
			{
				Response.Write("<!-- Most Outer : " + exn.ToString() + " -->");
				throw new Exception();
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

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));			

			if (Request.QueryString["tc"] == "3.6" && Request.QueryString["mc"] == "039") 
			{
				Response.Redirect("/SME/SPPK/ListSPPKMonitor.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
			else 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			ViewData();
			Response.Write("<script language='javascript'>window.open('/SME/Letters/SPPKEntry.aspx?bu=" + szBU + "&regno=" + Request.QueryString["regno"] + "&mc= " + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] +"','SPPKLetter','status=no,scrollbars=yes,width=1000,height=600');</script>");
		}

		private void BTN_RECALC_INSTALLMENT_Click(object sender, EventArgs e)
		{
			try 
			{
				reCalculateInstallment(Request.QueryString["regno"]);
			} 
			catch (Exception ex)
			{
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, Request.QueryString["regno"]);
				Response.Write("<!-- " + ex.ToString() + " -->");
			}

			ViewData();
		}
	}
}
