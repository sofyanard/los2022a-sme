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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for MainReportPortfolio.
	/// </summary>
	public partial class MainReportPortfolio : System.Web.UI.Page
	{
		private void InitializeComponent()
		{

		}

		protected System.Web.UI.WebControls.Label Label60;
		protected System.Web.UI.WebControls.Label Label7;
		/*
			private void Page_Load(object sender, System.EventArgs e)
			{
				// Put user code to initialize the page here
				conn = (Connection) Session["Connection"];
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

				string tmp_bussid="";
				string tmp_bussid2 ="";

				conn.QueryString = "exec CatchBusinessUnit '" + Request.QueryString["BU"] + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					for(int i=0;i<conn.GetRowCount();i++)
					{
						if(!tmp_bussid.Equals(""))
						{
							tmp_bussid += ","; 
						}
						tmp_bussid += "'" + conn.GetFieldValue(i,0) + "'";

						if(!tmp_bussid2.Equals(""))
						{
							tmp_bussid2 += ","; 
						}
						tmp_bussid2 += "''" + conn.GetFieldValue(i,0) + "''";

					}
				}
				Session.Add("bussunitid",tmp_bussid.ToString());
				//Session.Add("bussunitid2",tmp_bussid2.ToString()); //ahmad
				//Session.Add("bussunitid2",""); //ahmad
				try 
				{
					Session.Add("bussunitid2"," ''"+Request.QueryString["BU"].ToString()+"'' "); //doni again
				}
				catch
				{
					Session.Add("bussunitid2","");
				}

				conn.QueryString = "select sg_grpunit from scgroup where groupid='" + Session["GroupID"] + "'  ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
				{
					Session.Add("sg_grpunit",conn.GetFieldValue(0,0));
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
				this.Load += new System.EventHandler(this.Page_Load);

			}
			#endregion
		}*/
	}
}
