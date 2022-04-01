using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Mail;
using System.Web.Caching;
using System.Web.SessionState;
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		//protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		public Global()
		{
			InitializeComponent();
		}	
		
		//daily email sending process
		//once a day sending all email
		//public static System.Timers.Timer timer = new System.Timers.Timer(86400000);
		public static System.Timers.Timer timer = new System.Timers.Timer(360000);

		protected Connection conn = new Connection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn3 = new Connection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn4 = new Connection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn5 = new Connection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);

		protected void Application_Start(Object sender, EventArgs e)
		{
			// USING TIMER METHOD
			/*timer.Enabled = true;
			timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);*/

			// USING THREADING METHOD
			/*Thread oThread = new Thread(new ThreadStart(SendEmail1));
			Thread oThread2 = new Thread(new ThreadStart(SendEmail2));
			Thread oThread3 = new Thread(new ThreadStart(SendEmail3));
			Thread oThread4 = new Thread(new ThreadStart(SendEmail4));
			Thread oThread5 = new Thread(new ThreadStart(SendEmail5));

			oThread.Start();
			oThread2.Start();
			oThread3.Start();
			oThread4.Start();
			oThread5.Start();*/
		}
		
		static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if(System.DateTime.Now.TimeOfDay.ToString().StartsWith("09:4"))
			{	// Need a threading to boost the sending process
				
			}
			//MyConnection.SendEmail("purapura@bankmandiri.co.id", "prasetyo.wibowo@bankmandiri.co.id", "Tes accessed through conditional statements", System.DateTime.Now.TimeOfDay.ToString());
		}

		public void SendAllEmail()
		{
			/*
			 *	SEQ
				FROM
				TO
				SUBJECT
				MESSAGE
				IS_SENT
				DATE_SENT
			 * */

			
		}

		public void SendEmail1()
		{
			while (true)
			{
				conn.QueryString = "SELECT TOP 1 * FROM EMAIL_MESSAGE WHERE IS_SENT = 0";
				conn.ExecuteQuery();
				MyConnection.SendEmail(conn.GetFieldValue("FROM"), conn.GetFieldValue("TO"), conn.GetFieldValue("SUBJECT"), System.DateTime.Now.TimeOfDay.ToString());
				string seq = conn.GetFieldValue("SEQ").ToString();

				if(seq.ToString() != "")
				{
					conn.QueryString = "UPDATE EMAIL_MESSAGE SET IS_SENT = 1, DATE_SENT = '" + System.DateTime.Now.TimeOfDay.ToString() + "' WHERE SEQ = " + seq;
					conn.ExecuteQuery();
				}
			}
		}

		public void SendEmail2()
		{
			while (true)
			{
				conn2.QueryString = "SELECT TOP 1 * FROM EMAIL_MESSAGE WHERE IS_SENT = 0";
				conn2.ExecuteQuery();
				MyConnection.SendEmail(conn2.GetFieldValue("FROM"), conn2.GetFieldValue("TO"), conn2.GetFieldValue("SUBJECT"), conn2.GetFieldValue("MESSAGE"));
				string seq = conn2.GetFieldValue("SEQ").ToString();

				if(seq.ToString() != "")
				{
					conn2.QueryString = "UPDATE EMAIL_MESSAGE SET IS_SENT = 1, DATE_SENT = '" + System.DateTime.Now.TimeOfDay.ToString() + "' WHERE SEQ = " + seq;
					conn2.ExecuteQuery();
				}
			}
		}

		public void SendEmail3()
		{
			while (true)
			{
				conn3.QueryString = "SELECT TOP 1 * FROM EMAIL_MESSAGE WHERE IS_SENT = 0";
				conn3.ExecuteQuery();
				MyConnection.SendEmail(conn3.GetFieldValue("FROM"), conn3.GetFieldValue("TO"), conn3.GetFieldValue("SUBJECT"), conn3.GetFieldValue("MESSAGE"));
				string seq = conn3.GetFieldValue("SEQ").ToString();

				if(seq.ToString() != "")
				{
					conn3.QueryString = "UPDATE EMAIL_MESSAGE SET IS_SENT = 1, DATE_SENT = '" + System.DateTime.Now.TimeOfDay.ToString() + "' WHERE SEQ = " + seq;
					conn3.ExecuteQuery();
				}
			}
		}

		public void SendEmail4()
		{
			while (true)
			{
				conn4.QueryString = "SELECT TOP 1 * FROM EMAIL_MESSAGE WHERE IS_SENT = 0";
				conn4.ExecuteQuery();
				MyConnection.SendEmail(conn4.GetFieldValue("FROM"), conn4.GetFieldValue("TO"), conn4.GetFieldValue("SUBJECT"), conn4.GetFieldValue("MESSAGE"));
				string seq = conn4.GetFieldValue("SEQ").ToString();

				if(seq.ToString() != "")
				{
					conn4.QueryString = "UPDATE EMAIL_MESSAGE SET IS_SENT = 1, DATE_SENT = '" + System.DateTime.Now.TimeOfDay.ToString() + "' WHERE SEQ = " + seq;
					conn4.ExecuteQuery();
				}
			}
		}

		public void SendEmail5()
		{
			while (true)
			{
				conn5.QueryString = "SELECT TOP 1 * FROM EMAIL_MESSAGE WHERE IS_SENT = 0";
				conn5.ExecuteQuery();
				MyConnection.SendEmail(conn5.GetFieldValue("FROM"), conn5.GetFieldValue("TO"), conn5.GetFieldValue("SUBJECT"), conn5.GetFieldValue("MESSAGE"));
				string seq = conn5.GetFieldValue("SEQ").ToString();

				if(seq.ToString() != "")
				{
					conn5.QueryString = "UPDATE EMAIL_MESSAGE SET IS_SENT = 1, DATE_SENT = '" + System.DateTime.Now.TimeOfDay.ToString() + "' WHERE SEQ = " + seq;
					conn5.ExecuteQuery();
				}
			}
		}

		public void CountDQM()
		{

		}

		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
            // if session is lost
            /*
			if (Session["UserID"]==null)
			{
				Server.ClearError();
				Response.Redirect(Request.ApplicationPath + "/Logout.aspx?login", true);
			}
            */
			//Session.Add("ErrorMessage", Server.GetLastError().Message);
			//Server.Transfer("LastError.aspx");
		}

		protected void Session_End(Object sender, EventArgs e)
		{
            /*
            conn.QueryString = "exec SU_USERACTIVITY '" + Session["UserID"].ToString() + "', '" + 
				Session["GroupID"].ToString() + "', '0', '0', '0'";
			conn.ExecuteNonQuery();

			conn.QueryString = "exec SU_ALLUSERACTIVITY '" + Session["UserID"].ToString() + "', '" + 
				Session["GroupID"].ToString() + "', '0', '0', '0', '0'";
			conn.ExecuteNonQuery();
            */
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			try 
			{
				conn.QueryString = "exec SU_USERACTIVITY '" + Session["UserID"].ToString() + "', '" + 
					Session["GroupID"].ToString() + "', '0', '0', '0'";
				conn.ExecuteNonQuery();

				conn.QueryString = "exec SU_ALLUSERACTIVITY '" + Session["UserID"].ToString() + "', '" + 
					Session["GroupID"].ToString() + "', '0', '0', '0', '0'";
				conn.ExecuteNonQuery();
			}	catch { }
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

