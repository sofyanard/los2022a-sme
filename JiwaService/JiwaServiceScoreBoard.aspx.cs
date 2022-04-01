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

namespace SME.JiwaService
{
	/// <summary>
	/// Summary description for JiwaServiceScoreBoard.
	/// </summary>
	public partial class JiwaServiceScoreBoard : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		//protected System.Web.UI.WebControls.TextBox undefined;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{	
				TR_SCORING.Visible=false;

				DeptData();
				ViewData();
			}

			TR_SCORING.Visible=true;

			conn.QueryString = "EXEC JWS_SCORE_BOARD '" +
				Session["UserID"].ToString() + "','" +
				Session["BranchID"].ToString() + "','" +
				DDL_DEPT_NAME.SelectedValue + "'";
			conn.ExecuteQuery();

			string a = conn.GetFieldValue("SELF").ToString().Replace(",",".");
			string b = conn.GetFieldValue("CUSTOMER").ToString().Replace(",",".");
			string c = conn.GetFieldValue("VALIDATION").ToString().Replace(",",".");	
			
			if(int.Parse(a) == 0 && int.Parse(b) == 0 && int.Parse(c) == 0)
			{
				//int undef = 100 - (int.Parse(a) + int.Parse(b) + int.Parse(c));
				selfassesment.Text = a.ToString();
				internalcustomer.Text = b.ToString();
				validation.Text = c.ToString();
				//undefined.Text = undef.ToString();
			}

			else if(int.Parse(a) != 0 && int.Parse(b) != 0 && int.Parse(c) != 0)
			{
				//int undef = 100 - (int.Parse(a) + int.Parse(b) + int.Parse(c));
				//undef = undef / 3;

				double self = MyConnection.ConvertToDouble(a);// + undef;
				double customer = MyConnection.ConvertToDouble(b);// + undef;
				double valid = MyConnection.ConvertToDouble(c);// + undef;
			
				//int undef_result = 100 - (int.Parse(self.ToString()) + int.Parse(customer.ToString()) + int.Parse(valid.ToString()));

				selfassesment.Text = self.ToString();
				internalcustomer.Text = customer.ToString();
				validation.Text = valid.ToString();
				//undefined.Text = undef_result.ToString();
			}

			else if(int.Parse(a) != 0 && int.Parse(b) != 0 && int.Parse(c) == 0)
			{
				//int undef = 100 - (int.Parse(a) + int.Parse(b));
				//undef = undef / 2;

				double self = MyConnection.ConvertToDouble(a);// + undef;
				double customer = MyConnection.ConvertToDouble(b);// + undef;
			
				//int undef_result = 100 - (int.Parse(self.ToString()) + int.Parse(customer.ToString()));

				selfassesment.Text = self.ToString();
				internalcustomer.Text = customer.ToString();
				validation.Text = c.ToString();
				//undefined.Text = undef_result.ToString();
			}

			else if(int.Parse(a) != 0 && int.Parse(b) == 0 && int.Parse(c) != 0)
			{
				//int undef = 100 - (int.Parse(a) + int.Parse(c));
				//undef = undef / 2;

				double self = MyConnection.ConvertToDouble(a);// + undef;
				double valid = MyConnection.ConvertToDouble(c);// + undef;
			
				//int undef_result = 100 - (int.Parse(self.ToString()) + int.Parse(valid.ToString()));

				selfassesment.Text = self.ToString();
				internalcustomer.Text = b.ToString();
				validation.Text = valid.ToString();
				//undefined.Text = undef_result.ToString();
			}

			else if(int.Parse(a) == 0 && int.Parse(b) != 0 && int.Parse(c) != 0)
			{
				//int undef = 100 - (int.Parse(b) + int.Parse(c));
				//undef = undef / 2;

				double customer = MyConnection.ConvertToDouble(b);// + undef;
				double valid = MyConnection.ConvertToDouble(c);// + undef;
			
				//int undef_result = 100 - (int.Parse(customer.ToString()) + int.Parse(valid.ToString()));

				selfassesment.Text = a.ToString();
				internalcustomer.Text = customer.ToString();
				validation.Text = valid.ToString();
				//undefined.Text = undef_result.ToString();
			}

			else if(int.Parse(a) != 0 && int.Parse(b) == 0 && int.Parse(c) == 0)
			{
				//int undef = 100 - (int.Parse(a));

				selfassesment.Text = a.ToString();
				internalcustomer.Text = b.ToString();
				validation.Text = c.ToString();
				//undefined.Text = undef.ToString();
			}

			else if(int.Parse(a) == 0 && int.Parse(b) != 0 && int.Parse(c) == 0)
			{
				//int undef = 100 - (int.Parse(b));

				selfassesment.Text = a.ToString();
				internalcustomer.Text = b.ToString();
				validation.Text = c.ToString();
				//undefined.Text = undef.ToString();
			}

			else if(int.Parse(a) == 0 && int.Parse(b) == 0 && int.Parse(c) != 0)
			{
				//int undef = 100 - (int.Parse(c));

				selfassesment.Text = a.ToString();
				internalcustomer.Text = b.ToString();
				validation.Text = c.ToString();
				//undefined.Text = undef.ToString();
			}

			/*int undef = 100 - (int.Parse(a) + int.Parse(b) + int.Parse(c));
			undef = undef / 3;

			double self = MyConnection.ConvertToDouble(a) + undef;
			double customer = MyConnection.ConvertToDouble(b) + undef;
			double valid = MyConnection.ConvertToDouble(c) + undef;
			
			int undef_result = 100 - (int.Parse(self.ToString()) + int.Parse(customer.ToString()) + int.Parse(valid.ToString()));

			selfassesment.Text = self.ToString();
			internalcustomer.Text = customer.ToString();
			validation.Text = valid.ToString();
			undefined.Text = undef_result.ToString();*/

			TXT_SCORE.Text = conn.GetFieldValue("SCORE").ToString();
			TXT_CATEGORY.Text = conn.GetFieldValue("CATEGORY").ToString();
			
		}

		private void DeptData()
		{
			DDL_DEPT_NAME.Items.Clear();
			conn.QueryString = "SELECT * FROM VW_JWS_SELF WHERE USERID='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_DEPT_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,5), conn.GetFieldValue(i,4)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_JWS_GROUP WHERE USERID='" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			TXT_NAME.Text =  conn.GetFieldValue(0,1);
			TXT_GROUP.Text =  conn.GetFieldValue(0,3);
			
			conn.QueryString="EXEC FORMAT_DATE ''";
			conn.ExecuteQuery();

			TXT_DATE.Text = conn.GetFieldValue("TANGGAL");
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
			this.BTN_RETRIEVE.Click += new System.EventHandler(this.BTN_RETRIEVE_Click);

		}
		#endregion

		protected void BTN_RETRIEVE_Click(object sender, System.EventArgs e)
		{
			TR_SCORING.Visible=true;

			conn.QueryString = "EXEC JWS_SCORE_BOARD '" +
				Session["UserID"].ToString() + "','" +
				Session["BranchID"].ToString() + "','" +
				DDL_DEPT_NAME.SelectedValue + "'";
			conn.ExecuteQuery();

			selfassesment.Text = conn.GetFieldValue("SELF").ToString();
			internalcustomer.Text = conn.GetFieldValue("CUSTOMER").ToString();
			validation.Text = conn.GetFieldValue("VALIDATION").ToString();

			TXT_SCORE.Text = conn.GetFieldValue("SCORE").ToString();
			TXT_CATEGORY.Text = conn.GetFieldValue("CATEGORY").ToString();

			
		}
	}
}
