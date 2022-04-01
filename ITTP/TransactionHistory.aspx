<%@ Page language="c#" Codebehind="TransactionHistory.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.TransactionHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TransactionHistory</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
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
							<TD class="tdNoBorder">
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
												General Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<!--					
					<TR>
						<TD align="center" colSpan="2">
							<asp:LinkButton id="LNK_KETENTUAN230" runat="server" Font-Bold="True">Ketentuan 230</asp:LinkButton></TD>
					</TR>
					-->
						<TR>
							<TD class="tdHeader1" colSpan="2">Customer Info
								<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
								<asp:label id="lbl_cucif" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<tr>
							<td align="center" colSpan="2"><iframe id=if1 
							style="WIDTH: 100%; HEIGHT: 185px" name=if1 
							src="/SME/ITTP/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" 
							scrolling=no> </iframe>
							</td>
						</tr>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2"></TD>
						</TR>
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
								<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="80%" border="0">
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								</TABLE>
							</TD>
						</TR>
						<!-- pipeline -->
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save" Visible="False"></asp:button>
								<asp:label id="txt_CU_REF" runat="server" Visible="False"></asp:label></TD>
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
