<%@ Page language="c#" Codebehind="DetailLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.DisbursementWorksheet.NotaryAssignment.DetailLegalSigning_Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailLegalSigning_Data</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to update?");
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Worksheet</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Info Pemohon</td>
					</tr>
					<tr>
						<td colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Application No.</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" Runat="server" ReadOnly Columns="35"></asp:textbox><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Reference No.</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Sub-Segment/Program</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Team Leader</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Relationship Manager</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Business Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" vAlign="top">Alamat</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Runat="server" ReadOnly Columns="35"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR2" Runat="server" ReadOnly Columns="35"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR3" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Runat="server" ReadOnly Columns="35"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">Asuransi Jiwa</td>
					</tr>
					<tr>
						<td colSpan="2"><asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" PageSize="3" AutoGenerateColumns="False"
								Width="100%" CellPadding="1">
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
									<asp:TemplateColumn Visible="False" HeaderText="Function">
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
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
