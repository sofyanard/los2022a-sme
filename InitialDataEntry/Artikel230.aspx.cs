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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// </summary>
	public partial class Artikel230 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox Textbox7;
		protected System.Web.UI.WebControls.TextBox Textbox8;
		protected System.Web.UI.WebControls.TextBox Textbox9;
		protected Deduplication dedup = new Deduplication();
		protected Table TBL = new Table();
		private string theForm, theObj;
 // objek target

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			theForm = Request.QueryString["targetFormID"].Trim();
			theObj = Request.QueryString["targetObjectID"].Trim();

			//Response.Write(theForm+" "+theObj);

				conn.QueryString = "select AK_NO, AK_KETERANGAN, AK_NILAI from VW_IDE_ARTIKEL_LIST";
				conn.ExecuteQuery();


				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					TableRow tr = new TableRow();
					TableCell tc1 = new TableCell();
					TableCell tc2 = new TableCell();
					//TableCell tc3 = new TableCell();

					Label LBL_NO = new Label();
					Label LBL_DESC = new Label();
					//CheckBox CB_NILAI= new CheckBox();

					LBL_NO.Text = conn.GetFieldValue(i, "AK_NO") + "  ";
					LBL_DESC.Text = conn.GetFieldValue(i, "AK_KETERANGAN") + "  ";
					
					string STR_NILAI = conn.GetFieldValue(i, "AK_NILAI");
					int INT_NILAI = Convert.ToInt16(STR_NILAI);

					//CB_NILAI.Checked = Convert.ToBoolean(INT_NILAI);

					tc1.Controls.Add(LBL_NO);
					tc2.Controls.Add(LBL_DESC);

					tr.Cells.Add(tc1);
					tr.Cells.Add(tc2);
					//tr.Cells.Add(tc3);
					
					TBL.Rows.Add(tr);
				}
				
				this.PH_ARTIKEL.Controls.Add(TBL);
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

		protected void BTN_NO_Click(object sender, System.EventArgs e)
		{
			//Response.Write("window.opener.document." +theForm + "." + theObj + ".value='NO'; ");
			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj + ".value='EXIT'; " +
				"window.opener.document." + theForm + ".submit(); window.close();</script>");
			
			/*for(int i = 0; i < TBL.Rows.Count; i++)
			{
				TableRow tr = (TableRow)TBL.Rows[i];
				
				TableCell tc1 = (TableCell)tr.Cells[0];
				TableCell tc2 = (TableCell)tr.Cells[1];
				//TableCell tc3 = (TableCell)tr.Cells[2];

				Label lblNo = (Label)tc1.Controls[0];
				Label lblDesc = (Label)tc2.Controls[0];
				//CheckBox chkVal = (CheckBox)tc3.Controls[0];
								
				string szNo = lblNo.Text;
				string szDesc = lblDesc.Text;
				bool bVal = true;	//chkVal.Checked;
				
				int iVal = Convert.ToInt16(bVal);
				string szVal = iVal.ToString();
				
				conn.QueryString = "exec IDE_ARTIKEL '" + szNo + "', '" + szDesc + "', '" + szVal + "'";
				conn.ExecuteNonQuery();
			}*/
		}

		protected void BTN_YES_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}

	}
}
