<%@ Page language="c#" Codebehind="InquirySaldoPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.SyndicationCalculation.InquirySaldoPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>InquirySaldoPrint</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function cetak()
			{
				TRPRINT.style.display = "none";
				window.print();
				TRPRINT.style.display = "";
			}
		</script>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD align="left" colSpan="2"><asp:label id="LBL_TITLE_CUST" runat="server" Font-Bold="True" Font-Size="200%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right" colSpan="2"><IMG src="../../Image/LogoMandiri.jpg">
						</TD>
					</TR>
					<TR>
						<TD colSpan="3"></TD>
					</TR>
					<TR id="TR_KI" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PORSI_KI" runat="server">PORSI :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_PORSI_KI" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FASILITAS_KI" runat="server">FASILITAS :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_FASILITAS_KI" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUKU_BUNGA_KI" runat="server">SUKU BUNGA :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_SUKU_BUNGA_KI" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_POSISI_KI" runat="server">POSISI :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_POSISI_KI" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BAKI_DEBET_POKOK_KI" runat="server">BAKI DEBET POKOK :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_BAKI_DEBET_POKOK_KI" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BAKI_DEBET_IDC_KI" runat="server">BAKI DEBET IDC :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_BAKI_DEBET_IDC_KI" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_KMK" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PORSI_KMK" runat="server">PORSI :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_PORSI_KMK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FASILITAS_KMK" runat="server">FASILITAS :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_FASILITAS_KMK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SUKU_BUNGA_KMK" runat="server">SUKU BUNGA :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_SUKU_BUNGA_KMK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_POSISI_KMK" runat="server">POSISI :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_POSISI_KMK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OUTSTANDING_POKOK_KMK" runat="server">OUTSTANDING POKOK :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_OUTSTANDING_POKOK_KMK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OUTSTANDING_BUNGA_KMK" runat="server">OUTSTANDING BUNGA :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_OUTSTANDING_BUNGA_KMK" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_NCL" runat="server">
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PORSI_NCL" runat="server">PORSI :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_PORSI_NCL" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_FASILITAS_NCL" runat="server">FASILITAS :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_FASILITAS_NCL" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_POSISI_NCL" runat="server">POSISI :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_POSISI_NCL" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OUTSTANDING_NCL" runat="server">OUTSTANDING POKOK :</asp:label></TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox id="TXT_OUTSTANDING_NCL" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<TABLE width="100%" border="0">
					<TR id="TR_INQUIRY" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DATA_GRID" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="TRX_DATE" HeaderText="Tanggal Transaksi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TRX_DESC" HeaderText="Jenis Transaksi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TOT_TRX" HeaderText="Jumlah Transaksi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REMARK" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
				<TABLE width="100%" border="0">
					<TR id="TRPRINT">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<INPUT onclick="cetak()" type="button" value="Print" style="FONT-WEIGHT: bold; FONT-SIZE: 150%; COLOR: white; BACKGROUND-COLOR: #18386b">
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
