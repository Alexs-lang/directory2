<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Management/MasterPage.Master" CodeBehind="Consultar.aspx.vb" Inherits="Directory.Consultar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">    
    <%# "Hola" %>
        <div class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-lg-6">
                    <h1 class="m-0 text-dark">Consultar funcionario</h1>
                </div>
                <div class="col-lg-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item">Funcionario</li>
                        <li class="breadcrumb-item active">Consultar</li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-10 col-md-10">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Lista de funcionarios</h3>

                                <div class="card-tools">
                                    <asp:LinkButton ID="BtnAgregarFuncionario" runat="server" ToolTip="Agregar nuevo funcionario"><i class="fa fa-plus"></i> Agregar nuevo</asp:LinkButton>

                                </div>
                            </div>
                            <div class="card-body">
                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updLista">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:ListView ID="lvsFuncionarios" runat="server" ItemPlaceholderID="elementoPlaceHolder">
                                                <LayoutTemplate>
                                                    <table class="table table-striped projects tableFiltro" style="width:100%;">
                                                        <thead>
                                                        <tr>
                                                            <th style="width: 30%">Detalles</th>
                                                            <th style="width: 10%">Foto</th>
                                                            <th style="width: 30%">Nombre</th>
                                                            <th style="width: 10%" class="text-center">Estatus</th>
                                                            <th style="width: 25%">Acción</th>
                                                        </tr>
                                                            </thead>
                                                        <tbody>
                                                            <asp:PlaceHolder ID="elementoPlaceHolder" runat="server" />
                                                        </tbody>
                                                    </table>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <a><%#Eval("_TipoFuncionario") %></a>
                                                            <br>
                                                            <small><%#Eval("Cargo")%></small>
                                                            
                                                        </td>
                                                        <td>
                                                            <ul class="list-inline">
                                                                <li class="list-inline-item">
                                                                    <img class="table-avatar" src='<%# "../../images/Funcionarios/" + Eval("Foto") %>'>
                                                                </li>
                                                            </ul>
                                                        </td>
                                                        <td> <%#Eval("Nombre").ToString + " " + Eval("APaterno").ToString + " " + Eval("AMaterno").ToString%></td>
                                                        <td class="project-state">
                                                            <%# IIf(Eval("EsActivo") = True, "<span class='badge badge-success'>Activo</span>", "<span class='badge badge-danger'>Inactivo</span>") %>                          
                                                        </td>
                                                        <td class="project-actions text-right">

                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnVerInformacion" Text="Ver" CommandArgument='<%# Eval("id") %>' OnClick="btnVerInformacion_Click" CssClass="btn btn-primary btn-sm fas fa" runat="server" />
                                                                      <asp:LinkButton ID="BtnEditar" OnClick="BtnEditar_Click" CommandArgument='<%# Eval("Id")%>' runat="server" ToolTip="Editar funcionario" CssClass="btn btn-warning btn-sm">Editar</asp:LinkButton>
                                                            <asp:Button Text='<%# IIf(Eval("EsActivo") = True, "Desactivar", "Activar") %>' ID="btnDesactivarActivar" OnClick="btnDesactivarActivar_Click" CommandArgument='<%#Eval("Id")%> ' CssClass='<%#IIf(Eval("EsActivo") = True, "btn btn-danger btn-sm fa", "btn btn-success btn-sm fa") %>' runat="server" />

                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            
                                                          
                                                        </td>
                                                    </tr>

                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    <div class="mb-3 text-center lvs-border">
                                                        <i class="fa fa-commenting fa-4x grey-text m-5" aria-hidden="true"></i>
                                                        <br />
                                                        <span class="text-grey mt-3">
                                                            <h6>No se encontraron elementos para mostrar en esta vista.</h6>
                                                        </span>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:ListView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>                     
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <div class="modal fade " id="modalInformacion">
        <div class="modal-dialog modal-md">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Información general</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
              <div class="modal-body">
                  <asp:UpdatePanel runat="server">
                      <ContentTemplate>
                          <div class="col-12 col-sm-12 col-md-12 ">
                              <div class="card bg-light">
                                  <div class="card-header text-muted border-bottom-0">
                                      <asp:Label ID="lblTipoFuncionario" runat="server" />

                                  </div>
                                  <div class="card-body pt-0">
                                      <div class="row">
                                          <div class="col-7">
                                              <h2 class="lead"><b>
                                                  <asp:Label ID="lblNombre" runat="server" /></b></h2>
                                              <p class="text-muted text-sm"><b>Cargo: </b>
                                                  <asp:Label ID="lblCargo" runat="server" />
                                                  <br />
                                                  <b>Fecha de nacimiento: </b>
                                                  <asp:Label ID="lblFechaNacimiento" runat="server" />
                                              </p>
                                              <ul class="ml-4 mb-0 fa-ul text-muted">
                                                  <li class="small"><span class="fa-li"><i class="fas fa-lg fa-building"></i></span>Correo:
                                                      <asp:Label ID="lblCorreo" runat="server" /></li>
                                                  <li class="small"><span class="fa-li"><i class="fas fa-lg fa-phone"></i></span>Telefonos #:
                                                      <asp:ListView ID="lvsTelefonos" runat="server" ItemPlaceholderID="elementoPlaceHolder">
                                                          <LayoutTemplate>
                                                              <table class="">
                                                                  <tbody>
                                                                      <asp:PlaceHolder ID="elementoPlaceHolder" runat="server" />
                                                                  </tbody>
                                                              </table>
                                                          </LayoutTemplate>
                                                          <ItemTemplate>
                                                              <tr>
                                                                  <td style="width: 5%; text-align: center;">
                                                                      <asp:Label ID="lblNum" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                                                  <td>
                                                                      <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("tipo")%>'></asp:Label></td>
                                                                  <td>
                                                                      <asp:Label ID="lblEspecialidad" runat="server" Text='<%#Eval("numero")%>'></asp:Label></td>

                                                              </tr>
                                                          </ItemTemplate>

                                                      </asp:ListView>
                                                  </li>
                                              </ul>
                                          </div>
                                          <div class="col-5 text-center">
                                              <asp:Image ID="imgFoto" ImageUrl="~/images/user.png" runat="server" CssClass="img-circle img-fluid" />

                                          </div>

                                      </div>
                                      <div class="col-12">
                                          <iframe id="iframeUbicacion" style="width: 100%; height: 450px;" scrolling="No" frameborder="0" runat="server"></iframe>
                                      </div>
                                  </div>

                              </div>
                          </div>
                      </ContentTemplate>
                  </asp:UpdatePanel>

              </div>
            
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
    
    
    
</asp:Content>
<asp:Content  ID="Content4" ContentPlaceHolderID="script" runat="server">    

    <script type="text/javascript">
          var prm = Sys.WebForms.PageRequestManager.getInstance();
          if (prm != null) {
              prm.add_endRequest(function (sender, e) {
                  if (sender._postBackSettings.panelsToUpdate != null) {
                      window.onload = function () {

                          $(".tableFiltro").DataTable(
                          {
                              language: {
                                  "sProcessing": "Procesando...",
                                  "sLengthMenu": "Mostrar _MENU_ registros",
                                  "sZeroRecords": "No se encontraron resultados",
                                  "sEmptyTable": "Ningún dato disponible en esta tabla =(",
                                  "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                                  "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                                  "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                                  "sInfoPostFix": "",
                                  "sSearch": "Buscar:",
                                  "sUrl": "",
                                  "sInfoThousands": ",",
                                  "sLoadingRecords": "Cargando...",
                                  "oPaginate": {
                                      "sFirst": "Primero",
                                      "sLast": "Último",
                                      "sNext": "Siguiente",
                                      "sPrevious": "Anterior"
                                  },
                                  "oAria": {
                                      "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                                      "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                                  },
                                  "buttons": {
                                      "copy": "Copiar",
                                      "colvis": "Visibilidad"
                                  }
                              }
                          }

                        );
                      };
                  }
              });
          };
</script>
</asp:Content>  