<%@ Register TagPrefix="uc1" TagName="GenInfo" Src="CommonGeneralInfo.ascx" %>
<%@ Page language="c#" Codebehind="AccountInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.BankRelation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BankRelation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
		<script language="vbscript">
			function FormatCurrency2(edit)
				SetLocale("in")
				value = edit.value
				v_a = "1.000,00"    '-- in Rupiah Currency
				if isnumeric(v_a) and v_a = 1000 then	
					value = replace(value, ".", "")
					value = replace(value, ",", ".")
					if isnumeric(value) then
						edit.value =(formatnumber(eval(value),2))
					else	edit.value = ""
					end if
					edit.style.textAlign = "right"
				end if
			end function
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>ACCOUNT &amp; COLLATERAL 
												INFO</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD colSpan="2"><uc1:geninfo id="GenInfo1" runat="server"></uc1:geninfo></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Account &amp; Collateral Info</TD>
						</TR>
						<TR>
							<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="ACC_NO" HeaderText="No. Rekening">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FAC_CODE" HeaderText="Jenis Kredit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CURRENCYID" HeaderText="Currency" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="EXCHRP" HeaderText="Exchange Rate" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LOANAMOUNTRP" HeaderText="Limit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="OUTSTANDINGRP" HeaderText="Baki Debet">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TGKPOKOKRP" HeaderText="Tunggakan Pokok/bln">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TGKBUNGARP" HeaderText="Tunggakan Bunga/bln">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BIKOLE" HeaderText="Kol">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NILAIPENCAIRANRP" HeaderText="Jumlah Pencairan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NILAIAGUNANRP" HeaderText="Nilai Agunan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NILAIPENGIKATANRP" HeaderText="Nilai Pengikatan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TGL_PENILAIAN" HeaderText="Tanggal Penilaian">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ISREADONLY" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn>
											<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">No. Rekening</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_ACCNO" runat="server" Width="180px" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Jenis Kredit</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JENISKREDIT" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_JENISKREDIT_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Exchange Rate to IDR</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_EXCHRP" onblur="FormatCurrency(this)" runat="server"
												CssClass="mandatory" MaxLength="15" Width="180px">1</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Limit</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_LIMIT" onblur="FormatCurrency2(this)" runat="server"
												CssClass="mandatory" MaxLength="15" Width="180px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Baki Debet</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_BAKIDEBET" onblur="FormatCurrency2(this)"
												runat="server" Width="180" CssClass="angka" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Tunggakan 
											Pokok/thn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_TGKPOKOK" onblur="FormatCurrency2(this)"
												runat="server" Width="180" CssClass="angka" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Tunggakan 
											Bunga/thn</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_TGKBUNGA" onblur="FormatCurrency2(this)"
												runat="server" CssClass="angka" MaxLength="20" width="180"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Kolektibilitas</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KOLEKTIBILITAS" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Jumlah 
											Pencairan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_JMLPENCAIRAN" onblur="FormatCurrency2(this)"
												runat="server" Width="180" CssClass="angka" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Nilai Agunan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_NILAIAGUNAN" onblur="FormatCurrency2(this)"
												runat="server" Width="180" CssClass="angka" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Nilai 
											Pengikatan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_NILAIIKAT" onblur="FormatCurrency2(this)"
												runat="server" Width="180" CssClass="angka" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tanggal 
											Penilaian</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLPENILAIAN_DAY" runat="server" Width="24px"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLPENILAIAN_YEAR" runat="server" Width="36px"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Width="75px" CssClass="button1" Text="Insert" onclick="BTN_INSERT_Click"></asp:button><asp:button id="BTN_CLEAR" runat="server" Width="75px" CssClass="button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
