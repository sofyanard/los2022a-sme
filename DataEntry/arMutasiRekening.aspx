<%@ Page language="c#" Codebehind="arMutasiRekening.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.arMutasiRekening" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Mutasi Rekening</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/child.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table border="1" width="100%">
				<tr>
					<td width="100%" colspan="7" class="tdHeader1">SALDO RATA-RATA DAN MUTASI REKENING 
						SELAMA 6 BULAN TERAKHIR (Rp. 000)</td>
				</tr>
				<tr>
					<td width="48" rowspan="2" class="tdSmallHeader" style="WIDTH: 48px">No.</td>
					<td width="23%" rowspan="2" class="tdSmallHeader">Bulan</td>
					<td width="156" rowspan="2" class="tdSmallHeader" style="WIDTH: 156px">Saldo 
						Rata-Rata</td>
					<td width="58%" colspan="4" class="tdSmallHeader">Mutasi</td>
				</tr>
				<tr>
					<td width="14%" class="tdSmallHeader">Debet</td>
					<td width="14%" class="tdSmallHeader">Frek</td>
					<td width="15%" class="tdSmallHeader">Kredit</td>
					<td width="15%" class="tdSmallHeader">Frek</td>
				</tr>
				<tr>
					<td align="center" width="48" style="WIDTH: 48px">1.</td>
					<td width="23%">
						<asp:TextBox id="TextBox1" runat="server" Width="100%"></asp:TextBox></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox7" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox17" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox25" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox33" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox41" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr class="TblAlternating">
					<td align="center" width="48" style="WIDTH: 48px">2.</td>
					<td width="23%">
						<asp:TextBox id="TextBox2" runat="server" Width="100%"></asp:TextBox></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox8" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox18" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox26" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox34" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox42" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center" width="48" style="WIDTH: 48px">3.</td>
					<td width="23%">
						<asp:TextBox id="TextBox3" runat="server" Width="100%"></asp:TextBox></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox9" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox19" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox27" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox35" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox43" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr class="TblAlternating">
					<td align="center" width="48" style="WIDTH: 48px">4.</td>
					<td width="23%">
						<asp:TextBox id="TextBox4" runat="server" Width="100%"></asp:TextBox></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox10" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox20" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox28" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox36" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox44" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center" width="48" style="WIDTH: 48px">5.</td>
					<td width="23%">
						<asp:TextBox id="TextBox5" runat="server" Width="100%"></asp:TextBox></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox11" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox21" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox29" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox37" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox45" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr class="TblAlternating">
					<td align="center" width="48" style="WIDTH: 48px">6.</td>
					<td width="23%">
						<asp:TextBox id="TextBox6" runat="server" Width="100%"></asp:TextBox></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox12" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox22" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox30" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox38" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox46" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr class="TDBGColor">
					<td width="28%" colspan="2"><STRONG>JUMLAH</STRONG></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox13" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox23" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox31" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox39" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox47" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr class="TDBGColor">
					<td width="28%" colspan="2"><STRONG>RATA-RATA</STRONG></td>
					<td width="160" style="WIDTH: 160px">
						<asp:TextBox id="TextBox14" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox24" runat="server" Width="100%"></asp:TextBox></td>
					<td width="14%">
						<asp:TextBox id="TextBox32" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox40" runat="server" Width="100%"></asp:TextBox></td>
					<td width="15%">
						<asp:TextBox id="TextBox48" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="28%" colspan="2"><STRONG>LIMIT KREDIT</STRONG></td>
					<td width="156" style="WIDTH: 156px">
						<asp:TextBox id="TextBox15" runat="server" Width="100%"></asp:TextBox></td>
					<td width="28%" colspan="2"><STRONG>%SALDO TERHADAP LIMIT</STRONG></td>
					<td width="15%" colSpan="2">
						<asp:TextBox id="TextBox16" runat="server" Width="100%"></asp:TextBox></td>
				</tr>
				<tr>
					<td width="100%" colspan="7"></td>
				</tr>
				<tr>
					<td width="100%" colspan="7" style="HEIGHT: 25px"><STRONG>Catatan:</STRONG></td>
				</tr>
				<tr>
					<td width="100%" colspan="7"><TEXTAREA style="WIDTH: 760px; HEIGHT: 58px" rows="3" cols="92">
						</TEXTAREA></td>
				</tr>
				<TR>
					<TD class="tdbgcolor2" width="100%" colSpan="7">
						<asp:Button id="BTN_SAVE" runat="server" Width="100px" Text="Save" CssClass="button1"></asp:Button><INPUT class="button1" style="WIDTH: 100px" type="button" value="Close" onclick="window.close()"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
