<%@ Page language="c#" Codebehind="ApprovalPermohonan.aspx.cs" AutoEventWireup="True" Inherits="SME.BGSpan.Approval.ApprovalPermohonan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalPermohonan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
			cellPadding="1" width="100%" border="0">
			<TR>
				<TD>
					<TABLE id="Table3" style="WIDTH: 1196px; HEIGHT: 132px" cellSpacing="1" cellPadding="1"
						width="1196" border="0">
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 206px; HEIGHT: 22px"><FONT size="2">Amount</FONT></TD>
							<TD style="HEIGHT: 22px"><FONT size="2">:</FONT></TD>
							<TD style="HEIGHT: 22px"><asp:textbox id="TXT_CP_EXLIMITVAL" runat="server" CssClass="mandatory2" MaxLength="50" Width="288px"></asp:textbox><FONT size="2"></FONT></TD>
						</TR>
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 206px; HEIGHT: 22px"><FONT size="2">Tenor</FONT></TD>
							<TD style="HEIGHT: 22px"><FONT size="2">:</FONT></TD>
							<TD style="HEIGHT: 22px"><asp:textbox id="TXT_CP_JANGKAWKT" runat="server" CssClass="mandatory2" MaxLength="50" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory2"></asp:dropdownlist><FONT size="2"></FONT></TD>
						</TR>
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 206px; HEIGHT: 20px"><FONT size="2">Product</FONT></TD>
							<TD style="HEIGHT: 20px"><FONT size="2">:</FONT></TD>
							<TD style="HEIGHT: 20px"><FONT size="2"><asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" Width="296px"></asp:dropdownlist><asp:label id="LBL_PRODUCT_DESC" runat="server" Width="184px" Height="19px"></asp:label><asp:label id="LBL_APPTYPE_DESC" runat="server" Width="280px" Height="19px"></asp:label></FONT></TD>
						</TR>
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 206px; HEIGHT: 19px"><FONT size="2">Purpose Code</FONT></TD>
							<TD style="HEIGHT: 19px"><FONT size="2">:</FONT></TD>
							<TD style="HEIGHT: 19px"><FONT size="2"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory" Width="296px"></asp:dropdownlist></FONT></TD>
						</TR>
					</TABLE>
			<TR>
				<TD class="tdheader1" style="HEIGHT: 27px" colSpan="2">Override</TD>
			</TR>
			<TR>
				<TD>
					<TABLE id="Table3" style="WIDTH: 1196px; HEIGHT: 132px" cellSpacing="1" cellPadding="1"
						width="1196" border="0">
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 206px; HEIGHT: 44px"><FONT size="2">Override 
									Status</FONT></TD>
							<TD style="WIDTH: 20px; HEIGHT: 44px">:</TD>
							<TD style="HEIGHT: 44px"><asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory" Width="72px"></asp:dropdownlist><asp:label id="LBL_DECSTA" runat="server" Width="280px"></asp:label><asp:button id="btn_override" runat="server" CssClass="button1" Width="125px" Text="Override"></asp:button></TD>
						</TR>
						<TR>
							<TD class="TDBGColor1" style="WIDTH: 206px; HEIGHT: 20px"><FONT size="2">Override 
									Reason Facility</FONT></TD>
							<TD style="WIDTH: 20px; HEIGHT: 20px"><FONT size="2">:</FONT></TD>
							<TD style="HEIGHT: 20px"><FONT size="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" CssClass="mandatory"
										MaxLength="100" Width="196px" Height="50px" TextMode="MultiLine" Columns="100"></asp:textbox></FONT></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<asp:label id="Label8" runat="server" Visible="False"></asp:label><asp:label id="Label9" runat="server" Visible="False"></asp:label><asp:label id="Label10" runat="server" Visible="False"></asp:label></TD></TR></TABLE>
		</TBODY></FORM></SCRIPT>
	</body>
</HTML>
