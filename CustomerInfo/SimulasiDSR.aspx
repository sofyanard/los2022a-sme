<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimulasiDSR.aspx.cs" Inherits="SME.CustomerInfo.SimulasiDSR" %>

<%@ Register src="../CommonForm/DocumentUpload.ascx" tagname="DocumentUpload" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SimulasiDSR</title>
    <LINK href="../style.css" type="text/css" rel="stylesheet">
    <!-- #include file="../include/cek_entries.html" -->
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SIMULASI DSR</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">SIMULASI ANGSURAN</TD>
						</TR>
                        <TR>
				            <TD class="td" vAlign="top" width="50%">
					            <TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
						            <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px"><asp:RadioButton ID="RB_PLAFOND" runat="server" Text="Berdasarkan Plafond" Checked="True" GroupName="RBG1" AutoPostBack="True" OnCheckedChanged="RB_PLAFOND_CheckedChanged" /></TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND" runat="server" 
                                                onkeypress="return digitsonly()" onblur="FormatCurrency(this)"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px"><asp:RadioButton ID="RB_ANGSURAN" runat="server" Text="Berdasarkan Angsuran" GroupName="RBG1" AutoPostBack="True" OnCheckedChanged="RB_ANGSURAN_CheckedChanged" /></TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_ANGSURAN" runat="server" onkeypress="return digitsonly()" onblur="FormatCurrency(this)" Enabled="False"></asp:textbox></TD>
						            </TR>
				                </TABLE>
				            </TD>
				            <TD class="td" vAlign="top" width="50%">
					            <TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Jangka Waktu</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_JANGKAWAKTU" runat="server" 
                                                onkeypress="return numbersonly()"></asp:textbox>&nbsp;bulan</TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Suku Bunga</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue">
                                            <asp:textbox id="TXT_SUKUBUNGA" runat="server" onkeypress="return digitsonly()"></asp:textbox>
                                            &nbsp;%&nbsp;per&nbsp;tahun&nbsp;
                                            <asp:radiobuttonlist id="RDO_SIFATBUNGA" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Flat</asp:ListItem>
												<asp:ListItem Value="2" Selected="True">Anuitas</asp:ListItem>
											</asp:radiobuttonlist>
                                        </TD>
						            </TR>
					            </TABLE>
				            </TD>
			            </TR>
                        <TR>
				            <TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                                <asp:button id="BTN_CALCULATE" runat="server" Text="Hitung" CssClass="Button1" 
                                    Width="100px" onclick="BTN_CALCULATE_Click"></asp:button>&nbsp;&nbsp;
                            </TD>
			            </TR>
                        <TR>
							<TD colSpan="2">
                                <!--<ASP:DATAGRID id="datagrid1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="10"
									CellPadding="1" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="BULANKE" HeaderText="Bulan Ke">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
                                        <asp:BoundColumn DataField="ANGSURANPOKOK" HeaderText="Total Limit" DataFormatString="{0:0,00.00}">
										    <HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ANGSURANBUNGA" HeaderText="Total Limit" DataFormatString="{0:0,00.00}">
										    <HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TOTALANGSURAN" HeaderText="Total Limit" DataFormatString="{0:0,00.00}">
										    <HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundColumn>
                                        <asp:BoundColumn DataField="SISAPINJAMAN" HeaderText="Total Limit" DataFormatString="{0:0,00.00}">
										    <HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID>-->
							    <asp:GridView ID="DG_CICILAN" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True" ShowFooter="True" OnRowDataBound="DG_CICILAN_RowDataBound" OnPageIndexChanging="DG_CICILAN_PageIndexChanging" PageSize="25">
                                    <AlternatingRowStyle CssClass="TblAlternating"></AlternatingRowStyle>
                                    <Columns>
										<asp:BoundField DataField="BULANKE" HeaderText="Bulan Ke">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundField>
                                        <asp:BoundField DataField="ANGSURANPOKOK" HeaderText="Angsuran Pokok" DataFormatString="{0:0,00.00}" HtmlEncode="False">
										    <HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundField>
                                        <asp:BoundField DataField="ANGSURANBUNGA" HeaderText="Angsuran Bunga" DataFormatString="{0:0,00.00}" HtmlEncode="False">
                                            <HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundField>
                                        <asp:BoundField DataField="TOTALANGSURAN" HeaderText="Total Angsuran" DataFormatString="{0:0,00.00}" HtmlEncode="False">
										    <HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundField>
                                        <asp:BoundField DataField="SISAPINJAMAN" HeaderText="Sisa Pinjaman" DataFormatString="{0:0,00.00}" HtmlEncode="False">
										    <HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										    <ItemStyle HorizontalAlign="Right"></ItemStyle>
									    </asp:BoundField>
									</Columns>
									<PagerStyle></PagerStyle>
                                    <FooterStyle CssClass="tdSmallHeader"></FooterStyle>
                                </asp:GridView>
							</TD>
						</TR>
                        <!--
                        <TR>
							<TD class="tdHeader1" colSpan="2">SIMULASI USAHA PRODUKTIF</TD>
						</TR>
                        <TR>
				            <TD class="td" vAlign="top" width="50%">
					            <TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px"></TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><b>Informasi Keuangan</b></TD>
						            </TR>
						            <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Sales / Penjualan</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_SALES" runat="server" 
                                                onkeypress="return digitsonly()" onblur="FormatCurrency(this)"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Laba Kotor</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_LABAKOTOR" runat="server" 
                                                onkeypress="return digitsonly()" onblur="FormatCurrency(this)"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Biaya Operasional / Administrasi</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_BIAYAOPRADM" runat="server" 
                                                onkeypress="return digitsonly()" onblur="FormatCurrency(this)"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px"></TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><b>Kalkulator Kebutuhan Modal Kerja</b></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Rata-Rata Periode Piutang</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_RATA2PERIODEPIUTANG" runat="server" 
                                                onkeypress="return numbersonly()"></asp:textbox>&nbsp;hari</TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Rata-Rata Periode Hutang</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_RATA2PERIODEHUTANG" runat="server" 
                                                onkeypress="return numbersonly()"></asp:textbox>&nbsp;hari</TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Rata-Rata Jangka Waktu Persediaan Barang</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_RATA2PERSEDIAAN" runat="server" 
                                                onkeypress="return numbersonly()"></asp:textbox>&nbsp;hari</TD>
						            </TR>
                                    
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Sisa Pendapatan</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="Textbox5" runat="server" 
                                                onkeypress="return digitsonly()" onblur="FormatCurrency(this)"></asp:textbox>
                                        </TD>
						            </TR>
				                </TABLE>
				            </TD>
				            <TD class="td" vAlign="top" width="50%">
					            <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Estimasi Kebutuhan Modal Kerja</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_ESTIMASIKEBUTUHAN" runat="server" 
                                                ReadOnly="True"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Estimasi Pinjaman Bank</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_ESTIMASIPINJAMAN" runat="server" 
                                                ReadOnly="True"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Estimasi Piutang per Akhir Bulan</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_ESTIMASIPIUTANG" runat="server" 
                                                ReadOnly="True"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Estimasi Persediaan Barang per Akhir Bulan</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_ESTIMASIPERSEDIAAN" runat="server" 
                                                ReadOnly="True"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Estimasi Hutang per Akhir Bulan</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_ESTIMASIHUTANG" runat="server" 
                                                ReadOnly="True"></asp:textbox></TD>
						            </TR>
                                    <TR>
							            <TD class="TDBGColor1" style="WIDTH: 129px">Estimasi Biaya yang Dibayar per Akhir Bulan</TD>
							            <TD style="WIDTH: 15px"></TD>
							            <TD class="TDBGColorValue"><asp:textbox id="TXT_KMK_ESTIMASiBIAYA" runat="server" 
                                                ReadOnly="True"></asp:textbox></TD>
						            </TR>
					            </TABLE>
				            </TD>
			            </TR>
                        <TR>
				            <TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                                <asp:button id="Button1" runat="server" Text="Hitung" CssClass="Button1" 
                                    Width="100px" onclick="BTN_CALCULATE_Click"></asp:button>&nbsp;&nbsp;
                            </TD>
			            </TR>
                        -->
					</TBODY>
				</TABLE>
                <table>
                    <tr id="Tr1" colSpan="2" runat="server">
                            <td>
                                <uc1:DocumentUpload id="DocumentUpload1" runat="server"></uc1:DocumentUpload>
                            </td>
                        </tr>
                </table>
			</center>
		</form>
</body>
</html>
