<%@ Page language="c#" Codebehind="CustProductColl.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.CustProductColl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustProductColl</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center" colSpan="1"><BR>
							<ASP:DATAGRID id="DGR_COLL1" runat="server" Width="90%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True" HorizontalAlign="Center">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
									<asp:BoundColumn DataField="cl_desc" HeaderText="Collateral Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="coltypedesc" HeaderText="Collateral Type">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="lc_percentage" HeaderText="% of Use">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cl_value" HeaderText="Start Nomial">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="lc_value" HeaderText="End Nominal">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACTION" HeaderText="Action">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Visible="False" Text="Delete" HeaderText="Function" CommandName="Delete">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<td align="center" colSpan="2">
							<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<td align="center" colSpan="5">
										<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td><ASP:DATAGRID id="DGR_COLL2" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
														AllowPaging="True" HorizontalAlign="Center" PageSize="5">
														<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
														<Columns>
															<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
															<asp:BoundColumn DataField="CL_DESC" HeaderText="Collateral Description">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Collateral Type">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LC_CURRENCY" HeaderText="Curr. Coll.">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LC_AMOUNT" HeaderText="Amount">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LC_PERCENTAGE" HeaderText="% of Use">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LC_PLEDGE" HeaderText="Pledge Amount">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LC_EXCHANGERATE" HeaderText="Ex. Rate">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LC_VALUE" HeaderText="End Nominal">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
																<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:ButtonColumn>
														</Columns>
														<PagerStyle Mode="NumericPages"></PagerStyle>
													</ASP:DATAGRID>
												</td>
											</tr>
										</table>
									</td>
								</TR>
								<%if (Request.QueryString["de"] == "1") {%>
								<tr>
									<td style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #ff0066" align="center">
										Masukkan kembali seluruh Collateral yang terkait dengan fasilitas tersebut
									</td>
								</tr>
								<TR>
									<TD align="left">
										<table id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<tr align="center">
												<TD width="20%"><asp:dropdownlist id="DDL_CL_ID" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CL_ID_SelectedIndexChanged"></asp:dropdownlist></TD>
												<TD><asp:textbox id="TXT_CL_DESC" runat="server" ReadOnly="True"></asp:textbox></TD>
												<TD width="10%">
													<asp:dropdownlist id="DDL_COLLCURRENCY" runat="server" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
												<TD width="10%">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_COLLAMOUNT" runat="server" CssClass="angka"
														onblur="FormatCurrency(this)" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
												<TD width="15%">
													<asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" Width="48px"
														onblur="FormatCurrency(this)" CssClass="angka"></asp:textbox></TD>
												<TD width="15%">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_COLLPLEDGE" runat="server" CssClass="angka"
														onblur="FormatCurrency(this)"></asp:textbox></TD>
												<TD width="15%">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_COLLEXRATE" runat="server" Width="48px"
														onblur="FormatCurrency(this)" CssClass="angka"></asp:textbox></TD>
												<TD width="15%"><asp:textbox id="TXT_ENDVALUE" runat="server" ReadOnly="True" CssClass="angka" BackColor="Gainsboro"></asp:textbox></TD>
												<TD width="15%"><asp:button id="calc" runat="server" Text="hitung" onclick="calc_Click"></asp:button><BR>
													<asp:button id="insert" runat="server" Text="insert" onclick="insert_Click"></asp:button></TD>
											</tr>
										</table>
									</TD>
								</TR>
								<% } %>
							</table>
		</form>
		</TD></TR>
		<TR>
			<TD align="center" colSpan="2">
				<asp:Label id="LBL_REGNO" runat="server" Visible="False"></asp:Label>
				<asp:Label id="LBL_CUREF" runat="server" Visible="False"></asp:Label>
				<asp:Label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:Label>
				<asp:Label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:Label>
				<asp:Label id="LBL_APPTYPE" runat="server" Visible="False"></asp:Label>
				<asp:Label id="LBL_KET_CODE" runat="server" Visible="False"></asp:Label></TD>
		</TR>
		</TBODY></TABLE>
	</body>
</HTML>
