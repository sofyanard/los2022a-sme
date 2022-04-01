<%@ Register TagPrefix="uc1" TagName="GenInfo" Src="CommonGeneralInfo.ascx" %>
<%@ Page language="c#" Codebehind="RatingInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.RatingInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RatingInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>RATING HISTORY</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
								<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<uc1:GenInfo id="GenInfo1" runat="server"></uc1:GenInfo>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Bank Mandiri Rating</TD>
						</TR>
						<TR>
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
							<TD vAlign="top" align="center" colSpan="2">
								<asp:placeholder id="PH_BY" runat="server"></asp:placeholder><BR>
								<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label>
							</TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<iframe id="if" name="if" src="" frameBorder="no" width="95%" height="800"></iframe>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
