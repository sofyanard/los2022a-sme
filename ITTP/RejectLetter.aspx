<%@ Page language="c#" Codebehind="RejectLetter.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.RejectLetter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RejectLetter</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!--<frameset rows="100%,*">
		<frame src="RejectLetterPrint.aspx">
		<frame src="RejectLetterPrint.aspx">
</frameset> -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 20%" align="right"></TD>
						<TD class="tdNoBorder" style="WIDTH: 655px" align="right" colSpan="2"><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"></A></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="right"></TD>
						<TD style="WIDTH: 655px" align="right" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 15%; HEIGHT: 68px" align="right"></TD>
						<TD style="WIDTH: 655px; HEIGHT: 68px" align="right" colSpan="2">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 98px; HEIGHT: 20px"><FONT face="Tahoma" size="2">
											<asp:Label id="Label2" runat="server" Font-Size="X-Small"> Nomor </asp:Label></FONT></TD>
									<TD style="HEIGHT: 20px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD style="HEIGHT: 20px"><asp:textbox id="LBL_NO" runat="server" Width="200px" MaxLength="50" ForeColor="Black" Font-Size="X-Small"></asp:textbox><FONT face="Tahoma" size="2"></FONT>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px"><FONT face="Tahoma" size="2">
											<asp:Label id="Label1" runat="server" Font-Size="X-Small">Tanggal</asp:Label></FONT></TD>
									<TD style="WIDTH: 2%"><FONT face="System" size="2">:</FONT></TD>
									<TD>
										<asp:textbox id="LBL_CUR_TIME" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
											Width="200px" ReadOnly="True" BorderStyle="Ridge"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 67px" align="left"></TD>
						<TD style="WIDTH: 655px; HEIGHT: 67px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 17px" align="left"></TD>
						<TD style="WIDTH: 655px; HEIGHT: 17px" align="left" colSpan="2"><B><FONT face="Tahoma" size="2">
									<asp:Label id="Label3" runat="server" Font-Size="X-Small" Font-Bold="True">Kepada Yth.</asp:Label></FONT></B></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:textbox id="LBL_CUST_NAME" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:textbox id="LBL_ADDR" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:textbox id="LBL_ADDR2" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:textbox id="LBL_ADDR3" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:textbox id="LBL_CITY" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 25px" align="left"></TD>
						<TD style="WIDTH: 655px; HEIGHT: 25px" align="left" colSpan="2">
							<asp:textbox id="LBL_POSTCODE" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
								Width="200px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 69px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 69px" align="left"><B><FONT face="Tahoma" size="2">
									<asp:Label id="Label6" runat="server" ForeColor="White"></asp:Label>
									<asp:Label id="Label7" runat="server" ForeColor="White"></asp:Label>
									<asp:Label id="Label8" runat="server" ForeColor="White"></asp:Label></FONT></B></TD>
						<TD style="WIDTH: 666px; HEIGHT: 69px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 10%" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"><FONT face="Tahoma"><FONT size="2">
									<asp:Label id="Label5" runat="server" Font-Size="X-Small">Perihal :</asp:Label>
									<asp:Label id="Label4" runat="server" Font-Size="X-Small" Font-Bold="True"> Permohonan Saudara</asp:Label></FONT></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 26px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 26px" align="left" colSpan="2">
							<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><asp:label id="LBL_BODY11" runat="server" Font-Size="X-Small" ForeColor="Black"></asp:label></SPAN></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 25px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 25px" align="left" colSpan="2">
							<asp:Table id="ProductTable" runat="server" Font-Size="X-Small"></asp:Table>
							<asp:PlaceHolder id="PH1" runat="server"></asp:PlaceHolder></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 25px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 25px" align="left" colSpan="2">
							<asp:label id="LBL_BODY12" runat="server" Font-Size="X-Small" ForeColor="Black"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 25px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 25px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 30px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 30px" align="left" colSpan="2">
							<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US">
									<o:p>
										<FONT face="Tahoma" size="2">
											<asp:label id="LBL_BODY2" runat="server" Font-Size="X-Small"></asp:label></FONT></o:p></SPAN></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 73px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 73px" align="left" colSpan="2"><FONT size="7"></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 23px">
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><FONT face="Tahoma"><FONT size="2"><b>PT. 
															BANK MANDIRI (Persero) Tbk</b>
														<o:p></o:p></FONT></FONT></SPAN></P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 23px">
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><FONT size="2">
													<asp:textbox id="TXT_BRANCH" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
														Width="220px" align="center" Columns="4"></asp:textbox>
													<o:p></o:p></FONT></SPAN></P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 66px"><FONT size="2"></FONT></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 24px">
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><o:p><asp:textbox id="TXT_MANAGER" runat="server" Width="220px" MaxLength="50" Columns="4" align="center"
														ForeColor="Black" Font-Size="X-Small"></asp:textbox>
													<FONT size="2"></FONT>
												</o:p></SPAN></P>
									</TD>
								</TR>
								<TR>
									<TD>
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US">
												<asp:textbox id="TXT_GROUP" runat="server" Font-Size="X-Small" ForeColor="Black" MaxLength="50"
													Width="287px" align="center" Columns="4"></asp:textbox>
												<o:p></o:p></SPAN></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" align="center" border="0">
					</TR>
					<tr>
						<td align="center" width="100%">&nbsp;
							<asp:button id="PrintBtn" runat="server" CssClass="Button1" Text="Preview" Width="75px" onclick="PrintBtn_Click"></asp:button>&nbsp;
							<asp:button id="BTN_BACK" runat="server" Width="75px" Text="Back" CssClass="Button1" onclick="BTN_BACK_Click"></asp:button>&nbsp;
						</td>
					</tr>
				</TABLE>
		</form>
		</CENTER>
	</body>
</HTML>
