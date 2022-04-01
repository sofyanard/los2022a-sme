<%@ Page language="c#" Codebehind="CustomerData.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.CustomerBasicInformation.CustomerData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CustomerData</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function SearchSektorEkonomi(bifrm, biobj, biurl)
			{	
				Urlnya = biurl + "../CustomerBasicInformation/SearchSektorEkonomi.aspx" + "?bifrm=" + bifrm + "&biobj=" + biobj;
				window.open(Urlnya,"SearchSektorEkonomi","status=no,scrollbars=no,width=800,height=600")
			}
		</script>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CUSTOMER DATA</B></TD>
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAMA_DEBIT" runat="server">Nama Debitur :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_DEBIT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_KANPUS" runat="server">Alamat Kantor Pusat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_KANPUS" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_PABRIK" runat="server">Alamat Pabrik :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_PABRIK" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_WAKIL" runat="server">Alamat Perwakilan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_WAKIL" runat="server" Width="100%" TextMode="MultiLine" Height="40px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NPWP" runat="server">No.NPWP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NPWP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_OPERATE" runat="server">Beroperasi Sejak :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OPERATE_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_OPERATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_OPERATE_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BIDANG_USAHA" runat="server">Bidang Usaha :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BIDANG_USAHA" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_GROUP_USAHA" runat="server">Group Usaha :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_GROUP_USAHA" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SECTOR1" runat="server">Sektor Ekonomi BI 1 :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_SECTOR1" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_SECTOR1_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SECTOR2" runat="server">Sektor Ekonomi BI 2 :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_SECTOR2" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_SECTOR2_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SECTOR3" runat="server">Sektor Ekonomi BI 3 :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_SECTOR3" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_SECTOR3_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SECTOR4" runat="server">Sektor Ekonomi BI 4 :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_SECTOR4" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="Label1" runat="server">:</asp:label></TD>
									<TD class="TDBGColorValue" align="left" colSpan="2">
										<INPUT id="BTN_SEARCHSE" onclick="SearchSektorEkonomi('Form1','TXT_TEMPBI', '')" type="button"
											value="Search Sektor Ekonomi" name="BTN_SEARCHSE">&nbsp;
										<asp:textbox id="TXT_TEMPBI" runat="server" Width="1px" BorderStyle="None" ReadOnly="True" ontextchanged="TXT_TEMPBI_TextChanged"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KEY_PERSON" runat="server">Key Person :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KEY_PERSON" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_SIUP" runat="server">No.SIUP/TDP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_SIUP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SAVE" runat="server" CssClass="button1" Width="100px" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" CssClass="button1" Width="100px" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
