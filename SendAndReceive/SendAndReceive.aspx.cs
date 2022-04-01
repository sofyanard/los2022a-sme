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

namespace SME.SendAndReceive
{
	/// <summary>
	/// Summary description for SendAndReceive.
	/// </summary>
	public partial class SendAndReceive : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			try 
			{
				viewdatareceive();
				viewdatasend();
			}
			catch (Exception ex) { string temp = ex.ToString(); }
		}

		private void viewdatareceive() 
		{
			CheckBox t1 = new CheckBox();
			t1.ID = "all";
			t1.AutoPostBack = true;
			t1.CheckedChanged +=new EventHandler(t1_CheckedChanged);
			Table2.Rows[0].Cells.Add(new TableCell());
			Table2.Rows[0].Cells[3].Controls.Add(t1);

			conn.QueryString = "select * from VW_RECEIVEAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				Table2.Rows.Add(new TableRow());
				Table2.Rows[i+1].Cells.Add(new TableCell());
				Table2.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "AP_REGNO");
				Table2.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				Table2.Rows[i+1].Cells.Add(new TableCell());
				Table2.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "NAMA");
				Table2.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				Table2.Rows[i+1].Cells.Add(new TableCell());
				Table2.Rows[i+1].Cells[2].Text = tool.FormatDate(conn.GetFieldValue(i, "RECEIVEDATE"), true);
				Table2.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				
				CheckBox t = new CheckBox();
				t.ID = "check"+conn.GetFieldValue(i, "AP_REGNO");
				Table2.Rows[i+1].Cells.Add(new TableCell());
				Table2.Rows[i+1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				Table2.Rows[i+1].Cells[3].Controls.Add(t);
			}
		}

		private void viewdatasend() 
		{
			CheckBox t1 = new CheckBox();
			t1.ID = "all1";
			t1.AutoPostBack = true;
			t1.CheckedChanged +=new EventHandler(t2_CheckedChanged);
			Table3.Rows[0].Cells.Add(new TableCell());
			Table3.Rows[0].Cells[3].Controls.Add(t1);
			
			conn.QueryString = "select * from VW_SENDAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				Table3.Rows.Add(new TableRow());
				Table3.Rows[i+1].Cells.Add(new TableCell());
				Table3.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "AP_REGNO");
				Table3.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				Table3.Rows[i+1].Cells.Add(new TableCell());
				Table3.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "NAMA");
				Table3.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				Table3.Rows[i+1].Cells.Add(new TableCell());
				Table3.Rows[i+1].Cells[2].Text = tool.FormatDate(conn.GetFieldValue(i, "RECEIVEDATE"), true);
				Table3.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				
				CheckBox t = new CheckBox();
				t.ID = "check"+conn.GetFieldValue(i, "AP_REGNO");
				Table3.Rows[i+1].Cells.Add(new TableCell());
				Table3.Rows[i+1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				Table3.Rows[i+1].Cells[3].Controls.Add(t);
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

		protected void search_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_TRACKALLOW where AP_REGNO = '"+TXT_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			if (row == 0) 
			{
				Response.Write("<script>alert('The application is not on the right track !!!')</script>");
			}
			else 
			{
				conn.QueryString = "exec SR_SENDANDRECEIVE '"+TXT_AP_REGNO.Text+"', '"+Session["UserID"]+"'";
				conn.ExecuteNonQuery();
			}
			Server.Transfer("SendAndReceive.aspx");
		}

		protected void move_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_RECEIVEAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{ 
				if (((CheckBox)Table2.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked == true) 
				{
					conn.QueryString = "exec SR_MOVEAPPLICATION '"+conn.GetFieldValue(i, 0)+"', '" + Session["UserID"].ToString() + "', '1'";
					conn.ExecuteNonQuery();
				}
			}
			Server.Transfer("SendAndReceive.aspx");
		}

		protected void remove_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_SENDAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				if (((CheckBox)Table3.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked == true) 
				{
					conn.QueryString = "exec SR_MOVEAPPLICATION '"+conn.GetFieldValue(i, 0)+"', '" + Session["UserID"].ToString() + "', '2'";
					conn.ExecuteNonQuery();
				}
			}
			Server.Transfer("SendAndReceive.aspx");
		}

		private void t1_CheckedChanged(object sender, System.EventArgs e) 
		{
			conn.QueryString = "select * from VW_RECEIVEAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				if ( ((CheckBox)Table2.FindControl("all")).Checked == true ) 
				{
					((CheckBox)Table2.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked = true; }
				else {((CheckBox)Table2.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked = false;}
			}
		}

		private void t2_CheckedChanged(object sender, System.EventArgs e) 
		{
			conn.QueryString = "select * from VW_SENDAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				if ( ((CheckBox)Table3.FindControl("all1")).Checked == true ) 
				{
					((CheckBox)Table3.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked = true; }
				else {((CheckBox)Table3.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked = false;}
			}
		}

		protected void delete_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_RECEIVEAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				if (((CheckBox)Table3.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked == true) 
				{
					conn.QueryString = "exec SR_MOVEAPPLICATION '"+conn.GetFieldValue(i, 0)+"', '" + Session["UserID"].ToString() + "', '3'";
					conn.ExecuteNonQuery();
				}
			}
			Server.Transfer("SendAndReceive.aspx");
		}

		protected void sendreceive_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_SENDAPPLICATION";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				if (((CheckBox)Table3.FindControl("check"+conn.GetFieldValue(i, "AP_REGNO"))).Checked == true) 
				{
					conn.QueryString = "exec SR_MOVEAPPLICATION '"+conn.GetFieldValue(i, 0)+"', '"+Session["UserID"]+"', '4'";
					try { conn.ExecuteNonQuery(); }
					catch (Exception ex) { string temp = ex.ToString(); }
				}
			}
			Server.Transfer("SendAndReceive.aspx");
		}


	}
}
