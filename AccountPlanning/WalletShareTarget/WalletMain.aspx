<%@ Page language="c#" Codebehind="WalletMain.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.WalletShareTarget.WalletMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>WalletMain</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" border="0" width="100%">
					<TR>
						<TD align="left">
							<TABLE id="Table3">
								<TR>
									<TD style="WIDTH: 400px" class="tdBGColor2" align="center"><B>UPLOAD DATA WALLET SIZE</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="100%" height="35">
					<tr>
						<TD align="center" width="50%">
							<ASP:DATAGRID id="DATA_TEMPLATE" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID_TEMPLATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TEMPLATE_NAME" HeaderText="SOURCE FILE" ItemStyle-Width="350px"
										ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID>
						</TD>
						<TD align="center" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT style="WIDTH: 344px; HEIGHT: 19px" id="TXT_FILE_UPLOAD" size="38" type="file" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" colSpan="3" align="center"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD colSpan="3" align="center"></TD>
								</TR>
							</table>
						</TD>
					</tr>
				</TABLE>
				<br>
			</center>
			<br>
			<center>
				<table class="td" border="1" cellSpacing="1" cellPadding="1" width="100%" height="35">
					<TR>
						<TD class="tdHeader1" colSpan="7" height="35">UPLOAD RESULT</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<ASP:DATAGRID id="DatagridWalletMain" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CIF_GROUP" HeaderText="CIF Group">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_CIF" HeaderText="CIF Company">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WHOLESALECATEGORY" HeaderText="Product Group">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WALLETSIZECATEGORY" HeaderText="Product Category">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WALLETSIZEPRODUCT" HeaderText="Sub Product">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURRENT_INCOME" HeaderText="Current Income">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="POTENTIAL_INCOME" HeaderText="Potential Income">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CURRENT_VOLUME" HeaderText="Current Volume">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="POTENTIAL_VOLUME" HeaderText="Potential Volume">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COMPANY_ANNUAL_REVENUE" HeaderText="Company Annual Revenue">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</BODY>
</HTML>
