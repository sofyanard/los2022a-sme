<%@ Page language="c#" Codebehind="AssignmentComplyReview.aspx.cs" AutoEventWireup="True" Inherits="SME.ComplyReview.Channeling.Assignment.AssignmentComplyReview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Verification Assignment</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> New Comply, Review and 
												Legal Doc Assignment</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListComplyReview.aspx?mc=CHAN005"><IMG src="/SME/Image/back.jpg"></A><A href="../../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">
								GENERAL INFO</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px; HEIGHT: 21px">Business Unit
										</TD>
										<TD style="WIDTH: 1px; HEIGHT: 21px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 21px">
											<asp:DropDownList id="DDL_AP_BOOKINGBRANCH" runat="server" Width="300px" CssClass="mandatory" Enabled="False"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 886px">CO Unit
										</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD class="TDBGColorValue">
											<asp:DropDownList id="DDL_AP_CCOBRANCH" runat="server" Width="300px" CssClass="mandatory" Enabled="False"></asp:DropDownList></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="150">Application Date
										</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD class="TDBGColorValue">
											<asp:TextBox id="txt_DD_B" runat="server" Width="40px" CssClass="mandatory" Enabled="False"></asp:TextBox>&nbsp;
											<asp:DropDownList id="ddl_MM_B" runat="server" Width="176px" CssClass="mandatory" Enabled="False"></asp:DropDownList>&nbsp;
											<asp:TextBox id="txt_YY_B" runat="server" Width="80px" CssClass="mandatory" Enabled="False"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Application Number
										</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_APPLICATION" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
												CssClass="mandatory" Enabled="False"></asp:textbox></TD>
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
						<TD class="tdHeader1" colSpan="3">PLAFOND INFO</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" width="484" style="WIDTH: 49%">Plafond Owner</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:Label id="LBL_PLAFOND_OWNER" runat="server" Width="320px">Label</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">Remainaning eMAS Limit</TD>
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
						<TD class="tdNoBorder" align="center" colspan="3"></TD>
					</TR>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="3">ASSIGNMENT</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" style="WIDTH: 49%">
							Petugas</TD>
						<TD style="WIDTH: 1%">:</TD>
						<TD class="TDBGColorValue">
							<asp:DropDownList id="DDL_PETUGAS" runat="server" Width="336px"></asp:DropDownList>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="left"></TD>
					</TR>
				</table>
				<table style="WIDTH: 100%; HEIGHT: 36px">
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
							<asp:button id="Button1" runat="server" Width="153px" Text="ASSIGN" CssClass="BUTTON1" onclick="Button1_Click"></asp:button>
							<asp:button id="Button2" runat="server" Width="150px" Text="RETURN TO BU" CssClass="BUTTON1" onclick="Button2_Click"></asp:button>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
