using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Data.OleDb;
using System.Configuration;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

/*
 * FTP Client library in C#
 * Author: Jaimon Mathew
 * mailto:jaimonmathew@rediffmail.com
 * http://www.csharphelp.com/archives/archive9.html
 * 
 * Addapted for use by Dan Glass 07/03/03
 */


namespace WebCamService
{

	public class FtpClient
	{

		public class FtpException : Exception
		{
			public FtpException(string message) : base(message){}
			public FtpException(string message, Exception innerException) : base(message,innerException){}
		}

		private static int BUFFER_SIZE = 512;
		private static Encoding ASCII = Encoding.ASCII;

		private bool verboseDebugging = false;

		// defaults
		private string server = "localhost";
		private string remotePath = ".";
		private string username = "anonymous";
		private string password = "anonymous@anonymous.net";
		private string message = null;
		private string result = null;

		private int port = 21;
		private int bytes = 0;
		private int resultCode = 0;

		private bool loggedin = false;
		private bool binMode = false;

		private Byte[] buffer = new Byte[BUFFER_SIZE];
		private Socket clientSocket = null;

		private int timeoutSeconds = 10;

		/// <summary>
		/// Default contructor
		/// </summary>
		public FtpClient()
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="server"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public FtpClient(string server, string username, string password)
		{
			this.server = server;
			this.username = username;
			this.password = password;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="server"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="timeoutSeconds"></param>
		/// <param name="port"></param>
		public FtpClient(string server, string username, string password, int timeoutSeconds, int port)
		{
			this.server = server;
			this.username = username;
			this.password = password;
			this.timeoutSeconds = timeoutSeconds;
			this.port = port;
		}

		/// <summary>
		/// Display all communications to the debug log
		/// </summary>
		public bool VerboseDebugging
		{
			get
			{
				return this.verboseDebugging;
			}
			set
			{
				this.verboseDebugging = value;
			}
		}
		/// <summary>
		/// Remote server port. Typically TCP 21
		/// </summary>
		public int Port
		{
			get
			{
				return this.port;
			}
			set
			{
				this.port = value;
			}
		}
		/// <summary>
		/// Timeout waiting for a response from server, in seconds.
		/// </summary>
		public int Timeout
		{
			get
			{
				return this.timeoutSeconds;
			}
			set
			{
				this.timeoutSeconds = value;
			}
		}
		/// <summary>
		/// Gets and Sets the name of the FTP server.
		/// </summary>
		/// <returns></returns>
		public string Server
		{
			get
			{
				return this.server;
			}
			set
			{
				this.server = value;
			}
		}
		/// <summary>
		/// Gets and Sets the port number.
		/// </summary>
		/// <returns></returns>
		public int RemotePort
		{
			get
			{
				return this.port;
			}
			set
			{
				this.port = value;
			}
		}
		/// <summary>
		/// GetS and Sets the remote directory.
		/// </summary>
		public string RemotePath
		{
			get
			{
				return this.remotePath;
			}
			set
			{
				this.remotePath = value;
			}

		}
		/// <summary>
		/// Gets and Sets the username.
		/// </summary>
		public string Username
		{
			get
			{
				return this.username;
			}
			set
			{
				this.username = value;
			}
		}
		/// <summary>
		/// Gets and Set the password.
		/// </summary>
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}

		/// <summary>
		/// If the value of mode is true, set binary mode for downloads, else, Ascii mode.
		/// </summary>
		public bool BinaryMode
		{
			get
			{
				return this.binMode;
			}
			set
			{
				if ( this.binMode == value ) return;

				if ( value )
					sendCommand("TYPE I");

				else
					sendCommand("TYPE A");

				if ( this.resultCode != 200 ) throw new FtpException(result.Substring(4));
			}
		}
		/// <summary>
		/// Login to the remote server.
		/// </summary>
		public void Login()
		{
			if ( this.loggedin ) this.Close();

			Debug.WriteLine("Opening connection to " + this.server, "FtpClient" );

			IPAddress addr = null;
			IPEndPoint ep = null;

			try
			{
				this.clientSocket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
				addr = Dns.Resolve(this.server).AddressList[0];
				ep = new IPEndPoint( addr, this.port );
				this.clientSocket.Connect(ep);
			}
			catch(Exception ex)
			{
				// doubtfull
				if ( this.clientSocket != null && this.clientSocket.Connected ) this.clientSocket.Close();

				throw new FtpException("Couldn't connect to remote server",ex);
			}

			this.readResponse();

			if(this.resultCode != 220)
			{
				this.Close();
				throw new FtpException(this.result.Substring(4));
			}

			this.sendCommand( "USER " + username );

			if( !(this.resultCode == 331 || this.resultCode == 230) )
			{
				this.cleanup();
				throw new FtpException(this.result.Substring(4));
			}

			if( this.resultCode != 230 )
			{
				this.sendCommand( "PASS " + password );

				if( !(this.resultCode == 230 || this.resultCode == 202) )
				{
					this.cleanup();
					throw new FtpException(this.result.Substring(4));
				}
			}

			this.loggedin = true;

			Debug.WriteLine( "Connected to " + this.server, "FtpClient" );

			this.ChangeDir(this.remotePath);
		}
		
		/// <summary>
		/// Close the FTP connection.
		/// </summary>
		public void Close()
		{
			Debug.WriteLine("Closing connection to " + this.server, "FtpClient" );

			if( this.clientSocket != null )
			{
				this.sendCommand("QUIT");
			}

			this.cleanup();
		}

		/// <summary>
		/// Return a string array containing the remote directory's file list.
		/// </summary>
		/// <returns></returns>
		public string[] GetFileList()
		{
			return this.GetFileList("*.*");
		}

		/// <summary>
		/// Return a string array containing the remote directory's file list.
		/// </summary>
		/// <param name="mask"></param>
		/// <returns></returns>
		public string[] GetFileList(string mask)
		{
			if ( !this.loggedin ) this.Login();

			Socket cSocket = createDataSocket();

			this.sendCommand("NLST " + mask);

			if(!(this.resultCode == 150 || this.resultCode == 125)) throw new FtpException(this.result.Substring(4));

			this.message = "";

			DateTime timeout = DateTime.Now.AddSeconds(this.timeoutSeconds);

			while( timeout > DateTime.Now )
			{
				int bytes = cSocket.Receive(buffer, buffer.Length, 0);
				this.message += ASCII.GetString(buffer, 0, bytes);

				if ( bytes < this.buffer.Length ) break;
			}

			string[] msg = this.message.Replace("\r","").Split('\n');

			cSocket.Close();

			if ( this.message.IndexOf( "No such file or directory" ) != -1 )
				msg = new string[]{};

			this.readResponse();

			if ( this.resultCode != 226 )
				msg = new string[]{};
			//	throw new FtpException(result.Substring(4));

			return msg;
		}
		
		/// <summary>
		/// Return the size of a file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public long GetFileSize(string fileName)
		{
			if ( !this.loggedin ) this.Login();

			this.sendCommand("SIZE " + fileName);
			long size=0;

			if ( this.resultCode == 213 )
				size = long.Parse(this.result.Substring(4));

			else
				throw new FtpException(this.result.Substring(4));

			return size;
		}
	
		
		/// <summary>
		/// Download a file to the Assembly's local directory,
		/// keeping the same file name.
		/// </summary>
		/// <param name="remFileName"></param>
		public void Download(string remFileName)
		{
			this.Download(remFileName,"",false);
		}

		/// <summary>
		/// Download a remote file to the Assembly's local directory,
		/// keeping the same file name, and set the resume flag.
		/// </summary>
		/// <param name="remFileName"></param>
		/// <param name="resume"></param>
		public void Download(string remFileName,Boolean resume)
		{
			this.Download(remFileName,"",resume);
		}
		
		/// <summary>
		/// Download a remote file to a local file name which can include
		/// a path. The local file name will be created or overwritten,
		/// but the path must exist.
		/// </summary>
		/// <param name="remFileName"></param>
		/// <param name="locFileName"></param>
		public void Download(string remFileName,string locFileName)
		{
			this.Download(remFileName,locFileName,false);
		}

		/// <summary>
		/// Download a remote file to a local file name which can include
		/// a path, and set the resume flag. The local file name will be
		/// created or overwritten, but the path must exist.
		/// </summary>
		/// <param name="remFileName"></param>
		/// <param name="locFileName"></param>
		/// <param name="resume"></param>
		public void Download(string remFileName,string locFileName,Boolean resume)
		{
			if ( !this.loggedin ) this.Login();

			this.BinaryMode = true;

			Debug.WriteLine("Downloading file " + remFileName + " from " + server + "/" + remotePath, "FtpClient" );

			if (locFileName.Equals(""))
			{
				locFileName = remFileName;
			}

			FileStream output = null;

			if ( !File.Exists(locFileName) )
				output = File.Create(locFileName);

			else
				output = new FileStream(locFileName,FileMode.Open);

			Socket cSocket = createDataSocket();

			long offset = 0;

			if ( resume )
			{
				offset = output.Length;

				if ( offset > 0 )
				{
					this.sendCommand( "REST " + offset );
					if ( this.resultCode != 350 )
					{
						//Server dosnt support resuming
						offset = 0;
						Debug.WriteLine("Resuming not supported:" + result.Substring(4), "FtpClient" );
					}
					else
					{
						Debug.WriteLine("Resuming at offset " + offset, "FtpClient" );
						output.Seek( offset, SeekOrigin.Begin );
					}
				}
			}

			this.sendCommand("RETR " + remFileName);

			if ( this.resultCode != 150 && this.resultCode != 125 )
			{
				throw new FtpException(this.result.Substring(4));
			}

			DateTime timeout = DateTime.Now.AddSeconds(this.timeoutSeconds);

			while ( timeout > DateTime.Now )
			{
				this.bytes = cSocket.Receive(buffer, buffer.Length, 0);
				output.Write(this.buffer,0,this.bytes);

				if ( this.bytes <= 0)
				{
					break;
				}
			}

			output.Close();

			if ( cSocket.Connected ) cSocket.Close();

			this.readResponse();

			if( this.resultCode != 226 && this.resultCode != 250 )
				throw new FtpException(this.result.Substring(4));
		}

		
		/// <summary>
		/// Upload a file.
		/// </summary>
		/// <param name="fileName"></param>
		public void Upload(string fileName)
		{
			this.Upload(fileName,false);
		}

		
		/// <summary>
		/// Upload a file and set the resume flag.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="resume"></param>
		public void Upload(string fileName, bool resume)
		{
			if ( !this.loggedin ) this.Login();

			Socket cSocket = null ;
			long offset = 0;

			if ( resume )
			{
				try
				{
					this.BinaryMode = true;

					offset = GetFileSize( Path.GetFileName(fileName) );
				}
				catch(Exception)
				{
					// file not exist
					offset = 0;
				}
			}

			// open stream to read file
			FileStream input = new FileStream(fileName,FileMode.Open);

			if ( resume && input.Length < offset )
			{
				// different file size
				Debug.WriteLine("Overwriting " + fileName, "FtpClient");
				offset = 0;
			}
			else if ( resume && input.Length == offset )
			{
				// file done
				input.Close();
				Debug.WriteLine("Skipping completed " + fileName + " - turn resume off to not detect.", "FtpClient");
				return;
			}

			// dont create untill we know that we need it
			cSocket = this.createDataSocket();

			if ( offset > 0 )
			{
				this.sendCommand( "REST " + offset );
				if ( this.resultCode != 350 )
				{
					Debug.WriteLine("Resuming not supported", "FtpClient");
					offset = 0;
				}
			}

			this.sendCommand( "STOR " + Path.GetFileName(fileName) );

			if ( this.resultCode != 125 && this.resultCode != 150 ) throw new FtpException(result.Substring(4));

			if ( offset != 0 )
			{
				Debug.WriteLine("Resuming at offset " + offset, "FtpClient" );

				input.Seek(offset,SeekOrigin.Begin);
			}

			Debug.WriteLine( "Uploading file " + fileName + " to " + remotePath, "FtpClient" );

			while ((bytes = input.Read(buffer,0,buffer.Length)) > 0)
			{
				cSocket.Send(buffer, bytes, 0);
			}
			
			input.Close();

			if (cSocket.Connected)
			{
				cSocket.Close();
			}

			this.readResponse();

			if( this.resultCode != 226 && this.resultCode != 250 ) throw new FtpException(this.result.Substring(4));
		}
		
		/// <summary>
		/// Upload a directory and its file contents
		/// </summary>
		/// <param name="path"></param>
		/// <param name="recurse">Whether to recurse sub directories</param>
		public void UploadDirectory(string path, bool recurse)
		{
			this.UploadDirectory(path,recurse,"*.*");
		}
		
		/// <summary>
		/// Upload a directory and its file contents
		/// </summary>
		/// <param name="path"></param>
		/// <param name="recurse">Whether to recurse sub directories</param>
		/// <param name="mask">Only upload files of the given mask - everything is '*.*'</param>
		public void UploadDirectory(string path, bool recurse, string mask)
		{
			string[] dirs = path.Replace("/",@"\").Split('\\');
			string rootDir = dirs[ dirs.Length - 1 ];

			// make the root dir if it doed not exist
			if ( this.GetFileList(rootDir).Length < 1 ) this.MakeDir(rootDir);

			this.ChangeDir(rootDir);

			foreach ( string file in Directory.GetFiles(path,mask) )
			{
				this.Upload(file,true);
			}
			if ( recurse )
			{
				foreach ( string directory in Directory.GetDirectories(path) )
				{
					this.UploadDirectory(directory,recurse,mask);
				}
			}

			this.ChangeDir("..");
		}

		/// <summary>
		/// Delete a file from the remote FTP server.
		/// </summary>
		/// <param name="fileName"></param>
		public void DeleteFile(string fileName)
		{
			if ( !this.loggedin ) this.Login();

			this.sendCommand( "DELE " + fileName );

			if ( this.resultCode != 250 ) throw new FtpException(this.result.Substring(4));

			Debug.WriteLine( "Deleted file " + fileName, "FtpClient" );
		}

		/// <summary>
		/// Rename a file on the remote FTP server.
		/// </summary>
		/// <param name="oldFileName"></param>
		/// <param name="newFileName"></param>
		/// <param name="overwrite">setting to false will throw exception if it exists</param>
		public void RenameFile(string oldFileName,string newFileName, bool overwrite)
		{
			if ( !this.loggedin ) this.Login();

			this.sendCommand( "RNFR " + oldFileName );

			if ( this.resultCode != 350 ) throw new FtpException(this.result.Substring(4));

			if ( !overwrite && this.GetFileList(newFileName).Length > 0 ) throw new FtpException("File already exists");

			this.sendCommand( "RNTO " + newFileName );

			if ( this.resultCode != 250 ) throw new FtpException(this.result.Substring(4));

			Debug.WriteLine( "Renamed file " + oldFileName + " to " + newFileName, "FtpClient" );
		}
		
		/// <summary>
		/// Create a directory on the remote FTP server.
		/// </summary>
		/// <param name="dirName"></param>
		public void MakeDir(string dirName)
		{
			if ( !this.loggedin ) this.Login();

			this.sendCommand( "MKD " + dirName );

			if ( this.resultCode != 250 && this.resultCode != 257 ) throw new FtpException(this.result.Substring(4));

			Debug.WriteLine( "Created directory " + dirName, "FtpClient" );
		}

		/// <summary>
		/// Delete a directory on the remote FTP server.
		/// </summary>
		/// <param name="dirName"></param>
		public void RemoveDir(string dirName)
		{
			if ( !this.loggedin ) this.Login();

			this.sendCommand( "RMD " + dirName );

			if ( this.resultCode != 250 ) throw new FtpException(this.result.Substring(4));

			Debug.WriteLine( "Removed directory " + dirName, "FtpClient" );
		}

		/// <summary>
		/// Change the current working directory on the remote FTP server.
		/// </summary>
		/// <param name="dirName"></param>
		public void ChangeDir(string dirName)
		{
			if( dirName == null || dirName.Equals(".") || dirName.Length == 0 )
			{
				return;
			}

			if ( !this.loggedin ) this.Login();

			this.sendCommand( "CWD " + dirName );

			if ( this.resultCode != 250 ) throw new FtpException(result.Substring(4));

			this.sendCommand( "PWD" );

			if ( this.resultCode != 257 ) throw new FtpException(result.Substring(4));

			// gonna have to do better than this....
			this.remotePath = this.message.Split('"')[1];

			Debug.WriteLine( "Current directory is " + this.remotePath, "FtpClient" );
		}

		/// <summary>
		/// 
		/// </summary>
		private void readResponse()
		{
			this.message = "";
			this.result = this.readLine();

			if ( this.result.Length > 3 )
				this.resultCode = int.Parse( this.result.Substring(0,3) );
			else
				this.result = null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private string readLine()
		{
			while(true)
			{
				this.bytes = clientSocket.Receive( this.buffer, this.buffer.Length, 0 );
				this.message += ASCII.GetString( this.buffer, 0, this.bytes );

				if ( this.bytes < this.buffer.Length )
				{
					break;
				}
			}

			string[] msg = this.message.Split('\n');

			if ( this.message.Length > 2 )
				this.message = msg[ msg.Length - 2 ];

			else
				this.message = msg[0];


			if ( this.message.Length > 4 && !this.message.Substring(3,1).Equals(" ") ) return this.readLine();

			if ( this.verboseDebugging )
			{
				for(int i = 0; i < msg.Length - 1; i++)
				{
					Debug.Write( msg[i], "FtpClient" );
				}
			}

			return message;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		private void sendCommand(String command)
		{
			if ( this.verboseDebugging ) Debug.WriteLine(command,"FtpClient");

			Byte[] cmdBytes = Encoding.ASCII.GetBytes( ( command + "\r\n" ).ToCharArray() );
			clientSocket.Send( cmdBytes, cmdBytes.Length, 0);
			this.readResponse();
		}

		/// <summary>
		/// when doing data transfers, we need to open another socket for it.
		/// </summary>
		/// <returns>Connected socket</returns>
		private Socket createDataSocket()
		{
			this.sendCommand("PASV");

			if ( this.resultCode != 227 ) throw new FtpException(this.result.Substring(4));

			int index1 = this.result.IndexOf('(');
			int index2 = this.result.IndexOf(')');

			string ipData = this.result.Substring(index1+1,index2-index1-1);

			int[] parts = new int[6];

			int len = ipData.Length;
			int partCount = 0;
			string buf="";

			for (int i = 0; i < len && partCount <= 6; i++)
			{
				char ch = char.Parse( ipData.Substring(i,1) );

				if ( char.IsDigit(ch) )
					buf+=ch;

				else if (ch != ',')
					throw new FtpException("Malformed PASV result: " + result);

				if ( ch == ',' || i+1 == len )
				{
					try
					{
						parts[partCount++] = int.Parse(buf);
						buf = "";
					}
					catch (Exception ex)
					{
						throw new FtpException("Malformed PASV result (not supported?): " + this.result, ex);
					}
				}
			}

			string ipAddress = parts[0] + "."+ parts[1]+ "." + parts[2] + "." + parts[3];

			int port = (parts[4] << 8) + parts[5];

			Socket socket = null;
			IPEndPoint ep = null;

			try
			{
				socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
				ep = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);
				socket.Connect(ep);
			}
			catch(Exception ex)
			{
				// doubtfull....
				if ( socket != null && socket.Connected ) socket.Close();

				throw new FtpException("Can't connect to remote server", ex);
			}

			return socket;
		}
		
		/// <summary>
		/// Always release those sockets.
		/// </summary>
		private void cleanup()
		{
			if ( this.clientSocket!=null )
			{
				this.clientSocket.Close();
				this.clientSocket = null;
			}
			this.loggedin = false;
		}

		/// <summary>
		/// Destuctor
		/// </summary>
		~FtpClient()
		{
			this.cleanup();
		}


		/**************************************************************************************************************/
		#region Async methods (auto generated)

		/*
						WinInetApi.FtpClient ftp = new WinInetApi.FtpClient();

						MethodInfo[] methods = ftp.GetType().GetMethods(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public);

						foreach ( MethodInfo method in methods )
						{
							string param = "";
							string values = "";
							foreach ( ParameterInfo i in  method.GetParameters() )
							{
								param += i.ParameterType.Name + " " + i.Name + ",";
								values += i.Name + ",";
							}
					

							Debug.WriteLine("private delegate " + method.ReturnType.Name + " " + method.Name + "Callback(" + param.TrimEnd(',') + ");");

							Debug.WriteLine("public System.IAsyncResult Begin" + method.Name + "( " + param + " System.AsyncCallback callback )");
							Debug.WriteLine("{");
							Debug.WriteLine("" + method.Name + "Callback ftpCallback = new " + method.Name + "Callback(" + values + " this." + method.Name + ");");
							Debug.WriteLine("return ftpCallback.BeginInvoke(callback, null);");
							Debug.WriteLine("}");
							Debug.WriteLine("public void End" + method.Name + "(System.IAsyncResult asyncResult)");
							Debug.WriteLine("{");
							Debug.WriteLine(method.Name + "Callback fc = (" + method.Name + "Callback) ((AsyncResult)asyncResult).AsyncDelegate;");
							Debug.WriteLine("fc.EndInvoke(asyncResult);");
							Debug.WriteLine("}");
							//Debug.WriteLine(method);
						}
		*/


		private delegate void LoginCallback();
		public System.IAsyncResult BeginLogin(  System.AsyncCallback callback )
		{
			LoginCallback ftpCallback = new LoginCallback( this.Login);
			return ftpCallback.BeginInvoke(callback, null);
		}
		private delegate void CloseCallback();
		public System.IAsyncResult BeginClose(  System.AsyncCallback callback )
		{
			CloseCallback ftpCallback = new CloseCallback( this.Close);
			return ftpCallback.BeginInvoke(callback, null);
		}
		private delegate String[] GetFileListCallback();
		public System.IAsyncResult BeginGetFileList(  System.AsyncCallback callback )
		{
			GetFileListCallback ftpCallback = new GetFileListCallback( this.GetFileList);
			return ftpCallback.BeginInvoke(callback, null);
		}
		private delegate String[] GetFileListMaskCallback(String mask);
		public System.IAsyncResult BeginGetFileList( String mask, System.AsyncCallback callback )
		{
			GetFileListMaskCallback ftpCallback = new GetFileListMaskCallback(this.GetFileList);
			return ftpCallback.BeginInvoke(mask, callback, null);
		}
		private delegate Int64 GetFileSizeCallback(String fileName);
		public System.IAsyncResult BeginGetFileSize( String fileName, System.AsyncCallback callback )
		{
			GetFileSizeCallback ftpCallback = new GetFileSizeCallback(this.GetFileSize);
			return ftpCallback.BeginInvoke(fileName, callback, null);
		}
		private delegate void DownloadCallback(String remFileName);
		public System.IAsyncResult BeginDownload( String remFileName, System.AsyncCallback callback )
		{
			DownloadCallback ftpCallback = new DownloadCallback(this.Download);
			return ftpCallback.BeginInvoke(remFileName, callback, null);
		}
		private delegate void DownloadFileNameResumeCallback(String remFileName,Boolean resume);
		public System.IAsyncResult BeginDownload( String remFileName,Boolean resume, System.AsyncCallback callback )
		{
			DownloadFileNameResumeCallback ftpCallback = new DownloadFileNameResumeCallback(this.Download);
			return ftpCallback.BeginInvoke(remFileName, resume, callback, null);
		}
		private delegate void DownloadFileNameFileNameCallback(String remFileName,String locFileName);
		public System.IAsyncResult BeginDownload( String remFileName,String locFileName, System.AsyncCallback callback )
		{
			DownloadFileNameFileNameCallback ftpCallback = new DownloadFileNameFileNameCallback(this.Download);
			return ftpCallback.BeginInvoke(remFileName, locFileName, callback, null);
		}
		private delegate void DownloadFileNameFileNameResumeCallback(String remFileName,String locFileName,Boolean resume);
		public System.IAsyncResult BeginDownload( String remFileName,String locFileName,Boolean resume, System.AsyncCallback callback )
		{
			DownloadFileNameFileNameResumeCallback ftpCallback = new DownloadFileNameFileNameResumeCallback(this.Download);
			return ftpCallback.BeginInvoke(remFileName, locFileName, resume, callback, null);
		}
		private delegate void UploadCallback(String fileName);
		public System.IAsyncResult BeginUpload( String fileName, System.AsyncCallback callback )
		{
			UploadCallback ftpCallback = new UploadCallback(this.Upload);
			return ftpCallback.BeginInvoke(fileName, callback, null);
		}
		private delegate void UploadFileNameResumeCallback(String fileName,Boolean resume);
		public System.IAsyncResult BeginUpload( String fileName,Boolean resume, System.AsyncCallback callback )
		{
			UploadFileNameResumeCallback ftpCallback = new UploadFileNameResumeCallback(this.Upload);
			return ftpCallback.BeginInvoke(fileName, resume, callback, null);
		}
		private delegate void UploadDirectoryCallback(String path,Boolean recurse);
		public System.IAsyncResult BeginUploadDirectory( String path,Boolean recurse, System.AsyncCallback callback )
		{
			UploadDirectoryCallback ftpCallback = new UploadDirectoryCallback(this.UploadDirectory);
			return ftpCallback.BeginInvoke(path, recurse, callback, null);
		}
		private delegate void UploadDirectoryPathRecurseMaskCallback(String path,Boolean recurse,String mask);
		public System.IAsyncResult BeginUploadDirectory( String path,Boolean recurse,String mask, System.AsyncCallback callback )
		{
			UploadDirectoryPathRecurseMaskCallback ftpCallback = new UploadDirectoryPathRecurseMaskCallback(this.UploadDirectory);
			return ftpCallback.BeginInvoke(path, recurse, mask, callback, null);
		}
		private delegate void DeleteFileCallback(String fileName);
		public System.IAsyncResult BeginDeleteFile( String fileName, System.AsyncCallback callback )
		{
			DeleteFileCallback ftpCallback = new DeleteFileCallback(this.DeleteFile);
			return ftpCallback.BeginInvoke(fileName, callback, null);
		}
		private delegate void RenameFileCallback(String oldFileName,String newFileName,Boolean overwrite);
		public System.IAsyncResult BeginRenameFile( String oldFileName,String newFileName,Boolean overwrite, System.AsyncCallback callback )
		{
			RenameFileCallback ftpCallback = new RenameFileCallback(this.RenameFile);
			return ftpCallback.BeginInvoke(oldFileName, newFileName, overwrite, callback, null);
		}
		private delegate void MakeDirCallback(String dirName);
		public System.IAsyncResult BeginMakeDir( String dirName, System.AsyncCallback callback )
		{
			MakeDirCallback ftpCallback = new MakeDirCallback(this.MakeDir);
			return ftpCallback.BeginInvoke(dirName, callback, null);
		}
		private delegate void RemoveDirCallback(String dirName);
		public System.IAsyncResult BeginRemoveDir( String dirName, System.AsyncCallback callback )
		{
			RemoveDirCallback ftpCallback = new RemoveDirCallback(this.RemoveDir);
			return ftpCallback.BeginInvoke(dirName, callback, null);
		}
		private delegate void ChangeDirCallback(String dirName);
		public System.IAsyncResult BeginChangeDir( String dirName, System.AsyncCallback callback )
		{
			ChangeDirCallback ftpCallback = new ChangeDirCallback(this.ChangeDir);
			return ftpCallback.BeginInvoke(dirName, callback, null);
		}

		#endregion
	}
}


namespace SME.Credit_Channeling
{
	/// <summary>
	/// Summary description for MainChanneling.
	/// </summary>
	public partial class MainChanneling : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CH_BPR_NO;

		#region " My Variables "
		protected Connection conn;
		protected Tools tool = new Tools();
		private string userID, msg, dbip = "";
		private System.Diagnostics.Process proc;
		#endregion

		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = new Connection((string)Session["ConnString"]);			
			userID	= (string) Session["UserID"];
			msg		= Request.QueryString["msg"];

			//TODO: tambah screen restricted area !
			//...

			if (!IsPostBack) 
			{
				//GlobalTools.fillRefList(DDL_PROGRAM, "select PROGRAMID, PROGRAMDESC from VW_CHANN_RFPROGRAM ", conn);
				//GlobalTools.fillRefList(DDL_SIBS_PRODID, "select PRODUCTID, SIBS_PRODID from VW_CHANN_RFPRODUCT ", conn);

				GlobalTools.fillRefList(DDL_PROGRAM, "EXEC CHANN_RFPROGRAM '" + userID + "' ", conn);

				// get channeling company list 
				//GlobalTools.fillRefList(DDL_COMPNAME, "select CU_REF, CU_NAME from VW_CHANNELCOMP ", conn);//ahmad
				//////////////////////////////////////////////////////////////////
				/// ahmad
				/// used new stored procedure to get company
				/// 

				GlobalTools.fillRefList(DDL_COMPNAME, "EXEC CHANN_GETCOMPANY '" + userID + "'", conn);
				fillAANo();

				try
				{
					DDL_PROGRAM.SelectedIndex = 1;
				} 
				catch {}
				LBL_SU_FULLNAME.Text = (string) Session["FullName"];

				fillProgDependant();

				// for ftp filing
				Connection eConn = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]);
				eConn.QueryString = "select db_ip from rfmodule where moduleid = '01'";
				eConn.ExecuteQuery();
			
				dbip = eConn.GetFieldValue("db_ip");
				ViewState["dbip"] = dbip;
			}
			else
			{
				dbip = (string)ViewState["dbip"];
			}

			// Munculkan pesan next step
			if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null && LBL_MSGTRIP.Text == "0")  
			{
				GlobalTools.popMessage(this, Request.QueryString["msg"]);
				LBL_MSGTRIP.Text = "1";
			}

			BTN_UPLOAD.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;}");
		}

		private void fillProgDependant()
		{
			GlobalTools.fillRefList(DDL_SIBS_PRODID, "EXEC CHANN_RFPRODUCT '" + userID + "','" + DDL_PROGRAM.SelectedValue + "' ", conn);
			GlobalTools.fillRefList(DDL_AP_RELMNGR, "EXEC CHANN_GETRM '" + userID + "','" + DDL_PROGRAM.SelectedValue + "' ", conn);
		}

		private void fillAANo()
		{
			GlobalTools.fillRefList(DDL_AANO, "select distinct AA_NO, AA_NO from VW_CHANN_FAC " +
				"where CU_REF='" + DDL_COMPNAME.SelectedValue + "'", conn);
			if (DDL_AANO.Items.Count > 1)
				DDL_AANO.Enabled = true;
			fillSIBSProdid();
		}

		private void fillSIBSProdid()
		{

			string query = "select distinct PRODUCTID, PRODUCTID from VW_CHANN_FAC " +
				"where CU_REF = '" + DDL_COMPNAME.SelectedValue + "' " +
				"and AA_NO = '" + DDL_AANO.SelectedValue + "' ";
			GlobalTools.fillRefList(DDL_SIBS_PRODID, query, false, conn);
			if (DDL_SIBS_PRODID.Items.Count > 1)
				DDL_SIBS_PRODID.Enabled = true;
			fillAccSeq();
		}

		private void fillAccSeq()
		{
			LBL_LIMIT.Text = "";
			TXT_CH_PLAFOND_LOS.Text = "";
			TXT_CH_TENOR.Text = "";
			TXT_CH_TENORDESC.Text = "";

			string query = "select distinct ACC_SEQ,ACC_SEQ from VW_CHANN_FAC " +
				"where CU_REF = '" + DDL_COMPNAME.SelectedValue + "' " +
				"and AA_NO = '" + DDL_AANO.SelectedValue + "' " +
				"and PRODUCTID = '" + DDL_SIBS_PRODID.SelectedValue + "' ";
			GlobalTools.fillRefList(DDL_ACC_SEQ, query, false, conn);
			if (DDL_ACC_SEQ.Items.Count > 1)
				DDL_ACC_SEQ.Enabled = true;
		}


		#region "Defined Methods "

		private void connectToExcel() 
		{

			string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + LBL_CH_NAMAFILE.Text.Trim()  + ";Extended Properties=Excel 8.0";
//			Response.Write(strConn);
			string sList1 ="Sheet1";

			OleDbConnection oConn = new OleDbConnection(); 
			try 
			{
				oConn.ConnectionString = strConn; 
				oConn.Open(); 
	  
				OleDbDataAdapter oCmd = new OleDbDataAdapter("SELECT * FROM [" + sList1 + "$]", oConn); 
				DataSet oDS = new DataSet(); 
				oCmd.Fill(oDS,"[" + sList1 + "$]"); 
				DatGrdTemp.DataSource = oDS.Tables[0].DefaultView;
				
				DatGrdTemp.DataBind();
			} 
			catch
			{
				DatGrdTemp.CurrentPageIndex = 0;
				DatGrdTemp.DataBind();				
			}
			if (oConn.State == ConnectionState.Open) { oConn.Close(); }
 		}

		private void hitungLimitCustomer() 
		{
			double totalLimit = 0,limit;
			try
			{
				//				string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + LBL_CH_NAMAFILE.Text.Trim() + ";Extended Properties=Excel 8.0";
				//				Response.Write("<BR>"+Convert.ToString(DatGrdTemp.Items.Count));
				for(int i=0; i<DatGrdTemp.Items.Count; i++) 
				{
					try 
					{
						limit = Convert.ToDouble(DatGrdTemp.Items[i].Cells[5].Text.Trim());
					}
					catch
					{limit=0;}		
					totalLimit +=limit;
				}
//				OleDbConnection xlConn = new OleDbConnection();
//				xlConn.ConnectionString = strConn;
//				xlConn.Open();
//
//				OleDbDataAdapter oCmd = new OleDbDataAdapter("SELECT SUM(LIMIT) AS LIMIT FROM [Sheet1$]", xlConn); 
//				DataSet oDS = new DataSet(); 
//				oCmd.Fill(oDS,"[Sheet1$]");
//				DataRowCollection dra = oDS.Tables["[Sheet1$]"].Rows;
//
//				foreach (DataRow dr in dra)
//				{
//					LBL_LIMIT.Text = dr[0].ToString();
//				}
				LBL_LIMIT.Text = totalLimit.ToString();
//				Response.Write("<BR> Nilai LIMIT = "+ LBL_LIMIT.Text);  
			}
			catch
			{
				GlobalTools.popMessage(this, "Hitung limit customer Error !");
//				Response.Write("<BR>Hitung limit customer Error !"); 
			}
		}

		private bool isLimitInRange() 
		{
			bool inRange = true;
			//--- connect to excel
			connectToExcel();

			//--- hitung limit (customer) di excel
			hitungLimitCustomer();
			
			//--- bandingkan limit (customer) di excel dengan plafond
//			try
//			{
//				if (Convert.ToDouble(LBL_LIMIT.Text) <= Convert.ToDouble(TXT_CH_PLAFOND_LOS.Text)) 				
//					inRange = true;				
//				else
//					inRange = false;
//			}
//			catch
//			{
//				Response.Write("<BR>inRange Error !");
//				inRange = false;
//			}
			return inRange;
		}

		private string getValue(DataGrid dg, int rowidx, int colidx) 
		{
			string val = "";
			val = dg.Items[rowidx].Cells[colidx].Text.Trim();

			if (val=="" || val == "&nbsp;") 
			{
				//				if (colidx == 0 || colidx == 1 || colidx == 5 || colidx == 8 || colidx == 10 ||
				//					colidx == 18 || colidx == 21 || colidx == 22) 
				//				{
				//					val = "";
				//				}

				val = "";
			}

			return val;
		}

		private void saveCustomer(string BATCHNO, string CH_NAMAFILE) 
		{	
			//TODO : Periksa apakah nasabah baru memiliki nonas yang sama dengan nasabah lama ???

			//--- Cara #1 :
			//			conn.QueryString = "INSERT INTO CHANN_CUSTOMER (CH_ALAMAT, CH_HARGABELI, CH_IDENTITAS, CH_JB, CH_JDOK, CH_JPTG, CH_JW, CH_KOND_CODE, CH_LIMIT, CH_MERKB, CH_MKERJA, CH_NAMA, CH_NOMESIN, NONAS, CH_NOPK, CH_NORANGKA, CH_NPTG, CH_PENDAPATAN, CH_SBUN, CH_TAHUN, CH_TGLAHIR, CH_TGPK, CH_TUJ_CODE, CH_TYPE, BATCHNO) (select *, " + BATCHNO + " from opendatasource ('Microsoft.Jet.OLEDB.4.0','Data Source=" + @CH_NAMAFILE + ";Extended properties=Excel 8.0')...[Sheet1$])";
			//			conn.ExecuteQuery();			

			//--- Cara #2 :
			//TODO : Apakah ada cara lain selain satu per satu save ke database ??					
			string tglahir = "", tgpk = "";

			string delimStr = "/";
			char [] delimiter = delimStr.ToCharArray();
//			string temp;
//			string [] split = null;
			bool fileError = false;

			for(int i=0; i<DatGrdTemp.Items.Count; i++) 
			{				
				tglahir = getValue(DatGrdTemp, i, 4);
				tgpk = getValue(DatGrdTemp, i, 16);
//				//--- Mengambil tanggal lahir (format dd/mm/yyyy)
//				try 
//				{
//					temp = getValue(DatGrdTemp, i, 4);
//					Response.Write("temp tglahir = "+ temp.Trim() +"<BR>");
//					split = temp.Split(delimiter, 3);
//					Response.Write("Split 0 <BR>");
//					tglahir = tool.ConvertDate(split[0], split[1], split[2]);
//					Response.Write("Convert 0<BR>");
//				} 
//				catch 
//				{
//					fileError = true;
//				}
//
//				try 
//				{
//					//--- Mengambil tanggal pk (format dd/mm/yyyy)
//					temp = getValue(DatGrdTemp, i, 16);
//					Response.Write("temp tgPK = "+ temp.Trim() +"<BR>");
//					split = temp.Split(delimiter, 3);
//					Response.Write("Split 1<BR>");
//					tgpk = tool.ConvertDate(split[0], split[1], split[2]);
//					Response.Write("Convert 1<BR>");
//				} 
//				catch 
//				{
//					fileError = true;
//				}

				if (!fileError) 
				{
					try
					{
						conn.QueryString = "exec CHANN_CUST_CHANGE " +
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 0)) + "," +	// NONAS
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 1)) + "," +	// NAMA
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 2)) + "," +	// ALAMAT
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 3)) + "," +	// IDENTITAS
							"" + tool.ConvertNull(tglahir.Replace("'","")) + "," +		// TGLAHIR
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 5)) + "," +	// LIMIT
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 6)) + "," +	// HARGABELI
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 7)) + "," +	// SBUN
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 8)) + "," +	// JW
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 9)) + "," +	// JB
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 10)) + "," +	// MERKB
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 11))+ "," +	// TYPE
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 12)) + "," +	// TAHUN
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 13)) + "," +	// NORANGKA
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 14)) + "," +	// NOMESIN
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 15)) + "," +	// NOPK
							"" + tool.ConvertNull(tgpk.Replace("'","")) + "," +			// TGPK
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 17)) + "," +	// JDOK
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 18)) + "," +	// PENDAPATAN
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 19)) + "," +	// JPTG
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 20)) + "," +	// NPTG
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 21)) + "," +	// KONA
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 22)) + "," +	// MKERJA
							"" + tool.ConvertNull(getValue(DatGrdTemp, i, 23)) + "," +	// TPGUNA
							"" + BATCHNO                     + "," +					//-- Batchno INT
							"null, '" + DDL_COMPNAME.SelectedValue + "', " + (i+1) +	// CH_ISACCEPT, CH_BPR_CUREF, SEQ BATCH
							",'1'"; // STATUS
						conn.ExecuteNonQuery();
					}
					catch
					{
						GlobalTools.popMessage(this,"Save to Customer Failed ...!"); 
					}
				}
			}
		}

		private void adjustLimitBPR() 
		{
			try
			{
				string query = "";
				query = "exec SP_CHANN_IN_BPR '" + DDL_COMPNAME.SelectedValue + 
					"', '" + DDL_AANO.SelectedValue + 
					"', '" + DDL_SIBS_PRODID.SelectedValue + 
					"', '" + DDL_ACC_SEQ.SelectedValue + 
					//"', '" + tool.ConvertNull(TXT_CH_BPR_NO.Text.Trim()) + 
					"', " + tool.ConvertNull(DDL_COMPNAME.SelectedValue.Trim()) + 
					", '" + DDL_COMPNAME.SelectedItem.Text + "'";
				conn.QueryString = query;
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this,"Adjust Limit BPR Failed ...."); 
			}
		}
		
		private void insertIntoTrack() 
		{
			//Generate AP_REGNO
			conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
			conn.ExecuteQuery();
			string REGNO = conn.GetFieldValue(0,0);
			LBL_AP_REGNO.Text = REGNO;

			string BUSSUNITID = "";
			if (Session["BussUnit"].ToString() != "") BUSSUNITID = Session["BussUnit"].ToString();
			else BUSSUNITID = DDL_BUSINESSUNIT.SelectedValue;

			//Insert into Correspondence Tables
			conn.QueryString = "exec SP_CHANN_TRACKUPDATE '" + 
				REGNO + "', '" + 
				DDL_SIBS_PRODID.SelectedValue + "', '" + 
				DDL_COMPNAME.SelectedValue + "', '" + 
				DDL_AP_RELMNGR.SelectedValue + "', '" + 
				DDL_PROGRAM.SelectedValue + "', '" + 
				DDL_AANO.SelectedValue + "', '" + 
				DDL_ACC_SEQ.SelectedValue + "', '" + 
				tool.ConvertFloat(LBL_LIMIT.Text) + "', '1', '" + 
				tool.ConvertFloat(LBL_LIMIT.Text) + "', '01', '" + 
				Session["AreaID"].ToString() + "', '" + 
				Session["BranchID"].ToString() + "', '" + 
				TXT_CH_TENOR.Text + "', 'M', '" + 
				BUSSUNITID + "', '" + 
				Request.QueryString["tc"] + "','" +
				LBL_BATCHNO.Text + "'";
			conn.ExecuteNonQuery();
		}

		private void cekKelengkapanNasabah() 
		{
			//--- Mengambil Batchno
			string BATCHNO = "";
			conn.QueryString = "select MAX(BATCHNO) as BATCHNO from CHANNELING where CH_AA_NO = '" + DDL_AANO.SelectedValue +
				"' and CH_PRODUCTID = '" + DDL_SIBS_PRODID.SelectedValue + 
				"' and CH_ACC_SEQ = '" + DDL_ACC_SEQ.SelectedValue + "'";
			conn.ExecuteQuery();
			BATCHNO = conn.GetFieldValue("BATCHNO");

			//--- Mendapatkan field-field yang mandatory
			conn.QueryString = "select CH_PRM_FIELD from VW_CHANN_MANDATORYFIELD where CH_BPR_CUREF = '" + DDL_COMPNAME.SelectedValue + "'";
			conn.ExecuteQuery();
			if(conn.GetRowCount() > 0)
			{
				//--- Membentuk query untuk mendapatkan customer yang tidak lengkap field-fieldnya
				string query = "select * from CHANN_CUSTOMER where (";
				string query2 = ") and BATCHNO = (select MAX(BATCHNO) from CHANN_CUSTOMER where CH_BPR_CUREF = '" + DDL_COMPNAME.SelectedValue + "')";
				string field;

				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					//field = conn.GetFieldValue(i, "CH_PRM_FIELD") + " IS NULL OR ";
					field = "(" + conn.GetFieldValue(i, "CH_PRM_FIELD") + " IS NULL OR len(ltrim(rtrim(" + conn.GetFieldValue(i, "CH_PRM_FIELD") +"))) = 0 )";
					query = query + field;

					if (i+1 != conn.GetRowCount()) query = query + " OR ";
				}

				query = query + query2;
//				Response.Write(query); 
				conn.QueryString = query;
				conn.ExecuteQuery();
			}
			//--- Memberi tanda customer yang tidak lengkap
			DataTable dt = conn.GetDataTable().Copy();
			for(int j=0; j < dt.Rows.Count; j++) 
			{
				conn.QueryString = "update CHANN_CUSTOMER set CH_ISLENGKAP = '0' where BATCHNO = '" + dt.Rows[j]["BATCHNO"] + "' and BATCHSEQ = '" + dt.Rows[j]["BATCHSEQ"] + "'";
				conn.ExecuteNonQuery();
			}

			//--- Memberti tanda customer yang lengkap
			
			conn.QueryString = "update CHANN_CUSTOMER set CH_ISLENGKAP = '1' where BATCHNO = '" + BATCHNO + "' and ( CH_ISLENGKAP is NULL or rtrim(ltrim(CH_ISLENGKAP)) = '' )";
			conn.ExecuteNonQuery();
			
		}

		private string sendFTPcommand(string strPath, string cmdFile)
		{
			///
			/// addopted from Ben Meghreblian's code (15th Jan 2002) 
			/// benmeg at benmeg dot com / http://benmeg.com
			///
			string strCMD, strResFile, strCmdFile, strCommandResult;
			strCmdFile = strPath + "\\" + cmdFile;
			strResFile = strPath + "\\" + "res.ftp";

			//' Use cmd.exe to run ftp.exe, parsing our newly created command file
			strCMD = "ftp.exe -s:" + strCmdFile;

			//' Pipe output from cmd.exe to a temporary file (Not :| Steve)
			try
			{
				proc = System.Diagnostics.Process.Start("cmd.exe", " /c " + strCMD + " > " + strResFile);
			}
			catch
			{
				try
				{
					proc.Kill();
					proc.Close();
					proc.Dispose();
					proc = null;
				} catch {}
				throw new ApplicationException("eror...gimana nih....");
			}
			proc.Kill();
			proc.Close();
			proc.Dispose();
			proc = null;

			//' Grab output from temporary file
			StreamReader objResFile = new StreamReader(strResFile);
			strCommandResult = objResFile.ReadToEnd();
			objResFile.Close();
			objResFile = null;

			//' Delete the temporary & ftp-command files
			File.Delete(strResFile);
			File.Delete(strCmdFile);
			//' Print result of FTP session to screen
			return strCommandResult;
		}

		private string sendFTPTempFile()
		{
			///
			/// addopted from Ben Meghreblian's code (15th Jan 2002) 
			/// benmeg at benmeg dot com / http://benmeg.com
			///
			string strPath, strTextFile, fullTextFile, 
				ftp_address, ftp_username, ftp_password, ftp_remote_directory, ftp_file_to_put;

			FileInfo fi = new FileInfo(LBL_CH_NAMAFILE.Text);
			if (!fi.Exists)
			{
				GlobalTools.popMessage(this, "File not found!");
				return "";
			}
			ftp_address          = dbip;
			ftp_username         = "anonymous";
			ftp_password         = "password";
			ftp_remote_directory = "";
			ftp_file_to_put     = fi.Name;

			strPath = fi.DirectoryName;
			strTextFile = "test.ftp";
			fullTextFile = strPath +"\\"+ strTextFile;
			StreamWriter objTextFile = new StreamWriter(fullTextFile);

			//' Build our ftp-commands file
			objTextFile.WriteLine("lcd " + strPath);
			objTextFile.WriteLine("open " + ftp_address);
			objTextFile.WriteLine(ftp_username);
			objTextFile.WriteLine(ftp_password);
			//' Check to see if we need to issue a 'cd' command
			if (ftp_remote_directory != "")
				objTextFile.WriteLine("cd " + ftp_remote_directory);
			objTextFile.WriteLine("prompt");
			objTextFile.WriteLine("put " + ftp_file_to_put);
			objTextFile.WriteLine("bye");
			objTextFile.Flush();
			objTextFile.Close();
			objTextFile = null;

			return sendFTPcommand(strPath, strTextFile);
		}

		private string deleteFTPTempFile()
		{
			///
			/// addopted from Ben Meghreblian's code (15th Jan 2002) 
			/// benmeg at benmeg dot com / http://benmeg.com
			///
			string strPath, strTextFile, fullTextFile, 
				ftp_address, ftp_username, ftp_password, ftp_remote_directory, ftp_file_to_put;

			FileInfo fi = new FileInfo(LBL_CH_NAMAFILE.Text);
			if (!fi.Exists)
			{
				GlobalTools.popMessage(this, "File not found!");
				return "";
			}
			ftp_address          = dbip;
			ftp_username         = "anonymous";
			ftp_password         = "password";
			ftp_remote_directory = "";
			ftp_file_to_put     = fi.Name;

			strPath = fi.DirectoryName;
			strTextFile = "test.ftp";
			fullTextFile = strPath +"\\"+ strTextFile;
			StreamWriter objTextFile = new StreamWriter(fullTextFile);

			//' Build our ftp-commands file
			objTextFile.WriteLine("open " + ftp_address);
			objTextFile.WriteLine(ftp_username);
			objTextFile.WriteLine(ftp_password);
			//' Check to see if we need to issue a 'cd' command
			if (ftp_remote_directory != "")
				objTextFile.WriteLine("cd " + ftp_remote_directory);
			objTextFile.WriteLine("prompt");
			objTextFile.WriteLine("delete " + ftp_file_to_put);
			objTextFile.WriteLine("bye");
			objTextFile.Flush();
			objTextFile.Close();
			objTextFile = null;

			return sendFTPcommand(strPath, strTextFile);
		}

		#endregion

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

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			//Kalau file yang mau diupload kosong, sistem error
			if (TXT_FILE_UPLOAD.Value == "") 
			{
				GlobalTools.popMessage(this, "File Upload harap diisi!");
				return;
			}

			string mStatus = "";			
			string mStatusReport = "";		

			string path;
			string fullpath;
			string fullname;
			string random_str;

			//Mengambil Root Application
			conn.QueryString = "select APP_ROOT, CHANNELING_DIR from APP_PARAMETER";
			conn.ExecuteQuery();

			path = conn.GetFieldValue("APP_ROOT").ToString().Trim()+ conn.GetFieldValue("CHANNELING_DIR").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			LBL_STATUS.Text = "";
			LBL_STATUSREPORT.Text = "";
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				counter = i + 1;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{						
						conn.QueryString = "select right(convert(varchar, getdate(), 121),6) as random";
						conn.ExecuteQuery();
						random_str = conn.GetFieldValue("Random").ToString().Trim();

						//path = conn.GetFieldValue("APP_ROOT").ToString().Trim()+ conn.GetFieldValue("CHANNELING_DIR").ToString().Trim();
 
						//--- Format file disimpan : [USERID]-[SEQ BPR]-[ACC_NO]-[NAMA FILE] --- 
						// --- file name ditambah random string
						fullname = Session["USERID"].ToString()+ "-" + DDL_COMPNAME.SelectedValue + "-" + DDL_ACC_SEQ.SelectedItem.Text + random_str + "-" + Path.GetFileName(userPostedFile.FileName);
						fullpath = path + fullname;


						/***
						if (File.Exists(fullpath)) 
						{
							mStatus = "Upload Failed !";
							mStatusReport = "File already exist.";
						}
						else 
						{
						***/

						if (mField == 0)
						{			
							//--- Upload Excel file ke database
							conn.QueryString = "exec CHANN_FILE_UPLOAD '', '"+ 
								fullname +"', '"+ 
								tool.ConvertFloat(LBL_LIMIT.Text.Trim()) + "', '" +
								Session["USERID"].ToString() +"', '"+ 
								DDL_COMPNAME.SelectedValue +"','" + 
								DDL_AANO.SelectedValue + "', '" + 
								DDL_SIBS_PRODID.SelectedValue + "', '" + 
								DDL_ACC_SEQ.SelectedValue + "', '1', '" + 
								Request.QueryString["tc"] + "'";
							conn.ExecuteNonQuery();

							//--- Mengambil BATCHNO-nya untuk di pass ke NasabahList.aspx
							conn.QueryString = "select isnull(max(BATCHNO),0) BATCHNO from CHANNELING";
							conn.ExecuteQuery();

							LBL_BATCHNO.Text = conn.GetFieldValue("BATCHNO");

							//--- Save File ---
							userPostedFile.SaveAs(fullpath);
							LBL_STATUS.ForeColor = Color.Black;
							LBL_STATUSREPORT.ForeColor = Color.Black;
							mStatus = "Upload Successful!";
							mStatusReport = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + "kb<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>";
							mStatusReport += "Location Where Saved: " + path + "-" + Session["USERID"].ToString() + "-" + Path.GetFileName(userPostedFile.FileName) + "<p>";

							//--- Menyimpan nama file
							//LBL_CH_NAMAFILE.Text = TXT_FILE_UPLOAD.Value;
							LBL_CH_NAMAFILE.Text = fullpath;
						}


						/***}**/

						BTN_NEXT.Enabled = true;
					}
				}
				catch (Exception ex)
				{
					LBL_STATUS.ForeColor = Color.Red;
					LBL_STATUSREPORT.ForeColor = Color.Red;
					mStatus		  = "Error Uploading File";
					mStatusReport = ex.ToString();
					LBL_CH_NAMAFILE.Text = "";
				}
				
				LBL_STATUS.Text			= mStatus.Trim();
				LBL_STATUSREPORT.Text	= mStatusReport.Trim();							
			}
		}

		protected void BTN_NEXT_Click(object sender, System.EventArgs e)
		{	
			//--- Bandingkan limit customer kolektif dengan plafond perusahaan.
			//--- Jika masih dalam range, baru bisa lanjut
			//--- Jika tidak, munculkan pesan dan tidak bisa lanjut ---

			//sendFTPTempFile();
			FileInfo fi = new FileInfo(LBL_CH_NAMAFILE.Text);
			if (!fi.Exists)
			{
				GlobalTools.popMessage(this, "Uploaded file not found!");
				return;
			}
//			WebCamService.FtpClient ftp = new WebCamService.FtpClient();
//			ftp.Server = dbip;								//put uploaded excel file to the db server 
//			ftp.Username = "anonymous";						//to be read by the sp chann_procexcel
//			ftp.Password = "password";
//			ftp.RemotePath = "";
//
//			ftp.Upload(fi.FullName);
//
//			try
//			{
//				string ftpfile = ftp.RemotePath + "\\" + fi.Name;
//				ftpfile = ftpfile.Replace("\\", "\\\\");
//				conn.QueryString = "EXEC CHANN_PROCEXCEL '" + LBL_BATCHNO.Text + "', '" +
//					(string)Session["UserID"] + "', '" + DDL_COMPNAME.SelectedValue + "', '" +
//					ftpfile + "', " + DMS.CuBESCore.GlobalTools.ConvertFloat(TXT_CH_PLAFOND_LOS.Text);
//				conn.ExecuteNonQuery();
//			} 
//			catch (Exception ex)
//			{
//				Response.Write("<!-- " + ex.Message.ToString() + "\n ConnString: " + conn.connString + " -->");								
//
//				string errmsg = ex.Message.Replace("\n","\\n").Replace("'","");
//				if (errmsg.IndexOf("Last Query:") > 0)		//method Connection.ExecuteNonQuery() add this msg on exception 
//					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
//				GlobalTools.popMessage(this, errmsg);
//				//deleteFTPTempFile();
//				//ftp.DeleteFile(fi.Name);
//				ftp.Close();
//				ftp = null;
//				return;				
//			}
//			//deleteFTPTempFile();
//			//ftp.DeleteFile(fi.Name);						//delete excel file in the ftp dir of the db server after used
//			ftp.Close();
//			ftp = null;
			
			
			try 
			{
				if (!isLimitInRange()) 
				{	
					GlobalTools.popMessage(this, "Limit melebihi Plafond !");
					return;
				}
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Penghitungan limit di excel file mengalami masalah!");
				return;
			}

			saveCustomer(LBL_BATCHNO.Text, LBL_CH_NAMAFILE.Text);
			cekKelengkapanNasabah();
			adjustLimitBPR();
			
			insertIntoTrack();

			Response.Redirect("NasabahList.aspx?batchno=" + LBL_BATCHNO.Text + 
				"&regno=" + LBL_AP_REGNO.Text + 
				"&tc=" + Request.QueryString["tc"] + 
				"&mc=" + Request.QueryString["mc"]);
		}

		protected void DDL_COMPNAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillAANo();
		}
		
		protected void DDL_AANO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillSIBSProdid();
		}

		protected void DDL_SIBS_PRODID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillAccSeq();
		}

		protected void DDL_ACC_SEQ_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select LIMIT_CHANNELING, TENOR, TENORDESC " + 
				"from VW_CHANN_FAC " +
				"where CU_REF = '" + DDL_COMPNAME.SelectedValue + "' " +
				"and AA_NO = '" + DDL_AANO.SelectedValue + "' " +
				"and PRODUCTID = '" + DDL_SIBS_PRODID.SelectedValue + "' " +
				"and ACC_SEQ = '" + DDL_ACC_SEQ.SelectedValue  + "' ";
			conn.ExecuteQuery();

			TXT_CH_PLAFOND_LOS.Text	= tool.MoneyFormat(conn.GetFieldValue("LIMIT_CHANNELING"));
			TXT_CH_TENOR.Text		= conn.GetFieldValue("TENOR");
			TXT_CH_TENORDESC.Text	= conn.GetFieldValue("TENORDESC");
		}

		protected void DDL_PROGRAM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillProgDependant();
		}

	}
}
