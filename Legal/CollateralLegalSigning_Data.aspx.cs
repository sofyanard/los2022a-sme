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

namespace SME.Legal
{
	/// <summary>
	/// Summary description for CollateralLegalSigning_Data.
	/// </summary>
	public partial class CollateralLegalSigning_Data : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_CL_SEQ.Text = Request.QueryString["cl_seq"];
				LBL_CL_TYPE.Text = Request.QueryString["cl_type"];

				DDL_CL_IKATTYPE.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_CI_TYPE.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_CI_COMP.Items.Add(new ListItem("-- Pilih --", ""));

				//--- Jenis Pengikatan
				int jml_row;
				conn.QueryString = "select IKATID, IKATID + ' - ' + IKATDESC AS IKATDESC from RFIKAT where active = '1' order by IKATID";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_CL_IKATTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select INSRTYPEID, INSRTYPEDESC from RFINSRTYPE ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_CI_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select INSRCOMPID, INSRCOMPDESC from RFINSRCOMPANY ";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_CI_COMP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				

				ViewData();
				//ViewJaminan();

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
			this.DGR_INSR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_INSR_ItemCommand);

		}
		#endregion

		private void ViewData()
		{
			conn.QueryString = "select CL_APPRVALUE, CL_VALUE "+
				"from COLLATERAL "+
				"where CU_REF = '"+ LBL_CUREF.Text +"' and CL_SEQ = "+ LBL_CL_SEQ.Text +" ";
			conn.ExecuteQuery();

			TXT_CL_APPRVALUE.Text = tool.ConvertCurr(conn.GetFieldValue("CL_APPRVALUE"));
			TXT_CL_OFFERVALUE.Text = tool.ConvertCurr(conn.GetFieldValue("CL_VALUE"));
			//DDL_CL_IKATTYPE.SelectedValue = conn.GetFieldValue("CL_IKATTYPE");
			//CHB_CL_SERTADDRSM.Checked = tool.ConvertCheck(conn.GetFieldValue("CL_SERTADDRSM"));
			//TXT_CL_SERTADDR1.Text = conn.GetFieldValue("CL_SERTADDR1");
			//TXT_CL_SERTADDR2.Text = conn.GetFieldValue("CL_SERTADDR2");
			//TXT_CL_SERTADDR3.Text = conn.GetFieldValue("CL_SERTADDR3");
			//RDB_CM1.Checked = true;
			//RDB_CM2.Checked = true;

		}

		private void ViewJaminan()
		{
			conn.QueryString = "select ";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_INSR.DataSource = data;
			DGR_INSR.DataBind();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select isnull(, 0) as CI_PREMI "+
				"from "+
				"where = "+ tool.ConvertNum(TXT_CI_AMNT.Text) +"' and  = "+ tool.ConvertNum(TXT_CI_MASA.Text) +" "+
				"and = "+ TXT_CI_CLASS.Text;
			conn.ExecuteQuery();
			float CI_PREMI = float.Parse(conn.GetFieldValue("CI_PREMI"));

			conn.QueryString = "exec LGL_COLLINSR '1', '" + LBL_CUREF.Text+ "', "+ LBL_CL_SEQ.Text+", "+
				tool.ConvertNull(DDL_CI_TYPE.SelectedValue) +", "+ tool.ConvertNull(DDL_CI_COMP.SelectedValue) +" , "+
				tool.ConvertNum(TXT_CI_AMNT.Text) +", "+ tool.ConvertNum(TXT_CI_MASA.Text) +", "+
				tool.ConvertNum(TXT_CI_CLASS.Text) +"', "+ CI_PREMI ;
			conn.ExecuteNonQuery();
		}

		private void DGR_INSR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec LGL_COLLINSR '2',  '" + LBL_CUREF.Text+ "', "+ LBL_CL_SEQ.Text+", '', '', 0, 0, 0, 0";
					conn.ExecuteNonQuery();
					break;
			}
			ViewJaminan();
		}		
	}
}
