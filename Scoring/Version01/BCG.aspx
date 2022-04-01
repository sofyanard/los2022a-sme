<%@ Page language="c#" Codebehind="BCG.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.Version01.MainBCG" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="TBL_UTAMA" cellSpacing="2" cellPadding="2" width="100%" height="750">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 473px">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Final Scoring : B C G</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td class="tdNoBorder" align="right"><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../../Image/back.jpg"></asp:ImageButton>
							<A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD colSpan="2" align="center" class="tdNoBorder" style="HEIGHT: 41px"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Personal Data</TD>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2">
						
							<iframe id="if1" style="WIDTH: 100%; HEIGHT: 190px" name="if1" src="/SME/SPPK/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view" scrolling="no"></iframe>
						
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">BCG</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><asp:placeholder id="PH_BY" runat="server"></asp:placeholder><BR>
							<asp:Label id="LBL_CU_REF" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<tr>
						<td colSpan="2">
							<iframe id="if" style="WIDTH: 100.64%; HEIGHT: 521px" name="if" src="" frameBorder="no"
								width="100%" height="800"></iframe>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
