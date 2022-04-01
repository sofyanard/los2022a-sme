<%@ Page language="c#" Codebehind="ApprovalCondition.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprovalCondition" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalCondition</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="WIDTH: 495px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval</B></TD>
								</TR>
							</TABLE>
						</td>
						<td class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Informasi Pemohon</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td><asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_eye" runat="server" Visible="False"></asp:label>
							<asp:label id="mc" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_aprvcondby" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
					<TR id="TR_INFO_CRM" runat="server">
						<TD vAlign="top" width="100%">
							<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdheader1">Information acquired</TD>
								</TR>
								<TR>
									<TD>
										<asp:TextBox id="txt_acqinfo" Width="100%" Runat="server" ReadOnly="True" TextMode="MultiLine"
											Height="150"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
				<table id="Table3" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td vAlign="top">
							<asp:table id="tbl_prod" runat="server" CssClass="BackGroundList" CellSpacing="0" CellPadding="0"
								Width="100%"></asp:table>
						</td>
						<td align="right">
							<iframe id="if2" style="WIDTH: 800px; HEIGHT: 650px" name="if2" src="" scrolling="auto"
								frameborder="no"></iframe>
						</td>
					</tr>
				</table>
				<TABLE id="Table5" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" width="50%" colSpan="2">Limit Exposure</TD>
					</TR>
				</TABLE>
				<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="TDBGColor1" style="WIDTH: 135px" align="right">Limit Rp.</td>
						<td style="WIDTH: 12px">:</td>
						<td class="TDBGColor1" style="WIDTH: 122px"><asp:label id="lbl_limexp" Runat="server"></asp:label></td>
						<td style="WIDTH: 110px"></td>
						<td class="TDBGColor1" style="WIDTH: 136px">Apply Value Rp.</td>
						<td style="WIDTH: 12px">:</td>
						<td class="TDBGColor1" style="WIDTH: 112px" align="right"><asp:label id="lbl_reqlim" Runat="server"></asp:label></td>
						<td></td>
					</tr>
				</TABLE>
				<table id="Table8" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" style="WIDTH: 910px" width="910"><b>Remark</b></td>
					</tr>
					<tr>
						<td style="WIDTH: 910px; HEIGHT: 76px" vAlign="top">
							<P><asp:textbox onkeypress="return kutip_satu()" id="txt_remark" Width="991px" Runat="server" Height="97px"
									TextMode="MultiLine"></asp:textbox></P>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" style="WIDTH: 910px; HEIGHT: 14px" vAlign="top">Check for 
							Approve
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 910px; HEIGHT: 27px" vAlign="top"><asp:checkboxlist id="cbl_prod" Width="278px" Runat="server" Height="12px"></asp:checkboxlist><asp:checkboxlist id="cbl_prodrej" Width="936px" Runat="server" Height="12px"></asp:checkboxlist></td>
					</tr>
					<tr>
						<td class="tdHeader1" style="WIDTH: 910px" vAlign="top"><STRONG>Decision</STRONG></td>
					</tr>
					<tr>
					</tr>
				</table>
				<table>
					<tr id="tr_approve" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:label id="lbl_aprvwith" Runat="server">Approve With</asp:label></td>
						<td style="WIDTH: 387px" vAlign="top"><asp:dropdownlist id="ddl_aprvwith" Runat="server"></asp:dropdownlist></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_aprvrej" CssClass="button1" Width="155px" Runat="server" Text="Approve" onclick="btn_aprvrej_Click"></asp:button>&nbsp;
							<STRONG>&gt;&gt;Routing : </STRONG>
							<asp:Label id="LBL_APRV_ROUTING" runat="server" ForeColor="Blue" Font-Bold="True"></asp:Label>
							<asp:textbox id="TXT_VERIFY" runat="server" Width="1px" ReadOnly="True" BorderStyle="None" ontextchanged="TXT_VERIFY_TextChanged"></asp:textbox>
						</td>
					</tr>
					<tr align="center">
						<td colSpan="3">
							<asp:button id="btn_backtover" CssClass="button1" Runat="server" Text="Acquire Information"></asp:button>
							<asp:button id="btn_decision" CssClass="button1" Runat="server" Text="Decisions History"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" Width="1px" ReadOnly="True"></asp:textbox>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
