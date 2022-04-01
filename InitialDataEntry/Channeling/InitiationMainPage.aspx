<%@ Page language="c#" Codebehind="InitiationMainPage.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.Channeling.InitiationMainPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Verification Assignment</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/popup.html" -->
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table2">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Batch Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListInitiation.aspx?&amp;mc=CHAN001"><IMG src="/SME/Image/back.jpg"></A><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">
								General Info</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px; HEIGHT: 8px">Business Unit
										</TD>
										<TD style="WIDTH: 1px; HEIGHT: 8px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 8px">
											<asp:DropDownList id="DDL_AP_BOOKINGBRANCH" runat="server" Width="300px" CssClass="mandatory" Enabled="False"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px">CO Unit
										</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD class="TDBGColorValue">
											<asp:DropDownList id="DDL_AP_CCOBRANCH" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="182" style="WIDTH: 182px">Application Date
										</TD>
										<TD style="WIDTH: 6px">:</TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="txt_DD_B" runat="server" Width="40px" CssClass="mandatory" Enabled="False"></asp:TextBox>
											<asp:DropDownList id="ddl_MM_B" runat="server" Width="176px" CssClass="mandatory" Enabled="False"></asp:DropDownList>
											<asp:TextBox id="txt_YY_B" runat="server" Width="72px" CssClass="mandatory" Enabled="False"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 182px">Application Number
										</TD>
										<TD style="WIDTH: 6px">:</TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="TXT_APPLICATION" runat="server" Width="288px" CssClass="mandatory" Enabled="False"></asp:TextBox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colspan="2"></TD>
						</TR>
					</TBODY>
				</TABLE>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="3">Plafond Info</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" width="484" style="WIDTH: 49%">Plafond Owner</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_PLAFOND_OWNER" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Remaining eMas Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_REMAINING_EMAS" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Pending Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_PENDING_LIMIT" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Available Limit</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_AVAILBALE_LIMIT" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="right">
							<asp:CheckBox id="CB_EndUser" runat="server" Text="Check For Existing End User Entry Only !" Font-Bold="True"
								ForeColor="Red" TextAlign="Left"></asp:CheckBox>
						</TD>
					</TR>
				</table>
				<table style="WIDTH: 100%; HEIGHT: 36px">
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="BUTTON1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>
							<asp:button id="BTN_UPDATE_STATUS" runat="server" Width="167px" CssClass="Button1" Enabled="False"
								Text="UPDATE STATUS" onclick="BTN_UPDATE_STATUS_Click"></asp:button>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
