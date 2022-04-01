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
	/// Summary description for DocumentTrackingSend.
	/// </summary>
	public partial class DocumentTrackingSend : System.Web.UI.Page
	{
	
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				TXT_AP_REGNO.Text = Request.QueryString["regno"];
				ViewData();
				BindData();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM "+
				"where AP_REGNO = '"+ TXT_AP_REGNO.Text +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue(0, "AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue(0, "CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue(0, "AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue(0, "PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue(0, "BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue(0, "AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue(0, "AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue(0, "BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue(0, "CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue(0, "CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue(0, "CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue(0, "CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue(0, "CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue(0, "CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue(0, "BUSSTYPEDESC");
		}

		private void BindData()
		{
			string userid = (string) Session["UserID"];
			conn.QueryString = "SELECT * FROM VW_F_DOCTRACK_DOCLIST WHERE AP_REGNO = '"+ TXT_AP_REGNO.Text + "' AND " +
				"( RECVBY is not null AND RECVBY = '" + userid + "' ) ";
			conn.ExecuteQuery();
			DatGrd.DataSource = conn.GetDataTable().Copy();
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				try
				{
					DatGrd.CurrentPageIndex = 0;
					DatGrd.DataBind();
				}
				catch {}
			}
			System.Web.UI.WebControls.Image img;
			CheckBox chk;
			DropDownList ddl, ddlSendTo, ddlSendPurp;
			ddlSendTo = new DropDownList();
			ddlSendPurp = new DropDownList();
			GlobalTools.fillRefList(ddlSendTo, "select userid, su_fullname from scuser order by su_fullname ", conn);
			GlobalTools.fillRefList(ddlSendPurp, "select * from rfdoctrackpurpose ", conn);
			TextBox txt;
			Label lbl;
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[0].Text = ((int)(i + 1)).ToString();

				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[4].FindControl("IMG_AT_FIX");
				if(DatGrd.Items[i].Cells[5].Text == "1")
					img.ImageUrl = "../image/Complete.gif";
				else
					img.ImageUrl = "../image/UnComplete.gif";

				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[6].FindControl("IMG_ORIGINAL");
				chk = (CheckBox) DatGrd.Items[i].Cells[6].FindControl("CHK_ORIGINAL");
				if(DatGrd.Items[i].Cells[7].Text == "1")
				{
					img.ImageUrl = "../image/Complete.gif";
					chk.Checked = true;
					img.Visible = true;
					chk.Visible = false;
				}
				else if(DatGrd.Items[i].Cells[7].Text == "0")
				{
					img.ImageUrl = "../image/UnComplete.gif";
					chk.Checked = true;
					img.Visible = true;
					chk.Visible = false;
				}
				else
				{
					img.Visible = false;
					chk.Visible = true;
				}

				ddl = (DropDownList) DatGrd.Items[i].Cells[8].FindControl("DDL_SENDTO");
				lbl = (Label) DatGrd.Items[i].Cells[8].FindControl("LBL_SENDTO");
				if(convertNBSP(DatGrd.Items[i].Cells[17].Text) == "")		//if this doc is not been sent, enable sentTo ddl
				{
					for (int j = 0; j < ddlSendTo.Items.Count; j++)
					{
						ddl.Items.Add(new ListItem(ddlSendTo.Items[j].Text,ddlSendTo.Items[j].Value));
					}
					ddl.Visible = true;
					lbl.Visible = false;
				}
				else
				{
					lbl.Text = DatGrd.Items[i].Cells[19].Text;
					ddl.Visible = false;
					lbl.Visible = true;
					txt = (TextBox) DatGrd.Items[i].Cells[10].FindControl("TXT_NOTES");
					txt.Text = convertNBSP(DatGrd.Items[i].Cells[11].Text);
					txt.Enabled = false;
				}

				ddl = (DropDownList) DatGrd.Items[i].Cells[9].FindControl("DDL_PURPOSEID");
				lbl = (Label) DatGrd.Items[i].Cells[9].FindControl("LBL_DTP_DESC");
				if(convertNBSP(DatGrd.Items[i].Cells[17].Text) == "")		//check the SentTo field
				{
					for (int k = 0; k < ddlSendPurp.Items.Count; k++)
					{
						ddl.Items.Add(new ListItem(ddlSendPurp.Items[k].Text, ddlSendPurp.Items[k].Value));
					}
					ddl.Visible = true;
					lbl.Visible = false;
				}
				else
				{
					lbl.Text = DatGrd.Items[i].Cells[20].Text;
					ddl.Visible = false;
					lbl.Visible = true;
				}

				img = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[18].FindControl("IMG_SEND");
				chk = (CheckBox) DatGrd.Items[i].Cells[18].FindControl("CHK_SEND");
				if(convertNBSP(DatGrd.Items[i].Cells[17].Text) == "")		//if this doc is not been sent, enable send checkbox
				{
					img.Visible = false;
					chk.Visible = true;
				}
				else
				{
					img.ImageUrl = "../image/Complete.gif";
					chk.Checked = false;
					img.Visible = true;
					chk.Visible = false;
				}
			}
		}

		private string convertNBSP(string str)
		{
			if (str == "&nbsp;")
				return "";
			return str;
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

		protected void BTN_ACTION_Click(object sender, System.EventArgs e)
		{
			DropDownList ddl;
			TextBox txt;
			CheckBox chk;
			string regno = TXT_AP_REGNO.Text, doctype, docseq, docid, 
				sentby = (string) Session["UserID"], orig, 
				tc = tool.ConvertNull(Request.QueryString["tc"]), 
				purp, note, sendto;
			for(int i = 0; i < DatGrd.Items.Count; i++)
			{
				chk = (CheckBox) DatGrd.Items[i].Cells[18].FindControl("CHK_SEND");
				if (chk.Checked)
				{
					ddl = (DropDownList) DatGrd.Items[i].Cells[8].FindControl("DDL_SENDTO");
					sendto = convertNBSP(ddl.SelectedValue);
					if ((ddl.Enabled) && (sendto != ""))		//ensure that receiver has been set
					{
						doctype = DatGrd.Items[i].Cells[13].Text;
						docseq = DatGrd.Items[i].Cells[14].Text;
						docid = DatGrd.Items[i].Cells[15].Text;
						chk = (CheckBox) DatGrd.Items[i].Cells[6].FindControl("CHK_ORIGINAL");
						orig = "0";
						if (chk.Checked)
							orig = "1";
						ddl = (DropDownList) DatGrd.Items[i].Cells[9].FindControl("DDL_PURPOSEID");
						purp = tool.ConvertNull(convertNBSP(ddl.SelectedValue));
						txt = (TextBox) DatGrd.Items[i].Cells[10].FindControl("TXT_NOTES");
						note = tool.ConvertNull(convertNBSP(txt.Text));
						conn.QueryString = "EXEC F_DOCTRACK_SEND '" + regno + "', '" + doctype + "', " + docseq +
							", '" + docid + "', '" + sendto + "', '" + sentby + "', '" + orig + "', " + tc + ", " + purp + ", " + note;
						conn.ExecuteNonQuery();
					}
				}
			}
			BindData();
		}
	}
}
