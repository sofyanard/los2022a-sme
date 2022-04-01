<%@ Page language="c#" Codebehind="DocFasilitas.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.DocFasilitas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DocFasilitas</title>
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
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD vAlign="top"></TD>
						<TD vAlign="top"></TD>
						<TD vAlign="top">
							<asp:radiobuttonlist id="RBL_KETENTUAN" AutoPostBack="True" RepeatDirection="Horizontal" Runat="server"
								Height="24px"></asp:radiobuttonlist><asp:radiobuttonlist id="RBL_FASILITAS" Runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
								Height="24px"></asp:radiobuttonlist><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><input type="hidden" name="sta">
						</TD>
					</TR>
					<TR>
						<TD></TD>
						<TD class="td"></TD>
						<TD class="td">
							<asp:label id="Label1" Runat="server" CssClass="TDBGColor1" BorderWidth="1px">PRODUCT  : </asp:label>
							&nbsp;
							<asp:label id="LBL_PRODUCT" Runat="server"></asp:label>&nbsp;-
							<asp:label id="LBL_PRODUCTDESC" Runat="server"></asp:label></TD>
					</TR>
					<tr>
						<TD></TD>
						<TD></TD>
						<td><ASP:DATAGRID id="DGR_DF" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
								Width="950px">
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
											<asp:CheckBox ID="CHB_AT_FIX" Runat="server"></asp:CheckBox>
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
											<asp:TextBox ID="TXT_AT_RECEIVEDATEDAY" Runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
											<asp:DropDownList ID="DDL_AT_RECEIVEDATEMONTH" Runat="server"></asp:DropDownList>
											<asp:TextBox ID="TXT_AT_RECEIVEDATEYEAR" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="MANDATORY"></asp:BoundColumn>
									<asp:ButtonColumn Text="Delete"></asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="AT_RECEIVEDATE" HeaderText="tgl"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></td>
					</tr>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD style="WIDTH: 216px" align="right">Item</TD>
									<TD><asp:dropdownlist id="DDL_LIST2" runat="server" Width="352px"></asp:dropdownlist><asp:button id="Button1" runat="server" Text="Insert"></asp:button>
										<asp:label id="LBL_H_PROD_SEQ" Runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
