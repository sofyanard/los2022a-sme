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
	/// Summary description for ListWorksheet.
	/// </summary>
	public partial class ListWorksheet : System.Web.UI.Page
	{
		protected Connection conn;
		protected CommonForm.NotaExport DocExport1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");

			if(!IsPostBack)
			{
				DocExport1.GroupTemplate = "NOTAPRINT";

				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				//conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE AP_CURRTRACK='A1.5'";
				//conn.QueryString += "UNION SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE AP_CURRTRACK='A1.5'";
				conn.QueryString = "select * from vw_rekanan_search where ap_currtrack='A1.5' and areaid='" + Session["AreaID"].ToString() + "' and rfrekanantype='07'";
				conn.ExecuteQuery();
				FillGrid();
				TR_INFO.Visible = false;
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			TR_INFO.Visible = false;
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//string area="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					/*conn.QueryString = "select rfarea.areaid, rfarea.areaname from rekanan left outer join rfarea on rekanan.rekanan_wilayah=rfarea.areaid where rekanan_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					area = Session["AreaID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["AreaID"].ToString()))
					{
						Response.Redirect("PrintWorksheet.aspx?rekanan_ref=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + e.Item.Cells[1].Text);		
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "Rekanan ini merupakan rekanan: " + conn.GetFieldValue("areaname") + "');</script>");
					}*/
					TR_INFO.Visible = true;
					DocExport1.RekananRef = e.Item.Cells[0].Text;
					DocExport1.regnum = e.Item.Cells[1].Text;

					conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();

					if (conn.GetFieldValue("rekanantypeid")=="01")
					{
						conn.QueryString="select regnum, rekanandesc, namerekanan, id_number, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where regnum='" + e.Item.Cells[1].Text + "'";
						conn.ExecuteQuery();

						TXT_REGNUM.Text = conn.GetFieldValue("regnum");
						TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
						TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
						TXT_NPWP.Text = conn.GetFieldValue("id_number");
						TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
						TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
						TXT_CITY.Text = conn.GetFieldValue("city");
						TXT_NOTLP.Text = conn.GetFieldValue("phone");
					}
					else
					{
						conn.QueryString="select regnum, rekanandesc, namerekanan, id_number, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where regnum='" + e.Item.Cells[1].Text + "'";
						conn.ExecuteQuery();

						TXT_REGNUM.Text = conn.GetFieldValue("regnum");
						TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
						TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
						TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
						TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
						TXT_CITY.Text = conn.GetFieldValue("city");
						TXT_NOTLP.Text = conn.GetFieldValue("phone");
						TXT_NPWP.Text = conn.GetFieldValue("id_number");
					}
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void SearchData()
		{
			//conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' AND AP_CURRTRACK='A1.5'";
			//conn.QueryString += "UNION SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' AND AP_CURRTRACK='A1.5'";
			conn.QueryString = "select * from vw_rekanan_search where NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%' and ap_currtrack='A1.5' and areaid='" + Session["AreaID"].ToString() + "' and rfrekanantype='07'";
			conn.ExecuteQuery();
			FillGrid();
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion

	}
}
