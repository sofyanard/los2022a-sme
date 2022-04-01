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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for SubApplicationMain.
	/// </summary>
	public partial class SubApplicationMain : System.Web.UI.Page
	{


		#region " Variables "

		protected Connection conn;
		private string regno, curef, mc, tc, de, formParent, controlParent, exist, rm;

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			regno			= Request.QueryString["regno"];
			curef			= Request.QueryString["curef"];
			mc				= Request.QueryString["mc"];
			tc				= Request.QueryString["tc"];
			de				= Request.QueryString["de"];
			formParent		= Request.QueryString["formParent"];
			controlParent	= Request.QueryString["controlParent"];
			exist			= Request.QueryString["exist"];
			rm				= Request.QueryString["rm"];

			if (!IsPostBack) 
			{
				LBL_MAINREGNO.Text		= (string) Request.QueryString["mainregno"];
				LBL_MAINCUREF.Text		= (string) Request.QueryString["maincuref"];			
				LBL_MAINPROD_SEQ.Text	= (string) Request.QueryString["mainprod_seq"];
				LBL_MAINPRODUCTID.Text	= (string) Request.QueryString["mainproductid"];

				IF_SubDetail.Attributes.Add("src", "IDE_GeneralInfo.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&gi=0&tc=" + tc + "&mc=" + mc + "&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text + "&exist=" + exist + "&rm=" + rm);
			}

			BTN_CANCEL.Attributes.Add("onclick","if(!batal()) { return false; };");			
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

		#region " Defined Methods "

		private bool isKreditDefined(string AP_REGNO) 
		{
			bool isDefined = false;

			try 
			{
				conn.QueryString = "select KET_CODE from KETENTUAN_KREDIT where AP_REGNO = '" + AP_REGNO + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) isDefined = true;
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				isDefined = false;
			}

			return isDefined;
		}

		private bool isSandiBIDefined(string vAP_REGNO) 
		{
			bool isDefined = true;
			//-------cek Sandi BI--------------------
			conn.QueryString = "exec sandibi_mandatory '" + vAP_REGNO + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) != "1")
			{				
				isDefined = false;
			}
			//----------------------------------------
			return isDefined;
		}
		private int isGeneralInfoSaved() 
		{
			//////////////////////////////////////////////////////////////////////
			//
			//	Jika aplikasi belum dibuat, struktur kredit belum bisa dibuat
			//
			try 
			{
				conn.QueryString = "select COUNT(*) as JUM_APP from APPLICATION where AP_REGNO = '" + regno + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error!");
				return -1;
			}
			if (conn.GetFieldValue("JUM_APP") == "0") 
			{
				return 0;
			}
			//////////////////////////////////////////////////////////////////////
			
			return 1;
		}

		#endregion

		int CekGeneralInfo()
		{
			conn.QueryString =  "select * from application where ap_regno ='"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			if ( conn.GetRowCount() > 0 )
				return 1;
			
			Tools.popMessage(this, "General Info must be filled first");
			return 0;
		}

		protected void LNK_GEN_INFO_Click(object sender, System.EventArgs e)
		{
			IF_SubDetail.Attributes.Add("src", "IDE_GeneralInfo.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&gi=0&tc=" + tc + "&mc=" + mc + "&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text + "&exist=" + exist + "&rm=" + rm);
		}

		protected void LNK_INFO_PERUSAHAAN_Click(object sender, System.EventArgs e)
		{
			if (CekGeneralInfo() == 1) 
				IF_SubDetail.Attributes.Add("src", "IDE_InfoPerusahaan.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&tc= " + tc + "&mc= " + mc + "&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text);
		}

		protected void LNK_BLACKLIST_Click(object sender, System.EventArgs e)
		{
			if (CekGeneralInfo() == 1) 
				IF_SubDetail.Attributes.Add("src", "/SME/Blacklist/BL_Result.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&tc=" + tc + "&mc= " + mc + "&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text);
		}

		protected void LNK_STRUK_KRED_Click(object sender, System.EventArgs e)
		{
			if (CekGeneralInfo() == 0) 
				return;

			//////////////////////////////////////////////////////////////////////
			//
			//	Jika aplikasi belum dibuat, struktur kredit belum bisa dibuat
			//
			
			if (isGeneralInfoSaved() == 0) 
			{
				Tools.popMessage(this, "General Info belum disimpan!");
				return;				
			}
			


			//////////////////////////////////////////////////////////////////////
			/// Jika customer adalah badan usaha, maka cust stock holder 
			/// harus diisi
			/// 
			try 
			{
				conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + curef + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error!");
				return;
			}			
			string CU_CUSTTYPEID = conn.GetFieldValue("cu_custtypeid");


			try 
			{
				conn.QueryString = "select COUNT(*) as JUM_STOCKHOLDER from CUST_STOCKHOLDER where CU_REF = '" + curef + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error!");
				return;
			}			
			if (CU_CUSTTYPEID == "01" && conn.GetFieldValue("JUM_STOCKHOLDER") == "0") 
			{
				Tools.popMessage(this, "Data Direksi harus diisi!");
				return;				
			}
			//////////////////////////////////////////////////////////////////////

			

			//////////////////////////////////////////////////////////////////////
			///	Mengambil program id untuk di pass ke page berikutnya
			///	
			string prog;

			try 
			{
				conn.QueryString = "select PROG_CODE from APPLICATION where AP_REGNO = '" + regno + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error!");
				return;
			}
			prog = conn.GetFieldValue("PROG_CODE");

			IF_SubDetail.Attributes.Add("src", "/SME/InitialDataEntry/KetentuanKredit.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&tc=" + tc + "&mc= " + mc + "&prog=" + prog + "&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text);
			//////////////////////////////////////////////////////////////////////////
		}

		protected void LNK_JAMINAN_Click(object sender, System.EventArgs e)
		{
			if (CekGeneralInfo() == 1) 
			IF_SubDetail.Attributes.Add("src", "Jaminan_Detail.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&sta=view&tc=" + tc + "&mc=" + mc + "&de=1&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text);
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//--- cek dulu custproduct-nya ---//
			if (!isKreditDefined(regno)) 
			{
				Tools.popMessage(this, "Struktur Kredit belum dibuat!");
				return;
			}

			//---- cek dulu sandi BI ---//
			if (!isSandiBIDefined(regno)) 
			{
				Tools.popMessage(this, "Sandi BI belum diisi!");
				return;
			}


			Response.Write("<script language='JavaScript1.2'>window.opener.document." + formParent + "." + controlParent + ".selectedIndex=0;" +
					"window.opener.document." + formParent + ".submit(); window.close();</script>");

//			Response.Write("<script language='JavaScript1.2'>window.opener.location=" +
//				"'SubApplicationList.aspx?regno=" + mainregno + "&curef=" + + "&mc=" + mc + "&tc=" + tc + "&de=" + de + "'; window.close();</script>");
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////
			///	hapus aplikasi
			///	
			try 
			{
				conn.QueryString = "exec KET_KREDIT null, null, '" + regno + "', null, null, null, null,'3'";
				conn.ExecuteNonQuery();
			}			
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error!");
				return;
			}	
			//////////////////////////////////////////
			

			/////////////////////////////////////
			///	Tutup window
			///	
			Response.Write("<script language='JavaScript1.2'>window.opener.document." + formParent + "." + controlParent + ".selectedIndex=0;" +
				"window.opener.document." + formParent + ".submit(); window.close();</script>");
			////////////////////////////////////
		}

		protected void LNK_DTBO_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////////////////////////////////
			//
			//	Jika aplikasi belum dibuat, struktur kredit belum bisa dibuat
			//
			if (isGeneralInfoSaved() == 0) 
			{
				Tools.popMessage(this, "General Info belum disimpan!");
				return;				
			}

			IF_SubDetail.Attributes.Add("src", "../DTBO/DTBO.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&sta=view&tc=" + tc + "&mc=" + mc + "&de=1&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text);		
		}

		protected void LNK_SANDIBI_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////////////////////////////////
			//
			//	Jika aplikasi belum dibuat, struktur kredit belum bisa dibuat
			//
			if (isGeneralInfoSaved() == 0) 
			{
				Tools.popMessage(this, "General Info belum disimpan!");
				return;				
			}


			//////////////////////////////////////////////////////////////////////
			///	Cek Struktur Kredit dulu
			///	
			if (!isKreditDefined(regno)) 
			{
				Tools.popMessage(this, "Struktur Kredit belum dibuat!");
				return;
			}
			//////////////////////////////////////////////////////////////////////

			IF_SubDetail.Attributes.Add("src", "DetailSandiBI.aspx?mainregno=" + LBL_MAINREGNO.Text + "&regno=" + regno + "&curef=" + curef + "&sta=view&tc=" + tc + "&mc=" + mc + "&de=1&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + "&mainproductid=" + LBL_MAINPRODUCTID.Text);
		}
	}
}
