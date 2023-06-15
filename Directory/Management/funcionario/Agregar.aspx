<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Management/MasterPage.Master" CodeBehind="Agregar.aspx.vb" Inherits="Directory.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-lg-6">
                    <h1 class="m-0 text-dark">Agregar nuevo funcionario</h1>
                </div>
                <div class="col-lg-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item">Funcionario</li>
                        <li class="breadcrumb-item active">
                        Agregar</li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-7 col-md-7">
                        <div class="card card-secondary">
                            <div class="card-header">
                                <h3 class="card-title">Informacion genaral</h3>
                            </div>
                            <div class="card-body">
                                <div role="form">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                        <div class="col-lg-5 col-md-12">
                                            <div class="form-group">
                                                <label>Tipo funcionario (*)</label>
                                                
                                                <asp:DropDownList runat="server" ID="ddlTipoFuncionario" CssClass="form-control select2" Style="width: 100%;" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-7 col-md-12 ">
                                            <div class="form-group">
                                                <label>Cargo (*)</label>                                                
                                                <asp:TextBox runat="server" placeholder="Escribe el cargo" ID="txbCargo" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">

                                            <div class="form-group">
                                                <label>Nombre (*)</label>
                                                <asp:TextBox runat="server" placeholder="Escribe el nombre" ID="txbNombre" class="form-control" />

                                            </div>
                                        </div>
                                        <div class="col-lg-4">

                                            <div class="form-group">
                                                <label>Apellido Paterno (*)</label>
                                                <asp:TextBox runat="server" placeholder="Escribe el apellido paterno" ID="txbAPaterno" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">

                                            <div class="form-group">
                                                <label>Apellido Materno (*)</label>
                                                <asp:TextBox runat="server" placeholder="Escribe el apellido materno" ID="txbAMaterno" class="form-control" />

                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Fecha de nacimiento: (*)</label>

                                                <div class="input-group">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                                    </div>
                                                    <asp:TextBox runat="server" ID="txbFechaNacimiento" type="date" class="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label>Correo</label>
                                                <asp:TextBox runat="server" placeholder="Escribe el correo" ID="txbCorreo" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12">

                                            <div class="form-group">
                                                <label>Ubicación de oficina</label>
                                                <div class="input-group">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fa fa-map-marker"></i></span>
                                                    </div>
                                                    <asp:TextBox runat="server" placeholder="Copia y pega la url de la ubicacion con google maps" ID="txbMapaOficina" class="form-control" />
                                                </div>
                                                

                                            </div>
                                        </div>
                                    </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div role="form">
                                        <label>Telefonos</label>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>

                                            <div class="input-group ">
                                                <div class="input-group-prepend">
                                                    <asp:DropDownList ID="cmbTipoTelefono" runat="server" class="form-control fa">
                                                        <asp:ListItem Text="Tipo" Selected="True" disabled="true" />
                                                        <asp:ListItem Text="Movil" />
                                                        <asp:ListItem Text="Casa" />
                                                        <asp:ListItem Text="Trabajo" />
                                                    </asp:DropDownList>
                                                </div>
                                                <asp:TextBox runat="server" ID="txbTelefono" class="form-control" placeholder="Escribe el número" MaxLength="20" />
                                                <span class="input-group-append">
                                                    <asp:Button ID="btnAgregarTelefono" Text="Agregar" class="btn btn-default btn-fla fa" runat="server" />
                                                </span>
                                            </div>
                                            <ul class="list-inline row">

                                                <li class="col-xs-12 p-l-10">
                                                    <asp:ListView ID="lvsTelefonos" runat="server" ItemPlaceholderID="elementoPlaceHolder" class="table">
                                                        <LayoutTemplate>
                                                            <table class="table table-hover table-responsive">
                                                                <tbody>
                                                                    <asp:PlaceHolder ID="elementoPlaceHolder" runat="server" />
                                                                </tbody>
                                                            </table>
                                                        </LayoutTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="width: 5%; text-align: center;">
                                                                    <asp:Label ID="lblNum" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("tipo")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblEspecialidad" runat="server" Text='<%#Eval("numero")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Button Text="&#xf1f8;" ID="btnEliminarTelefono" CssClass="fa" OnClick="btnEliminarTelefono_Click" CommandArgument='<%#Container.DataItemIndex%>' runat="server" /></td>
                                                            </tr>
                                                        </ItemTemplate>

                                                    </asp:ListView>
                                                </li>
                                            </ul>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                </div>
                            </div>
                            <div class="card-footer">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <asp:LinkButton ID="BtnGuardar" class="btn btn-success float-righ" runat="server">Guardar</asp:LinkButton>
                                        <asp:LinkButton id="BtnCerrar" CssClass="btn btn-default float-righ" runat="server" >Cerrar</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-5">
                        <div class="card card-secondary">
                            <div class="card-header">
                                <h3 class="card-title">Subir foto</h3>
                            </div>
                            <div class="card-body box-profile">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="text-center">
                                            <asp:Image ID="imgFoto" CssClass="profile-user-img img-fluid img-circle" ImageUrl="../../images/user.png" Height="100%" runat="server" />
                                        </div>
                                        <p class="text-muted text-center">Foto de funcionario</p>
                                        <asp:Label runat="server" ID="lblFoto" BorderColor="White" BorderStyle="None" ForeColor="White" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="user-btm-box">
                                    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                                    <script type="text/javascript">
                                        function UploadFile(fileUpload) {
                                            if (fileUpload.value != '') {
                                                document.getElementById("<%=btnUpload.ClientID %>").click();
                                            }
                                        }
                                    </script>
                                    <div class="btn btn-block btn-default btn-file pull-center m-t-15 p-l-25 p-r-25 p-t-10">
                                        <i class="fa fa-camera"></i>Seleccionar foto
                                        <asp:FileUpload ID="img" runat="server" class="file-loading" accept=".jpg" Width="195px" ClientIDMode="Static" />
                                    </div>

                                </div>
                            </div>

                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    
 <script>
    
 </script>
</asp:Content>
