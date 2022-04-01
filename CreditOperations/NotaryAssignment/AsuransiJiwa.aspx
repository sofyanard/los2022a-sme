<%@ Page language="c#" Codebehind="AsuransiJiwa.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.NotaryAssignment.AsuransiJiwa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AsuransiJiwa</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
		<!-- #include file="../../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Notary Assignment : Life 
											Insurance Assignment</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Asuransi Jiwa
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></td>
					</tr>
					<tr>
						<td colSpan="2"><asp:datagrid id="DataGrid1" runat="server" CellPadding="1" Width="100%" AutoGenerateColumns="False"
								PageSize="3" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRCOMPDESC" HeaderText="Nama Perusahaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRTYPEDESC" HeaderText="Insurance Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_POLICYNO" HeaderText="No Polis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_CUR" HeaderText="Mata Uang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_VALUE" HeaderText="Nilai Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATESTART" HeaderText="Tanggal Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATEEND" HeaderText="Tanggal Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_PERCENTAGE" HeaderText="% Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_PREMI" HeaderText="Premi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IC_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IT_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CUR_ID"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="BTNEDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNDEL" runat="server" CommandName="delete">Delete</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNLNK_PRINT" runat="server" CommandName="print">Print</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Perusahaan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_INSRCOMP" Runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_AP_INSRCOMP_SelectedIndexChanged"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Rate</td>
												<td></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_ICRATE" Runat="server"></asp:dropdownlist></td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Jenis Asuransi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_INSRTYPE" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Polis</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_POLICYNO" Runat="server" Columns="25"
														MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Mata Uang</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_CUR" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</td>
									<TD class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_INSRAMNT" Runat="server" Columns="25"
														onblur="FormatCurrency(this)" CssClass="mandatory" MaxLength="20"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal mulai</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_DAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_DATESTART_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_YEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal akhir</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_DAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_DATEEND_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_YEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">% Pertanggungan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_INSRPCT" Runat="server" Columns="4"
														CssClass="angkamandatory" MaxLength="4"></asp:textbox>%</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Premi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_INSRPREMI" Runat="server" MaxLength="20"
														onblur="FormatCurrency(this)" ColumnsCssClass="angka" CssClass="mandatory"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
								<TR>
									<TD class="td" align="center" colSpan="2"><asp:button id="BTN_TAMBAH" runat="server" Text="Tambah" onclick="BTN_TAMBAH_Click"></asp:button>
										<asp:label id="LBL_H_SEQ" Runat="server" Visible="False">0</asp:label>
										<asp:button id="BTN_CANCEL" runat="server" Visible="False" Text="Cancel"></asp:button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
