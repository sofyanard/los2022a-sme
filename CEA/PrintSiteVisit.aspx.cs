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
using DMS.BlackList;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for PrintSiteVisit.
	/// </summary>
	public partial class PrintSiteVisit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label B;
		protected System.Web.UI.WebControls.Label C;
		protected System.Web.UI.WebControls.Label D;
		protected System.Web.UI.WebControls.Label E;
		protected System.Web.UI.WebControls.Label F;

		protected Tools tool = new Tools();

		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx"); */

			if(!IsPostBack)
			{
				//ViewData();
            }
			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if(conn.GetFieldValue("rekanantypeid")=="01")
				conn.QueryString = "select namerekanan, address1, address2, city, phone_area + '-' + phone# as telp from vw_rekanan_company where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";
			else
				conn.QueryString = "select namerekanan, address1, address2, city, office_area + '-' + office# as telp from vw_rekanan_personal where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";

			conn.ExecuteQuery();

			LBL_NAMA.Text = conn.GetFieldValue("namerekanan");
			LBL_ALAMAT.Text = conn.GetFieldValue("address1") + " " + conn.GetFieldValue("address2");
			LBL_CITY.Text = conn.GetFieldValue("city");
			
			LBL_TELP.Text = conn.GetFieldValue("telp");

			conn.QueryString = "select address1 + ' ' + add#1 + ' ' + add_city1 as alamatcabang1, address2 + ' ' + add#2 + ' ' + add_city2 as alamatcabang2 from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			ALAMAT_CABANG1.Text = conn.GetFieldValue("alamatcabang1");
			ALAMAT_CABANG2.Text = conn.GetFieldValue("alamatcabang2");

			conn.QueryString = "select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			TGL_KUNJUNGAN.Text = tool.FormatDate(conn.GetFieldValue("tgl_kunjungan"));
			DITERIMA1.Text = conn.GetFieldValue("diterima1");
			DITERIMA2.Text = conn.GetFieldValue("diterima2");
			DITERIMA3.Text = conn.GetFieldValue("diterima3");
			LBL_AREA.Text = conn.GetFieldValue("area");
			RDO_STATUS.SelectedValue = conn.GetFieldValue("status");
			OWN_AGE.Text = conn.GetFieldValue("own_age");
			SINCE.Text = conn.GetFieldValue("since");
			CP1.Text = conn.GetFieldValue("pic1");
			CP2.Text = conn.GetFieldValue("pic2");
			CP3.Text = conn.GetFieldValue("pic3");
			EMPLOYEE.Text = conn.GetFieldValue("employee");
			EXPERT.Text = conn.GetFieldValue("expert");
			ADMIN.Text = conn.GetFieldValue("admin");
			OUTSOURCE.Text = conn.GetFieldValue("outsource");
			RDO_EQUITMENT.SelectedValue = conn.GetFieldValue("equitment");
			RDO_DB.SelectedValue = conn.GetFieldValue("database_rsv");
			RDO_BUILDING.SelectedValue = conn.GetFieldValue("building");
			ARSIP_ROOM.SelectedValue = conn.GetFieldValue("arsip_room");
			ACTIVITY1.Text = conn.GetFieldValue("activity1");
			ACTIVITY2.Text = conn.GetFieldValue("activity2");
			SC_ADD.Text = conn.GetFieldValue("sc_add");
			SC_SARANA.Text = conn.GetFieldValue("sc_sarana");
			SC_DATABASE.Text =  conn.GetFieldValue("SC_DATABASE");
			SC_EQUITMENT.Text = conn.GetFieldValue("SC_EQUITMENT");
			SC_BUILDING.Text = conn.GetFieldValue("SC_BUILDING");
			SC_RESOURCE.Text = conn.GetFieldValue("SC_RESOURCE");
			SC_TOT.Text = conn.GetFieldValue("SC_TOT");

			CekA();
			CekB();
			CekC();
			CekD();
			CekE();
			CekF();
			
		}

		private void CekA()
		{
			if (SC_ADD.Text=="0,1")
			{
				A1.Visible=true;
				A2.Visible=false;
				A3.Visible=false;
				A4.Visible=false;
				A5.Visible=false; 
			}

			else if (SC_ADD.Text=="0,2")
			{
				A1.Visible=false;
				A2.Visible=true;
				A3.Visible=false;
				A4.Visible=false;
				A5.Visible=false;
			}

			else if (SC_ADD.Text=="0,3")
			{
				A1.Visible=false;
				A2.Visible=false;
				A3.Visible=true;
				A4.Visible=false;
				A5.Visible=false;
			}

			else if (SC_ADD.Text=="0,4")
			{
				A1.Visible=false;
				A2.Visible=false;
				A3.Visible=false;
				A4.Visible=true;
				A5.Visible=false;
			}

			else if (SC_ADD.Text=="0,5")
			{
				A1.Visible=false;
				A2.Visible=false;
				A3.Visible=false;
				A4.Visible=false;
				A5.Visible=true;
			}

		}

		private void CekB()
		{
			if (SC_SARANA.Text=="0,2")
			{
				B1.Visible=true;
				B2.Visible=false;
				B3.Visible=false;
				B4.Visible=false;
				B5.Visible=false;
			}

			else if (SC_SARANA.Text=="0,4")
			{
				B1.Visible=false;
				B2.Visible=true;
				B3.Visible=false;
				B4.Visible=false;
				B5.Visible=false;
			}

			else if (SC_SARANA.Text=="0,6")
			{
				B1.Visible=false;
				B2.Visible=false;
				B3.Visible=true;
				B4.Visible=false;
				B5.Visible=false;
			}

			else if (SC_SARANA.Text=="0,8")
			{
				B1.Visible=false;
				B2.Visible=false;
				B3.Visible=false;
				B4.Visible=true;
				B5.Visible=false;
			}

			else if (SC_SARANA.Text=="1")
			{
				B1.Visible=false;
				B2.Visible=false;
				B3.Visible=false;
				B4.Visible=false;
				B5.Visible=true;
			}
		}

		private void CekC()
		{
			if (SC_DATABASE.Text=="0,15")
			{
				C1.Visible=true;
				C2.Visible=false;
				C3.Visible=false;
				C4.Visible=false;
				C5.Visible=false;
			}

			else if (SC_DATABASE.Text=="0,3")
			{
				C1.Visible=false;
				C2.Visible=true;
				C3.Visible=false;
				C4.Visible=false;
				C5.Visible=false;
			}

			else if (SC_DATABASE.Text=="0,45")
			{
				C1.Visible=false;
				C2.Visible=false;
				C3.Visible=true;
				C4.Visible=false;
				C5.Visible=false;
			}

			else if (SC_DATABASE.Text=="0,6")
			{
				C1.Visible=false;
				C2.Visible=false;
				C3.Visible=false;
				C4.Visible=true;
				C5.Visible=false;
			}

			else if (SC_DATABASE.Text=="0,75")
			{
				C1.Visible=false;
				C2.Visible=false;
				C3.Visible=false;
				C4.Visible=false; 
				C5.Visible=true;
			}
		}

		private void CekD()
		{
			if (SC_EQUITMENT.Text=="0,15")
			{
				D1.Visible=true;
				D2.Visible=false;
				D3.Visible=false;
				D4.Visible=false;
				D5.Visible=false;
			}

			else if (SC_EQUITMENT.Text=="0,3")
			{
				D1.Visible=false;
				D2.Visible=true;
				D3.Visible=false;
				D4.Visible=false;
				D5.Visible=false;
			}

			else if (SC_EQUITMENT.Text=="0,45")
			{
				D1.Visible=false;
				D2.Visible=false;
				D3.Visible=true;
				D4.Visible=false;
				D5.Visible=false;
			}

			else if (SC_EQUITMENT.Text=="0,6")
			{
				D1.Visible=false;
				D2.Visible=false;
				D3.Visible=false;
				D4.Visible=true;
				D5.Visible=false;
			}

			else if (SC_EQUITMENT.Text=="0,75")
			{
				D1.Visible=false;
				D2.Visible=false;
				D3.Visible=false;
				D4.Visible=false;
				D5.Visible=true;
			}
		}

		private void CekE()
		{
			if (SC_BUILDING.Text=="0,15")
			{
				E1.Visible=true;
				E2.Visible=false;
				E3.Visible=false;
				E4.Visible=false;
				E5.Visible=false;
			}

			else if (SC_BUILDING.Text=="0,3")
			{
				E1.Visible=false;
				E2.Visible=true;
				E3.Visible=false;
				E4.Visible=false;
				E5.Visible=false;
			}

			else if (SC_BUILDING.Text=="0,45")
			{
				E1.Visible=false;
				E2.Visible=false;
				E3.Visible=true;
				E4.Visible=false;
				E5.Visible=false;
			}

			else if (SC_BUILDING.Text=="0,6")
			{
				E1.Visible=false;
				E2.Visible=false;
				E3.Visible=false;
				E4.Visible=true;
				E5.Visible=false;
			}

			else if (SC_BUILDING.Text=="0,75")
			{
				E1.Visible=false;
				E2.Visible=false;
				E3.Visible=false;
				E4.Visible=false;
				E5.Visible=true;
			}
		}

		private void CekF()
		{
			if (SC_RESOURCE.Text=="0,25")
			{
				F1.Visible=true;
				F2.Visible=false;
				F3.Visible=false;
				F4.Visible=false;
				F5.Visible=false;
			}

			else if (SC_RESOURCE.Text=="0,5")
			{
				F1.Visible=false;
				F2.Visible=true;
				F3.Visible=false;
				F4.Visible=false;
				F5.Visible=false;
			}

			else if (SC_RESOURCE.Text=="0,75")
			{
				F1.Visible=false;
				F2.Visible=false;
				F3.Visible=true;
				F4.Visible=false;
				F5.Visible=false;
			}

			else if (SC_BUILDING.Text=="1")
			{
				F1.Visible=false;
				F2.Visible=false;
				F3.Visible=false;
				F4.Visible=true;
				F5.Visible=false;
			}

			else if (SC_RESOURCE.Text=="1,25")
			{
				F1.Visible=false;
				F2.Visible=false;
				F3.Visible=false;
				F4.Visible=false;
				F5.Visible=true;
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
	}
}
