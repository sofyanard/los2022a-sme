<%@ Page language="c#" Codebehind="DTBO.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.DTBO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DTBO</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="2"><B>DATA PEMOHON</B></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="165">Sub-Segment/Program</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Cabang/CBC/Group</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team Leader</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SU_FULLNAME" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Relationship Manager</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RELMNGR" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="165">Nama Pemohon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Business Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BU" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Application #</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" ReadOnly Columns="20"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<TD vAlign="top" align="center" colSpan="2"><asp:placeholder id="PLH_DTBO" Runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<iframe id="IFR_DTBO" name="IFR_DTBO" scrolling="auto" height="300" width="100%" border="0" 
							src="../../DTBO/DocUmum.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&tc=<%=Request.QueryString["tc"]%>&mc=<%=Request.QueryString["mc"]%>" ></iframe>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>
							<input class="button1" id="BTN_SAVE" onclick="simpan()" type="button" value="save">
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
			function simpan()
			{
				document.IFR_DTBO.document.Form1.sta.value = "save";
				document.IFR_DTBO.document.Form1.submit();
			}
		</script>
	</body>
</HTML>
