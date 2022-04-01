<%@ Page language="c#" Codebehind="RejectDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.RejectDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RejectDetail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" colSpan="2">Info Pemohon</td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Application No.</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_REGNO" Runat="server" ReadOnly Columns="35"></asp:textbox>
										<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Reference No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_REF" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_SIGNDATE" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_PROGRAMDESC" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cabang/CBC/Group</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BRANCH_NAME" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team Leader</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_TMLDRNM" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Relationship Manager</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_RMNM" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Business Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BU_DESC" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Nama Pemohon</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_NAME" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_ADDR1" Runat="server" ReadOnly Columns="35"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR2" Runat="server" ReadOnly Columns="35"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR3" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_CITYNM" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telp</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_PHN" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_BUSSTYPEDESC" Runat="server" ReadOnly Columns="35"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">&nbsp;
							<asp:button id="BTN_CONFIRM" Runat="server" Text="Confirm" CssClass="button1" onclick="BTN_CONFIRM_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UNCONFIRM" Runat="server" Text="Unconfirm" CssClass="button1" Visible="False" onclick="BTN_UNCONFIRM_Click"></asp:button>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2">
							<ASP:DATAGRID id="Datagrid1" runat="server" CellPadding="1" Width="100%" PageSize="5" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="UF_ERRORTYPE" HeaderText="Error Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UF_DESC" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UF_DATA" HeaderText="Data">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td colspan="2" align="center">
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
