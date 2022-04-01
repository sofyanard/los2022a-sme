<%@ Page language="c#" Codebehind="LastError.aspx.cs" AutoEventWireup="True" Inherits="SME.LastError" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LastError</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="60%" border="0" class="TD">
							<TR>
								<TD class="tdheader1">Error Report</TD>
							</TR>
							<TR>
								<TD><STRONG>Deskripsi :</STRONG></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="LBL_DESC" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></TD>
							</TR>
							<TR>
								<TD><STRONG>Keterangan :</STRONG></TD>
							</TR>
							<TR>
								<TD>Error muncul karena beberapa hal. Periksa kondisi-kondisi berikut :</TD>
							</TR>
							<TR>
								<TD>
									<OL>
										<LI>
										Validitas Input (Tanggal, Mandatory Field, Number Field, dll).
										<LI>
											Kondisi Server</LI></OL>
								</TD>
							</TR>
							<TR>
								<TD align="center" class="tdbgcolor2">
									<INPUT class="button1" id="BTN_BACK" style="WIDTH: 80px; HEIGHT: 26px" type="button" size="20"
										onclick="back()" value="Back"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">
		function back() {
			history.back(-1);
		}
		</script>
	</body>
</HTML>
