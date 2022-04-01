<%@ Page language="c#" Codebehind="HistoricalLoanList.aspx.cs" AutoEventWireup="True" Inherits="SME.HistoricalLoanInfo.HistoricalLoanList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HistoricalLoanList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" width="421">
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Historical Loan Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
                            <A href="ListCustomer.aspx?si="></A>
							    <asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg">
                                </asp:ImageButton>
                            <A href="../Body.aspx">
                                <IMG src="../Image/MainMenu.jpg">
                            </A>
                            <A href="../Logout.aspx" target="_top">
                                <IMG src="../Image/Logout.jpg">
                            </A>
                        </TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 4px" colSpan="2">
							<TABLE id="Table1">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 110px">Application #</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD>
										<asp:textbox onkeypress="return kutip_satu()" id="txt_regno" runat="server" Width="176px" Columns="30"
											MaxLength="20"></asp:textbox></TD>
									<TD style="WIDTH: 5px"></TD>
									<TD>
										<asp:button id="btn_cari" runat="server" Text="F i n d"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2" vAlign="top">
							<p>
								<ASP:DATAGRID id="DGR_LOANLIST" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%"
									CellPadding="1">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="cu_ref" HeaderText="Ref No">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Nama" HeaderText="Customer Name">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Rm" HeaderText="Relation Manager">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PROGRAMDESC" HeaderText="Program">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="APPROVE_AMT" HeaderText="Approved Limit" DataFormatString="{0:00,00.00}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="STATUS" HeaderText="Status">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LOC" HeaderText="Location">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">View</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</ASP:DATAGRID></p>
						</TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdH" colSpan="2">
							<asp:Label id="LBL_AMOUNT" runat="server" Font-Bold="True">Amount :</asp:Label>&nbsp;
							<asp:TextBox id="TXT_AMOUNT" runat="server" Width="80px" ReadOnly="True" BackColor="Gainsboro"></asp:TextBox>
							<asp:Label id="LBL_CUREF" runat="server" Visible="False"></asp:Label>
							<asp:placeholder id="Menu" runat="server" Visible="False"></asp:placeholder></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
