<%@ Page language="c#" Codebehind="Assigment.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.Assigment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assigment</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
		<script language="javascript">
		function continueApproval(action)
		{			
			pesan = "Are you sure you want to " + action + " ? ";			
			conf = confirm(pesan);
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="WIDTH: 495px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assigment</B></TD>
								</TR>
							</TABLE>
						</td>
						<td class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2"><asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label><asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label><asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>Customer 
							Info
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label><asp:label id="lbl_userid" runat="server" Visible="False"></asp:label><asp:label id="lbl_eye" runat="server" Visible="False"></asp:label><asp:label id="mc" runat="server" Visible="False"></asp:label><asp:label id="lbl_aprvuntil" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><iframe id=if1 
      style="WIDTH: 100%; HEIGHT: 185px" name=if1 
      src="/SME/ITTP/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view" 
      scrolling=no> </iframe>
						</td>
					</tr>
				</table>
				<TR id="TR_INFO_CRM" runat="server">
					<TD vAlign="top" width="100%">
						<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">Assigment</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TABLE>
				<table id="Table3" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td vAlign="top"></td>
						<td align="right"><asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label><asp:label id="LBL_AP_REGNO" Visible="False" Runat="server"></asp:label><asp:label id="LBL_CU_REF" Visible="False" Runat="server"></asp:label><asp:label id="LBL_BS_COMPLETE" Visible="False" Runat="server"></asp:label><asp:label id="LBL_BS_BIASSIGN" Visible="False" Runat="server"></asp:label></td>
					</tr>
				</table>
				<TABLE id="Table5" cellSpacing="2" cellPadding="2" width="100%">
				</TABLE>
				<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
				</TABLE>
				<table id="Table7" cellSpacing="2" cellPadding="2" width="100%">
				</table>
				<table id="Table8" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td style="WIDTH: 910px; HEIGHT: 27px" vAlign="top">
							<TABLE id="Table10" style="WIDTH: 712px; HEIGHT: 30px" cellSpacing="1" cellPadding="1"
								width="712">
								<TR>
									<TD class="tdbgcolor1" style="WIDTH: 99px; HEIGHT: 17px">Petugas</TD>
									<TD style="WIDTH: 53px; HEIGHT: 17px"></TD>
									<TD style="HEIGHT: 17px"><asp:dropdownlist id="DDL_PETUGAS" runat="server" Width="352px"></asp:dropdownlist><asp:button id="BTN_ASSIGN" runat="server" Width="80px" Text="Assign" CssClass="Button1" onclick="BTN_ASSIGN_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<asp:label id="TXT_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="TXT_CU_REF" runat="server" Visible="False"></asp:label></td>
					</tr>
					<tr>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
