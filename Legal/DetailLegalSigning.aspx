<%@ Page language="c#" Codebehind="DetailLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.DetailLegalSigning_Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailLegalSigning_Data</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td class="tdHeader1"><B>Info Pemohon</B></td>
					</tr>
					<tr>
						<td>
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td width="50%" class="td" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Application #</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_REGNO" Runat="server" ReadOnly Columns="35"></asp:TextBox>
													<asp:Label id="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
													<asp:Label id="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
													<asp:Label id="LBL_TC" Runat="server" Visible="False"></asp:Label>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Reference #</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CU_REF" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_AP_SIGNDATEDAY" Runat="server" ReadOnly Columns="2"></asp:TextBox>
													<asp:DropDownList ID="DDL_AP_SIGNDATEMONTH" Runat="server" ReadOnly></asp:DropDownList>
													<asp:TextBox ID="TXT_AP_SIGNDATEYEAR" Runat="server" ReadOnly Columns="4"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Sub-Segment/Program</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_PROGRAMDESC" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_BRANCH_NAME" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Team Leader</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_TMLDRNM" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Relationship Manager</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_RMNM" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Business Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_BU_DESC" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CU_NAME" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" valign="top">Alamat</td>
												<td></td>
												<td class="TDBGColorValue">
													<asp:TextBox ID="TXT_CU_ADDR1" Runat="server" ReadOnly Columns="35"></asp:TextBox><br>
													<asp:TextBox ID="TXT_CU_ADDR2" Runat="server" ReadOnly Columns="35"></asp:TextBox><br>
													<asp:TextBox ID="TXT_CU_ADDR3" Runat="server" ReadOnly Columns="35"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CU_CITYNM" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_CU_PHN" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_BUSSTYPEDESC" Runat="server" ReadOnly Columns="35"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1"><B>Asuransi Jiwa</B></td>
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
												<td class="TDBGColorValue"><asp:DropDownList ID="DDL_AP_INSRCOMP" Runat="server"></asp:DropDownList></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Insurance Type</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_INSRTYPE" Runat="server" Columns="35" MaxLength="50" onKeypress="return kutip_satu()"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" valign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_INSRAMNT" Runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()" CssClass="angka"></asp:TextBox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Masa Pertanggungan</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_INSRMASA" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()" CssClass="angka"></asp:TextBox>Tahun</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Premi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:TextBox ID="TXT_AP_INSRPREMI" Runat="server" ReadOnly Columns="35" CssClass="angka"></asp:TextBox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
				</table>
				
			</center>
		</form>
	</body>
</HTML>
