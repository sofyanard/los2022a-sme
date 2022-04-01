<%@ Page language="c#" Codebehind="Assignment.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.Assignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assignment</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table4">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="FindCustomer.aspx?mc=060"><img src="../Image/back.jpg"></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%">Assign Application</TD>
					<TD class="tdHeader1">Assign Customer</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Application No</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_AP_REGNO" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_AP_REGNO_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="129">Unit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_BRANCH_NAME" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="129">Current Track</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_TRACK" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Current AO</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_CUR_RM" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							<TR>
								<TD class="TDBGColor1">Current CO</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_CUR_CO" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Current CR</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_CUR_CA" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Current PS Verification</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_PRRK" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Current PIC</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_AP_APRVCOMMITEE" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: AO</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_AP_RM" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: CCO Branch</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_AP_CCOBRANCH" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: CO</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_AP_CO" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: CR</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_AP_CA" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: PS Verification</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_PRRK" runat="server" Enabled="False"></asp:dropdownlist>
									<asp:Label id="Label1" runat="server" Visible="False"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: PIC</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_AP_APRVCOMMITEE" runat="server"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Nama</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_FULLNAME" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Unit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_CU_BRANCHNAME" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Current RM</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox id="TXT_CU_RM" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: Branch</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_BRANCH_CODE" runat="server" AutoPostBack="True" CssClass="mandatory2" onselectedindexchanged="DDL_BRANCH_CODE_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Assign To: User</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue">
									<asp:dropdownlist id="DDL_USERID" runat="server"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" align="center" width="50%">
						<asp:button id="Button2" runat="server" Width="125px" Text="Assign" CssClass="button1" onclick="Button2_Click"></asp:button></TD>
					<TD class="td" vAlign="top" align="center">
						<asp:button id="Button1" runat="server" Width="125px" Text="Assign" CssClass="button1" onclick="Button1_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
