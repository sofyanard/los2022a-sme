<%@ Page language="c#" Codebehind="BCG.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.MainBCG" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="TBL_UTAMA" height="750" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 473px">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Final Scoring : Bank 
											Pundi Rating</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td class="tdNoBorder" align="right"><asp:imagebutton id="ImageButton1" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Personal Data</TD>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2"><iframe id="if1" style="WIDTH: 100%; HEIGHT: 190px" name="if1" src="/SME/SPPK/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&amp;sta=view" scrolling="no"></iframe>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Bank Pundi Rating</TD>
					</TR>
					<TR id="_TOBEHIDDEN" runat="server">
						<TD vAlign="top" align="left">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdbgcolor1">Last Rate</TD>
									<TD></TD>
									<TD><asp:label id="LBL_RATING" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="tdbgcolor1">Rating Date</TD>
									<TD></TD>
									<TD><asp:label id="LBL_RATINGDATE" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="left">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdbgcolor1">Financial Period</TD>
									<TD></TD>
									<TD><asp:label id="LBL_RATIO_PERIOD" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="tdbgcolor1">Financial Report Type</TD>
									<TD></TD>
									<TD><asp:label id="LBL_RATIO_TYPE" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><asp:placeholder id="PH_BY" runat="server"></asp:placeholder><BR>
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<tr>
						<td colSpan="2"><iframe id="if" name="if" src="" frameBorder="no"
								width="95%" height="800"></iframe>
						</td>
					</tr>
					<TR>
						<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
