<%@ Page language="c#" Codebehind="arMiddleCommercial.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.arMiddleCommercial" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>arMiddleCommercial</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="1">
				<TR>
					<TD class="tdHeader1" width="100%" colSpan="3">
						<P>NOTE</P>
					</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3"><nobr>Ketentuan Kredit:
							<asp:dropdownlist id="ddl_AM_KETKREDIT" runat="server" Enabled="False">
								<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							</asp:dropdownlist>
<asp:Label id=lbl_PAR runat="server" Visible="False"></asp:Label></nobr></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">Catatan:</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<asp:TextBox id="txt_AM_NOTE" runat="server" MaxLength="1000" Width="100%" TextMode="MultiLine"
							Height="120px" onkeypress="return kutip_satu()"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" align="center" width="100%" colSpan="3">
						<asp:button id="btn_Save" runat="server" CssClass="Button1" Text="Simpan" 
                            onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:button id="btn_Delete" runat="server" CssClass="Button1" Text="Hapus" 
                            onclick="btn_Delete_Click"></asp:button></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
