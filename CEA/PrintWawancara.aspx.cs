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
	/// Summary description for PrintWawancara.
	/// </summary>
	public partial class PrintWawancara : System.Web.UI.Page
	{
		protected Tools tool = new Tools();

		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx"); 

			if(!IsPostBack)
			{
				ViewData();
			}
			//ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if(conn.GetFieldValue("rekanantypeid")=="01")
				conn.QueryString = "select namerekanan, address1, address2, phone_area + '-' + phone# as telp from vw_rekanan_company where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";
			else
				conn.QueryString = "select namerekanan, address1, address2, office_area + '-' + office# as telp from vw_rekanan_personal where rekanan_ref='" + Request.QueryString["rekanan_Ref"] + "'";

			conn.ExecuteQuery();

			LBL_NAMA.Text = conn.GetFieldValue("namerekanan");
			LBL_ALAMAT.Text = conn.GetFieldValue("address1");
			LBL_CITY.Text = conn.GetFieldValue("address2");
			LBL_TELP.Text = conn.GetFieldValue("telp");

			conn.QueryString = "select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			TGL_WAWANCARA.Text=tool.FormatDate(conn.GetFieldValue("intview_date"));
			PESERTA1.Text=conn.GetFieldValue("candidate1");
			PESERTA2.Text=conn.GetFieldValue("candidate2");
			PESERTA3.Text=conn.GetFieldValue("candidate3");
			NONS_TIME.Text=conn.GetFieldValue("nons_time");
			NONS_PREPARE.Text=conn.GetFieldValue("nons_prepare");
			NONS_DELIVARY.Text=conn.GetFieldValue("nons_delivary");
			NONS_TOT.Text=conn.GetFieldValue("nons_tot");
			S_EXPERIAN.Text=conn.GetFieldValue("s_experiance");
			S_EXPERT.Text=conn.GetFieldValue("s_expert");
			S_MUTU.Text=conn.GetFieldValue("s_mutu");
			S_COST.Text=conn.GetFieldValue("s_cost");
			S_OTHERS.Text=conn.GetFieldValue("s_others");
			S_TOT.Text=conn.GetFieldValue("s_TOT");
			SC_TOTAL.Text=conn.GetFieldValue("SC_TOTAL");

            COMENT1.Text=conn.GetFieldValue("s_exp_comment");
			COMENT2.Text=conn.GetFieldValue("s_expert_comment");
			COMENT3.Text=conn.GetFieldValue("s_mutu_comment");
			COMENT4.Text=conn.GetFieldValue("s_cost_comment");
			COMENT5.Text=conn.GetFieldValue("s_others_comment");
			CAT.Text=conn.GetFieldValue("cat");

			
			//Non-Substansi
			CekA();
			CekB();
			CekC();

			//Substansi
			CekD();
			CekE();
			CekF();
			CekG();
			CekH();
			
		}

		private void CekA()
		{
			if (NONS_TIME.Text=="0,2")
			{
				A1.Visible=true;
				A2.Visible=false;
				A3.Visible=false;
				A4.Visible=false;
				A5.Visible=false; 
			}

			else if (NONS_TIME.Text=="0,4")
			{
				A1.Visible=false;
				A2.Visible=true;
				A3.Visible=false;
				A4.Visible=false;
				A5.Visible=false;
			}

			else if (NONS_TIME.Text=="0,6")
			{
				A1.Visible=false;
				A2.Visible=false;
				A3.Visible=true;
				A4.Visible=false;
				A5.Visible=false;
			}

			else if (NONS_TIME.Text=="0,8")
			{
				A1.Visible=false;
				A2.Visible=false;
				A3.Visible=false;
				A4.Visible=true;
				A5.Visible=false;
			}

			else if (NONS_TIME.Text=="1")
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
			if (NONS_PREPARE.Text=="0,2")
			{
				B1.Visible=true;
				B2.Visible=false;
				B3.Visible=false;
				B4.Visible=false;
				B5.Visible=false;
			}

			else if (NONS_PREPARE.Text=="0,4")
			{
				B1.Visible=false;
				B2.Visible=true;
				B3.Visible=false;
				B4.Visible=false;
				B5.Visible=false;
			}

			else if (NONS_PREPARE.Text=="0,6")
			{
				B1.Visible=false;
				B2.Visible=false;
				B3.Visible=true;
				B4.Visible=false;
				B5.Visible=false;
			}

			else if (NONS_PREPARE.Text=="0,8")
			{
				B1.Visible=false;
				B2.Visible=false;
				B3.Visible=false;
				B4.Visible=true;
				B5.Visible=false;
			}

			else if (NONS_PREPARE.Text=="1")
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
			if (NONS_DELIVARY.Text=="0,6")
			{
				C1.Visible=true;
				C2.Visible=false;
				C3.Visible=false;
				C4.Visible=false;
				C5.Visible=false;
			}

			else if (NONS_DELIVARY.Text=="1,2")
			{
				C1.Visible=false;
				C2.Visible=true;
				C3.Visible=false;
				C4.Visible=false;
				C5.Visible=false;
			}

			else if (NONS_DELIVARY.Text=="1,8")
			{
				C1.Visible=false;
				C2.Visible=false;
				C3.Visible=true;
				C4.Visible=false;
				C5.Visible=false;
			}

			else if (NONS_DELIVARY.Text=="2,4")
			{
				C1.Visible=false;
				C2.Visible=false;
				C3.Visible=false;
				C4.Visible=true;
				C5.Visible=false;
			}

			else if (NONS_DELIVARY.Text=="3")
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
			if (S_EXPERIAN.Text=="0,3")
			{
				D1.Visible=true;
				D2.Visible=false;
				D3.Visible=false;
				D4.Visible=false;
				D5.Visible=false;
			}

			else if (S_EXPERIAN.Text=="0,6")
			{
				D1.Visible=false;
				D2.Visible=true;
				D3.Visible=false;
				D4.Visible=false;
				D5.Visible=false;
			}

			else if (S_EXPERIAN.Text=="0,9")
			{
				D1.Visible=false;
				D2.Visible=false;
				D3.Visible=true;
				D4.Visible=false;
				D5.Visible=false;
			}

			else if (S_EXPERIAN.Text=="1,2")
			{
				D1.Visible=false;
				D2.Visible=false;
				D3.Visible=false;
				D4.Visible=true;
				D5.Visible=false;
			}

			else if (S_EXPERIAN.Text=="1,5")
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
			if (S_EXPERT.Text=="0,3")
			{
				E1.Visible=true;
				E2.Visible=false;
				E3.Visible=false;
				E4.Visible=false;
				E5.Visible=false;
			}

			else if (S_EXPERT.Text=="0,6")
			{
				E1.Visible=false;
				E2.Visible=true;
				E3.Visible=false;
				E4.Visible=false;
				E5.Visible=false;
			}

			else if (S_EXPERT.Text=="0,9")
			{
				E1.Visible=false;
				E2.Visible=false;
				E3.Visible=true;
				E4.Visible=false;
				E5.Visible=false;
			}

			else if (S_EXPERT.Text=="1,2")
			{
				E1.Visible=false;
				E2.Visible=false;
				E3.Visible=false;
				E4.Visible=true;
				E5.Visible=false;
			}

			else if (S_EXPERT.Text=="1,5")
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
			if (S_MUTU.Text=="0,2")
			{
				F1.Visible=true;
				F2.Visible=false;
				F3.Visible=false;
				F4.Visible=false;
				F5.Visible=false;
			}

			else if (S_MUTU.Text=="0,4")
			{
				F1.Visible=false;
				F2.Visible=true;
				F3.Visible=false;
				F4.Visible=false;
				F5.Visible=false;
			}

			else if (S_MUTU.Text=="0,6")
			{
				F1.Visible=false;
				F2.Visible=false;
				F3.Visible=true;
				F4.Visible=false;
				F5.Visible=false;
			}

			else if (S_MUTU.Text=="0,8")
			{
				F1.Visible=false;
				F2.Visible=false;
				F3.Visible=false;
				F4.Visible=true;
				F5.Visible=false;
			}

			else if (S_MUTU.Text=="1")
			{
				F1.Visible=false;
				F2.Visible=false;
				F3.Visible=false;
				F4.Visible=false; 
				F5.Visible=true;
			}
		}

		private void CekG()
		{
			if (S_COST.Text=="0,1")
			{
				G1.Visible=true;
				G2.Visible=false;
				G3.Visible=false;
				G4.Visible=false;
				G5.Visible=false;
			}

			else if (S_COST.Text=="0,2")
			{
				G1.Visible=false;
				G2.Visible=true;
				G3.Visible=false;
				G4.Visible=false;
				G5.Visible=false;
			}

			else if (S_COST.Text=="0,3")
			{
				G1.Visible=false;
				G2.Visible=false;
				G3.Visible=true;
				G4.Visible=false;
				G5.Visible=false;
			}

			else if (S_COST.Text=="0,4")
			{
				G1.Visible=false;
				G2.Visible=false;
				G3.Visible=false;
				G4.Visible=true;
				G5.Visible=false;
			}

			else if (S_COST.Text=="0,5")
			{
				G1.Visible=false;
				G2.Visible=false;
				G3.Visible=false;
				G4.Visible=false; 
				G5.Visible=true;
			}
		}
		
		private void CekH()
		{
			if (S_OTHERS.Text=="0,1")
			{
				H1.Visible=true;
				H2.Visible=false;
				H3.Visible=false;
				H4.Visible=false;
				H5.Visible=false;
			}

			else if (S_OTHERS.Text=="0,2")
			{
				H1.Visible=false;
				H2.Visible=true;
				H3.Visible=false;
				H4.Visible=false;
				H5.Visible=false;
			}

			else if (S_OTHERS.Text=="0,3")
			{
				H1.Visible=false;
				H2.Visible=false;
				H3.Visible=true;
				H4.Visible=false;
				H5.Visible=false;
			}

			else if (S_OTHERS.Text=="0,4")
			{
				H1.Visible=false;
				H2.Visible=false;
				H3.Visible=false;
				H4.Visible=true;
				H5.Visible=false;
			}

			else if (S_OTHERS.Text=="0,5")
			{
				H1.Visible=false;
				H2.Visible=false;
				H3.Visible=false;
				H4.Visible=false; 
				H5.Visible=true;
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
