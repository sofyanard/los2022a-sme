using System.Web;
using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Web.Mail;
using DMS.DBConnection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMS.CuBESCore;

namespace SME
{
	/// <summary>
	/// Summary description for Connection
	/// </summary>
	/// 

		public class MyConnection
		{
			private SqlConnection myConn;
			private SqlCommand myCMD;
			private SqlDataReader myReader;
			private static string koneksi = ConfigurationSettings.AppSettings["conn"];

			public static double ChannelingOnlyConvertToDouble(string s)
			{
				if(s.EndsWith(".00"))
				{
					//s = s.Replace(".00","");
					s = s.Remove(s.Length - 3,3);
				}
				else if(s.EndsWith(",00"))
				{
					s = s.Remove(s.Length - 3,3);
				}
			
				s = s.Replace(".","");
				s = s.Replace(",","");
				s = s.Replace("%","");

				System.Globalization.CultureInfo oldCI;
				oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			
				double b = Convert.ToDouble(s);
				System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

				return b;
			}

			public static bool SendEmail(string FromAddress, string ToAddress, string Subject, string Content)
			{
				MailMessage oMessage = new MailMessage();
				oMessage.To = ToAddress;
				oMessage.From = FromAddress;
				oMessage.Subject = Subject;
				oMessage.Body = Content;

				System.Web.Mail.SmtpMail.SmtpServer = "10.204.5.104";

				try
				{
					System.Web.Mail.SmtpMail.Send(oMessage);
					return true;
				}
				catch (Exception Ex)
				{
					string ErrorMessage = Ex.InnerException.InnerException.Message.ToString();
					return false;
				}

				return true;
			}	

			public static void SendAllEmail()
			{
				Connection conn = new Connection(koneksi);
				Connection conn2 = new Connection(koneksi);
				conn.QueryString = "SELECT * FROM EMAIL_MESSAGE WHERE IS_SENT = '0'";
				conn.ExecuteQuery();

				//need threading
				for(int i=0; i<conn.GetRowCount(); i++)
				{
					SendEmail(conn.GetFieldValue(i,"FROM").ToString(), conn.GetFieldValue(i,"TO").ToString(), conn.GetFieldValue(i,"SUBJECT").ToString(), conn.GetFieldValue(i,"MESSAGE").ToString());
				
					conn2.QueryString = "UPDATE EMAIL_MESSAGE SET IS_SENT = '1' WHERE SEQ = '" + conn.GetFieldValue(i,"SEQ") + "'";
					conn2.ExecuteQuery();
				}
			}

			public void SendAllSyndicationEmail()
			{
				
			}

			public static double ConvertToDouble(string s)
			{
				if(s.EndsWith(".00"))
				{
					//s = s.Replace(".00","");
					s = s.Remove(s.Length - 3,3);
				}
				else if(s.EndsWith(",00"))
				{
					s = s.Remove(s.Length - 3,3);
				}
			
				s = s.Replace(".",".");
				s = s.Replace(",",".");

				System.Globalization.CultureInfo oldCI;
				oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			
				double b = Convert.ToDouble(s);
				System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

				return b;
			}

			public static double ConvertToDouble2(string s)
			{
				s = s.Replace(",",".");
				s = s.Replace("%","");

				/*if(s.EndsWith(".00"))
				{
					//s = s.Replace(".00","");
					s = s.Remove(s.Length - 3,3);
				}
				else if(s.EndsWith(",00"))
				{
					s = s.Remove(s.Length - 3,3);
				}*/

				int i = 0;
				for(int a = 0; a < s.Length; a++)
				{
					if(s[a] == '.')
					{
						i++;
					}
				}

				if(i > 1)
				{
					for(int a = 0; a < s.Length; a++)
					{
						if(s[a] == '.' || s[a] == ',')
						{
							if(a != (s.Length - 3))
							{
								s = s.Remove(a,1);
							}
						}
					}
				}

				System.Globalization.CultureInfo oldCI;
				oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			
				double b = Convert.ToDouble(s);
				System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

				return b;
			}

			public static float ConvertToFloat(string s)
			{
				if(s.EndsWith(".00"))
				{
					s = s.Remove(s.Length - 3,3);
				}
				else if(s.EndsWith(",00"))
				{
					s = s.Remove(s.Length - 3,3);
				}
			
				s = s.Replace(".","");
				s = s.Replace(",","");

				System.Globalization.CultureInfo oldCI;
				oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			
				float c = float.Parse(s);
				System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

				return c;
			}

			public MyConnection()
			{
				myConn = new SqlConnection(koneksi);
			}

			public string OpenConnection()
			{
				try
				{
					myConn.Open();
					return "Opening connection succeeded";
				}
				catch (Exception ex)
				{
					return ex.Message.ToString();
				}
			}

			public string CloseConnection()
			{
				try
				{
					myConn.Close();
					return "Connection closed successily";
				}
				catch (Exception ex)
				{
					return ex.Message.ToString();
				}
			}

			public int Execute(string SQL)
			{
				int rows;

				myCMD = new SqlCommand(SQL, myConn);
				rows = myCMD.ExecuteNonQuery();
				return rows;
			}

			public SqlDataReader Query(string SQL)
			{
				myCMD = new SqlCommand(SQL, myConn);
				myReader = myCMD.ExecuteReader();
				return myReader;
			}
		}
		

		public class TheATeam
		{
			public static string controlid = "";

			public static string cekMandatoryField(Control thecontrol)
			{
				controlid = "";

				foreach(Control control in thecontrol.Controls)
				{
					if(control.Controls.Count > 0)
					{
						cekMandatoryField(control);
					}
					else
					{
						if(control is DropDownList)
						{
							DropDownList ddl = (DropDownList)control;
							if(ddl.CssClass == "mandatory")
							{
								if(ddl.SelectedIndex == 0)
								{
									controlid = ddl.ID.Replace("_"," ").Replace("DDL ","");
									break;
								}
							}
						}
						else if(control is TextBox)
						{
							TextBox tbx =  (TextBox)control;
							if(tbx.CssClass == "mandatory")
							{
								if(tbx.Text == "")
								{
									controlid = tbx.ID.Replace("_"," ").Replace("TXT ","");
									break;
								}
							}
						}
					}
				}

				return controlid;
			}
		}
	}
