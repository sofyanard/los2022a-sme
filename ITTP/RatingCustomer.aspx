<%@ Page language="c#" Codebehind="RatingCustomer.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.RatingCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RatingCustomer</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<script language="javascript">
		  function fillText(sTXT)
		  {
		    objTXT = eval('document.Form1.TXT_' + sTXT)
		    objDDL = eval('document.Form1.DDL_' + sTXT)
		    objTXT.value = objDDL.options[objDDL.selectedIndex].text;
		  }
		</script>
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 20px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE style="WIDTH: 424px; HEIGHT: 25px" width="424">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Rating Customer</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="MainCreditAnalysis.aspx?"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<td align="center"><iframe id=if1 
      style="WIDTH: 100%; HEIGHT: 185px" name=if1 
      src="/SME/ITTP/RatingHistory.aspx?curef=<%=Request.QueryString["curef"]%>" 
      scrolling=yes> </iframe>
					</td>
				</TR>
			</TABLE>
			<Table cellSpacing="2" cellPadding="2" width="100%">
				<TR id="TR_BODY" runat="server">
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_H" width="100%" runat="server">
							<!-- -------- rating qualitative new ----------------->
							<TR>
								<TD class="td" colSpan="2">
									<table width="100%">
										<TR width="100%">
											<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
													AllowPaging="True">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="SUBQUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Assesment Parameter">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBQUALITATIVEDESC" HeaderText="Assesment Sub Parameter">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Assesment Sub Sub Parameter">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemTemplate>
																<asp:radiobuttonlist id="RBL_SUBSUBQUAL" runat="server" RepeatDirection="Vertical"></asp:radiobuttonlist>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="SCORE" HeaderText="Score">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FLAG" HeaderText="Flag">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</ASP:DATAGRID></TD>
										</TR>
										<tr>
											<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVEQUAL" runat="server" Text="Save" CssClass="Button1" onclick="BTN_SAVEQUAL_Click"></asp:button></td>
										</tr>
										<tr>
											<td class="td" align="center" colSpan="2"><asp:datagrid id="DGR_CLASSIFY" Width="500px" AutoGenerateColumns="False" CellPadding="1" Runat="server"
													PageSize="1">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ratedesc" HeaderText="Classification">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUMSCORE" HeaderText="Score">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td class="td" colSpan="2">
												<table width="100%">
													<tr>
														<TD class="TDBGColor1" style="HEIGHT: 45px" width="20%">Klasifikasi&nbsp;Nasabah</TD>
														<TD style="HEIGHT: 45px">:</TD>
														<TD class="TDBGColorValue" style="HEIGHT: 45px" width="30%"><asp:label id="LBL_KATEGORINSB" runat="server"></asp:label></TD>
														<TD class="TDBGColor1" style="HEIGHT: 45px" width="20%">Kategori&nbsp;Nasabah</TD>
														<TD style="HEIGHT: 45px">:</TD>
														<TD class="TDBGColorValue" style="HEIGHT: 45px" width="30%"><asp:label id="LBL_KLASIFIKASINSB" runat="server"></asp:label></TD>
													</tr>
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 39px" width="20%">Profil Risk Nasabah</TD>
														<TD style="HEIGHT: 39px">:</TD>
														<TD class="TDBGColorValue" style="HEIGHT: 39px" width="30%"><asp:label id="LBL_PROFILRISKNSB_SCORE" runat="server"></asp:label><asp:label id="LBL_PROFILRISKNSB" runat="server"></asp:label></TD>
														<TD class="TDBGColor1" style="HEIGHT: 39px" width="20%">Kategori Risk Profile 
															Produk</TD>
														<TD style="HEIGHT: 39px">:</TD>
														<TD class="TDBGColorValue" style="HEIGHT: 39px" width="30%"><asp:label id="LBL_RISKPROFNSB" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 21px" width="20%">Risk Appetite Nasabah</TD>
														<TD style="HEIGHT: 21px">:</TD>
														<TD class="TDBGColorValue" style="HEIGHT: 21px" width="30%"><asp:label id="LBL_RISKAPPETITENSB" runat="server"></asp:label></TD>
														<TD class="TDBGColor1" style="HEIGHT: 21px" width="20%">Catatan Tenor</TD>
														<TD style="HEIGHT: 21px"></TD>
														<TD class="TDBGColorValue" style="HEIGHT: 21px" width="30%"><asp:label id="catatantenor" runat="server" Width="344px" Height="36px"></asp:label></TD>
													</TR>
													<TR>
														<TD width="20%"></TD>
														<TD></TD>
														<TD width="30%"></TD>
														<TD width="20%"></TD>
														<TD></TD>
														<TD width="30%"></TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD class="TDBGColor1" width="20%">Rekomendasi Produk (Berdasarkan Klasifikasi 
															Nasabah)</TD>
														<TD>:</TD>
														<TD class="TDBGColorValue" width="30%"><asp:label id="Label3" runat="server"></asp:label></TD>
														<TD class="TDBGColor1" width="20%">Catatan</TD>
														<TD>:</TD>
														<TD class="TDBGColorValue" width="30%"><asp:textbox id="TextBox1" runat="server" Width="344px" Height="71px"></asp:textbox></TD>
													</TR>
												</table>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</Table>
			<!-- SEPARATOR -->
			<table id="TBL_SAVE" width="100%" runat="server">
				<TR id="TR_BUTTONS" runat="server">
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SIMPANLAH" runat="server" Width="150px" CssClass="Button1" Text="S A V E" onclick="BTN_SIMPANLAH_Click"></asp:button><asp:label id="LBL_H_JNSNASABAH" runat="server" Visible="False"></asp:label><asp:label id="LBL_H_PROGRAMID" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
