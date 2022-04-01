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

namespace SME.Syndication.PerjanjianKredit
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// </summary>
	public partial class GeneralInfo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			ViewData();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
					}
					else 
					{
						strtemp = ""; 
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
			conn.QueryString = "SELECT TOP 1 * FROM VW_SDC_DOC_GENERAL_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			TXT_CIF.Text				= conn.GetFieldValue("CIF").ToString();
			TXT_NAMA_DEBIT.Text			= conn.GetFieldValue("CUST_NAME").ToString();
			TXT_ALAMAT_KANPUS.Text		= conn.GetFieldValue("HQ_ADR").ToString();
			TXT_ALAMAT_PABRIK.Text		= conn.GetFieldValue("FACTORY_ADR").ToString();
			TXT_ALAMAT_WAKIL.Text		= conn.GetFieldValue("AGENCY_ADR").ToString();
			TXT_GROUP_USAHA.Text		= conn.GetFieldValue("GROUP_NM").ToString();
			TXT_OPERATE.Text			= tools.FormatDate(conn.GetFieldValue("ISTABLISH_DATE").ToString());
			TXT_SECTOR4.Text			= conn.GetFieldValue("SEKTOR").ToString();
			TXT_KEY_PERSON.Text			= conn.GetFieldValue("KEY_PERSON").ToString();
			TXT_NPWP.Text				= conn.GetFieldValue("NPWP").ToString();
			TXT_NO_SIUP.Text			= conn.GetFieldValue("SIUP_TDP_NUMBER").ToString();
			TXT_RM_NAME.Text			= conn.GetFieldValue("SU_FULLNAME").ToString();
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
