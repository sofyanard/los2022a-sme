<%@ Page language="c#" Codebehind="ViewCatatan.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DataEntry.ViewCatatan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewCatatan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="setMandatory2()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Catatan Rekanan</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">
						CATATAN REKANAN</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatgrdCat" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
							AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="SEQ" HeaderText="SEQ" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="REKANAN_REF" HeaderText="Registrasi#" Visible="False">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TGL_LAPOR" HeaderText="TANGGAL LAPORAN">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PELAPOR" HeaderText="UNIT KERJA PELAPOR">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Lihat Catatan" HeaderText="Function" CommandName="View">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr>
					<TD class="TDBGColor2" id="TR_A" vAlign="top" align="center" width="50%" colSpan="2"><asp:textbox id="txt_catatan" Height="100px" Runat="server" Width="100%" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
