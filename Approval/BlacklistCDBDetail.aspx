<%@ Page language="c#" Codebehind="BlacklistCDBDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.BlacklistCDBDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RejectCancelApplication</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="432" style="WIDTH: 432px; HEIGHT: 220px">
				<TR>
					<TD class="tdHeader1" colSpan="2">
						Blacklist Checking Detail&nbsp;
						<asp:label id="regno" Visible="False" Runat="server"></asp:label>
						<asp:label id="seq" Runat="server" Visible="False"></asp:label></TD>
				</TR>
				<tr>
				</tr>
				<TR>
					<TD vAlign="top" colSpan="2">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="440" border="0" style="WIDTH: 440px; HEIGHT: 157px">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Application No</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_ap_regno" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Seq</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_seq" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Exactmatch</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_EXACTMATCH_DESC" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Remark</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_REMARK" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Name</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_name" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">ID Type</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_idtype" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">ID Number</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_idNumber" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Source</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_source" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Address</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_Address1" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right"></TD>
								<TD style="WIDTH: 10px"></TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_Address2" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right"></TD>
								<TD style="WIDTH: 10px"></TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_Address3" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right"></TD>
								<TD style="WIDTH: 10px"></TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_Address4" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 107px" align="right">Start Date</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_STARTDATE" Runat="server"></asp:label></TD>
							</TR>
							<tr>
							</tr>
							<TR>
								<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7">&nbsp; <INPUT class="Button1" type="button" value="Close" onclick="javascript:window.close();"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
