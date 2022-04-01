<%@ Page language="c#" Codebehind="FasilitasLegalSigning_Data.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.FasilitasLegalSigning_Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FasilitasLegalSigning_Data</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<center>
			<TABLE cellSpacing="0" cellPadding="0" width="100%">
				<form id="Form1" method="post" runat="server">
					<tr>
						<td class="tdHeader1"><B>Struktur Kredit</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Limit</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT" Columns="35" ReadOnly Runat="server" CssClass="angka"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tenor</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_TENOR" Columns="6" ReadOnly Runat="server" CssClass="angka"></asp:textbox>Bulan</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Interest/P.a</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_INTEREST" Columns="6" ReadOnly Runat="server" CssClass="angka"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Interest Type</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_INTTYPE" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Tujuan Penggunaan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList id="DDL_CP_LOANPURPOSE" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">&nbsp;Issue of payment date</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:textbox id="TXT_CP_ISSUEDATEDAY" Columns="2" ReadOnly Runat="server"></asp:textbox>
													<asp:DropDownList id="DDL_CP_ISSUEDATEMONTH" ReadOnly Runat="server"></asp:DropDownList>
													<asp:textbox id="TXT_CP_ISSUEDATEYEAR" Columns="4" ReadOnly Runat="server"></asp:textbox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">PK No.</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_PKNO" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">PK Due Date</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CP_PKDATEDAY" Columns="2" ReadOnly Runat="server"></asp:textbox><asp:dropdownlist id="DDL_CP_PKDATEMONTH" ReadOnly Runat="server"></asp:dropdownlist><asp:textbox id="TXT_CP_PKDATEYEAR" Columns="4" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
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
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAADM" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Provisi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAPROVISI" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Notaris</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEANOTARIS" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Biaya Pengikatan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_BEAIKAT" Columns="25" Runat="server"
														CssClass="angkamandatory" MaxLength="21"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Biaya Meterai</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CP_BEAMATERAI" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angkamandatory"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Asuransi Kredit</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td width="50%" class="td" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Perusahaan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_CP_INSRCOMP" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Insurance Type</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CP_INSRTYPE" Runat="server" Columns="35" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CP_INSRAMNT" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Masa Pertanggungan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CP_INSRMASA" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"
														CssClass="angka"></asp:TextBox>Tahun</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Premi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CP_INSRPREMI" Runat="server" Columns="25" ReadOnly></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td><b>Choose Legal Signing</b></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="TDBGColor1" width="150">PERJANJIAN KREDIT</td>
									<td width="15"></td>
									<td class="TDBGColorValue">
										<asp:RadioButton ID="RDB_PK1" GroupName="RDB_PK" Runat="server" Text="Notary"></asp:RadioButton>
										<asp:RadioButton ID="RDB_PK2" GroupName="RDB_PK" Runat="server" Text="Di bawah tangan"></asp:RadioButton>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Button ID="BTN_SAVE" Runat="server" Text="Simpan" CssClass="button1"></asp:Button>
							<input type="button" value="View Asuransi Kredit" class="button1"><input type="button" value="View PK" class="button1">
							<asp:Label ID="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_PRODUCTID" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_PROD_SEQ" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_APPTYPE" Runat="server" Visible="False"></asp:Label>
						</td>
					</tr>
			</TABLE>
			</FORM>
		</center>
	</body>
</HTML>
