<%@ Page language="c#" Codebehind="GeneralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.PerjanjianKredit.GeneralInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>GeneralInfo</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GENERAL INFO</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">CUSTOMER INFO</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">No.CIF :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAMA_DEBIT" runat="server">Nama Debitur :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_DEBIT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_KANPUS" runat="server">Alamat Kantor Pusat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_KANPUS" runat="server" Width="100%" Height="40px" TextMode="MultiLine"
											Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_PABRIK" runat="server">Alamat Pabrik :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_PABRIK" runat="server" Width="100%" Height="40px" TextMode="MultiLine"
											Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_WAKIL" runat="server">Alamat Perwakilan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_WAKIL" runat="server" Width="100%" Height="40px" TextMode="MultiLine"
											Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_USAHA" runat="server">Group Usaha :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_GROUP_USAHA" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OPERATE" runat="server">Beroperasi Sejak :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OPERATE" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SECTOR4" runat="server">Sektor Ekonomi BI 4 :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_SECTOR4" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KEY_PERSON" runat="server">Key Person :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KEY_PERSON" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NPWP" runat="server">No.NPWP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NPWP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_SIUP" runat="server">No.SIUP/TDP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_SIUP" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_RM_NAME" runat="server">AM Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_RM_NAME" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
