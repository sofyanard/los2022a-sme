<%@ Page language="c#" Codebehind="MainProductList.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.MainProductList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>List Product</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout" bottomMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<asp:table id="Table1" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderStyle="Solid"
				GridLines="Both">
				<asp:TableRow VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="White" BackColor="MidnightBlue"
					Font-Bold="True">
					<asp:TableCell Text="Jenis Kredit" CssClass="tdSmallHeader" Width="30%"></asp:TableCell>
					<asp:TableCell Text="Jenis Pengajuan" CssClass="tdSmallHeader" Width="30%"></asp:TableCell>
					<asp:TableCell Text="" CssClass="tdSmallHeader" Width="15%"></asp:TableCell>
				</asp:TableRow>
			</asp:table>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD width="30%">&nbsp;
						<asp:DropDownList id="ddl_PRODUCTID" runat="server" Width="250px"></asp:DropDownList></TD>
					<TD width="30%">&nbsp;
						<asp:DropDownList id="ddl_APPTYPE" runat="server" Width="250px"></asp:DropDownList></TD>
					<TD width="15%">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" colspan="3">
						<asp:Button id="insert" runat="server" Text="Insert" onclick="insert_Click"></asp:Button>
						<asp:Button id="delete" runat="server" Text="Delete" onclick="delete_Click"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
