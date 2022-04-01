using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace DMS.DBConnection
{
	/// <summary>
	/// Summary description for Connection2.
	/// </summary>
	public class Connection2
	{
		public SqlConnection conn;
		private SqlTransaction tran;
		private DataTable dataTable;
		private DataSet ds = new DataSet();
		private string sqlQuery;
		public string connString =  ConfigurationSettings.AppSettings["conn"];

		public Connection2()
		{
			//
			// TODO: Add constructor logic here
			//

			conn = new SqlConnection(connString);
			tran = null;
		}

		public Connection2(string strConn)
		{
			this.connString = strConn;
			conn = new SqlConnection(strConn);
			tran = null;
		}

		~Connection2()
		{
			if (tran != null)
				tran.Rollback();
		}

		public string QueryString
		{
			get { return sqlQuery; }
			set { sqlQuery = value;	}
		}

		public void ExecuteQuery()
		{
			try
			{
				if (conn.State != ConnectionState.Open)
					conn.Open();
				SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlQuery, conn);
				dataTable = new DataTable();
				mySqlDataAdapter.Fill(dataTable);
				mySqlDataAdapter.Dispose();
				conn.Close();
			}
			catch(SqlException e)
			{
				throw new ApplicationException(e.Message + " Last Query: " + sqlQuery);
			}
		}

		public void ExecuteQuery(string tableName)
		{
			try
			{
				if (conn.State != ConnectionState.Open)
					conn.Open();
				SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlQuery, conn);
				mySqlDataAdapter.Fill(ds, tableName);
				dataTable = ds.Tables[tableName];
				mySqlDataAdapter.Dispose();
				conn.Close();
			}
			catch(SqlException e)
			{
				throw new ApplicationException(e.Message + " Last Query: " + sqlQuery);
			}
		}

		public void ExecuteNonQuery()
		{
			ExecuteNonQuery(600);
		}

		public void ExecuteNonQuery(int TimeOut)
		{
			try
			{
				if (conn.State != ConnectionState.Open)
					conn.Open();
				SqlCommand command = new SqlCommand(sqlQuery, conn);
				command.CommandTimeout = TimeOut;
				command.ExecuteNonQuery();
				conn.Close();
			}
			catch(SqlException e)
			{
				throw new ApplicationException(e.Message + " Last Query: " + sqlQuery);
			}
		}

		public void ExecuteQuery(int intTimeOut)
		{
			int intCurrTimeout;
			try
			{

				if (conn.State != ConnectionState.Open)
					conn.Open();

				SqlCommand command = new SqlCommand(sqlQuery, conn);
				command.CommandText = sqlQuery;
				intCurrTimeout = command.CommandTimeout;
				command.CommandTimeout = intTimeOut;
				
				SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(command);				
				dataTable = new DataTable();
				mySqlDataAdapter.Fill(dataTable);
				mySqlDataAdapter.Dispose();
				command.CommandTimeout = intCurrTimeout;
				conn.Close();
			}
			catch(SqlException e)
			{
				throw new ApplicationException(e.Message + " Last Query: " + sqlQuery);
			}
		}

		/// <summary>
		/// This method enables the transaction property (commit/rollback) to be used. 
		/// Thus, the method is intentionally does not call the conn.Close() method. 
		/// After series of commands, call the method ExecTran_Commit() or 
		/// ExecTran_Rollback to finalize the transaction. To ensure clean operation, 
		/// always finalize a transaction within one routine. Improper used of the 
		/// method can cause jammed up to the database tables affected by the transaction. 
		/// 
		///	*********WARNING*********	
		/// DO NOT INVOKE THE ExecTran_Commit() AFTER POSTBACK !!! 
		///	The Page destroys the Connection object, hence, lose the transaction. 
		/// </summary>
		/// 
		public void ExecTrans ()
		{
			ExecTrans(600);
		}

		public void ExecTrans (int TimeOut)
		{
			try
			{
				if (conn.State != ConnectionState.Open)
					conn.Open();
				if (tran == null)
					tran = conn.BeginTransaction();
				SqlCommand cmd = new SqlCommand(sqlQuery,conn,tran);
				cmd.CommandTimeout = TimeOut;
				cmd.ExecuteNonQuery();
			}
			catch(SqlException e)
			{
				if (tran != null)
				{
					tran.Rollback();
					tran = null;
					throw new ApplicationException(e.Message + " (Transaction rollback) Last Query : " + sqlQuery);
				}
			}
		}

		public bool ExecTran_Commit()
		{
			try
			{
				tran.Commit();
				tran = null;
				conn.Close();
			} 
			catch {return false;}
			return true;
		}

		public bool ExecTran_Rollback()
		{
			try
			{
				tran.Rollback();
				tran = null;
				conn.Close();
			} 
			catch {return false;}
			return true;
		}



		public int GetRowCount()
		{
			return dataTable.Rows.Count;
		}

		public int GetColumnCount()
		{
			return dataTable.Columns.Count;
		}

		public int GetRowCount(DataTable dTable)
		{
			return dTable.Rows.Count;
		}

		public int GetColumnCount(DataTable dTable)
		{
			return dTable.Columns.Count;
		}

		public string GetFieldValue(string columnName)
		{
			if (dataTable.Rows.Count > 0)
				return dataTable.Rows[dataTable.Rows.Count-1][columnName].ToString().Trim();
			else
				return "";
		}

		public string GetFieldValue(int row, int column)
		{
			return dataTable.Rows[row][column].ToString().Trim();
		}

		public string GetFieldValue(int row, string columnName)
		{
			return dataTable.Rows[row][columnName].ToString().Trim();
		}

		public string GetFieldValue(string dTableName, string columnName)
		{
			dataTable = ds.Tables[dTableName];
			if (dataTable.Rows.Count > 0)
				return dataTable.Rows[dataTable.Rows.Count-1][columnName].ToString().Trim();
			else
				return "";
		}
		
		public string GetFieldValue(string dTableName, int row, int column)
		{
			dataTable = ds.Tables[dTableName];
			return dataTable.Rows[row][column].ToString().Trim();
		}

		public string GetFieldValue(string dTableName, int row, string columnName)
		{
			dataTable = ds.Tables[dTableName];
			return dataTable.Rows[row][columnName].ToString().Trim();
		}

		public string GetFieldValue(DataTable dTable, int row, int column)
		{
			return dTable.Rows[row][column].ToString().Trim();
		}

		public string GetFieldValue(DataTable dTable, int row, string columnName)
		{
			return dTable.Rows[row][columnName].ToString().Trim();
		}

		public DataSet GetDataSet()
		{
			return ds;
		}

		public DataTable GetDataTable()
		{
			return dataTable;
		}

		/// <summary>
		/// Close connection to database. 
		/// </summary>
		public void CloseConnection()
		{
			conn.Close();
			conn.Dispose();
		}

		/// <summary>
		/// Clear DataSet and DataTable
		/// </summary>
		public void ClearData()
		{
			ds.Clear();			ds.Dispose();
			dataTable.Clear();	dataTable.Dispose();
		}

		/// <summary>
		/// Execute store procedure with command 
		/// Sample of usage 
		///				ArrayList paramname = new ArrayList(), paramtype = new ArrayList(), 
		///						paramdir = new ArrayList(), paramvalue = new ArrayList(), 
		///						paramsize = new ArrayList();
		/// 			paramname.Add("retval");
		///				paramtype.Add(SqlDbType.Int);
		///				paramdir.Add(ParameterDirection.ReturnValue);
		///				paramvalue.Add("");
		///				paramsize.Add(4);
		///				
		///				paramname.Add("@mBranch");
		///				paramtype.Add(SqlDbType.VarChar);
		///				paramdir.Add(ParameterDirection.Input);
		///				paramvalue.Add("14401");
		///				paramsize.Add(5);
		///				
		///				paramname.Add("@mStatus");
		///				paramtype.Add(SqlDbType.VarChar);
		///				paramdir.Add(ParameterDirection.Input);
		///				paramvalue.Add("1");
		///				paramsize.Add(1);
		///				
		///				SqlParameterCollection ret = ExecProc("SP_LASTSEQPRM",paramname,paramtype,paramdir,paramvalue,paramsize);
		///				if(ret == null)
		///					return "NULL";
		///				return (ret["retval"].Value).ToString();
		/// </summary>
		/// <param name="spname">Store Procedure Name</param>
		/// <param name="paramname">(string)Param Name (include '@' if any)</param>
		/// <param name="paramtype">(SqlDbType)Param Datatype</param>
		/// <param name="paramdir">(ParameterDirection)Param Type</param>
		/// <param name="paramvalue">(string)Param Value</param>
		/// <param name="paramsize">(int)Param Size</param>
		/// <returns>null if required param list inconsistence, else, Object of type SqlParameterCollection</returns>
		public SqlParameterCollection ExecProc (string spname, ArrayList paramname, ArrayList paramtype, 
			ArrayList paramdir, ArrayList paramvalue, ArrayList paramsize)
		{
			if ((paramname.Count != paramtype.Count)||(paramtype.Count != paramdir.Count)
				||(paramdir.Count != paramvalue.Count))
				return null;

			SqlCommand cmd;
			SqlParameter par;
			
			try
			{
				if (conn.State != ConnectionState.Open)
					conn.Open();
				cmd = new SqlCommand(spname,conn);
				cmd.CommandType = CommandType.StoredProcedure;

				for(int i = 0; i < paramname.Count; i++)
				{
					par = cmd.Parameters.Add((string)paramname[i], (SqlDbType)paramtype[i]);
					par.Direction = (ParameterDirection)paramdir[i];
					par.Value = (string)paramvalue[i];
					if (paramsize.Count == paramname.Count)
						par.Size = (int)paramsize[i];
				}

				cmd.ExecuteNonQuery();

				conn.Close();
			}
			catch(SqlException e)
			{
				throw new ApplicationException(e.Message + " Last Query: <executing storeprocedure " + spname + ">");
			}

			return cmd.Parameters;
		}

		public SqlParameterCollection ExecProc (string spname, ArrayList paramname, ArrayList paramtype, 
			ArrayList paramdir, ArrayList paramvalue)
		{
			ArrayList paramsize = new ArrayList();
			return ExecProc(spname, paramname, paramtype, paramdir, paramvalue, paramsize);
		}
	}
}
