<%@ Page language="c#" Codebehind="OtherData.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.OtherData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OtherData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td class="tdHeader1"><B>Biaya-biaya</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Administrasi</td>
												<td width="15">:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_BEAADM" MaxLength="21" Runat="server" Columns="25"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Provisi</td>
												<td>:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_BEAPROVISI" runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Notaris</td>
												<td>:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_BEANOTARIS" MaxLength="21" Runat="server" Columns="25"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Pengikatan</td>
												<td width="15">:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_BEAIKAT" MaxLength="21" Runat="server" Columns="25"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Meterai</td>
												<td>:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_BEAMATERAI" MaxLength="21" Runat="server" Columns="25"></asp:textbox></td>
											</tr>
										</TABLE>
										<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCTID" Runat="server" Visible="False"></asp:label><asp:label id="LBL_APPTYPE" Runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_PROD_SEQ" Runat="server" Visible="False"></asp:label></td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1"><B>Jenis Pengikatan Kredit</B></TD>
					</TR>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">No. PK Pertama</td>
												<td width="15">:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_PKNO" Runat="server" Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal PK Pertama</td>
												<td>:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_PKDATEDAY" MaxLength="2" Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEMONTH" Runat="server"></asp:dropdownlist><asp:textbox id="TXT_CP_PKDATEYEAR" MaxLength="4" Runat="server" Columns="4"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" width="150">No. Addendum PK</td>
												<td width="15">:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_PKNOADD" Runat="server" Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Addendum PK</td>
												<td>:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_PKDATEADDDAY" MaxLength="2" Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEADDMONTH" Runat="server"></asp:dropdownlist><asp:textbox id="TXT_CP_PKDATEADDYEAR" MaxLength="4" Runat="server" Columns="4"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Perjanjian Kredit</td>
												<td width="15">:</td>
												<td class="TDBGColorValue"><asp:radiobuttonlist id="RBL_LEGALSTAPROD" runat="server"></asp:radiobuttonlist></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:button id="BTN_SAVE_KREDIT" Runat="server" Text="Save Credit Data" CssClass="button1" onclick="BTN_SAVE_KREDIT_Click"></asp:button></TD>
					</TR>
					<tr>
						<td>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1"><B>Data Asuransi</B></TD>
					</TR>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Asuransi Jiwa</td>
												<td width="15">:</td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_IC_ID" Runat="server" Columns="20"></asp:textbox>
													<asp:label id="LBL_IC_DESC" Runat="server"></asp:label></td>
											</tr>
											<TR>
												<TD class="TDBGColor1" width="150">Biaya Asuransi Jiwa</TD>
												<TD width="15">:</TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_ALI_PREMI" Columns="20" Runat="server"></asp:textbox></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center"><asp:button id="BTN_SAVE_ASURANSI" Runat="server" Text="Save Insurance Data" CssClass="button1" onclick="BTN_SAVE_ASURANSI_Click"></asp:button></TD>
					</TR>
					<tr>
						<td>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Other</B></td>
					</tr>
					<TR>
						<TD>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TBODY>
									<TR>
										<TD class="TDBGColor1">Tanggal Kirim Ke Decision Center</TD>
										<TD style="WIDTH: 1px">:</TD>
										<TD style="WIDTH: 188px">
											<asp:textbox id="TXT_KIRIM_AD_DAY" Columns="2" Runat="server" MaxLength="2" Visible="False"></asp:textbox>
											<asp:dropdownlist id="DDL_KIRIM_AD_MONTH" Runat="server" Visible="False"></asp:dropdownlist>
											<asp:textbox id="TXT_KIRIM_AD_YEAR" Columns="4" Runat="server" MaxLength="4" Visible="False"></asp:textbox></TD>
										<TD style="WIDTH: 281px"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">RM&nbsp;Code</TD>
										<TD style="WIDTH: 5px">:</TD>
										<TD style="WIDTH: 188px">
											<asp:label id="LBL_RMOFFICERCODE" Runat="server"></asp:label></TD>
										<TD style="WIDTH: 281px">
											<asp:textbox id="TXT_RMOFFICERCODE" Runat="server" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">BU&nbsp;Approval Code</TD>
										<TD style="WIDTH: 5px">:</TD>
										<TD style="WIDTH: 188px"><asp:label id="LBL_BUOFFICERCODE" Runat="server"></asp:label></TD>
										<TD style="WIDTH: 281px"><asp:textbox id="TXT_BUOFFICERCODE" Runat="server" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">CCRA Approval Code</TD>
										<TD width="15">:</TD>
						</TD>
						<TD style="WIDTH: 188px">
							<asp:label id="LBL_CCRAOFFICERCODE" Runat="server"></asp:label></TD>
						<TD>
							<asp:textbox id="TXT_CCRAOFFICERCODE" Runat="server" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Tanggal Persetujuan BU</TD>
						<TD width="15"></TD>
						<TD style="WIDTH: 188px">
							<asp:textbox id="TXT_AD_DATE_BU_DAY" Columns="2" Runat="server" MaxLength="2" Visible="False"></asp:textbox>
							<asp:dropdownlist id="DDL_AD_DATE_BU_MONTH" Runat="server" Visible="False"></asp:dropdownlist>
							<asp:textbox id="TXT_AD_DATE_BU_YEAR" Columns="4" Runat="server" MaxLength="4" Visible="False"></asp:textbox></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Tanggal Persetujuan CCRA</TD>
						<TD width="15"></TD>
						<TD style="WIDTH: 188px">
							<asp:textbox id="TXT_AD_DATE_CRM_DAY" Columns="2" Runat="server" MaxLength="2" Visible="False"></asp:textbox>
							<asp:dropdownlist id="DDL_AD_DATE_CRM_MONTH" Runat="server" Visible="False"></asp:dropdownlist>
							<asp:textbox id="TXT_AD_DATE_CRM_YEAR" Columns="4" Runat="server" MaxLength="4" Visible="False"></asp:textbox></TD>
						<TD></TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR>
					<TD class="TDBGColor2" align="center">
						<asp:button id="BTN_SAVE_OTHER" Runat="server" CssClass="button1" Text="Save Officer Data" onclick="BTN_SAVE_OTHER_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="LBL_CCRAUSERID" Runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_BUUSERID" Runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_RMUSERID" Runat="server" Visible="False"></asp:label>
						<asp:textbox id="TXT_COST_CENTRE" Columns="35" Runat="server" Visible="False"></asp:textbox>
						<asp:textbox id="TXT_ACCOUNT_OFFICER" Columns="35" Runat="server" Visible="False"></asp:textbox></TD>
				</TR>
				</TBODY></TABLE>
			</center>
		</form>
	</body>
</HTML>
