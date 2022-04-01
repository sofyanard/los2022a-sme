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

namespace SME.BlackList
{
	/// <summary>
	/// Summary description for InternalCheck.
	/// </summary>	
	public partial class InternalCheck : System.Web.UI.Page
	{
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			// Put user code to initialize the page here
			if (!IsPostBack) 
			{
				redirect();
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

		private void redirect() 
		{
			conn.QueryString = "select * from APP_PARAMETER";
			conn.ExecuteQuery();

			string dir = @conn.GetFieldValue("BL_BACKUPDIR");
			string root = @conn.GetFieldValue("APP_ROOT");

			string file = Request.QueryString["regno"];
			string temp = @"\SME\" + @dir + @"\" + file + ".txt";	
			string temp2 = @dir + @"\" + file + ".txt";	

			if (!System.IO.File.Exists(@root + @temp2)) 
			{
				string msgfile = root.Replace("\\", "/") + temp2.Replace("\\", "/");
				Tools.popMessage(this, "File " + msgfile + " tidak ada !");
				Response.Write("<script language='javascript'>history.back(-1);</script>");
			}
			else
				Response.Redirect("/SME/BlackList/BlackListText.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&de="+Request.QueryString["de"]+"&file="+temp);
		}
	}
}
