<%@ Page language="c#" Codebehind="StructureCredit.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.StructureCredit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StructureCredit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdHeader1" Credit Structure</TD>
				</TR>
				<TR
					<TD colSpan="2" class="td">
                        <!-- 
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="tdbgcolor1">Ketentuan Kredit</TD>
											<TD>:</TD>
											<TD>
												<asp:DropDownList id="DDL_KETENTUAN_KREDIT" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_KETENTUAN_KREDIT_SelectedIndexChanged"></asp:DropDownList></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">AA No.</TD>
											<TD>:</TD>
											<TD>
												<asp:TextBox id="TXT_AA_NO" runat="server"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">No Rekening</TD>
											<TD>:</TD>
											<TD>
												<asp:TextBox id="TXT_ACC_NO" runat="server"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="tdbgcolor1">Facility Code</TD>
											<TD>:</TD>
											<TD>
												<asp:TextBox id="TXT_PRODUCTID" runat="server"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1">Seq</TD>
											<TD>:</TD>
											<TD>
												<asp:TextBox id="TXT_ACC_SEQ" runat="server"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" align="center" colspan="2"><asp:button id="BTN_SAVE_KREDIT" Runat="server" Text="Save Account Data" CssClass="button1" onclick="BTN_SAVE_KREDIT_Click"></asp:button></TD>
							</TR>
						</TABLE>
                        -->
                        <ASP:DATAGRID id="DataGrid1" runat="server" AutoGenerateColumns="False" 
                            Width="100%" CellPadding="1"
								AllowPaging="True" Visible="true" onitemcommand="DataGrid1_ItemCommand">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" DataField="KET_CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="UF_CPSEQ" HeaderText="Product Sequence">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Permohonan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tanggal Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" HeaderText="Nama RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="STATUS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											&nbsp;
											<asp:LinkButton id="BTN_GRID_VIEW" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>

					</TD>
				</TR>
				<TR>
					<td vAlign="top" width="100%">
						<asp:Table id="Table1" runat="server" ForeColor="Black" Width="100%" CellPadding="0" CellSpacing="0"
							BorderColor="White" BorderStyle="Dotted" BorderWidth="1px" GridLines="Both">
							<asp:TableRow>
								<asp:TableCell Width="2%"></asp:TableCell>
								<asp:TableCell Width="31%"></asp:TableCell>
								<asp:TableCell Width="2%"></asp:TableCell>
								<asp:TableCell Width="31%"></asp:TableCell>
								<asp:TableCell Width="2%"></asp:TableCell>
								<asp:TableCell Width="32%"></asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</td>
				</TR>
				<tr>
					<td width="100%">
					<iframe id="ProdDetail" name="ProdDetail" tabIndex="0" frameBorder="no" width="100%" height="600" scrolling="yes"></iframe>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
