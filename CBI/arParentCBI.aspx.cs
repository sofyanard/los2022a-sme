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

namespace SME.CBI
{
	/// <summary>
	/// Summary description for arParent.
	/// </summary>
	public partial class arParentCBI : System.Web.UI.Page
	{
		//protected System.Web.UI.WebControls.DropDownList ddl_KetentuanKredit;

		private Connection conn;
		private Tools tool = new Tools();
		string REGNO, CUREF, TC, MC, DE, PAR, KETKREDIT;
		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			REGNO	= Request.QueryString["regno"];
			CUREF	= Request.QueryString["curef"];
			TC		= Request.QueryString["tc"];
			MC		= Request.QueryString["mc"];
			DE		= Request.QueryString["de"];
			PAR		= Request.QueryString["par"];

			if (!IsPostBack) 
			{
				GlobalTools.fillRefList(this.ddl_KetentuanKredit,"select * from KETENTUAN_KREDIT where AP_REGNO = '" + REGNO + "';",false,conn);
			}

			ViewListAspek();
			ViewMenu();
		}



		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+ MC +"'";
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
							strtemp = "regno=" + REGNO + "&curef=" + CUREF + "&tc=" + TC;
						else	strtemp = "regno=" + REGNO + "&curef=" + CUREF + "&mc=" + MC + "&tc=" + TC;
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + DE;
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + PAR;
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


		protected void IMG_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (PAR != null && PAR != "") 
				Response.Redirect(PAR + "&regno=" + REGNO + "&curef=" + CUREF + "&tc=" + TC);
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(TC.ToString(), conn));
		}


		private void ViewListAspek()
		{
			string hlink ="";

			conn.QueryString = "select * from VW_ASPEK_LIST_CBI where AP_REGNO = '"+ REGNO +"'";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			
			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 1; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);

			int row = conn.GetRowCount();
			string BGCOLOR = "TDBGColor11";
			int no_row;
			for (int i = 0; i < row; i++)
			{
				if (BGCOLOR == "TDBGColor11")
					BGCOLOR = "TDBGColor21";
				else
					BGCOLOR = "TDBGColor11";

				switch (dt.Rows[i][2].ToString())
				{
					case "A":
						hlink = "arAspekTeknisCBI.aspx";
						break;

					case "B":
						hlink = "arNonCashLoanCBI.aspx";
						break;
				
					case "C":
						hlink = "arKontraktorCBI.aspx";
						break;

					case "D":
						hlink = "arMiddleCommercialCBI.aspx";
						break;

				}
		

				HyperLink t = new HyperLink();
				//t.Text = dt.Rows[i][4].ToString()+" ("+dt.Rows[i][3].ToString()+")";
				t.Text = "("+dt.Rows[i][3].ToString()+")";
				t.ID = "COLL_LINK"+ i;
				t.Font.Bold = true;
				t.NavigateUrl = hlink + "?de=" + DE + "&regno=" + REGNO + "&curef=" + CUREF + "&ketkredit=" + dt.Rows[i][1].ToString() + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR;				
				t.Target = "ApprResult";


				//no_row = (i*2)+1;
				no_row = i + 1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(t);
				this.Table_List.Rows[no_row].Cells[0].VerticalAlign = VerticalAlign.Top;
			}
		}

		protected void btn_Insert_Click(object sender, System.EventArgs e)
		{
			/*if (this.ddl_KetentuanKredit.SelectedIndex == 0)
			{
				Response.Write("<script language='javascript'>alert('Ketentuan Kredit harus dipilih dulu');</script>");
			}
			else
			{
				KETKREDIT = this.ddl_KetentuanKredit.SelectedValue;*/

				switch (this.ddl_Pilih.SelectedValue)
				{
					case "1":
						if_Child.Attributes.Add("src", "arAspekTeknisCBI.aspx?de=" + Request.QueryString["de"] + "&regno=" + REGNO + "&curef=" + CUREF + "&ketkredit=" + KETKREDIT + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR);
						break;

					case "2":
						if_Child.Attributes.Add("src", "arNonCashLoanCBI.aspx?de=" + Request.QueryString["de"] + "&regno=" + REGNO + "&curef=" + CUREF + "&ketkredit=" + KETKREDIT + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR);
						break;
				
					case "3":
						if_Child.Attributes.Add("src", "arKontraktorCBI.aspx?de=" + Request.QueryString["de"] + "&regno=" + REGNO + "&curef=" + CUREF + "&ketkredit=" + KETKREDIT + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR);
						break;

					case "4":
						if_Child.Attributes.Add("src", "arMiddleCommercialCBI.aspx?de=" + Request.QueryString["de"] + "&regno=" + REGNO + "&curef=" + CUREF + "&ketkredit=" + KETKREDIT + "&mc=" + MC + "&tc=" + TC + "&par=" + PAR);
						break;

					default:
						if_Child.Attributes.Add("src", "");
						break;
				}
			//}
		}


	}
}
