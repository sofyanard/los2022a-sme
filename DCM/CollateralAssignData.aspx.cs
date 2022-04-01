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

namespace SME.DCM
{
	/// <summary>
	/// Summary description for CollateralAssignData.
	/// </summary>
	public partial class CollateralAssignData : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				
			}

			ViewListCollateral(Request.QueryString["accno"], Request.QueryString["colid"]);
		}

		private void ViewListCollateral(string accno, string colid)
		{
			conn2.QueryString = "EXEC DCM_COLLATERAL_CORRECTION_VIEWLISTCOLLATERAL '" + 
				accno + "', '" +
				colid + "'";
			conn2.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
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

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				/*** Hyperlink Collateral ID ***/
				HyperLink HL_COLID = (HyperLink) DatGrd.Items[i].Cells[0].FindControl("HL_COLID");
				HL_COLID.Text = dt.Rows[i][1].ToString();
				HL_COLID.ID = "HL_COLID." + i.ToString();
				HL_COLID.Font.Bold = true;
				HL_COLID.NavigateUrl = dt.Rows[i][6].ToString() + "&mc=" + Request.QueryString["mc"];
				if (Request.QueryString["asgn"] != null)
					HL_COLID.NavigateUrl = HL_COLID.NavigateUrl + "&asgn=" + Request.QueryString["asgn"];
				HL_COLID.Target = "coldetail";

				/*** Image Assignment Status ***/
				System.Web.UI.WebControls.Image IMG_STA = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[0].FindControl("IMG_STA");
				IMG_STA.ImageUrl = dt.Rows[i][5].ToString();

				/*** Label Assignment Status ***/
				Label LBL_STA = (Label) DatGrd.Items[i].Cells[0].FindControl("LBL_STA");
				LBL_STA.Text = dt.Rows[i][4].ToString();

				/*** DropDownList Assign To ***/
				DropDownList DDL_OFCR = (DropDownList) DatGrd.Items[i].Cells[1].FindControl("DDL_OFCR");
				DDL_OFCR.ID = "DDL_OFCR." + i.ToString();
				GlobalTools.fillRefList(DDL_OFCR, "EXEC DCM_COLLATERAL_CORRECTION_DDLOFCR '" + Session["UserID"].ToString() + "'", conn);
				try { DDL_OFCR.SelectedValue = dt.Rows[i][9].ToString().Trim(); }
				catch {}
				if (dt.Rows[i][10].ToString() == "1")
					DDL_OFCR.Enabled = true;
				else
					DDL_OFCR.Enabled = false;

				/*** Button Process ***/
				Button BTN_PROC = (Button) DatGrd.Items[i].Cells[1].FindControl("BTN_PROC");
				BTN_PROC.ID = "BTN_PROC." + i.ToString();
				BTN_PROC.Text = dt.Rows[i][7].ToString();
				if (dt.Rows[i][8].ToString() == "1")
					BTN_PROC.Enabled = true;
				else
					BTN_PROC.Enabled = false;
				BTN_PROC.Click += new EventHandler(BTN_PROCESS_Click);
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

		private void BTN_PROCESS_Click(object sender, System.EventArgs e)
		{
			try
			{
				Button b = (Button) sender;
				string idx = b.ID.Replace("BTN_PROC.","");
				string act = b.Text;

				HyperLink h = (HyperLink) DatGrd.Items[int.Parse(idx)].Cells[11].FindControl("HL_COLID."+idx);
				string colid = h.Text.Trim();

				DropDownList d = (DropDownList) DatGrd.Items[int.Parse(idx)].Cells[12].FindControl("DDL_OFCR."+idx);
				string ofcr = d.SelectedValue.Trim();
				
				conn2.QueryString  = "EXEC DCM_COLLATERAL_CORRECTION_ASSIGNPROCESS '" + 
					colid + "', '" + act + "', '" + ofcr + "', '" + Session["UserID"].ToString() + "'";
				conn2.ExecuteNonQuery();

				ViewListCollateral(Request.QueryString["accno"], Request.QueryString["colid"]);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
	}
}
