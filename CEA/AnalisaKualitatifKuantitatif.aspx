<%@ Page language="c#" Codebehind="AnalisaKualitatifKuantitatif.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.AnalisaKualitatifKuantitatif" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AnalisaKualitatifKuantitatif</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<tr>
						<td>
							<table>
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Analisa Kualitatif &amp; 
											Kuantitatif</B></TD>
								</TR>
							</table>
						</td>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE>
				<table width="100%">
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><FONT size="2"><STRONG>1. 
									Aspek Penilaian Kuantitatif</STRONG></FONT>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAN" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="QUANTITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SUBQUANTITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn DataField="QUANTITATIVEDESC" HeaderText="Quantitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SUBQUANTITATIVEDESC" HeaderText="Sub Quantitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Sub Sub Quantitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_SUBSUBQUAN" runat="server" RepeatDirection="Vertical"></asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="nilai" HeaderText="Score" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="rfrekanantype"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><asp:label id="LBL_RFREKANANTYPE" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUANR" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="False"
								Width="100%" Visible="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="false" DataField="SUM"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">TOTAL PENILAIAN KUANTITAITF&nbsp;:<asp:textbox id="TXT_TOTAL_QUAN" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
				</table>
				<table width="100%">
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">2. 
									Aspek Penilaian Kualitatif</FONT></STRONG>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%" PageSize="12" DESIGNTIMEDRAGDROP="466">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField=""></asp:BoundColumn>
									<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Qualitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Sub Qualitative">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_SUBQUAL" runat="server" RepeatDirection="Vertical"></asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SCORE" Visible="False" HeaderText="Score">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="rfrekanantype"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QUALR" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="False"
								Width="100%" Visible="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SUM"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">TOTAL PENILAIAN KUALITATIF&nbsp;:<asp:textbox id="TXT_TOTAL_QUAL" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 675px" vAlign="top" width="675"><STRONG><FONT size="2">3. 
									Kriteria Tambahan</FONT></STRONG>
						</TD>
					</TR>
					<tr width="100%">
						<td colSpan="2"><ASP:DATAGRID id="DGR_CLA" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%" PageSize="12">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CRITEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField=""></asp:BoundColumn>
									<asp:BoundColumn DataField="CRITEDESC" HeaderText="Kriteria Tambahan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Klasifikasi A">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_CLA" runat="server" RepeatDirection="Vertical"></asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="" HeaderText="Nilai" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="rfrekanantype"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></td>
						</TD></tr>
					<TR>
						<TD class="TDBGColor1">TOTAL&nbsp;:<asp:textbox id="TOTAL_SCORING" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Penetapan Klasifikasi&nbsp;:<asp:textbox id="KLASIFIKASI" runat="server" Width="320px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_PRINT" runat="server" CssClass="Button1" Text="Print" onclick="BTN_PRINT_Click"></asp:button></td>
					</tr>
					<tr width="100%">
						<td colSpan="2"><ASP:DATAGRID id="DGR_SCORE" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%" PageSize="12" visible="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="regnum"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="rfrekanantype"></asp:BoundColumn>
									<asp:BoundColumn DataField="sc_kuantitatif" HeaderText="Kriteria Tambahan">
										<HeaderStyle CssClass="sc_kualitatif"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="total" HeaderText="Nilai" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="klasifikasi"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></td>
						</TD></tr>
					<TR>
					</TR>
				</table>
			</center>
		</form>
		</TD></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
