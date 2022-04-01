<%@ Page language="c#" Codebehind="AppInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.AppInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AppInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fAppInfo" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="td" vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px">Nama Pemohon</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_nama" runat="server" Width="100%" Columns="30" MaxLength="100"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px; HEIGHT: 21px" vAlign="top">Alamat</td>
									<td style="WIDTH: 15px; HEIGHT: 21px"></td>
									<td class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox id="txt_addr" runat="server" Width="100%" MaxLength="200" TextMode="MultiLine" Rows="3"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px">Kota</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_city" runat="server" Width="100%" MaxLength="30"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px">Kodepos</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_zipcode" runat="server" Width="100%" MaxLength="6" onkeypress="return kutip_satu()"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px">No Telp</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_phnarea" runat="server" Width="40px" MaxLength="4"></asp:textbox><asp:textbox id="txt_phnnum" runat="server" Width="200px" MaxLength="10"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px">Bidang Usaha</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_jobarea" runat="server" Width="100%" MaxLength="50"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 106px">Tanggal Aplikasi</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_signdate" runat="server" MaxLength="20" Width="100%"></asp:textbox></td>
								</tr>
							</table>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_STA" runat="server" Visible="False"></asp:label>
						</td>
						<td class="td" vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" style="WIDTH: 136px" width="200">No. Aplikasi</td>
									<td width="15"></td>
									<td class="TDBGColorValue">
										<asp:textbox id="txt_regno" runat="server" MaxLength="20" Width="100%"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td class="TDBGColor1">No. Referensi</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_curef" runat="server" MaxLength="20" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">KC/KCP</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_branch" runat="server" MaxLength="50" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Supervisi</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_teamleader" runat="server" MaxLength="50" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Analis</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_relmngr" runat="server" MaxLength="50" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Petugas</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_analis" runat="server" MaxLength="50" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1">Segmen</td>
									<td></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_busunit" runat="server" MaxLength="50" Width="100%"></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
