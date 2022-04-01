<%@ Page language="c#" Codebehind="NotaryLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.NotaryLegalSigning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NotaryLegalSigning</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1"><B>Notary</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td valign="top" width="50%" class="td">
										<TABLE cellSpacing="0" cellPadding="0">
											<tr>
												<td width="150" class="TDBGColor1">Notary Name</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_NTID" Runat="server" onselectedindexchanged="CH_NTID"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1" valign="top">Address</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_NT_ADDR1" Runat="server" ReadOnly Columns="35"></asp:TextBox><br>
													<asp:TextBox ID="TXT_NT_ADDR2" Runat="server" ReadOnly Columns="35"></asp:TextBox><br>
													<asp:TextBox ID="TXT_NT_ADDR3" Runat="server" ReadOnly Columns="35"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">City</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_NT_CITY" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
									<td valign="top" class="td">
										<TABLE cellSpacing="0" cellPadding="0">
											<tr>
												<td width="150" class="TDBGColor1">&nbsp;E-mail</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_NT_EMAIL" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Phone No</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_NT_PHNAREA" Runat="server" ReadOnly Columns="5"></asp:TextBox>
													<asp:TextBox ID="TXT_NT_PHNNUM" Runat="server" ReadOnly Columns="15"></asp:TextBox>
													<asp:TextBox ID="TXT_NT_PHNEXT" Runat="server" ReadOnly Columns="5"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Fax</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_NT_FAXAREA" Runat="server" ReadOnly Columns="5"></asp:TextBox>
													<asp:TextBox ID="TXT_NT_FAXNUM" Runat="server" ReadOnly Columns="15"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Zip Code</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_NT_ZIPCODE" Runat="server" ReadOnly Columns="5"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td>
							<table cellpadding="2" cellspacing="2" width="100%">
								<tr>
									<td class="td" valign="top" width="50%">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGCOLOR1" width="150">Date</td>
												<td width="15"></td>
												<td class="TDBGCOLORValue">
													<asp:TextBox ID="TXT_NA_APPNTDATETIMEDAY" Runat="server" MaxLength="2" Columns="2" onKeypress="return numbersonly()"></asp:TextBox>
													<asp:DropDownList ID="DDL_NA_APPNTDATETIMEMONTH" Runat="server"></asp:DropDownList>
													<asp:TextBox ID="TXT_NA_APPNTDATETIMEYEAR" Runat="server" MaxLength="4" Columns="4" onKeypress="return numbersonly()"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Time</td>
												<td></td>
												<td class="TDBGCOLORValue">
													<asp:TextBox ID="TXT_NA_APPNTDATETIMEHOUR" Runat="server" MaxLength="2" Columns="2" onKeypress="return numbersonly()"></asp:TextBox>:
													<asp:TextBox ID="TXT_NA_APPNTDATETIMEMINUTE" Runat="server" MaxLength="2" Columns="2" onKeypress="return numbersonly()"></asp:TextBox>
												</td>
											</tr>
										</table>
									</td>
									<td class="td" valign="top">
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td class="TDBGCOLOR1" width="150" valign="top">Remarks</td>
												<td width="15"></td>
												<td class="TDBGCOLORValue"><asp:TextBox ID="TXT_NA_REMARKS" Runat="server" MaxLength="100" Columns="40" Rows="4" Height="50" onKeypress="return kutip_satu()"
														TextMode="MultiLine"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD align="center">
							<asp:Button ID="BTN_SAVE" Text="Simpan" Runat="server" CssClass="button1" onclick="BTN_SAVE_Click"></asp:Button>
							<input type="button" value="Print Notary Assignment" Class="button1">
							<asp:Label ID="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_PRODUCTID" Runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
