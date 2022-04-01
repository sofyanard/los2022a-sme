using System;
using System.Data;
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for clsUploadVarious.
	/// </summary>
	public class clsUploadVarious
	{
		private Connection conn;
		private string regno;
		private string curef;
		public clsUploadVarious(Connection cons,string reg_no,string cu_ref)
		{
			//
//			// TODO: Add constructor logic here
//			//
//			//Upload Account Info
//			StreamReader sr1=File.OpenText(@"C:\Inetpub\ftproot\LCUCACT");
//			string strHasil,strCekNol="";
//			int l1,l2;
//			string x,xTemp;
//
//			SqlConnection con = new  SqlConnection();	
//			
//			con.ConnectionString = conn.connString;
//			con.Open();
//
//			SqlCommand cmd = con.CreateCommand();
//			SqlCommand cmdIn= con.CreateCommand();
//
//			string szAccNo = "";
//			string szCu_Ref = "";
//			
//			while ((strHasil=sr1.ReadLine())!=null)
//			{
//				try
//				{
//					szAccNo = strHasil.Substring(6,13).Trim();
//					szCu_Ref = strHasil.Substring(230,18).Trim();
//				}
//				catch 
//				{
//					continue;
//				}
//
//				cmd.CommandText = "Select * from acc_info where acc_no = '" + szAccNo + "' and cu_ref = '" + szCu_Ref + "'";
//				SqlDataReader a = cmd.ExecuteReader();
//				if(!a.HasRows)
//				{
//					x="insert into acc_info(acc_no,acc_type,dept_code,acc_currency," + 
//						"original_ammount,current_balance,accrual_interest,accrual_late_charge," +
//						"billed_principle,billed_interest,billed_late_charge,billed_other_charge," +
//						"billed_misc,coll_bi,coll_bm,npl_stat,acc_stat,tgl_jth_tempo,"+
//						"tgl_byr_tghn_pokok,"+
//						"tgl_byr_tghn_bunga,loan_term,loan_term_code,suku_bunga," +
//						"lama_tunggakan_pokok,lama_tunggakan_bunga, cu_ref) values(";
//				}
//				else
//				{
//					a.Close();
//					continue;
//				}
//				a.Close();
//
//				//tolong check, pri key cu_ref +acc_no
//				
//				cmd.CommandText = "Select * from RFUPFILE where upfile_name='ACCOUNT NUMBER' and UPFILE_GROUP='0' order by upfile_id ASC";
//				SqlDataReader dr = cmd.ExecuteReader();
//				dr.Read();
//				l2=dr.GetInt32(3);
//				xTemp=strHasil.Substring(0,l2);
//				dr.Close();
//				cmd.CommandText="select * from ACC_INFO where ACC_NO='" + xTemp + "'";
//				dr=cmd.ExecuteReader();
//				if(dr.HasRows)
//				{
//					dr.Close();
//					cmd.CommandText="delete from ACC_INFO where ACC_NO='" + xTemp + "'";
//					cmd.ExecuteNonQuery();
//				}
//				else
//				{
//					dr.Close();
//				}
//				int pos=0;
//				cmd.CommandText = "Select * from RFUPFILE where UPFILE_GROUP='0' order by upfile_id ASC";
//				dr = cmd.ExecuteReader();
//				while(dr.Read())
//				{
//					int intStart,intLength;
//					intStart=pos;
//					intLength=dr.GetInt32(3);
//					if(dr.GetString(2)=="N")
//					{
//						xTemp=strHasil.Substring(pos,intLength);
//						l1=dr.GetInt32(4);
//						if(l1>0)
//						{
//							xTemp=xTemp.Substring(0,intLength-l1)+"."+ xTemp.Substring(intLength-l1,l1);
//						}
//						x=x+xTemp;
//					}
//					else if(dr.GetString(2)=="C")
//					{
//						int xxx = strHasil.Length;
//						int length_baca = intLength;
//						
//						if ( (xxx - pos) < intLength)
//							length_baca = xxx - pos; 
//
//						xTemp=strHasil.Substring(pos,length_baca);
//						if(dr.GetString(1)=="ACCOUNT NUMBER")
//						{
//							strCekNol=strHasil.Substring(pos,intLength).Trim();
//							for(int i=0;i<strCekNol.Length;i++)
//							{
//								if(strCekNol.Substring(0+i,1).Equals("0"))
//								{
//								}
//								else
//								{
//									strCekNol=strCekNol.Substring(i,strCekNol.Length-i);
//									i=strCekNol.Length;
//								}
//							}
//							xTemp=strCekNol;
//						}
//						x=x+"'"+xTemp+"'";
//					}
//					else if(dr.GetString(2)=="D")
//					{
//						string strTgl;
//						strTgl=	strHasil.Substring(pos,intLength);
//						if (strTgl.Equals("00000000"))
//						{
//							strTgl="null";
//							x=x+strTgl;
//						}
//						else
//						{
//							strTgl=strTgl.Substring(2,2)+"/"+strTgl.Substring(0,2)+"/"+strTgl.Substring(4,4);
//							x=x+"'"+strTgl+"'";
//						}
//					}
//					pos=pos+intLength;
//					if(pos<strHasil.Length)
//					{
//						x=x+",";
//					}
//					else
//					{
//						x=x+")";
//					}
//				}
//				dr.Close(); 
//			
//				try 
//				{
//					////////////////////////////////////
//					/// Kalau sudah punya account,
//					/// tidak perlu dimasukkan lagi
//					/// 
//					cmdIn.CommandText=x;
//					cmdIn.ExecuteNonQuery();
//				} 
//				catch {}
//
//				cmdIn.CommandText = "exec UP_LOAD_NEW"; // It New Storeprocedure
//				cmdIn.ExecuteNonQuery();

//			}
		}
	}
}
