<%@ Page language="c#" Codebehind="Jaminan_ListCBI.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.Jaminan_ListCBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Jaminan_List</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to Delete?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Table id="Table_List" runat="server" Width="100%" CellPadding="0" CellSpacing="0" CssClass="BackGroundList"></asp:Table>
			<table Width="100%" class="BackGroundList">
				<tr>
					<td vAlign="top" align="center">
						<asp:DropDownList ID="DDL_CL_TYPE" Runat="server"></asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td class="TDBGColor2" vAlign="top" align="center">
						<asp:Button CssClass="Button1" Text="Insert" runat="server" ID="BTN_SAVE" Width="70px" onclick="BTN_SAVE_Click"></asp:Button>
						<asp:Button CssClass="Button1" Text="Delete" runat="server" ID="BTN_DELETE" Width="70px" onclick="BTN_DELETE_Click"></asp:Button>
						<asp:TextBox ID="TXT_JML_JAMINAN" runat="server" Visible="False"></asp:TextBox>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
