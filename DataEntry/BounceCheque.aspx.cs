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
using System.IO;
using System.Data.SqlClient;

namespace Websysca
{
	/// <summary>
	/// Summary description for PRM_TBOMonitoring.sadfasdfsfd
	/// </summary>
	public partial class BounceCheque : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.PlaceHolder MenuUtama;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button1;
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");


			if(!IsPostBack)
			{
				LBL_CUREF.Text=Request.QueryString["curef"];
				viewData();
				view_listbouncecheque();
			}
			viewMenu();
			SecureData();
		}		


		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for(k = 0; k < coll.Count; k++) 
				{
					if (coll[k] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						break;
					}
				}
				if (k == coll.Count) return;

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is Button)
					{
						Button btn = (Button) coll[k].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[k].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[k].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[k].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[k].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[k].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
						/**
						else if (coll[k].Controls[i] is DataGrid) 
						{						
							DataGrid dg = (DataGrid) coll[k].Controls[i];						
							dg.Columns[10].Visible = false;
							for (int j = 0; j < dg.Items.Count; j++) 
							{
								//dg.Items[j].Cells[10].Enabled = false;
								dg.Items[j].Cells[10].Visible = false;
							}
						}**/
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion

		private void viewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0)
							strtemp = strtemp + "&de=" + Request.QueryString["de"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if ((TXT_JMLBC.Text.Trim()!="")&&(TXT_JMLBC.Text.Trim()!="0"))
			{
				conn.QueryString = "delete from CUST_BOUNCECHEQUE where CU_REF='" + Request.QueryString["curef"]  +"'"; 
				conn.ExecuteQuery();
				conn.QueryString = "insert into CUST_BOUNCECHEQUE(CU_REF, NUMBOUNCECHEQUE) values('" + Request.QueryString["curef"] + "'," + TXT_JMLBC.Text  + ")";
				conn.ExecuteQuery();
				viewData();
			}
			else
				GlobalTools.popMessage(this,"Cannot be zero or empty!");
		}

		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			if (txtNoRekGiro.Text.Trim()!= "")
			{
				conn.QueryString = "select * from ACC_GIRO where ACC_GIRO = '"+txtNoRekGiro.Text+"' ";
				conn.QueryString += "and cu_ref = '"+ LBL_CUREF.Text  + "'";
				conn.ExecuteQuery();
				int jml=conn.GetRowCount();
				if (jml==0)//jika belum ada di table ACC_GIRO
				{
					conn.QueryString = "insert into ACC_GIRO(CU_REF, ACC_GIRO, NOTE) values('" + 
						LBL_CUREF.Text  + "','" + txtNoRekGiro.Text.Trim() + "', '" + TXT_NOTE.Text.Trim() + "')";
					conn.ExecuteNonQuery();
					viewData();
				}
				else GlobalTools.popMessage(this,"Account number has already in database!");
			}
			else GlobalTools.popMessage(this,"Fill account number, please!");

			// clear form
			txtNoRekGiro.Text = "";
			TXT_NOTE.Text = "";
		}

		/* menampilkan datar account yang ditolak */
		private void viewData()
		{
			conn.QueryString  = "select * from ACC_GIRO where CU_REF='" + LBL_CUREF.Text  + "'";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();

			conn.QueryString = "select NUMBOUNCECHEQUE from CUST_BOUNCECHEQUE where cu_ref='" + Request.QueryString["curef"]  +"'"; 
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				TXT_JMLBC.Text=conn.GetFieldValue("NUMBOUNCECHEQUE");
			}
			else
			{
				TXT_JMLBC.Text="0";
			}
		}

		/* menampilkan semua cek yang ditolak untuk semua rekening yang terdaftar pad suatu cu_ref */
		private void view_listbouncecheque()
		{
			/**
			conn.QueryString  = "select ACC_NO, CHEQUE_NO, CHEQUE_AMOUNT, CHEQUE_RETURN_DATE, BAD_CHEQUE_REASON ";
			conn.QueryString += "from BOUNCE_CHEQUE where ACC_NO in ";
			conn.QueryString += "(select ACC_GIRO from ACC_GIRO where CU_REF='" + LBL_CUREF.Text + "') ";
			conn.QueryString += "and datediff(month, CHEQUE_RETURN_DATE, getdate()) <= '" + DDL_TIMERANGE.SelectedValue + "'";
			**/

			conn.QueryString = "select * from VW_DE_BOUNCE_CHEQUE_LIST where CU_REF = '" + LBL_CUREF.Text + "' and CHEQUE_RETURN_DATE_cond <= '" + DDL_TIMERANGE.SelectedValue + "'";
			conn.ExecuteQuery();

			//Response.Write("<!-- connstring : " + conn.QueryString.ToString() + " -->");

			LBL_TOTAL_BC.Text	= "Jumlah Cek yang Ditolak:  " + conn.GetRowCount();
			TXT_JMLBC.Text		= conn.GetRowCount().ToString();

			DataTable data1 = new DataTable();
			data1 = conn.GetDataTable().Copy();
			DGR_LIST2.DataSource = data1;
			DGR_LIST2.DataBind();
		}

		
		private void Button1_Click(object sender, System.EventArgs e)
		{
			UploadBounceCheque();
		}

		private void UploadBounceCheque()
		{

			StreamReader sr1=File.OpenText(@"C:\Inetpub\ftproot\LCUCCHQ");
			string strHasil;
			int l1;
			string x,xTemp;

			SqlConnection oConn = new  SqlConnection((string)Session["ConnString"]);	

			oConn.Open();
			SqlCommand cmd = oConn.CreateCommand();
			while ((strHasil=sr1.ReadLine())!=null)
			{
				x="insert into bounce_cheque(acc_no,acc_type,cheque_no,cheque_amount," + 
					"cheque_return_date,bad_cheque_reason_code,bad_cheque_reason) values(";
				cmd.CommandText="select * from bounce_cheque";
				SqlDataReader dr = cmd.ExecuteReader();
				if(dr.HasRows)
				{
					dr.Close();
					cmd.CommandText="delete from bounce_cheque";
					cmd.ExecuteNonQuery();
				}
				else
				{
					dr.Close();
				}
				int pos=0;
				cmd.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='2'";
				dr = cmd.ExecuteReader();
				while(dr.Read())
				{
					int intLengthLast;
					int intStart,intLength;
					intStart=pos;
					intLength=dr.GetInt32(3);
					if(dr.GetString(2)=="N")
					{
						xTemp=strHasil.Substring(pos,intLength);
						l1=dr.GetInt32(4);
						if(l1>0)
						{
							xTemp=xTemp.Substring(0,intLength-l1)+"."+ xTemp.Substring(intLength-l1,l1);
						}
						x=x+xTemp;
					}
					else if(dr.GetString(2)=="C")
					{
						intLengthLast=strHasil.Length-pos;
						if (intLengthLast<intLength)
						{
							x=x+"'"+strHasil.Substring(pos,intLengthLast)+"'";
						}
						else
						{
							x=x+"'"+strHasil.Substring(pos,intLength)+"'";
						}
					}
					else if(dr.GetString(2)=="D")
					{
						string strTgl;
						strTgl=	strHasil.Substring(pos,intLength);
						strTgl=strTgl.Substring(2,2)+"/"+strTgl.Substring(0,2)+"/"+strTgl.Substring(4,4);
						x=x+"'"+strTgl+"'";
					}
					pos=pos+intLength;
					if(pos<strHasil.Length)
					{
						x=x+",";
					}
					else
					{
						x=x+")";
					}
				}
				conn.QueryString=x;
				conn.ExecuteNonQuery();
				x="";
				dr.Close(); 
			}
			sr1.Close(); 
			GlobalTools.popMessage(this,"Upload bounce cheque finished.");

		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="delete")
			{
				string acc_no = e.Item.Cells[1].Text.Trim();
				string sql = "delete from acc_giro where acc_giro='" + acc_no + "'";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
				viewData();
			}
		}

		protected void BTN_SEARCH_Click(object sender, System.EventArgs e)
		{
			view_listbouncecheque();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListCustomer.aspx?tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
		
		}
		protected void DGR_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}
		protected void DGR_LIST2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
