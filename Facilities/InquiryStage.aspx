<%@ Page language="c#" Codebehind="InquiryStage.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.InquiryStage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InquiryStage</title>
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
						<TD class="tdNoBorder" width="421"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Inquiry Stage</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 4px" colSpan="2">
							<asp:Label id="Label1" runat="server" Font-Bold="True">Status :</asp:Label>&nbsp;&nbsp;&nbsp;
							<asp:DropDownList id="DDL_STATUS" runat="server"></asp:DropDownList>&nbsp;
							<asp:Button id="BTN_VIEW" runat="server" Text="View" Width="75px" CssClass="button1" onclick="BTN_VIEW_Click"></asp:Button></TD>
					</TR>
					<TR>
						<TD colSpan="2" vAlign="top">
							<p>
								<ASP:DATAGRID id="DatGrd" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%"
									CellPadding="1">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="Application No."></asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Application No.">
											<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LINK_VIEW" runat="server" CommandName="View"></asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn DataField="cu_ref" HeaderText="Ref No">
											<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Nama" HeaderText="Customer Name">
											<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Rm" HeaderText="Relation Manager">
											<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="AP_CURRTRACKDATE" HeaderText="Track Date">
											<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="trackBy" HeaderText="Track By">
											<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
									</Columns>
								</ASP:DATAGRID></p>
						</TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdH" colSpan="2">
							<asp:Label id="LBL_AMOUNT" runat="server" Font-Bold="True">Amount :</asp:Label>&nbsp;
							<asp:TextBox id="TXT_AMOUNT" runat="server" Width="40px" ReadOnly="True"></asp:TextBox></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
