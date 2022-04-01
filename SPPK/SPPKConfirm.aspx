<%@ Page language="c#" Codebehind="SPPKConfirm.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.SPPKConfirm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SPPKConfirm</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_all.html" -->		
		<script language="vbscript">
			function CekTombol()
				set obj = document.fSppkConfirm
				if obj.chk_cancel.checked then
					obj.ddl_reason.disabled	= false					
					obj.btn_cancel.disabled = false					
				else
					obj.ddl_reason.disabled	= true					
					obj.btn_cancel.disabled = true					
				end if
			end function
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkConfirm" method="post" runat="server">
			<center>				
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td>
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SPPK Confirm</B></TD>
								</TR>
							</TABLE>
						</td>
						<td class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" vAlign="top" width="50%" colSpan="2">Informasi Pemohon
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
						
						<iframe id="if1" style="WIDTH: 100%; HEIGHT: 200px" name="if1" scrolling="no" src="appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&prod=<%=Request.QueryString["prod"]%>&sta=view"></iframe>
						
						</td>
					</tr>
				</table>
				<table id="tbl_acqinfo" runat="server" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
						
						<iframe id="if1" style="WIDTH: 100%; HEIGHT: 200px" name="if1" scrolling="no" src="../Approval/Acqinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&prod=<%=Request.QueryString["prod"]%>&sta=view"></iframe>
						
						</td>
					</tr>
				</table>
				<table id="Table3" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder></td>
					</tr>
				</table>
				<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><iframe id="if2" style="WIDTH: 998px; HEIGHT: 244px" name="if2" src="../dataentry/custproduct.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&prod=<%=Request.QueryString["prod"]%>&sta=view"></iframe></td>
					</tr>
				</table>
				<table id="Table5" cellSpacing="3" cellPadding="0" width="100%">
					<tr>
						<td>
							<asp:CheckBox ID="chk_cancel" Runat="server" Text="Cek untuk Pembatalan" 
                                onclick="CekTombol()"></asp:CheckBox>
						</td>
						<td>
							<asp:label ID="lbl_reason" Runat="server">Alasan</asp:label>&nbsp;&nbsp;&nbsp;
							<asp:DropDownList ID="ddl_reason" Runat="server" CssClass="mandatory"></asp:DropDownList>&nbsp;&nbsp;&nbsp;
							<asp:button ID="btn_cancel" Runat="server" Text="Batal" Enabled=False 
                                onclick="btn_cancel_Click"></asp:button>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
