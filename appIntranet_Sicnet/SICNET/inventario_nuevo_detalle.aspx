<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="inventario_nuevo_detalle.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.inventario_nuevo_detalle"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="titlePage" runat="server">
  <a href="inventario.aspx">INVENTARIO</a>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyweb" runat="server">

   
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="container-fluid">
                <div class="side-body">
                    <div class="page-title">
                     
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo Item?" Width="150" CssClass="btn btn-primary"   OnClick="btn_NUEVO_Click" />                       
                        <asp:Button  runat="server"  ID="btn_Editar" Text="Editar" Width="150" CssClass="btn btn-primary" OnClick="btn_Editar_Click" />
                         <asp:Button  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"   />
                          <asp:Button  runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-success"  />
                                                  
                           

                    </div>
                     <asp:Literal runat="server"  ID="div_error" Visible="false"></asp:Literal> 
                     <asp:Literal runat="server"  ID="div_confirmacion" Visible="false"></asp:Literal> 
                    

                <!-- MIGRACION-->
                <div class="row">
                        <div class="col-xs-12">
                            <div class="card">                                

                                <div class="card-body">
                                    <div class="row no-margin">
                                       
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                   <div style="background-color:#1ABC9C;width:100%;height:30px;text-align:center;vertical-align:bottom">
                                                   <strong style="color:white;">DATOS PRODUCTO</strong>
                                                       
                                                   </div>
                                                   
                                                    <hr />
                                                        <div class="form-group">
                                                              <label for="exampleInputName2" >TIPO  &nbsp;&nbsp</label> <br />                                               
                                                              <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"  ID="cbo_Tipo" Width="130">
                                                                  <asp:ListItem Value="0" Selected="True">--Seleccione--</asp:ListItem>
                                                                  <asp:ListItem Value="1">Individual</asp:ListItem>
                                                                  <asp:ListItem Value="2">Compuesto</asp:ListItem>
                                                              </asp:DropDownList>
                                                    &nbsp;&nbsp;                                                            
                                                        </div>
                                                        <div class="form-group">
                                                              <label for="exampleInputName2" >CATEGORIA  &nbsp;&nbsp; </label>  <br />                                              
                                                              <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"  ID="cbo_categoria" Width="130" AutoPostBack="True" OnSelectedIndexChanged="cbo_categoria_SelectedIndexChanged">                                                          
                                                              </asp:DropDownList>  
                                                        </div>
                                                        <div class="form-group">
                                                              <label for="exampleInputName2" >SUB-CATEGORIA : &nbsp;&nbsp;</label>  <br />                                              
                                                              <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"   Width="130" ID="cbo_sub_categoria" OnSelectedIndexChanged="cbo_sub_categoria_SelectedIndexChanged" AutoPostBack="True">
                                                                  <asp:ListItem Value="0" Selected="True">--Seleccione--</asp:ListItem>
                                                              </asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                              <label for="exampleInputName2">MARCA  &nbsp;&nbsp;</label>  <br />                                              
                                                              <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"  Width="130" ID="cbo_Marca"> 
                                                                  <asp:ListItem Value="100" Selected="True">--Seleccione--</asp:ListItem>                                                         
                                                              </asp:DropDownList> 
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="exampleInputName2">DESCRIPCION : &nbsp;&nbsp;</label>                                                
                                                             <asp:TextBox  runat="server" ID="txt_Descripcion" CssClass="form-control" placeHolder="Nombre y Detalle de producto..." AutoCompleteType="Disabled"></asp:TextBox>                                                
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputName2">COMENTARIOS : &nbsp;&nbsp;</label>                                                
                                                             <asp:TextBox runat="server" ID="txt_Comentarios"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                                
                                                        </div>                   
                                                       
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    
                                                          <div class="form-group">
                                                             <label for="exampleInputName2" >CODIGO-NET  &nbsp;&nbsp</label>                                                
                                                             <asp:TextBox runat="server" ID="txt_Codigo"   style="background-color:#E0E0E0;font-family:Verdana;text-transform:uppercase;border-top:solid 1px black;border-left:solid 1px black" CssClass="form-control" AutoCompleteType="Disabled" ReadOnly="True" ></asp:TextBox>                                                 
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >CODIGO-COMERCIAL &nbsp;&nbsp</label>                                                
                                                            <asp:TextBox runat="server" ID="txt_Cod_Comercial"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                                 
                                                        </div>
                                                       <div class="form-group">
                                                            <label for="exampleInputName2" >ESTADO  &nbsp;&nbsp</label>    <br />                                            
                                                             <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"   ID="cbo_Estado">                                                          
                                                                  <asp:ListItem Selected="True" Value="1">Disponible</asp:ListItem>
                                                                  <asp:ListItem Value="2">Descontinuado</asp:ListItem>
                                                              </asp:DropDownList> 
                                                        </div>
                                                       <div class="form-group">
                                                            <label for="exampleInputName2" >FECHA-REGISTRO : &nbsp;&nbsp</label> <br />                                                   
                                                             <asp:Label runat="server" for="exampleInputName2" id="lbl_Fecha_registo" ></asp:Label>
                                                        </div>
                                                       
                                                      
                                                </div>
                                            </div>
                                        </div>                                        
                                         
                                    </div>
                                </div>                               
                            </div>
                        </div>
                    </div>

                   <div class="row">
                        <div class="col-xs-12">
                            <div class="card">                                

                                <div class="card-body">
                                    <div class="row no-margin">
                                       
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    <div style="background-color:#1ABC9C;width:100%;height:30px;text-align:center;vertical-align:bottom">
                                                        <strong style="color:white">ESTRUCTURA DE COSTOS </strong>
                                                    </div>
                                                    <hr />
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >COSTO ITEM S/.  &nbsp;&nbsp</label>                                                
                                                             <asp:TextBox style="text-align:right" ReadOnly="true" Text="0.00" onkeyup="Calcular()" runat="server" ID="txt_Costo_Item"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                                                                                                          
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >COSTO SERVICIO  &nbsp;&nbsp; </label>                                                 
                                                             <asp:TextBox runat="server" ID="txt_costo_servicio" onkeyup="Calcular()" text="0.00" style="text-align:right"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >PRECIO VENTA  &nbsp;&nbsp; </label>                                                  
                                                            <asp:TextBox runat="server" ID="txt_Precio_venta" ReadOnly="true" Text="0.00" style="text-align:right"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="exampleInputName2" >UTILIDAD S/.  &nbsp;&nbsp</label>                                              
                                                            <asp:TextBox runat="server" ReadOnly="true"  ID="txt_Porc_Utilidad" onkeyup="Calcular()"  Text="0" style="text-align:right" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>                                               
                                                       
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    <br />
                                                    
                                                       <div class="form-group">
                                                             <div>
                                                                    <h4>HISTORIAL DE PRECIOS ITEM :</h4>

                                                                    <!--GRID HISTORIAL-->
                                                                <div style="BORDER-BOTTOM-STYLE: inset; BORDER-RIGHT-STYLE: inset; WIDTH: 100%; BORDER-TOP-STYLE: inset; HEIGHT: 150px; BORDER-LEFT-STYLE: inset; overflow-x: hidden;overflow-y:auto"
															                id="div_segopp">
															                <asp:GridView style="Z-INDEX: 0" id="gw_items_historial" runat="server" Width="100%" Font-Size="Small"
																                Font-Names="Verdana" PageSize="19" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="3"
																                GridLines="None" BackColor="White" >
																                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
																                <SelectedRowStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedRowStyle>
																                <AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
																                <RowStyle ForeColor="#000066"></RowStyle>
																                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="DarkCyan"></HeaderStyle>
																                <Columns>

                                                                   
																	                 <asp:BoundField DataField="FECHA_ACT"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"  HeaderText="FECHA ACT"/>
                                                                                    <asp:BoundField  DataField="PRECIO_UNIDAD" ItemStyle-HorizontalAlign="Left" HeaderText="PRECIO UNIDAD"/>
                                                                                    <asp:BoundField  DataField="UTILIDAD_U" ItemStyle-HorizontalAlign="Left" HeaderText="UTILIDAD" />
                                                                                    <asp:BoundField  DataField="PRECIO_VENTA" ItemStyle-HorizontalAlign="Left" HeaderText="PRECIO VENTA" />
                                                                   
																	
																    
																   
																   
																    
																   
																    
																                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <b>sin datos</b>
                                                                                </EmptyDataTemplate>
															                </asp:GridView></div>

                                                                </div> 
                                                        </div>
                                                        
                                                        
                                                      
                                                </div>
                                            </div>
                                        </div>                                        
                                         
                                    </div>
                                </div>                               
                            </div>
                        </div>
                    </div>      

                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">                                

                                <div class="card-body">
                                    <div class="row no-margin">
                                       
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                   <div style="background-color:#1ABC9C;width:100%;height:30px;text-align:center;vertical-align:bottom">
                                                   <strong style="color:white">DATOS Y ESTRUCTURA WEB</strong>
                                                   </div>
                                                    <hr />
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >DESPONIBILIDAD  - WEB : &nbsp;&nbsp</label> <br />                                                
                                                            <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"   ID="cbo_Disp_Web" >                                                          
                                                              <asp:ListItem Value="1" >Si</asp:ListItem>
                                                              <asp:ListItem Value ="0" Selected="True">No</asp:ListItem>
                                                           </asp:DropDownList>                                                            
                                                        </div>
                                                        <div class="form-group">
                                                             <label for="exampleInputName2" >PRECIO  - WEB : &nbsp;&nbsp</label>                                                
                                                             <asp:TextBox    runat="server" ID="txt_Precio_web" Text="0.00"  CssClass="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >DESCRIPCION WEB : &nbsp;&nbsp</label>                                               
                                                            <asp:TextBox   style="resize:none"  runat="server" ID="txt_Descripcion_web"  CssClass="form-control" TextMode="MultiLine" AutoCompleteType="Disabled"></asp:TextBox>                                                 
                                                        </div>                                                     
                                                       
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    <br />
                                                    
                                                      
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">IMAGEN WEB</label>                                                      
                                                            <asp:Image runat="server" id="img_Web" GenerateEmptyAlternateText="true"  AlternateText="No se ha cargado ninguna imagen." height="300" width="400" CssClass="img-responsive" />
                                                            <br />
                                                            <asp:FileUpload runat="server"  ID="img_File"/>
                                                            <asp:TextBox Visible="false" runat="server" ID="txt_Stock" Text="0"   CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                        
                                                      
                                                </div>
                                            </div>
                                        </div>                                        
                                         
                                    </div>
                                </div>                               
                            </div>
                        </div>
                    </div>



                     <div class="page-title" style="text-align:right">
                      
                                                        <asp:Button  runat="server"  ID="btn_Cancelar" Text="CANCELAR" Width="150" CssClass="btn btn-danger" OnClick="btn_Cancelar_Click"   />
                                                        <asp:Button  runat="server"  ID="btn_Grabar" Text="GRABAR" Width="150" CssClass="btn btn-success" OnClick="btn_Grabar_Click" />
                                                         
                  

                     
                                        <!-- Modal Error -->

                      </div>
            </div>
        



        </div>



</asp:Content>
