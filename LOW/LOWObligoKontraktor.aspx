<%@ Page language="c#" Codebehind="LOWObligoKontraktor.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWObligoKontraktor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LOWObligoKontraktor</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">
			function deleteconfirm()
			{
				conf = confirm("Are you sure you want to delete?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>OBLIGO KMK KONTRAKTOR</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Obligo KMK Kontraktor</TD>
						</TR>
						<TR id="TR_COMPANY" runat="Server">
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">CIF No.</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Debitur</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<!-- Additional Field : Right --></TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD colSpan="3"></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DG_OB" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True" PageSize="5" HorizontalAlign="Center">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
										<asp:BoundColumn DataField="OB_SEQ" HeaderText="Seq">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BOUWHEERNAME" HeaderText="Nama Bouwheer">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CONTRACTNO" HeaderText="No. SPK/Kontrak">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CONTRACTEXPDATE" HeaderText="Tanggal JT Kontrak" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CONTRACTVALUE" HeaderText="Nilai Kontrak" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NETTOVALUE" HeaderText="NK Netto" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROJECTCOST" HeaderText="Project Cost" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DOWNPAYMENT" HeaderText="Uang Muka" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BIAYABANK" HeaderText="Pembiayaan Bank" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:ButtonColumn Text="Edit" CommandName="Edit">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
										<asp:ButtonColumn Text="Delete" CommandName="Delete">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR id="Tr2" runat="Server">
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Nama Bouwheer</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_BOUWHEERNAME" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. SPK/Kontrak</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CONTRACTNO" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal JT Kontrak</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CONTRACTEXPDATE_DAY" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CONTRACTEXPDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CONTRACTEXPDATE_YEAR" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nilai Kontrak</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CONTRACTVALUE" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<!-- Additional Field : Right --></TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">NK Netto</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_NETTOVALUE" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Project Cost</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PROJECTCOST" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Uang Muka</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_DOWNPAYMENT" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pembiayaan Bank</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_BIAYABANK" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2" id="TR_BTN1" runat="server"><asp:button id="BTN_SAVE" runat="server" Width="80px" CssClass="Button1" Text="Save"></asp:button>&nbsp;
								<asp:button id="BTN_CLEAR" runat="server" Width="80px" CssClass="Button1" Text="Clear"></asp:button>&nbsp;
								<asp:label id="LBL_SEQ" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD colSpan="2"></TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DG_DET" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True" PageSize="5" HorizontalAlign="Center">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="OB_SEQ"></asp:BoundColumn>
										<asp:BoundColumn DataField="DET_SEQ" HeaderText="Seq">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENCAIRAN_TGL" HeaderText="Tanggal Pencairan" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENCAIRAN_NILAI" HeaderText="Nilai Pencairan" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENCAIRAN_TUJUAN" HeaderText="Tujuan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROGRESS_TGL" HeaderText="Tanggal Progres Prestasi" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROGRESS_PERCENT" HeaderText="% Progres Prestasi">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROGRESS_NILAI" HeaderText="Nilai Progres Prestasi" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENAGIHAN_TGL" HeaderText="Tanggal Penagihan Termijn" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENAGIHAN_PERCENT" HeaderText="% Penagihan Termijn">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENAGIHAN_NILAI" HeaderText="Nilai Penagihan Termijn" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PEMBAYARAN_TGL" HeaderText="Tanggal Pembayaran Termijn" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PEMBAYARAN_PERCENT" HeaderText="% Pembayaran Termijn">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PEMBAYARAN_NILAI" HeaderText="Nilai Pembayaran Termijn" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="POSISI_TGL" HeaderText="Tanggal Posisi" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="POSISI_SISA" HeaderText="Sisa Tagihan" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="POSISI_BAKIDEBET" HeaderText="Baki Debet" DataFormatString="{0:0,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="POSISI_COVERAGE" HeaderText="% Coverage">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:ButtonColumn Text="Edit" CommandName="Edit">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
										<asp:ButtonColumn Text="Delete" CommandName="Delete">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR id="Tr1" runat="Server">
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Tanggal Pencairan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PENCAIRAN_TGL_DAY" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_PENCAIRAN_TGL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PENCAIRAN_TGL_YEAR" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nilai Pencairan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PENCAIRAN_NILAI" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tujuan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_PENCAIRAN_TUJUAN" runat="server" Width="300px" TextMode="MultiLine" Rows="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Progress Prestasi</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PROGRESS_TGL_DAY" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_PROGRESS_TGL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PROGRESS_TGL_YEAR" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">% Progress Prestasi</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PROGRESS_PERCENT" runat="server" MaxLength="5"
												Columns="5"></asp:textbox>&nbsp;%
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nilai Progress Prestasi</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PROGRESS_NILAI" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Penagihan Termijn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PENAGIHAN_TGL_DAY" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_PENAGIHAN_TGL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PENAGIHAN_TGL_YEAR" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">% Penagihan Termijn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PENAGIHAN_PERCENT" runat="server" MaxLength="5"
												Columns="5"></asp:textbox>&nbsp;%
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nilai Penagihan Termijn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PENAGIHAN_NILAI" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Tanggal Pembayaran Termijn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PEMBAYARAN_TGL_DAY" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_PEMBAYARAN_TGL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PEMBAYARAN_TGL_YEAR" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">% Pembayaran Termijn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PEMBAYARAN_PERCENT2" runat="server" MaxLength="5"
												Columns="5"></asp:textbox>&nbsp;%
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nilai Pembayaran Termijn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_PEMBAYARAN_NILAI2" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Posisi Tanggal</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_POSISI_TGL_DAY" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_POSISI_TGL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_POSISI_TGL_YEAR" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Sisa Tagihan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_POSISI_SISA" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Baki Debet</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_POSISI_BAKIDEBET" onblur="FormatCurrency(this)"
												runat="server" Width="300px" MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">% Coverage</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_POSISI_COVERAGE" runat="server" MaxLength="5"
												Columns="5"></asp:textbox>&nbsp;%
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2" id="TR_BTN2" runat="server"><asp:button id="BTN_SAVE2" runat="server" Width="80px" CssClass="Button1" Text="Save"></asp:button>&nbsp;
								<asp:button id="BTN_CLEAR2" runat="server" Width="80px" CssClass="Button1" Text="Clear"></asp:button>&nbsp;
								<asp:label id="LBL_SEQ2" runat="server"></asp:label></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
