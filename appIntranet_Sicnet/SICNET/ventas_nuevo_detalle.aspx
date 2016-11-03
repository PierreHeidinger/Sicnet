<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="ventas_nuevo_detalle.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.ventas_nuevo_detalle" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titlePage" runat="server">
    <a href="ventas.aspx"> VENTAS </a> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyweb" runat="server">
    <script src="../tools/dist/lib/js/bootstrap.min.js"></script>
    <script src="../tools/dist/lib/js/jquery.min.js"></script>
    <!--script-->

    <script type="text/javascript">

        function modalItems() {
            $(window).load(function () {
                $('#modalItems').modal('show');
            });
        };

      

        function disableButton() {
            document.getElementById("AgButton").disabled = true;
        }

        function openPreview(codigo) {
            window.open('utilitarios/consolidadoVenta.aspx?cod_venta=' + codigo +'', 'sicnet', 'width=700,height=600,scrollbars=NO,resizable=YES,left=500%,top=100%');
        }

        function checkIt(evt) {

            evt = (evt) ? evt : window.event;

            var charCode = (evt.which) ? evt.which : evt.keyCode;

            if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                status = "This field accepts numbers only.";

                return false;

            }

            status = "";

            return true;

        }

    </script>


     <div class="container-fluid">
                <div class="side-body">
                    <div class="page-title">
                      
                        <asp:Button runat="server" ID="b" Text="." Width="1" Height="1" />
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nueva Venta" Width="150" CssClass="btn btn-primary" OnClick="btn_NUEVO_Click" ToolTip="REGISTRE A UNA NUEVA VENTA" />
                         <asp:Button  runat="server"  ID="btn_Preview" Text="Preview" Width="150" CssClass="btn btn-primary" OnClick="btn_Preview_Click"  ToolTip="IMPRIMA EL LISTADO VISTO EN PANTALLA" />
                       <asp:Button  runat="server"  ID="btn_Generar" Text="Generar Comprobante"  Width="150" CssClass="btn btn-warning" Enabled="false" ToolTip="EXPORTE A EXCEL EL LISTADO VISTO EN PANTALLA" />

                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-header">
                                    <div class="card-title">
                                        <asp:ImageButton runat="server" ImageUrl="../img/mas.png" Width="25" ToolTip="AGREGAR UN CLIENTE" />
                                     
                                    </div>
                                </div>
                                <div class="card-body">
                                   
                                        
                                    <table>


                                        <tr>
                                            <td>
                                                <label for="exampleInputName2">CODIGO : &nbsp;&nbsp;&nbsp; </label>
                                            </td>

                                            <td>
                                                <asp:TextBox runat="server" ID="txt_Codigo" ReadOnly="true" CssClass="form-control" ></asp:TextBox>              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="exampleInputName2">FECHA : </label>
                                            </td>

                                            <td>
                                                <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txt_Fecha_Registro" ></asp:TextBox>              
                                            </td>
                                            <td>
                                                 <asp:TextBox runat="server" Visible="false" CssClass="form-control" ID="txt_CODIGOS" ></asp:TextBox>   
                                            </td>
                                        </tr>


                                    </table>

                                            
                                   
                                        
                                        
                                      
                                   
                                </div>
                            </div>
                        </div>
                    </div>

                        <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-header">

                              
                                   <button type="button"  class="btn btn-primary btn-info" style="width:150px" data-toggle="modal" id="AgButton" data-target="#modalItems">
                                            Agregar Producto
                                   </button>


                                </div>
                                <div class="card-body">
                                   
                                         <div style="BORDER-BOTTOM-STYLE: inset; BORDER-RIGHT-STYLE: inset; WIDTH: 100%; BORDER-TOP-STYLE: inset; HEIGHT: 200px; BORDER-LEFT-STYLE: inset; overflow-x: hidden;overflow-y:auto"
															id="div_segopp">
                                                           
															<asp:GridView style="Z-INDEX: 0;font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif" id="gw_Items_Venta"  OnRowCommand="gw_Items_Venta_RowCommand" runat="server" Width="100%" Font-Size="11"
															    PageSize="19" AutoGenerateColumns="False"   BorderColor="Black" HeaderStyle-Height="30" CellPadding="3"
																GridLines="None" BackColor="White"  >
																<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
																<SelectedRowStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedRowStyle>
																<AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
																<RowStyle ForeColor="#000066"></RowStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="GrayText"></HeaderStyle>
																<Columns>
                                                                    
                                                                    <asp:BoundField DataField="COD_LOTE" ItemStyle-BackColor="Yellow" ItemStyle-Width="5%" Visible="true"  HeaderText="CODIGO"/>
																	 <asp:BoundField DataField="DESCRIPCION"  Visible="true"  HeaderText="DESCRIPCION"/>                                                                
                                                                    
																	<asp:TemplateField HeaderText="CANTIDAD">
                                                                        
                                                                        <ItemTemplate>

                                                                          <asp:TextBox runat="server" Width="50" onkeydown = "return (event.keyCode!=13);" onKeyPress="return checkIt(event)" ID="txt_Cantida_r" AutoCompleteType="Disabled" style="text-align:center"  EnableViewState="true" Text='1'></asp:TextBox>
                                                                            <asp:ImageButton runat="server" ImageUrl="~/img/actualizar.png" Width="15" CommandName="Agregar" CommandArgument="<%# Container.DataItemIndex %>"/>
                                                                        </ItemTemplate>
																	</asp:TemplateField>

                                                                    <asp:BoundField DataField="PRECIO_UNIDAD"  Visible="true"  HeaderText="P.COSTO S/."/> 
                                                                    <asp:BoundField DataField="UTILIDAD_U"  Visible="true"  HeaderText="UTIL S/."/> 
																    
                                                                    <asp:TemplateField HeaderText="P.VENTA U. S/." >
                                                                        <ItemTemplate >
                                                                          <asp:Label runat="server" Width="80" id="lbl_Total_I"  EnableViewState="true" Text='<%# Eval("PRECIO_VENTA_U") %>' ></asp:Label>
                                                                        </ItemTemplate>
																	</asp:TemplateField>

                                                              
																    <asp:TemplateField HeaderText="P.TOTAL S/.">
                                                                        <ItemTemplate >
                                                                          <asp:Label  runat="server" Width="80" id="lbl_Total" BackColor="SpringGreen" EnableViewState="true" Text='<%# Eval("PRECIO_VENTA_U") %>' ></asp:Label>
                                                                        </ItemTemplate>
																	</asp:TemplateField>

                                                                     <asp:TemplateField >
                                                                        <ItemTemplate >
                                                                          <asp:Label  runat="server" Visible="false" Width="80" id="lbl_cod_item" BackColor="SpringGreen" EnableViewState="true" Text='<%# Eval("COD_ITEM") %>' ></asp:Label>
                                                                        </ItemTemplate>
																	</asp:TemplateField>
																    
																	<asp:TemplateField>
                                                                        <ItemTemplate >
                                                                            <asp:ImageButton runat="server" ImageUrl="~/img/eliminar.gif" OnClientClick="return confirm('¿Esta seguro de desea retirar el producto?');" Width="15" CommandName="eliminar" CommandArgument="<%# Container.DataItemIndex %>"     />
                                                                        </ItemTemplate>
																	</asp:TemplateField>
																    
																   
																    
																</Columns>
                                                                <EmptyDataTemplate>
                                                                    <b>sin datos</b>
                                                                </EmptyDataTemplate>
															</asp:GridView>
                                                            
                                                            <asp:GridView style="Z-INDEX: 0;font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif" id="gw_datos_venta" Visible="false"  OnRowCommand="gw_Items_Venta_RowCommand"  runat="server" Width="100%" Font-Size="11"
															    PageSize="19" AutoGenerateColumns="False"   BorderColor="Black" HeaderStyle-Height="30" CellPadding="3"
																GridLines="None" BackColor="White"   >
																<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
																<SelectedRowStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedRowStyle>
																<AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
																<RowStyle ForeColor="#000066"></RowStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="GrayText"></HeaderStyle>
																<Columns>
                                                                    
                                                                    <asp:BoundField DataField="COD_LOTE" ItemStyle-BackColor="Yellow" HeaderText="CODIGO" />
                                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                                                                    <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" />
                                                                    <asp:BoundField DataField="PRECIO_U" HeaderText="PRECIO U. S/." />
                                                                    <asp:BoundField DataField="UTILIDAD_I" HeaderText="UTILIDAD U. S/." />
                                                                    <asp:BoundField DataField="PRECIO_VENTA" ItemStyle-BackColor="MediumSeaGreen" HeaderText="TOTAL S/." />
                                                              
																   
																    
																</Columns>
                                                                <EmptyDataTemplate>
                                                                    <b>sin datos</b>
                                                                </EmptyDataTemplate>
															</asp:GridView>


                                         </div>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                      <div class="page-title">
                          <table>

                              <tr>
                                  <td>
                                         <label for="exampleInputName2">CANTIDAD TOTAL : &nbsp;&nbsp;&nbsp; </label>
                                  </td>
                                  <td>
                                           <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" style="text-align:right"  ID="txt_Cantidad_Total" Width="120" ></asp:TextBox> 
                                  </td>
                                   <td>
                                       <label for="exampleInputName2">TOTAL P. COSTO : &nbsp;&nbsp;&nbsp; </label>
                                  </td>
                                  <td>
                                       <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" style="text-align:right"  ID="txt_TOTAL_P_COSTO" Width="120" ></asp:TextBox>  
                                  </td>
                                   <td>
                                       <label for="exampleInputName2">TOTAL UTILIDAD : &nbsp;&nbsp;&nbsp; </label>
                                  </td>
                                  <td>
                                       <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" style="text-align:right"  ID="txt_T_UTILIDAD" Width="120" ></asp:TextBox>  
                                  </td>
                                  <td>
                                       <label for="exampleInputName2">IGV : &nbsp;&nbsp;&nbsp; </label>
                                  </td>
                                  <td>
                                       <asp:TextBox runat="server" CssClass="form-control" Text="0.00" ReadOnly="true" style="text-align:right"  ID="txt_IGV_TOTAL" Width="120" ></asp:TextBox>  
                                  </td>
                                  <td>
                                      <label for="exampleInputName2">TOTAL VENTA : &nbsp;&nbsp;&nbsp; </label>
                                  </td>
                                  <td>
                                      <asp:TextBox runat="server" CssClass="form-control" BackColor="YellowGreen" Font-Bold="true" ReadOnly="true" style="text-align:right" ID="txt_TOTAL_VENTA" Width="120" ></asp:TextBox>  
                                  </td>
                                  
                              </tr>
                          </table>
                     
                    
                      
                       
                        
                        
                    </div>
                    
                       <div class="page-title" style="text-align:right">
                      
                        
                        
                         <asp:Button  runat="server"  ID="btn_Cancelar" Text="CANCELAR" OnClick="btn_Cancelar_Click" Width="150" CssClass="btn btn-danger"   />
                        <asp:Button  runat="server"  ID="btn_Grabar" OnClick="btn_Grabar_Click" Text="GRABAR" Width="150" CssClass="btn btn-success" />

                    </div>

                   </div>
   </div>

    
                                    <!-- Modal -->
                                   
                                        <div class="modal fade modal-info" id="modalItems" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" style="width:800px">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title" id="myModalLabel">Lista Productos</h4>
                                                    </div>
                                                    <div class="modal-body">                             
                                                    <asp:ScriptManager runat="server"></asp:ScriptManager >
                                                    
                                                         <table>
                                                                <tr>
                                                              
                                                                    <td>                                                 
                                                                         <asp:TextBox runat="server"  ID="txt_bus_nombre" placeHolder="DESCRIPCION DEL PRODUCTO..." CssClass="form-control" Width="350" onkeydown = "return (event.keyCode!=13);"    ></asp:TextBox>
                                                                    </td>                                                                    
                                                                    <td style="width:48%;text-align:right">    
                                                                          <asp:Button runat="server" ID="btn_Buscar" Width="150" Text="Buscar" CssClass="btn btn-info" OnClick="btn_Buscar_Click" />              
                                                                    </td>
                                            
                                          
                                            
                                                                </tr>
                                                        </table>
                                                         
                                                        &nbsp;
                                                        &nbsp;
                                                        &nbsp;
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                          
                                                        <div style="BORDER-BOTTOM-STYLE: inset; BORDER-RIGHT-STYLE: inset; WIDTH: 100%; BORDER-TOP-STYLE: inset; HEIGHT: 200px; BORDER-LEFT-STYLE: inset; overflow-x: hidden;overflow-y:auto"
															id="DIV">
															<asp:GridView style="Z-INDEX: 0;font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif" id="gw_items" runat="server" Width="100%" Font-Size="11"
																Font-Names="Verdana" PageSize="19" AutoGenerateColumns="False"  BorderWidth="1px" BorderColor="Black" HeaderStyle-Height="30" CellPadding="3"
																GridLines="None" BackColor="White">
																<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
																<SelectedRowStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedRowStyle>
																<AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
																<RowStyle ForeColor="#000066"></RowStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="GrayText"></HeaderStyle>
																<Columns>

                                                                  
																	<asp:BoundField  DataField="COD_LOTE" ItemStyle-Font-Bold="true" ItemStyle-BackColor="Yellow" ItemStyle-Width="5%" HeaderText="LOTE N°"/>
                                                                    <asp:BoundField  DataField="DES_ITEM" HeaderText="DESCRIPCION ITEM "/>
                                                                    <asp:BoundField  DataField="CANTIDAD_ENTRADA" HeaderText="CANTIDAD" />
                                                                    <asp:BoundField  DataField="PRECIO_VENTA_U" HeaderText="PRECIO V." />
                                                                    <asp:BoundField  DataField="FECHA_REGISTRO" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%" HeaderText="REGISTRO" />

                                                                    <asp:TemplateField ItemStyle-BackColor="YellowGreen" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox BackColor="YellowGreen" runat="server" ID="chkItem" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>									   
																    
																</Columns>
                                                                <EmptyDataTemplate>
                                                                    <b>sin datos</b>
                                                                </EmptyDataTemplate>
															</asp:GridView>
                                                   

                                                         </div>
                                                      
                                                   </ContentTemplate>    

                                                
                                                        <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="btn_Buscar" EventName="Click" />
                                                        </Triggers>
                                                        </asp:UpdatePanel>
                                                    
                                                      
                                                        <div class="modal-footer">
                                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                                        <asp:Button runat="server" ID="btn_Cargar" CssClass="btn btn-info" OnClick="btn_Cargar_Click" Text="CARGAR" />
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                            </div>
                                                          

</asp:Content>
