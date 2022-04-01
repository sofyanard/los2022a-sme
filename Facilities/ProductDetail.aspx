<%@ Page language="c#" Codebehind="ProductDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.Maintenance.Parameters.General.ProductDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RFProduct</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center">
										<B>Product Detail</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton>
							<A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A> <A href="/SME/Logout.aspx" target="_top">
								<IMG src="/SME/Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Produt Detail</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Product Code</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_PRODUCTID" runat="server" Width="228px">PRODUCTID</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">LOS Product Name</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_PRODUCTDESC" runat="server" Width="228px">PRODUCTDESC</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">SIBS Product Code</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_SIBS_PRODCODE" runat="server">SIBS_PRODCODE</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px">SIBS Facility Code</TD>
									<TD style="HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px">
										<asp:Label id="LBL_SIBS_PRODID" runat="server">SIBS_PRODID</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Currency</TD>
									<TD style="HEIGHT: 19px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px">
										<asp:Label id="LBL_CURRENCY" runat="server">CURRENCY</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Currency Description</TD>
									<TD style="HEIGHT: 19px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px">
										<asp:Label id="LBL_CURRENCYDESC" runat="server">CURRENCYDESC</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Interest Rest</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_INTERESTREST" runat="server">INTERESTREST</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:radiobuttonlist id="RDO_ISCASHLOAN" runat="server" RepeatDirection="Horizontal" Enabled="False">
											<asp:ListItem Value="1" Selected="True">Cash Loan</asp:ListItem>
											<asp:ListItem Value="0">Non-Cash Loan</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_REVOLVING" runat="server" RepeatDirection="Horizontal" Enabled="False">
											<asp:ListItem Value="1" Selected="True">Revolving</asp:ListItem>
											<asp:ListItem Value="0">Non-Revolving</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Interest Type</TD>
									<TD width="17" style="HEIGHT: 6px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 6px">
										<asp:Label id="LBL_INTERESTTYPE" runat="server">INTERESTTYPE</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue">
										<asp:radiobuttonlist id="RBL_NEGO" runat="server" Width="233px" Enabled="False" RepeatDirection="Horizontal"
											AutoPostBack="True">
											<asp:ListItem Value="0" Selected="True">Not Negotiable</asp:ListItem>
											<asp:ListItem Value="1">Negotiable</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Fixed&nbsp;Rate</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_INTERESTTYPERATE" runat="server">INTERESTTYPERATE</asp:Label>&nbsp; 
										%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Rate Number</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue">
										<asp:Label onkeypress="return kutip_satu()" id="LBL_RATENO" runat="server" Columns="4" ReadOnly="True"></asp:Label>&nbsp;
										<asp:Label onkeypress="return kutip_satu()" id="LBL_RATEPERCENT" runat="server" Columns="4"
											ReadOnly="True">0</asp:Label>&nbsp;%&nbsp;
										<asp:Label onkeypress="return kutip_satu()" id="LBL_RATE" runat="server" Columns="4" ReadOnly="True"></asp:Label></TD>
								<TR>
									<TD class="TDBGColor1">Variance Code</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_VARCODE" runat="server" RepeatDirection="Horizontal" Enabled="False">
											<asp:ListItem Selected="True">&amp;nbsp;&amp;nbsp;&amp;nbsp;</asp:ListItem>
											<asp:ListItem Value="+">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Variance</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_VARIANCE" runat="server">VARIANCE</asp:Label>&nbsp; %</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">SPK</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_SPK" runat="server" RepeatDirection="Horizontal" Enabled="False">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Payment Type</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_ISINSTALLMENT" runat="server" RepeatDirection="Horizontal" Enabled="False">
											<asp:ListItem Value="1" Selected="True">Installment</asp:ListItem>
											<asp:ListItem Value="0">Interest</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Installment Type</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:Label id="LBL_INSTALLMENTTYPE" runat="server">INSTALLMENTTYPE</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Rekening Koran</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:radiobuttonlist id="RDO_CONFIRMKORAN" runat="server" RepeatDirection="Horizontal" Enabled="False">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" colSpan="2">
							<asp:Button id="BTN_VIEW" runat="server" Enabled="False" Text="View Preset Alternate Rate" CssClass="Button1" onclick="BTN_VIEW_Click"></asp:Button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
