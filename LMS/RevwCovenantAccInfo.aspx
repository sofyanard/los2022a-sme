<%@ Page language="c#" Codebehind="RevwCovenantAccInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.RevwCovenantAccInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RevwCovenantAccInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>REVIEW COVENANT</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">&nbsp;</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Account Information</TD>
						</TR>
						<TR>
							<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
									CellPadding="1">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="CU_REF" Visible="False"></asp:BoundColumn>
										<asp:BoundColumn DataField="LMS_REGNO" HeaderText="LMS App. No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LMS_RECVDATE" HeaderText="LMS App. Date." DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
										<asp:BoundColumn DataField="LINK" Visible="False"></asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
