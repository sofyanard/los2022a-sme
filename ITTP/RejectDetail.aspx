<%@ Page language="c#" Codebehind="RejectDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.RejectDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RejectDetail</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" colSpan="2">Info Pemohon</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><iframe id=if1 
      style="WIDTH: 100%; HEIGHT: 185px" name=if1 
      src="/SME/ITTP/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" 
      scrolling=no> </iframe>
						</td>
					</tr>
				</table>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">&nbsp;
							<asp:button id="BTN_CONFIRM" Runat="server" Text="Confirm" CssClass="button1" onclick="BTN_CONFIRM_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UNCONFIRM" Runat="server" Text="Unconfirm" CssClass="button1" Visible="False" onclick="BTN_UNCONFIRM_Click"></asp:button>&nbsp;
							<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_AP_REGNO" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_CU_REF" Runat="server" Visible="False"></asp:label>
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
