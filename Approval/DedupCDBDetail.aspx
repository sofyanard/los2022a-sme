<%@ Page language="c#" Codebehind="DedupCDBDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.DedupCDBDetail" %>
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
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="560" style="WIDTH: 560px; HEIGHT: 552px">
				<TR>
					<TD class="tdHeader1" colSpan="2">
						Duplicate Checking Detail&nbsp;
						<asp:label id="regno" Visible="False" Runat="server"></asp:label>
						<asp:label id="regno_CDB" Runat="server" Visible="False"></asp:label>
						<asp:label id="seq" Runat="server" Visible="False"></asp:label></TD>
				</TR>
				<tr>
				</tr>
				<TR>
					<TD vAlign="top" colSpan="2">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="552" border="0" style="WIDTH: 552px; HEIGHT: 500px">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Application No</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_ap_regno" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Application No. CDB</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_ap_Regno_cdb" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Seq</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_seq" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Cust Reff</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_cu_ref" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Cust CIF</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_cu_cif" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Exactmatch</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_EXACTMATCH_DESC" Runat="server" Width="432px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Remark</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue" style="WIDTH: 300px">
									<asp:label id="lbl_REMARK" Runat="server" Width="432px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Name</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_name" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Borndate</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_cu_borndate" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Sex</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_sex" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">ID Type</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_idtype" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">ID Number</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_idNumber" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Mother Name</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_cu_mothername" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Address</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_cu_Address" Runat="server" Width="424px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">BUC</TD>
								<TD style="WIDTH: 10px"></TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_modulename" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Receive Date</TD>
								<TD style="WIDTH: 10px"></TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_ap_recvdate" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Product</TD>
								<TD style="WIDTH: 10px"></TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_ap_product" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Amount</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_ap_amount" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Tenor</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_ap_tenor" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Interest</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_ap_interest" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Installment</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_ap_installment" Runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 97px" align="right">Status</TD>
								<TD style="WIDTH: 10px">:</TD>
								<TD class="TDBGColorValue">
									<asp:label id="lbl_status" Runat="server"></asp:label></TD>
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
