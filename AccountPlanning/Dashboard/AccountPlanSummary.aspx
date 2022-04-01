<%@ Register TagPrefix="uc1" TagName="DocExport" Src="CommonForm/DocExport.ascx" %>
<%@ Page language="c#" Codebehind="AccountPlanSummary.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.Dashboard.AccountPlanSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
	<TITLE>AccountPlanSummary</TITLE>
	<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
	<meta content=C# name=CODE_LANGUAGE>
	<meta content=JavaScript name=vs_defaultClientScript>
	<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
	<LINK href="../../style.css" type=text/css rel=stylesheet >
	<!-- set up the jquery -->
	<script src="../../jQuery/Main/jquery-1.7.1.min.js" type="text/javascript"></script>
	<script src="../../jQuery/Chart/highcharts.js" type="text/javascript"></script>
	<script src="../../jQuery/Chart/highchartThemes/gray.js" type="text/javascript"></script>
	<script src="../../jQuery/Chart/modules/exporting.js" type="text/javascript"></script>
	<!-- hide the box with CSS -->
	<LINK rel="stylesheet" type="text/css" href="../../CSS/pras.css">
  </HEAD>
<BODY MS_POSITIONING="GridLayout">
<FORM id=Form1 method=post runat="server">
<TABLE id=Table4 width="100%" border=0>
	<TR>
		<TD align=left colSpan=1>
			<TABLE id=Table3>
				<TR>
					 <TD class=tdBGColor2 style="WIDTH: 400px" align=center ><B>ACCOUNT PLAN SUMMARY</B>
					 </TD>
				</TR>
			</TABLE>
		</TD>
		<TD class=tdNoBorder align=right><A href="../../Body.aspx"  ?><IMG height=25 src="/SME/Image/MainMenu.jpg" width=106 ></A> 
			<A href="../../Logout.aspx" target=_top ><IMG src="/SME/Image/Logout.jpg"></A> 
		</TD>
	</TR>
	<tr>
		<td></td>
	</tr>
	<TR>
		<TD colSpan=2>
			<TABLE id=TBL_MainTable cellSpacing=2 cellPadding=2 width="100%" align=center border=1 runat="server">
				<TR>
					<TD class=tdHeader1 align=center colSpan=2>GENERAL INFO </TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width="50%">Unit Group Name :</TD>
					<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_GROUP runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="DDL_GROUP_SelectedIndexChanged"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1 width="50%">Unit Name :</TD>
					<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_UNIT runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table4 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width="50%">Industry Name :</TD>
					<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_INDUSTRY runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1 width="50%">Product Name :</TD>
					<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_PRODUCT runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<tr>
		<td class=TDBGColor2 colSpan=2><asp:button id=BTN_RTV CssClass="button1" Runat="server" Text="RETRIEVE" onclick="BTN_RTV_Click"></asp:button></td>
	</tr>
	<TR id=TR_GROUPUNIT runat="server">
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<td class=td align=left colSpan=2>
						<table cellSpacing=0 cellPadding=0 width="100%">
							<tr>
								<td class=tdSmallHeader align=center width="40%" rowSpan=2>In IDR Mn</td>
								<td class=tdSmallHeader align=center width="60%" colSpan=12>Key Targets</td>
							</tr>
							<tr>
								<td class=tdSmallHeader align=center width="33%" colSpan=4>Target 2012</td>
								<td class=tdSmallHeader align=center width="33%" colSpan=4>W.size.est.</td>
								<td class=tdSmallHeader align=center width="34%" colSpan=4>W.Share(%)</td>
							</tr>
							<tr id=br2>
								<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>&nbsp;&nbsp;&nbsp;Volume</STRONG></td>
							</tr>
							<tr id=br3 align=left>
								<TD class=TDBGColor1 align=left width="40%">Low Cost Funds</TD>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_LC1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_LC2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_LC3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Time Deposits</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3><asp:textbox id=TXT_TD1_GROUP 
									tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TD2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TD3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Total Credit Fac.</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TC1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TC2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TC3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Investment Loan</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_IL1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_IL2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_IL3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Working Capital Loan</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WL1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WL2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WL3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Utilization (%)</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_U1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_U2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_U3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br2>
								<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>&nbsp;&nbsp;&nbsp;Wholesale Income</STRONG></td>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Net Interest Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_NII1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_NII2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_NII3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Assets</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_ASSETS1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_ASSETS2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_ASSETS3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Liabilities</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_LIABILITIS1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_LIABILITIS2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_LIABILITIS3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Fee Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_FI1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_FI2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_FI3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Direct Cost Allocation</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_DCA1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_DCA2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_DCA3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Contribution Margin</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_CM1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_CM2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_CM3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br2>
								<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>&nbsp;&nbsp;&nbsp;Alliance Income</STRONG></td>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Net Interest Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_NII1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_NII2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_NII3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Assets</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_ASSETS1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_ASSETS2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_ASSETS3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Liabilities</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_LIABILITIS1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_LIABILITIS2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_LIABILITIS3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Fee Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_FI1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_FI2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_FI3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td style="PADDING-RIGHT: 40px" align=left width="40%"><STRONG>Total Relationship Income</STRONG></td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TRI1_GROUP tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TRI2_GROUP tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TRI3_GROUP tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table6 cellSpacing=2 cellPadding=2 width="100%">
				<TR>
					<div id=container style="MARGIN: 0px auto; HEIGHT: 400px" runat="server"></div>
					<asp:TextBox id="internalcustomer" CssClass="tobehide" runat="server"></asp:TextBox>
					<asp:TextBox id="validation" CssClass="tobehide" runat="server"></asp:TextBox>
					<asp:TextBox id="selfassesment" CssClass="tobehide" runat="server"></asp:TextBox>
					<!--<asp:TextBox id="undefined" CssClass="tobehide" runat="server"></asp:TextBox>-->
				</TR>
				<TR id="TR_SCORING" runat="server">						
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="50%">Total Anchor :</TD>
								<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SCORE" runat="server" ReadOnly="True" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="50%">Average Wallet Size :</TD>
								<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CATEGORY" runat="server" ReadOnly="True" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<tr>
		<td></td>
	</tr>
	<TR id=TR_UNIT align=left runat="server">
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=td vAlign=top align=center width="50%" colSpan=2>
						<asp:datagrid id=DGR_UNIT runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="Anchor_Name" HeaderText="Anchor Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Target_2012" HeaderText="Target 2012">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="W_Size_Est" HeaderText="W.size est.">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Wallet_Share" HeaderText="W.Share (%)">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table6 cellSpacing=2 cellPadding=2 width="100%">
				<TR>
					<div id=Div1 style="MARGIN: 0px auto; HEIGHT: 400px" runat="server"></div>
				</TR>				
			</TABLE>
		</TD>
	</TR>
	<TR id=TR_INDUSTRY runat="server">
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<td class=td align=left colSpan=2>
						<table cellSpacing=0 cellPadding=0 width="100%">
							<tr>
								<td class=tdSmallHeader align=center width="40%" rowSpan=2>In IDR Mn</td>
								<td class=tdSmallHeader align=center width="60%" colSpan=12>Key Targets</td>
							</tr>
							<tr>
								<td class=tdSmallHeader align=center width="33%" colSpan=4>Target 2012</td>
								<td class=tdSmallHeader align=center width="33%" colSpan=4>W.size.est.</td>
								<td class=tdSmallHeader align=center width="34%" colSpan=4>W.Share(%)</td>
							</tr>
							<tr id=br2>
								<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>&nbsp;&nbsp;&nbsp;Volume</STRONG></td>
							</tr>
							<tr id=br3 align=left>
								<TD class=TDBGColor1 align=left width="40%">Low Cost Funds</TD>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_LCF1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_LCF2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_LCF3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Time Deposits</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TD1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TD2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TD3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Total Credit Fac.</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TCF1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TCF2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TCF3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Investment Loan</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_IL1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_IL2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_IL3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Working Capital Loan</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WCL1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WCL2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WCL3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Utilization (%)</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>\
									<asp:textbox id=TXT_U1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_U2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_U3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br2>
								<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>&nbsp;&nbsp;&nbsp;Wholesale Income</STRONG></td>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Net Interest Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_NII1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_NII2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_NII3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Assets</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_ASSETS1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_ASSETS2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_ASSETS3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Liabilities</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_LIABILITIES1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_LIABILITIES2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_LIABILITIES3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Fee Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_FI1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_FI2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_FI3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Direct Cost Allocation</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_DCA1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_DCA2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_DCA3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Contribution Margin</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_CM1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_CM2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_WI_CM3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br2>
								<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>&nbsp;&nbsp;&nbsp;Alliance Income</STRONG></td>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Net Interest Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_NII1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_NII2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_NII3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
							<td class=TDBGColor1 align=left width="40%">Assets</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_ASSETS1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_ASSETS2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_ASSETS3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Liabilities</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_LIABILITIES1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_LIABILITIES2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_LIABILITIES3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td class=TDBGColor1 align=left width="40%">Fee Income</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_FI1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_FI2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_AI_FI3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
							<tr id=br3>
								<td style="PADDING-RIGHT: 40px" align=left width="40%"><STRONG>Total Relationship Income</STRONG></td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TRI1_INDUSTRY tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TRI2_INDUSTRY tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
								<td class=TDBGColorValue align=left width="20%" colSpan=3>
									<asp:textbox id=TXT_TRI3_INDUSTRY tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox>
								</td>
								<TD width="1%">&nbsp;</TD>
							</tr>
						</table>
									<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END SEPARATOR UTK ISI NERACA %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% ----------------------------------------------------->
					</td>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table6 cellSpacing=2 cellPadding=2 width="100%">
				<TR>
					<div id=Div2 style="MARGIN: 0px auto; HEIGHT: 400px" runat="server"></div>
				</TR>
				<TR id="Tr1" runat="server">						
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="50%">Total Anchor :</TD>
								<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="Textbox1" runat="server" ReadOnly="True" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="50%">Average Wallet Size :</TD>
								<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="Textbox2" runat="server" ReadOnly="True" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR id=TR_PRODUCT align=left runat="server">
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=td vAlign=top align=center width="50%" colSpan=2>
						<asp:datagrid id=DGR_PRODUCT runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Anchor Name" DataField= "Anchor_Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Customer Name" DataField="Cust_Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Target 2012" DataField="Target_2012">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="W.size est." DataField="W_size_Est">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="W.Share (%)" DataField="Wallet_Share">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table6 cellSpacing=2 cellPadding=2 width="100%">
				<TR>
					<div id=Div3 style="MARGIN: 0px auto; HEIGHT: 400px" runat="server"></div>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD colSpan=2><uc1:docexport id=DocExport1 runat="server"></uc1:docexport></TD></TR>
	<TR>
		<TD class=tdHeader1 vAlign=top width="50%" colSpan=2>CUSTOMER DETAIL INFO</TD></TR>
	<TR>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width="50%">Unit Name :</TD>
					<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_UNIT_NAME runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table4 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width="50%">Customer Name :</TD>
					<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id=DDL_CUST_NAME runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<tr>
		<td class=TDBGColor2 colSpan=2><asp:button id=BTN_RETRIEVE2 CssClass="button1" Runat="server" Text="RETRIEVE" onclick="BTN_RETRIEVE2_Click"></asp:button></td>
	</tr>
	<tr>
		<td></td>
	</tr>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>1. RELATIONSHIP :</STRONG></FONT></TD>
	</TR>
	<TR>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table6 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1>CIF No.</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_CIF_NO runat="server" Width="300px" ReadOnly="True" Height="16px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1>Customer Name</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_CUST_NAME runat="server" Width="300px" ReadOnly="True" Height="16px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1>Address</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_ADDRESS runat="server" Width="300px" ReadOnly="True" Height="16px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1>Kota</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_KOTA runat="server" Width="300px" ReadOnly="True" Height="16px" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1>Primary Relations</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_PRIMARY_RELATIONS runat="server" Width="300px" ReadOnly="True" Height="16px" BorderStyle="None"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width=150>Customer Date</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_CUST_DATE runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1 width=150>Length of relationship</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_LOR runat="server" Width="100px" ReadOnly="True"></asp:textbox><asp:label id=Label1 runat="server">Year</asp:label></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1 width=150>Relationship Manager</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_RELATIONSHIP_MANAGER runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1 width=150>Group Name</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_GROUP_NAME runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1 width=150>Unit Name</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_UNIT_NAME runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>2. BUSINESS SNAPSHOT :</STRONG></FONT> </TD>
	</TR>
	<TR>
		<TD class=td vAlign=top width="100%" colSpan=2>
			<TABLE id=Table6 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width=150>Business Description</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_BUSINESS_DESC runat="server" Width="600px" ReadOnly="True" Height="32px" BorderStyle="None" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class=TDBGColor1>Recent Development</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_RECENT_DEV runat="server" Width="600px" ReadOnly="True" Height="32px" BorderStyle="None" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>3. COMPANY TREE :</STRONG></FONT></TD>
	</TR>
	<TR>
		<TD class=td vAlign=top align=center width="50%" colSpan=2>
			<asp:datagrid id=DGR_COMP_TREE runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
			<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
			<Columns>
				<asp:BoundColumn HeaderText="Key Companies" DataField="key_companies">
					<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
				</asp:BoundColumn>
				<asp:BoundColumn HeaderText="Industry" DataField="industry">
					<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:BoundColumn>
				<asp:BoundColumn HeaderText="Revenue (IDR Bn)" DataField="Revenue">
					<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:BoundColumn>
				<asp:BoundColumn HeaderText="Relationship Status" DataField="relationship_status">
					<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:BoundColumn>
				<asp:BoundColumn HeaderText="Contact Person" DataField="contact_person">
					<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:BoundColumn>
			</Columns>
			<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>4. KEY FINANCIAL :</STRONG></FONT></TD></TR>
	<TR>
		<TD class=td vAlign=top width="50%">
			<TABLE id=Table6 cellSpacing=0 cellPadding=0 width="50%">
				<TR>
					<TD class=TDBGColor1 width=200>Currency</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_CURRENCY runat="server" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD class=TDBGColor1 width=150>Denominator</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_DENOMINATOR runat="server" Width="200px" ReadOnly="True"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
<table id=Table4 width="100%" border=0>
	<TR>
		<td class=td align=left>
			<table cellSpacing=0 cellPadding=0 width="100%">
				<tr>
					<td class=tdSmallHeader align=center width="20%">Target 2012</td>
					<td class=tdSmallHeader align=center width="20%">W.size.est.</td>
					<td class=tdSmallHeader align=center width="20%">W.Share(%)</td>
					<td class=tdSmallHeader align=center width="20%">W.Share(%)</td>
					<td class=tdSmallHeader align=center width="20%">W.Share(%)</td>
				</tr>
				<tr>
					<td class=tdSmallHeader align=center width="20%">Number of Month</td>
					<td class=tdSmallHeader align=center width="20%">9</td>
					<td class=tdSmallHeader align=center width="20%">12</td>
					<td class=tdSmallHeader align=center width="20%">12</td>
					<td class=tdSmallHeader align=center width="20%">Growth</td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Balance Sheet</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Cash &amp; Bank</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CASHBANK1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CASHBANK2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CASHBANK3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CASHBANK4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Total Assets</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_ASSET1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_ASSET2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_ASSET3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_ASSET4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Total Loan</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_LOAN1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_LOAN2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_LOAN3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_TOT_LOAN4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Profitability</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Operating Earnings</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_OPERATING_EARNING1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_OPERATING_EARNING2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_OPERATING_EARNING3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_OPERATING_EARNING4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">EBIT</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">EBIT Margins</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT_MARGINS1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT_MARGINS2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT_MARGINS3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EBIT_MARGINS4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Net Income</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NET_INCOME1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NET_INCOME2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NET_INCOME3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NET_INCOME4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">NPAT Margins</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NPAT_MARGINS1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NPAT_MARGINS2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NPAT_MARGINS3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_NPAT_MARGINS4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Key Ratios</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Current Ratio</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CURRENT_RATIO1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CURRENT_RATIO2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CURRENT_RATIO3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_CURRENT_RATIO4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td></tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Debt to Assets</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_DEBT_TO_ASSETS1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_DEBT_TO_ASSETS2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_DEBT_TO_ASSETS3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_DEBT_TO_ASSETS4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Interest Coverage</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INTEREST_COVERAGE1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INTEREST_COVERAGE2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INTEREST_COVERAGE3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INTEREST_COVERAGE4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Inventory Turnover</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INVENTORY_TURNOVER1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INVENTORY_TURNOVER2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INVENTORY_TURNOVER3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_INVENTORY_TURNOVER4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Average Collection Period</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_ACP1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_ACP2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_ACP3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_ACP4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Others</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%"># of Employees</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EMPLOYEE1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EMPLOYEE2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EMPLOYEE3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_EMPLOYEE4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
			</table>
		</td>
	</TR>
	<tr>
		<td></td>
	</tr>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>5. COMPETITOR SCAN :</STRONG></FONT></TD></TR>
	<TR>
		<TD class=td vAlign=top align=center width="50%" colSpan=2>
			<asp:datagrid id=DGR_COMPETITOR_SCAN runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
				<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
				<Columns>
					<asp:BoundColumn HeaderText="Product" DataField="product">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Primary Competitor" DataField="prime_competitor">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Secondary Competitor" DataField="secondary_competitor">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Comments" DataField="comments">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>6. DEAL :</STRONG></FONT></TD>
	</TR>
	<tr>
		<td class=tdSmallHeader align=left width="100%">TOP 10 LEADS TO PERSUE</td>
	</tr>
	<TR>
		<TD class=td vAlign=top align=center width="50%" colSpan=2>
			<asp:datagrid id=DGR_DEAL_TOP10 runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
				<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
				<Columns>
					<asp:BoundColumn HeaderText="Company" DataField="company">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Product" DataField="product">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Timeline" DataField="timeline">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Revenue Potential" DataField="revenue">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Probability" DataField="probability">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<tr>
		<td class=tdSmallHeader align=left width="100%">KEY DEALS OVER LAST 12 MONTHS (GROUP HOLDING AND SUBSIDIARY)</td>
	</tr>
	<TR>
		<TD class=td vAlign=top align=center width="50%" colSpan=2>
			<asp:datagrid id=DGR_DEAL_KEY runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
				<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
				<Columns>
					<asp:BoundColumn HeaderText="Company" DataField="company">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Deal Product" DataField="deal_product">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Status" DataField="status">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="When" DataField="kapan">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Comments" DataField="comments">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<TR>
		<TD class=td vAlign=top width="100%" colSpan=2>
			<TABLE id=Table6 cellSpacing=0 cellPadding=0 width="100%">
				<TR>
					<TD class=TDBGColor1 width=150>Notes</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class=TDBGColorValue><asp:textbox id=TXT_NOTES runat="server" Width="600px" ReadOnly="True" Height="32px" BorderStyle="None" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<tr>
		<td></td>
	</tr>
	<TR>
		<TD class=td colSpan=2><FONT size=2><STRONG>7. KEY TARGETS :</STRONG></FONT></TD>
	</TR>
	<TR>
		<td class=td align=left>
			<table cellSpacing=0 cellPadding=0 width="100%">
				<tr>
					<td class=tdSmallHeader align=center width="20%">In IDR Mn</td>
					<td class=tdSmallHeader align=center width="20%">2011</td>
					<td class=tdSmallHeader align=center width="20%">Target 2012</td>
					<td class=tdSmallHeader align=center width="20%">Wallet Share Estimed</td>
					<td class=tdSmallHeader align=center width="20%">Wallet Share(%)</td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Volume</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Low Cost Funds</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_LCF1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_LCF2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_LCF3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_LCF4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 style="HEIGHT: 22px" align=left width="20%">Time Deposits</td>
					<td class=TDBGColorValue style="HEIGHT: 22px" align=left width="20%"><asp:textbox id=TXT_KEY_TD1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue style="HEIGHT: 22px" align=left width="20%"><asp:textbox id=TXT_KEY_TD2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue style="HEIGHT: 22px" align=left width="20%"><asp:textbox id=TXT_KEY_TD3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue style="HEIGHT: 22px" align=left width="20%"><asp:textbox id=TXT_KEY_TD4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Total Credit Facilities</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_TCF1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_TCF2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_TCF3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_TCF4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Investment Loan</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_IL1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_IL2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_IL3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_IL4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Working Capital Loan</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WCL1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WCL2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WCL3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WCL4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Utilization (%)</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_U1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_U2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_U3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_U4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Wholesale Income</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Net Interest Income</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_NII1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_NII2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_NII3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_NII4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Assets</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_A1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_A2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_A3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_A4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Liabilities</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_L1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_L2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_L3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_L4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td></tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Fee Income</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_FI1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_FI2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_FI3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_FI4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Direct Cost Allocation</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_DCA1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_DCA2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_DCA3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_DCA4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Contribution Margin</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_CM1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_CM2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_CM3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_WI_CM4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br2>
					<td class=TDBGColor style="PADDING-RIGHT: 40px" align=left width="24%" colSpan=13><STRONG>Alliance Income</STRONG></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Net Interest Income</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_NII1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_NII2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_NII3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_NII4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Assets</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_A1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_A2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_A3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_A4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Liabilities</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_L1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_L2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_L3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_L4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr id=br3>
					<td class=TDBGColor1 align=left width="20%">Fee Income</td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_FI1 tabIndex=7 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_FI2 tabIndex=44 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_FI3 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td>
					<td class=TDBGColorValue align=left width="20%"><asp:textbox id=TXT_KEY_AI_FI4 tabIndex=84 runat="server" Width="100%" ReadOnly="True"></asp:textbox></td></tr></table></td></TR></table>
<CENTER></CENTER>
</FORM>	
<script type="text/javascript">
							var chart;
							
							$(document).ready(function() {
							var selfassesment;
							var internalcustomer;
							var validation;
							//var undefined;
							
								selfassesment = parseInt($("#selfassesment").val());
								internalcustomer = parseInt($("#internalcustomer").val());
								validation = parseInt($("#validation").val()); 
								//undefined = parseInt($("#undefined").val()); 
							
								chart = new Highcharts.Chart({
									chart: {
										renderTo: 'container',
										plotBackgroundColor: null,
										plotBorderWidth: null,
										plotShadow: false
									},
									title: {
										text: ''
									},
									tooltip: {
										formatter: function() {
											return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';
										}
									},
									plotOptions: {
										pie: {
											allowPointSelect: true,
											cursor: 'pointer',
											dataLabels: {
												enabled: true,
												color: '#000000',
												connectorColor: '#000000',
												formatter: function() {
													return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';
												}
											}
										}
									},
									series: [{
										type: 'pie',
										name: '',
										data: [
											['CBC Plaza Mandiri', selfassesment],
											['CBC Surabaya', internalcustomer],
											//['Undefined', undefined],
											{
												name: 'CBC Kelapa Gading',    
												y: validation,
												sliced: true,
												selected: true
											}
										]
									}]
								});
							}
							);
		</script>
</SCRIPT>
</BODY>
</HTML>
