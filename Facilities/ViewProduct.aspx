<%@ Page language="c#" Codebehind="ViewProduct.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.ViewProduct" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewProduct</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="TDBGColor1" width="40%">Application #</td>
						<td width="5%"></td>
						<td class="TDBGColorValue" width="55%">
							<asp:Label id="LBL_AP_REGNO" runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td class="TDBGColor1" width="40%">Track</td>
						<td></td>
						<td class="TDBGColorValue">
							<asp:Label id="LBL_TRACKNAME" runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td colSpan="3" height="4"></td>
					</tr>
					<tr>
						<td colSpan="3">
							<asp:DataGrid id="DatGrid" runat="server" Width="100%" AutoGenerateColumns="False">
								<Columns>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Product">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:DataGrid></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
