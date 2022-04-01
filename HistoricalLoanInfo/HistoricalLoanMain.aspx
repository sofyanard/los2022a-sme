<%@ Page language="c#" Codebehind="HistoricalLoanMain.aspx.cs" AutoEventWireup="True" Inherits="SME.HistoricalLoanInfo.HistoricalLoanMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HistoricalLoanMain</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Historical Loan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Information</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Application No.</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_AP_REGNO" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Reference&nbsp;No.</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_CU_REF" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_AP_SIGNDATE" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_PROGRAMDESC" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Branch / CBC</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_BRANCH_NAME" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team Leader</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_TEAMLEADER" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Relationship Manager</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_RELMNGR" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Business Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_GR_BUSINESSUNIT" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Channels</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_CHANNEL_DESC" runat="server" ReadOnly="True" Width="175px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sales Agency</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="txt_AP_SALESAGENCY" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sales Agency Supervisor</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="txt_AP_SALESSUPERV" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sales Executive</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_AP_SALESEXEC" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Source Code</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_AP_SRCCODE" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
							<asp:textbox id="txt_AP_LIMITEXPOSURE" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"
								Visible="False"></asp:textbox>
							<asp:placeholder id="PH_SUBMENU" runat="server" Visible="False"></asp:placeholder>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table22" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="40%">Diterima Tanggal</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RECVDATE_DAY" runat="server" Width="24px" MaxLength="2" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_AP_RECVDATE_MONTH" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist><asp:textbox id="TXT_AP_RECVDATE_YEAR" runat="server" Width="36px" MaxLength="4" Columns="4"
											ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:label id="Label3" runat="server" Visible="False"></asp:label><asp:label id="Label1" runat="server" Visible="False"></asp:label><asp:label id="Label2" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Struktur Kredit</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD align="center" colSpan="1"><ASP:DATAGRID id="DatGrd" runat="server" Width="60%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE"></asp:BoundColumn>
												<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
