<%@ Page language="c#" Codebehind="RejectLetterAllPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Letters.RejectLetterAllPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:o>
	<HEAD>
		<title>RejectLetterPrint</title>
		<script language="javascript">
function print_frame() {
	//window.parent.framelkkn.focus();
	tr_print.style.display = "none";
	window.print();
	tr_print.style.display = "";
}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!--<script language="JavaScript">

if (window.print)
    document.write('<input type="button" value="Print"onClick="parent.frames[1].focus();parent.frames[1].print()">');

</script>-->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 20%" align="right"></TD>
						<TD class="tdNoBorder" style="WIDTH: 655px" align="right" colSpan="2"><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"></A></TD>
					</TR>
					<TR id="tr_print">
						<TD style="WIDTH: 119px" align="right"></TD>
						<TD style="WIDTH: 655px" align="center" colSpan="2"><INPUT class="Button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
								name="BTN_PRINT"><INPUT class="Button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
								value="Back" name="BTN_BACK"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 15%; HEIGHT: 68px" align="right"></TD>
						<TD style="WIDTH: 655px; HEIGHT: 68px" align="right" colSpan="2">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 98px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><asp:label id="LBL_NO" runat="server" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 98px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 2%"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><asp:label id="LBL_CUR_TIME" runat="server" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"></FONT></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 67px" align="left"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="WIDTH: 655px; HEIGHT: 67px" align="left" colSpan="2"><FONT face="Tahoma" size="2"></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 17px" align="left"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="WIDTH: 655px; HEIGHT: 17px" align="left" colSpan="2"><B><FONT face="Tahoma" size="2">Kepada 
									Yth.</FONT></B></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2"><asp:label id="LBL_CUST_NAME" runat="server" Font-Size="X-Small"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2"><asp:label id="LBL_ADDR" runat="server" Font-Size="X-Small"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:label id="LBL_ADDR2" runat="server" Font-Size="X-Small"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2">
							<asp:label id="LBL_ADDR3" runat="server" Font-Size="X-Small"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2"><asp:label id="LBL_CITY" runat="server" Font-Size="X-Small"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 655px" align="left" colSpan="2"><asp:label id="LBL_POSTCODE" runat="server" Font-Size="X-Small"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 69px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 69px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 69px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 10%" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"><FONT face="Tahoma"><FONT size="2">Perihal 
									: <b>Permohonan Kredit Saudara</b></FONT></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 20px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 20px" align="left" colSpan="2">
							<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><asp:label id="LBL_BODY11" runat="server" Font-Size="X-Small"></asp:label><asp:label id="LBL_BODY12" runat="server" Font-Size="X-Small"></asp:label></SPAN><SPAN style="mso-ansi-language: EN-US"><o:p></o:p></SPAN></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2"><asp:table id="ProductTable" runat="server" Font-Size="X-Small" Visible="False"></asp:table></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px" align="left"></TD>
						<TD style="WIDTH: 666px" align="left" colSpan="2">
							<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><asp:label id="LBL_BODY2" runat="server" Font-Size="X-Small" Width="100%"></asp:label><o:p></o:p></SPAN></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 119px; HEIGHT: 73px" align="left"></TD>
						<TD style="WIDTH: 666px; HEIGHT: 73px" align="left" colSpan="2"></TD>
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
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><FONT size="2"><FONT face="Tahoma"><b>PT. 
															Bank Pembangunan Daerah Papua</b>
														<o:p></o:p></FONT></FONT></SPAN></P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 23px">
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><FONT size="2"><FONT face="Tahoma"><asp:label id="LBL_BRANCH1" runat="server" Font-Size="X-Small"></asp:label><o:p></o:p></FONT></FONT></SPAN></P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 66px"><FONT face="Tahoma" size="2"></FONT></TD>
								</TR>
								<TR>
									<TD>
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><o:p><asp:label id="LBL_MANAGER" runat="server" Font-Size="X-Small"></asp:label>
													<FONT face="Tahoma" size="2"></FONT>
												</o:p></SPAN></P>
									</TD>
								</TR>
								<TR>
									<TD>
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><o:p><asp:label id="LBL_BRANCH2" runat="server" Font-Size="X-Small"></asp:label>
												</o:p></SPAN></P>
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
						<td align="center" width="100%">&nbsp;&nbsp;&nbsp;
						</td>
					</tr>
				</TABLE>
		</form>
		</CENTER>
	</body>
</HTML>
