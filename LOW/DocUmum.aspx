<%@ Page language="c#" Codebehind="DocUmum.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.DocUmum" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DocUmum</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 536px; HEIGHT: 50px"
					borderColor="gray" cellSpacing="1" cellPadding="1" width="100%" border="0">
				</TABLE>
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td><ASP:DATAGRID id="DGR_DU" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="DOCID"></asp:BoundColumn>
									<asp:BoundColumn DataField="DOCDESC" HeaderText="Item">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle Width="420px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AT_FIX"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Avail">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHB_AT_FIX" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AT_EXPDATE"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Expired Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox ID="TXT_AT_EXPDATEDAY" Runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
											<asp:DropDownList ID="DDL_AT_EXPDATEMONTH" Runat="server"></asp:DropDownList>
											<asp:TextBox ID="TXT_AT_EXPDATEYEAR" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AT_KETERANGAN"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox ID="TXT_AT_KETERANGAN" Runat="server" Columns="25" MaxLength="100" onKeypress="return kutip_satu()"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AT_RECEIVEDATE"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Received Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox onkeypress="return numbersonly()" id="TXT_AT_RECEIVEDATEDAY" Runat="server" MaxLength="2"
												Columns="2"></asp:TextBox>
											<asp:DropDownList id="DDL_AT_RECEIVEDATEMONTH" Runat="server"></asp:DropDownList>
											<asp:TextBox onkeypress="return numbersonly()" id="TXT_AT_RECEIVEDATEYEAR" Runat="server" MaxLength="4"
												Columns="4"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="MANDATORY"></asp:BoundColumn>
									<asp:ButtonColumn Text="Delete"></asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="AT_RECEIVEDATE" HeaderText="tgl"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID><asp:label id="LBL_REGNO" Visible="False" Runat="server"></asp:label><asp:label id="LBL_CUREF" Visible="False" Runat="server"></asp:label><asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label><input type="hidden" name="sta">
							<P align="center">&nbsp;</P>
						</td>
					</tr>
					<TR>
						<TD style="HEIGHT: 48px">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD style="WIDTH: 224px" align="right">Item</TD>
									<TD>
										<P align="left"><asp:dropdownlist id="DDL_NEWITEM" runat="server" Width="489px"></asp:dropdownlist><asp:button id="Button1" runat="server" Text="Insert"></asp:button></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center"></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
