<%@ Page language="c#" Codebehind="AppInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.BGSpan.AppInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AppInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fAppInfo" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 240px; HEIGHT: 17px">CIF Number</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_CIF" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox><asp:label id="txt_CU_REF" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 240px; HEIGHT: 26px">Customer Name</TD>
									<TD style="WIDTH: 15px; HEIGHT: 26px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:textbox id="TXT_CU_NAME" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 240px; HEIGHT: 23px">ID Type</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_CU_IDTYPE" runat="server" Width="200px" BorderStyle="None" Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 240px; HEIGHT: 24px">ID Number</TD>
									<TD style="WIDTH: 15px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_CU_IDNUM" runat="server" Width="200px" BorderStyle="None" Height="22px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 240px">Address</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CON" runat="server" Width="1px" BorderStyle="None" ReadOnly="True" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txt_addr" runat="server" Width="100%" TextMode="MultiLine" Rows="3" MaxLength="200"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_STA" runat="server" Visible="False"></asp:label>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px" width="173">Application #</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 24px" width="173">Data Receive 
										Date</TD>
									<TD style="WIDTH: 15px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" Width="200px" BorderStyle="None" Height="22px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 25px" width="173"></TD>
									<TD style="WIDTH: 15px; HEIGHT: 25px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 25px"><asp:textbox id="Textbox9" runat="server" Width="200px" BorderStyle="None" Height="15px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px" width="173"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox10" runat="server" Width="200px" BorderStyle="None" Height="17px"></asp:textbox></TD>
								</TR>
								<TR>
									<!-- pipeline -->
									<TD class="TDBGColor1" style="WIDTH: 173px" width="173">Person In Charge</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RELMNGR" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
									<!-- pipeline --></TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px" width="173">Team Leader / Section Head</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_TL" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
								</TR>
								<TR id="TR_generalinfo3" runat="server">
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 31px" width="173">Unit Name</TD>
									<TD style="HEIGHT: 31px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px"><asp:textbox id="TXT_BRANCH_NAME" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
