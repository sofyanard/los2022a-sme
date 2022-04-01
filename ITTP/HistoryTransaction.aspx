<%@ Page language="c#" Codebehind="HistoryTransaction.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.HistoryTransaction" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HistoryTransaction</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder" style="WIDTH: 867px">
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>NCL History Transaction</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Customer Info
								<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 970px" vAlign="top" width="970" colSpan="3">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px; HEIGHT: 17px">CIF Number</TD>
										<TD style="WIDTH: 15px; HEIGHT: 17px">:</TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 17px; BORDER-BOTTOM-STYLE: none"><asp:textbox id="TXT_CU_CIF" runat="server" Height="24px" BorderStyle="None" Width="352px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px; HEIGHT: 26px">Customer Name</TD>
										<TD style="WIDTH: 15px; HEIGHT: 26px">:</TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px; HEIGHT: 26px"><asp:textbox id="TXT_CU_NAME" runat="server" Height="24px" BorderStyle="None" Width="352px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px; HEIGHT: 24px">Birth / Establish Date</TD>
										<TD style="WIDTH: 15px; HEIGHT: 24px"></TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px; HEIGHT: 24px"><asp:textbox id="TXT_TGL_LAHIR" runat="server" Height="24px" BorderStyle="None" Width="352px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px; HEIGHT: 24px">NPWP</TD>
										<TD style="WIDTH: 15px; HEIGHT: 24px">:</TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px; HEIGHT: 24px"><asp:textbox id="TXT_NPWP" runat="server" Height="22px" BorderStyle="None" Width="352px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px">Address</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px">
											<P><asp:textbox id="TXT_ALAMAT1" runat="server" Height="22px" BorderStyle="None" Width="352px"></asp:textbox></P>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px"><asp:textbox id="TXT_ALAMAT2" runat="server" Height="22px" BorderStyle="None" Width="352px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 533px"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue" style="WIDTH: 357px"><asp:textbox id="TXT_ALAMAT3" runat="server" Height="22px" BorderStyle="None" Width="352px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2"></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Non Cash Loan Info</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="Datagrid1" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True" PageSize="5" HorizontalAlign="Center">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="AA_NO" HeaderText="AA No.">
											<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PRODUCTID" HeaderText="No. Fasilitas">
											<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ACC_SEQ" HeaderText="Sequence">
											<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LIMIT" HeaderText="Total Limit" DataFormatString="{0:0,00.00}">
											<HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CURRENCY" HeaderText="Currency">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TENOR" HeaderText="Tenor">
											<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:ButtonColumn Visible="False" Text="View" HeaderText="Function" CommandName="view">
											<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						<TR>
							<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Transaction Info</TD>
						</TR>
						<TR>
							<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_CIF" HeaderText="CIF No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
										<asp:BoundColumn DataField="PRODUCT_TYPE" HeaderText="Fac.">
											<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ACC_SEQ" HeaderText="Seq#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CURR" HeaderText="Curr">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LIMIT" HeaderText="Limit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="DATE_CHANGE" HeaderText="TRX Date">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="PRODUCT_TYPE" HeaderText="Product Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="AMOUNT_UTI" HeaderText="TRX Amount">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AMOUNT_UTI" HeaderText="O/S" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LIMIT" HeaderText="Nilai Agunan" Visible="False">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								</TABLE>
							</TD>
						</TR>
						<!-- pipeline -->
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
