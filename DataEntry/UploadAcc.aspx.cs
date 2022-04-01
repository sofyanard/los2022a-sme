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
using System.Data.SqlClient; 

namespace Test
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class WebForm1 : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			StreamReader sr1=File.OpenText(@"C:\Inetpub\ftproot\LCUCACT");
			string strHasil;
			int l1,l2;
			string x,xTemp;
			x="insert into acc_info(acc_no,acc_type,dept_code,acc_currency," + 
				"original_ammount,current_balance,accrual_interest,accrual_late_charge," +
				"billed_principle,billed_interest,billed_late_charge,billed_other_charge," +
				"billed_misc,coll_bi,coll_bm,npl_stat,acc_stat,tgl_jth_tempo,"+
				"tgl_byr_tghn_pokok,"+
				"tgl_byr_tghn_bunga,loan_term,loan_term_code,suku_bunga," +
				"lama_tunggakan_pokok,lama_tunggakan_bunga) values(";

			SqlConnection conn = new  SqlConnection((string)Session["ConnString"]);	

			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			while ((strHasil=sr1.ReadLine())!=null)
			{
				cmd.CommandText = "Select * from RFUPFILE where upfile_name='ACCOUNT NUMBER' and UPFILE_GROUP='0'";
				SqlDataReader dr = cmd.ExecuteReader();
				dr.Read();
				l2=dr.GetInt32(3);
				xTemp=strHasil.Substring(0,l2);
				dr.Close();
				cmd.CommandText="select * from ACC_INFO where ACC_NO='" + xTemp + "'";
				dr=cmd.ExecuteReader();
				if(dr.HasRows)
				{
					dr.Close();
					cmd.CommandText="delete from ACC_INFO where ACC_NO='" + xTemp + "'";
					cmd.ExecuteNonQuery();
				}
				else
				{
					dr.Close();
				}
				int pos=0;
				cmd.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='0'";
				dr = cmd.ExecuteReader();
				while(dr.Read())
				{
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
						x=x+"'"+strHasil.Substring(pos,intLength)+"'";
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
				dr.Close(); 
			}

			SqlCommand cmdIn=conn.CreateCommand();
			cmdIn.CommandText=x;
			cmdIn.ExecuteNonQuery();
			
			


			

			StreamReader sr2=File.OpenText(@"C:\Inetpub\ftproot\LCUCKOL");
			strHasil="";
			l1=0;l2=0;
			x="";xTemp="";
			int sudahCek=0;
			while ((strHasil=sr2.ReadLine())!=null)
			{
				x="insert into acc_coll(acc_no,acc_type,coll_code,tgl_perubahan_coll,user_id)" +
					" values(";
				cmd.CommandText = "Select * from RFUPFILE where upfile_name='ACCOUNT NUMBER' and UPFILE_GROUP='1'";
				SqlDataReader dr = cmd.ExecuteReader();
				dr.Read();
				l2=dr.GetInt32(3);
				xTemp=strHasil.Substring(0,l2);
				dr.Close();
				if(sudahCek==0) 
				{
					cmd.CommandText="select * from ACC_COLL where ACC_NO='" + xTemp + "'";
					dr=cmd.ExecuteReader();
					if(dr.HasRows)
					{
						dr.Close();
						cmd.CommandText="delete from ACC_COLL where ACC_NO='" + xTemp + "'";
						cmd.ExecuteNonQuery();
					}
					else
					{
						dr.Close();
					}
					sudahCek=1;
				}
				int pos=0;
				cmd.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='1'";
				dr = cmd.ExecuteReader();
				while(dr.Read())
				{
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
						x=x+"'"+strHasil.Substring(pos,intLength)+"'";
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
				dr.Close(); 
				cmdIn.CommandText=x;
				cmdIn.ExecuteNonQuery();
			}
			


			
			
			sr1.Close(); 
			sr2.Close(); 

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

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
