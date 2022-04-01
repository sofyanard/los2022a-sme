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
using System.IO;
using System.Configuration;
using DMS.DBConnection;
using System.Xml;

namespace SME
{
	/// <summary>
	/// Summary description for Body. 
	/// </summary>
	public partial class Body : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection connESecurity = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//conn = new Connection(Session["ConnString"].ToString());
			conn = (Connection) Session["Connection"];

			connESecurity.QueryString = "select moduleid, modulename from vw_grpaccessmodule where groupid = '" + Session["GroupID"].ToString() + "' and menu_display = '1'";
			connESecurity.ExecuteQuery();


			if (connESecurity.GetRowCount() > 1)
			{
				for (int i = 0; i < connESecurity.GetRowCount(); i++)
				{
					LinkButton lb = new LinkButton();
					lb.Text = connESecurity.GetFieldValue(i, "modulename");
					lb.Font.Bold = true;
					lb.Font.Name = "verdana";
					lb.Font.Size = FontUnit.Point(8);
					lb.ForeColor = Color.RoyalBlue;

					if (connESecurity.GetFieldValue(i, "moduleid") == ConfigurationSettings.AppSettings["ModuleID"].ToString())
					{
						lb.ForeColor = Color.BlueViolet;
						lb.Attributes.Add("onclick", "return false;");
					}	
					else lb.Click += new EventHandler(lb_Click);

					PlaceHolder1.Controls.Add(lb);
					PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				}
				if (!IsPostBack)
				{
					Label1.Text = connESecurity.GetFieldValue(0, "moduleid");
				}
			}
			else
			{
				if (!IsPostBack)
				{
					try
					{
						Label1.Text = connESecurity.GetFieldValue(0, "moduleid");						
					}
					catch {}
				}
			}

			LoadMenu();
			showPendingApplicationsMessage();
		}			

		/// <summary>
		/// Menentukan apakah user yang login perlu diperlihatkan aplikasi yang pending pada tiap track
		/// (Cek apakah user itu BU atau bukan)
		/// </summary>
		/// <param name="userid"></param>
		/// <returns></returns>
		private bool isShowPendingApplication(string userid) 
		{
			bool isShow = false;

			conn.QueryString = "select * from VW_PENDINGAPPLICATION_SHOW where userid = '" + userid + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) isShow = true;

			return isShow;
		}

		/// <summary>
		/// Menampilkan pesan jumlah aplikasi yang pending di tiap track.
		/// Pesan hanya muncul jika user yang login ada BU (Business Unit).
		/// </summary>
		//private void showPendingApplicationsMessage()
        public string showPendingApplicationsMessage()
		{
			/// Mengambil jumlah kemunculan pesan aplikasi
			/// 
            string result = "";
			int pendingAppCount = 0;
			try { pendingAppCount = (int) Session["pendingAppCount"]; } 
			catch { 
				// get the default value (0)
			}

			try 
			{
				if (this.isShowPendingApplication(Session["UserID"].ToString()) && pendingAppCount != 1) 
				{
					//Response.Write("<script for=window event=onload language='javascript'>PopupPage('PendingApplicationInfo.aspx?targetFormID=Form1&targetObjectID=TXT_CON', '450','480');</script>");
                    result = "<script for=window event=onload language='javascript'>PopupPage('PendingApplicationInfo.aspx?targetFormID=Form1&targetObjectID=TXT_CON', '450','480');</script>";
				}
			} 
			catch (Exception ex)
			{
				/// Turn it on if you want to debug
				/// 
				//Response.Write("<!-- " + ex.Message + "--->");
			}
            return result;
		}

        private string LoadXML(string element)
        {
            string renderedMenu = "";
            string URL = "";
            string Label = "";
            int prevDepth = 0;
            string prevElement = "";
            int selisih = 0;

            using (XmlReader reader = XmlReader.Create(element))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "MenuData":
                            if (renderedMenu == "")
                            {
                                renderedMenu += "<div class=\"Menus\"><ul class=\"sf-menu\">";
                            }
                            break;
                        case "MenuGroup":
                            //cek selisih minus atau plus !
                            selisih = prevDepth - reader.Depth;
                            if (selisih > 0)
                            {
                                renderedMenu += "</ul>";
                            }
                            else
                            {
                                int Place = renderedMenu.LastIndexOf("</li>");
                                if (Place > 0)
                                {
                                    renderedMenu = renderedMenu.Remove(Place, ("</li>".Length)).Insert(Place, "<ul>");
                                }
                            }

                            if (reader.IsEmptyElement)
                            {
                                int Place = renderedMenu.LastIndexOf("<ul>");
                                if (Place > 0)
                                {
                                    renderedMenu = renderedMenu.Remove(Place, ("<ul>".Length)).Insert(Place, "</li>");
                                }
                            }
                            prevElement = "MenuGroup";
                            break;
                        case "MenuItem":
                            if (reader.HasAttributes)
                            {
                                /*selisih = prevDepth - reader.Depth;
                                if (selisih < 0)
                                {
                                    renderedMenu += "</ul>";
                                }
                                if (reader.Depth == 2)
                                {
                                    prevElement = "Node";
                                }*/

                                URL = reader.GetAttribute("URL");
                                if (URL == null)
                                {
                                    URL = "#";
                                }
                                Label = reader.GetAttribute("Label");
                                renderedMenu += "<li><a href=\"" + URL + "\">" + Label + "</a></li>";
                            }
                            prevElement = "MenuItem";
                            break;
                    }
                    prevDepth = reader.Depth;
                }
            }

            renderedMenu += "</ul></div>";
            return renderedMenu;
        }

		private void LoadMenu()
		{	
			string loginUrl = "";

			connESecurity.QueryString = "select login_scr from rfmodule where moduleid = '" + ConfigurationSettings.AppSettings["ModuleID"] + "'";
			connESecurity.ExecuteQuery();
			if (connESecurity.GetRowCount() > 0)
				loginUrl = connESecurity.GetFieldValue(0, "login_scr");
			
			conn.QueryString = "select app_root + menudir, menudir from rfmodule where moduleid='" + ConfigurationSettings.AppSettings["ModuleID"] + "'";
			conn.ExecuteQuery();

			//string temp = conn.GetFieldValue(0,0) + "Maintenance\\MenuAccess\\" + groupID + "-MenuData.xml";

			string a = conn.GetFieldValue(0,0) + Session["GroupID"].ToString() + "-MenuData.xml";

			if (File.Exists(conn.GetFieldValue(0,0) + Session["GroupID"].ToString() + "-MenuData.xml"))
//			if (File.Exists("D:\\Project\\Development\\SME\\Maintenance\\MenuAccess\\" + Session["GroupID"].ToString() + "-MenuData.xml"))
			{			
				try
				{
					//Menu1.MenuData = "D:\\Project\\Development\\SME\\Maintenance\\MenuAccess\\" + Session["GroupID"].ToString() + "-MenuData.xml";
					a = conn.GetFieldValue(0,1).Replace("\\", "/") + Session["GroupID"].ToString() + "-MenuData.xml";
					//Menu1.MenuData = conn.GetFieldValue(0,1).Replace("\\", "/") + Session["GroupID"].ToString() + "-MenuData.xml";
                    MenuDIV.InnerHtml += LoadXML(ConfigurationManager.AppSettings["serverPath"] + conn.GetFieldValue(0, 1).Replace("\\", "/") + Session["GroupID"].ToString() + "-MenuData.xml");
				}
				catch
				{
                    Response.Redirect(loginUrl + "?expire=1");
				}
			}
			else
			{
				Response.Redirect(loginUrl + "?menu=0");
			}

			/*
			if (File.Exists(conn.GetFieldValue(0,0) + "Maintenance\\MenuAccess\\" + Session["GroupID"] + "-MenuData.xml"))
			{			
				try
				{
					Menu1.MenuData = "Maintenance/MenuAccess/" + Session["GroupID"] + "-MenuData.xml";
				}
				catch
				{
					Response.Redirect("Login.aspx?expire=1");
				}
			}
			else
			{
				Response.Redirect("Login.aspx?menu=0");
			}
			*/
		}

//		private void RedirectOnLoad(string url)
//		{
//			Response.Write("<script for='window' event='onload'>\n");
//			Response.Write("var head = null;\n");
//			Response.Write("try {\n");
//			Response.Write("\tif (window.parent!=null && window.parent.frames.length>=3)\n");
//			Response.Write("\t\thead = window.parent.frames(0).document.Form1;\n");
//			Response.Write("\tif (head!=null) head.logout.value = '1';\n");
//			Response.Write("} catch (e) { }\n");
//			Response.Write("top.location = '" + url + "';\n");
//			Response.Write("</script>\n");
//		}

		private void lb_Click(object sender, System.EventArgs e)
		{
			string appURL = "";

			LinkButton lbl = (LinkButton) sender;
			connESecurity.QueryString = "select app_url, moduleid from rfmodule where modulename = '" + lbl.Text + "'";
			connESecurity.ExecuteQuery();
			
			if (connESecurity.GetRowCount() > 0)
				appURL = connESecurity.GetFieldValue(0,0);
			
			string token = System.Guid.NewGuid().ToString();
					
			connESecurity.QueryString = "exec ES_SAVETOKEN '" + token + "', '" + connESecurity.GetFieldValue(0, "moduleid") + "', '" + Session["UserID"].ToString() + "', '" + 
				Session["FullName"].ToString() + "', '" + 
				Session["GroupID"].ToString() + "', '" + 
				Session["BranchID"].ToString() + "', '" + 
				Session["AreaID"].ToString() + "', '" + 
				Session["CBC"].ToString() + "', '" + 
				Session["PWD"].ToString() + "'";
			connESecurity.ExecuteNonQuery();
					
			string link = appURL + "?gid=" + Session["GroupID"].ToString() + "&tkn=" + token;
			Response.Redirect(link);
		}

        public int getPendingCount()
        {
            conn.QueryString = "exec PENDINGAPPLICATIONLIST '" + (string)Session["UserID"] + "'";
            conn.ExecuteQuery();

            var appCount = conn.GetDataTable().Rows.Count;

            conn.QueryString = "exec PENDINGMESSAGELIST '" + (string)Session["UserID"] + "'";
            conn.ExecuteQuery();

            var msgCount = conn.GetDataTable().Rows.Count;

            return appCount + msgCount;
        }
			/*
			conn = (Connection) Session["Connection"];
			//conn = new Connection(Session["ConnectionString"].ToString());
			
			conn.QueryString = "select app_root from app_parameter";
			conn.ExecuteQuery();

			if (File.Exists(conn.GetFieldValue(0,0) + "Maintenance\\MenuAccess\\" + Session["GroupID"] + "-MenuData.xml"))
			{			
				try
				{
					Menu1.MenuData = "Maintenance/MenuAccess/" + Session["GroupID"] + "-MenuData.xml";
				}
				catch
				{
					Response.Redirect("Login.aspx?expire=1");
				}
			}
			else
			{
				Response.Redirect("Login.aspx?menu=0");
			}
			*/

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
