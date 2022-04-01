<%@ Register TagPrefix="uc1" TagName="DocExport" Src="CommonForm/DocExport.ascx" %>
<%@ Page language="c#" Codebehind="InputBIReq.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.InputBIReq" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InputBIReq</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<!-- <form id="Fmain" name="Fmain" action="SearchCustomer.aspx?mc=030" method="post" target="main">
		</form> -->
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>INPUT BI REQUEST</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<td colspan="2">
							<table>
								<tr>
									<td class="TDBGColor1" width="130">IDI BI Request # :</td>
									<td align="right"><asp:textbox id="TXT_IDI_REQ" Height="28px" Runat="server" Width="222px" ReadOnly="True"></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">CUSTOMER DATA</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">Request Date 
										:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DAY_REQ" runat="server" Width="24px" CssClass="mandatory"
											MaxLength="2" Columns="4" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_BLN_REQ" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_REQ" runat="server" Width="36px" CssClass="mandatory"
											MaxLength="4" Columns="4" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">Last Checking 
										Date :</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DAY_CHECK" runat="server" Width="24px"
											MaxLength="2" Columns="4" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_BLN_CHECK" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_CHECK" runat="server" Width="36px"
											MaxLength="4" Columns="4" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">No&nbsp;Surat :
									</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_SURAT" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">DIN :
									</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIN" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 21px">NPWP :</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NPWP" runat="server" Width="300px" MaxLength="200"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 17px">Nama Debitur :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA_DEBITUR" runat="server" Width="300px"
											MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 17px">No KTP/Akte Pendirian :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_KTP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 17px">
										Tempat Lahir/Pendirian :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BORN_PLACE" runat="server" Width="300px"
											MaxLength="50"></asp:textbox></TD>
								</tr>
								<!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 18px">Tgl. Lahir/ Tgl. 
										Pendirian :</TD>
									<TD style="HEIGHT: 18px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAHIR" runat="server" MaxLength="2"
											Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAHIR" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAHIR" runat="server" MaxLength="4"
											Columns="4" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">Kode Pos :</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPZIPCODE" runat="server" AutoPostBack="True"
											MaxLength="6" Columns="6"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 17px">Dati II :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_DATI2" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">Alamat Debitur :</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_ALAMAT" runat="server" Width="300px" MaxLength="300"
												TextMode="MultiLine"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">Kebutuhan Permintaan :</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_PERMINTAAN" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
											Width="200px">
											<asp:ListItem Value="1" Selected="True">Bank Pelopor</asp:ListItem>
											<asp:ListItem Value="0">Debitur</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 17px">Tujuan Permintaan IDI :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_IDI_TUJUAN" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 17px">CO Unit :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_CO" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 17px">Status APP :</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_STATUS_APP" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" id="TR_B" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="75px" CssClass="button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="85px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;<asp:button id="BTN_UPDATE" runat="server" Width="144px" CssClass="button1" Text="UPDATE STATUS" onclick="BTN_UPDATE_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
					</TR>
				</TABLE>
				</TD></TR></TABLE>
			</center>
		</form>
	</body>
</HTML>
