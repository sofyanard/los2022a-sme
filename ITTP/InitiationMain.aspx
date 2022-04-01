<%@ Page language="c#" Codebehind="InitiationMain.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.InitiationMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InitiationMain</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder">
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>General Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<!--					
					<TR>
						<TD align="center" colSpan="2">
							<asp:LinkButton id="LNK_KETENTUAN230" runat="server" Font-Bold="True">Ketentuan 230</asp:LinkButton></TD>
					</TR>
					-->
						<TR>
							<TD class="tdHeader1" style="HEIGHT: 42px" colSpan="2"><FONT size="3">General Info</FONT></TD>
						</TR>
						<TR>
							<TD class="td" style="HEIGHT: 151px" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 328px; HEIGHT: 33px"><FONT size="2">Region</FONT></TD>
										<TD style="WIDTH: 15px; HEIGHT: 33px"><FONT size="2"></FONT></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 33px"><asp:textbox id="TXT_AREAID" runat="server" CssClass="mandatory" ReadOnly="True" Width="240px"
												Height="27px"></asp:textbox><FONT size="2"></FONT></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 328px; HEIGHT: 36px"><FONT size="2">Business Unit</FONT></TD>
										<TD style="WIDTH: 15px; HEIGHT: 36px"><FONT size="2"></FONT></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 36px"><FONT size="2">
												<asp:dropdownlist id="DDL_AP_BUSINESSUNIT" runat="server" CssClass="mandatory" Width="240px" Height="27px"
													AutoPostBack="True"></asp:dropdownlist></FONT></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 328px; HEIGHT: 33px"><FONT size="2">Program</FONT></TD>
										<TD style="WIDTH: 15px; HEIGHT: 33px"><FONT size="2"></FONT></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 33px"><asp:dropdownlist id="DDL_PROG_CODE" runat="server" CssClass="mandatory" Width="240px" Height="27px"
												AutoPostBack="True"></asp:dropdownlist><FONT size="2"></FONT></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 328px; HEIGHT: 36px"><FONT size="2">Operation Unit</FONT></TD>
										<TD style="HEIGHT: 36px"><FONT size="2"></FONT></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 36px"><asp:dropdownlist id="DDL_CCOBRANCH" runat="server" CssClass="mandatory" Width="240px" Height="27px"
												AutoPostBack="True"></asp:dropdownlist><FONT size="2"></FONT></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" style="HEIGHT: 151px" vAlign="top">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 37px" width="150"><FONT size="2">Application 
												Date&nbsp;</FONT></TD>
										<TD style="WIDTH: 15px; HEIGHT: 37px"><FONT size="2"></FONT></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 37px"><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_DAY" runat="server" CssClass="mandatory"
												Width="32px" Height="19px" Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATE_MONTH" runat="server" CssClass="mandatory" Width="88px" Height="17px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_YEAR" runat="server" CssClass="mandatory"
												Width="51px" Height="18px" Columns="4" MaxLength="4"></asp:textbox><FONT size="2"></FONT></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 40px" width="150"><FONT size="2">Application 
												Number</FONT></TD>
										<TD style="WIDTH: 15px; HEIGHT: 40px"><FONT size="2"></FONT></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 40px"><asp:textbox id="TXT_AP_REGNO" runat="server" ReadOnly="True" Width="168px" Height="25px" BorderStyle="None"></asp:textbox><asp:textbox id="TXT_CU_REF" runat="server" Visible="False"></asp:textbox><FONT size="2"></FONT></TD>
									</TR>
								</TABLE>
								<P>
									<asp:label id="LBL_USERID" runat="server"></asp:label>
									<asp:label id="LBL_UPDATE" runat="server"></asp:label></P>
								<P><asp:label id="temp_areaid" runat="server"></asp:label><asp:label id="temp_userid" runat="server"></asp:label><asp:label id="temp_ccobranch" runat="server"></asp:label><asp:label id="temp_grpunit" runat="server"></asp:label>
									<asp:label id="temp_businessunit" runat="server"></asp:label>
									<asp:label id="temp_progcode" runat="server"></asp:label></P>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
								<asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="100px" Text="Save" onclick="BTN_SAVE_Click"></asp:button>
								<asp:button id="BTN_UPDATE_STATUS" runat="server" CssClass="Button1" Width="100px" Text="Update Status" onclick="BTN_UPDATE_STATUS_Click"></asp:button></TD>
						</TR>
						<tr>
							<td colspan="2">
								<asp:textbox id="txt_acqinfo" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 320px"
									Height="150" Width="100%" ReadOnly="True" Runat="server" TextMode="MultiLine"></asp:textbox>
								<CENTER></CENTER>
							</td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
