<%@ Page language="c#" Codebehind="Perizinan.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DataEntry.Perizinan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Perizinan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function setMandatory() {
			nilai_1 = document.Form1.RDO_KEY_PERSON[0].checked;	// key person : YES
			nilai_2 = document.Form1.RDO_KEY_PERSON[1].checked;	// key person : NO

			if (nilai_1) {
				document.Form1.DDL_CS_EDUCATION.className = "mandatoryColl";
				document.Form1.TXT_CS_CHILDREN.className  = "mandatoryColl";
				document.Form1.TXT_CS_MULAIMENETAPMM.className  = "mandatoryColl";
				document.Form1.TXT_CS_MULAIMENETAPYY.className  = "mandatoryColl";
				document.Form1.DDL_CS_HOMESTA.className  = "mandatoryColl";
				document.Form1.DDL_CS_MARITAL.className  = "mandatoryColl";
			}			
			else {
				document.Form1.DDL_CS_EDUCATION.className = "";
				document.Form1.TXT_CS_CHILDREN.className  = "";
				document.Form1.TXT_CS_MULAIMENETAPMM.className  = "";
				document.Form1.TXT_CS_MULAIMENETAPYY.className  = "";
				document.Form1.DDL_CS_HOMESTA.className  = "";
				document.Form1.DDL_CS_MARITAL.className  = "";
			}
		}

		function setMandatory2() {
			nilai_1 = document.Form1.RDO_RFCUSTOMERTYPE[1].checked;		// Perorangan
			if (nilai_1) {
				document.Form1.DDL_CS_SEX.className = "mandatoryColl";
				document.Form1.DDL_CS_MARITAL.className = "mandatoryColl";
			}
			else {
				document.Form1.DDL_CS_SEX.className = "";
				document.Form1.DDL_CS_MARITAL.className = "";
			}
		}
		
		function checkChannFac() {
			// If user decide this facility as a Channeling-Facility, 
			// then follow this policy :
			// - Nomor rekening must be empty
			// - Bank Percentage must be empty
			// - Remaining eMAS limit must be empty
			// - Maturity Date is mandatory
			
			if (Form1.CHK_ISCHANNFACILITY.checked) 
			{
				Form1.TXT_AI_NOREK.value = "";				
				Form1.TXT_AI_NOREK.disabled = true;
			}
			else 
			{
				Form1.TXT_AI_NOREK.disabled = false;
			}
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="setMandatory2()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Perijinan</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="MenuPerizinan" runat="server"></asp:placeholder></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">List Dokumen</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDoc" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
							CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<ASP:BoundColumn DataField="SEQ" Visible="False"></ASP:BoundColumn>
								<asp:BoundColumn DataField="DOC_DESC" HeaderText="Jenis Dokumen">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOC#" HeaderText="Nomer Dokumen">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOC_DATE" HeaderText="Tgl. Dokumen">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOC_END" HeaderText="Tgl. Berakhir">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOC_FROM" HeaderText="Dikeluarkan Oleh">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="EDIT_DOC" runat="server" CommandName="edit_doc">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="DELETE_DOC" runat="server" CommandName="delete_doc">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID></TD>
					<asp:label id="TXT_SEQ" Visible="False" Runat="server"></asp:label></TR>
				<tr>
				</tr>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Jenis Dokumen</TD>
								<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_DOC" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Nomor Dokumen</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_DOC" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Dikeluarkan Oleh</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIKELUARKAN_OLEH" runat="server" Width="300px"
										MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl. Dokumen</TD>
								<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_DOC" runat="server" Width="24px" MaxLength="2"
										Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_DOC" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_DOC" runat="server" Width="36px" MaxLength="4"
										Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl. Berakhir 
									Dokumen</TD>
								<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLEXP_DOC" runat="server" Width="24px"
										MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLNEXP_DOC" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THNEXP_DOC" runat="server" Width="36px"
										MaxLength="4" Columns="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 262px" width="262">Notaris</TD>
								<TD style="WIDTH: 20px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NOTARIS" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" CssClass="button1" Text="Insert" onclick="BTN_INSERT_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Update" onclick="BTN_UPDATE_Click"></asp:button><asp:button id="BTN_CLEAR" runat="server" CssClass="button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
