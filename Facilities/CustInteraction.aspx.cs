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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for CustInteraction.sdfds
	/// </summary>
	public partial class CustInteraction : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Tools tools = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
				ViewData("0");
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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion

		private void ViewData(string v_sta)
		{
			int cust;
			if (RB_PELANGGAN.Items[0].Selected)
				cust	= 1;
			else
				cust	= 0;
			conn.QueryString = Query(TXT_APPNO.Text,TXT_NAME.Text,cust,TXT_CIF.Text,TXT_IDNUMBER.Text,TXT_NPWP.Text,v_sta);
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();

			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[3].Text = tools.FormatDate(DGR_LIST.Items[i].Cells[3].Text, true);
		}

		private void RB_PELANGGAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RB_PELANGGAN.Items[0].Selected)
				TXT_IDNUMBER.Enabled = true;
			else
			{
				TXT_IDNUMBER.Text	 = "";
				TXT_IDNUMBER.Enabled = false;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_APPNO.Text		= "";
			TXT_CIF.Text		= "";
			TXT_IDNUMBER.Text	= "";
			TXT_NAME.Text		= "";
			TXT_NPWP.Text		= "";
			TXT_IDNUMBER.Enabled= true;
			RB_PELANGGAN.Items[0].Selected = true;
			ViewData("0");
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}

		string Query(string ap_regno,string name,int cust_type,string cif,string cu_idcardnum,string npwp, string v_sta)
		{
			string where="";
			if (v_sta=="0")
				where = "and ap_regno='###' ";
			if (!ap_regno.Equals(""))
				where = " and ap_regno = '"+ ap_regno +"'";
			if (!name.Equals(""))
				where = where +" and ltrim(rtrim(Nama)) like  '%"+ name +"%'";
			if (!cif.Equals(""))
				where = where +" and cu_cif = "+cif+"";	
			if (!npwp.Equals(""))
				where = where +" and cu_npwp = '"+ npwp +"'";
			if (cust_type == 1)
			{
				if (!cu_idcardnum.Equals(""))
					where = where +" and cu_idcardnum = '"+ cu_idcardnum +"'";
				return "select ap_regno, cu_cif, nama,  convert(varchar,AP_RECVDATE,106)+' '+convert(varchar,AP_RECVDATE,108) as AP_RECVDATE, cu_npwp from vw_app_personal where 1=1 "+ where +"";
			}
			else
				return "select ap_regno, cu_cif, nama,  convert(varchar,AP_RECVDATE,106)+' '+convert(varchar,AP_RECVDATE,108) as AP_RECVDATE, cu_npwp from vw_app_company where 1=1 "+ where +"";
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("InteractionMemo.aspx?regno="+ e.Item.Cells[0].Text +"&cif="+ e.Item.Cells[1].Text +"&nama="+ e.Item.Cells[2].Text+"&npwp="+ e.Item.Cells[5].Text+"&mc=" + Request.QueryString["mc"]);
					break;
			}		
		}
	}
}
