<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessApplication.aspx.cs" Inherits="SME.MobileApplication.ProcessApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../include/bootstrap.min.css" />
	<link type="text/css" rel="stylesheet" href="../include/bootstrap-select.min.css" />
	<style type="text/css">
		.Hide { display:none; }
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-md-6">
                    <b>Process Application From Mobile Apps</b>
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                    <a href="ListCustomer.aspx?si="></a><a href="../Body.aspx">
                        <img src="../Image/MainMenu.jpg"></a>
                    <a href="../Logout.aspx" target="_top">
                        <img src="../Image/Logout.jpg"></a>
                </div>
            </div>

            <div><h3>1. New Applications From Mobile Apps</h3></div>

			<div><h5>Aplikasi yang di-submit nasabah lewat mobile apps dan belum diproses</h5></div>

            <div class="row">
				<div class="col-md-12">

				    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" >
                        <Columns>
							<asp:BoundField DataField="Id" />
							<asp:BoundField DataField="NasabahId" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                            <asp:BoundField DataField="NamaLengkap" HeaderText="Nama Nasabah" />
							<asp:BoundField DataField="PRODUCTDESC" HeaderText="Product" />
							<asp:BoundField DataField="Limit" HeaderText="Limit" DataFormatString="{0:0,00.00}" />
							<asp:BoundField DataField="Tenor" HeaderText="Tenor" />
							<asp:BoundField DataField="COLTYPEDESC" HeaderText="Collateral" />
                            <asp:ButtonField CommandName="detail" Text="Detail" />
                        </Columns>
                    </asp:GridView>

				</div>
			</div>

            <div><h3>2. Detail Application From Mobile Apps</h3></div>

			<div><h5>Pilih satu aplikasi dari tabel, klik Detail</h5></div>

            <div class="row">
                <div class="col-md-6">

                    <dl class="row">
						<dt class="col-md-4">Nasabah Id</dt>
						<dd class="col-md-8"><asp:Label ID="LblNasabahId" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">User Name</dt>
						<dd class="col-md-8"><asp:Label ID="LblUserName" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Cust Ref No</dt>
						<dd class="col-md-8"><asp:Label ID="LblLosCuRef" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Nama Nasabah</dt>
						<dd class="col-md-8"><asp:Label ID="LblNamaLengkap" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Jenis Kelamin</dt>
						<dd class="col-md-8"><asp:Label ID="LblJenisKelamin" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Tanggal Lahir</dt>
						<dd class="col-md-8"><asp:Label ID="LblTanggalLahir" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">No Identitas</dt>
						<dd class="col-md-8"><asp:Label ID="LblNoIdentitas" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Alamat Rumah</dt>
						<dd class="col-md-8"><asp:Label ID="LblAlamatRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Kota/Kab Rumah</dt>
						<dd class="col-md-8"><asp:Label ID="LblKotaKabRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                </div>
                <div class="col-md-6">

                    <dl class="row">
						<dt class="col-md-4">Pengajuan Id</dt>
						<dd class="col-md-8"><asp:Label ID="LblId" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Product</dt>
						<dd class="col-md-8"><asp:Label ID="LblProduct" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Limit</dt>
						<dd class="col-md-8"><asp:Label ID="LblLimit" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Tenor</dt>
						<dd class="col-md-8"><asp:Label ID="LblTenor" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Purpose</dt>
						<dd class="col-md-8"><asp:Label ID="LblPurpose" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Collateral</dt>
						<dd class="col-md-8"><asp:Label ID="LblCollateralFlag" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Collateral Type</dt>
						<dd class="col-md-8"><asp:Label ID="LblCollateralType" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Collateral Value</dt>
						<dd class="col-md-8"><asp:Label ID="LblCollateralValue" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Certificate Type</dt>
						<dd class="col-md-8"><asp:Label ID="LblCertificateType" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                    <dl class="row">
						<dt class="col-md-4">Certificate No</dt>
						<dd class="col-md-8"><asp:Label ID="LblCertificateNo" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

                </div>
            </div>

            <div class="row">
				<div class="col-md-12">

				    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-sm" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView2_PageIndexChanging">
						<Columns>
							<asp:BoundField DataField="Id" />
							<asp:BoundField DataField="Caption" HeaderText="Caption" />
                            <asp:TemplateField HeaderText="File Name">  
								<ItemTemplate>  
									<asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" CommandArgument='<%# Eval("FileUrl") %>'  
                                            OnClick="downloadFile" Text='<%# Eval("FileName") %>' />  
								</ItemTemplate>  
							</asp:TemplateField>
                        </Columns>
                    </asp:GridView>

				</div>
			</div>

			<div><h3>3. Process Application From Mobile Apps</h3></div>

			<div><h5>Aplikasi akan diproses ke Initial Data Entry</h5></div>

			<div class="row">
				<div class="col-md-6">
				    <asp:Button ID="Button1" runat="server" Text="Process Application" CssClass="btn btn-primary" OnClick="Button1_Click" />
				</div>
				<div class="col-md-6"></div>
			</div>



			<br />
			<br />
        </div>
    </form>
    <script type="text/javascript" src="../include/jquery.min.js"></script>
	<script type="text/javascript" src="../include/popper.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap-select.min.js"></script>
</body>
</html>
