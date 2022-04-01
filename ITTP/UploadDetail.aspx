<%@ Page language="c#" Codebehind="UploadDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.UploadDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UploadDetail</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../SourceSMEReport/style.css" type="text/css" rel="stylesheet">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/ConfirmBox.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Upload Detail</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">
							<asp:Label id="LBL_CU_REF" runat="server">LBL_CU_REF</asp:Label>
							<asp:Label id="LBL_CU_CIF" runat="server">LBL_CU_CIF</asp:Label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>Customer 
							Info</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><iframe id=if1 
      style="WIDTH: 100%; HEIGHT: 185px" name=if1 
      src="/SME/ITTP/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" 
      scrolling=no> </iframe>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							<P align="center">Compliance Condition</P>
						</TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2"><asp:datagrid id="DGR_LIST" Runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="des" HeaderText="Syarat">
										<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_accdate" HeaderText="Tanggal Dipenuhi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_ket" HeaderText="Keterangan">
										<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq"></asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="60px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2" class="tdBGCOlor2">
							<asp:button id="BTN_CONFIRM" Runat="server" Width="80px" CssClass="button1" Text="Confirm" onclick="BTN_CONFIRM_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_UNCONFIRM" Runat="server" Width="91px" CssClass="button1" Text="Unconfirmed" onclick="BTN_UNCONFIRM_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_ACQINFO" Runat="server" Width="96px" Text="Acquire Info" CssClass="button1" onclick="BTN_ACQINFO_Click"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ReadOnly="True" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
