<%@ Page language="c#" Codebehind="ListDataLoanCO.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.ListDataLoanCO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListDataLoanCO</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LOAN ASSIGNMENT &amp; 
											VALIDATION</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Umum</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">CIF No</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer&nbsp;Name</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_ACCTNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Account Officer</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACCT" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Data Owner Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Assignment</TD>
					</TR>
					<TR>
						<td vAlign="top" width="25%">
							<table cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td>
										<ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" AutoGenerateColumns="False" AllowPaging="True"
											Width="100%">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ACC_NO" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="STATUS_FLAG" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="STATUS_DESC" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="STATUS_IMG" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="BTN_TEXT" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="BTN_ENABLE" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="CURR_OFCR" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="DDL_ENABLE" Visible="False"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Status">
													<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_COLID" runat="server"></asp:HyperLink>
														<br>
														<asp:Image id="IMG_STA" runat="server"></asp:Image>
														<asp:Label id="LBL_STA" runat="server"></asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Assignment">
													<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:DropDownList id="DDL_OFCR" runat="server"></asp:DropDownList>
														<br>
														<asp:Button id="BTN_PROC" runat="server" Width="100px"></asp:Button>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID>
									</td>
								</tr>
							</table>
						</td>
						<td width="55%" vAlign="top"><iframe id="coldetail" name="coldetail" width="100%" height="580" frameborder="0"></iframe>
						</td>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
