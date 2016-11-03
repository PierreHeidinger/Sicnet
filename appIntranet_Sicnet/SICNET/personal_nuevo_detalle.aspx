<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="personal_nuevo_detalle.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.personal_nuevo_detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlePage" runat="server">
   <a href="personal.aspx">PERSONAL</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyweb" runat="server">
    
    <asp:ScriptManager runat="server"></asp:ScriptManager>

     <div class="container-fluid">
                <div class="side-body">
                    <div class="page-title">

                         <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo" Width="150" CssClass="btn btn-primary" OnClick="btn_NUEVO_Click"   />                       
                         <asp:Button  runat="server"  ID="btn_Editar" Text="Editar" Width="150" CssClass="btn btn-primary" OnClick="btn_Editar_Click"   />
                         <asp:Button  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"   />
                         <asp:Button  runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-success"  />

                         <asp:Literal runat="server"  ID="div_error" Visible="false"></asp:Literal> 
                         <asp:Literal runat="server"  ID="div_confirmacion" Visible="false"></asp:Literal> 
                    </div>

                   <div class="row">
                        <div class="col-xs-12">
                            <div class="card">                                

                                <div class="card-body">
                                    <div class="row no-margin">
                                       
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                   <strong style="color:maroon;text-decoration:underline">DATOS PERSONALES</strong>
                                                    <hr />
                                                        <div class="form-group">
                                                            <label for="exampleInputName2">Codigo </label>
                                                            <asp:TextBox runat="server" ID="txt_codigo" style="border-top:solid 1px black;border-left:solid 1px black" ReadOnly="true" CssClass="form-control" ></asp:TextBox>                                                            
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Nombres</label>
                                                            <asp:TextBox runat="server" ID="txt_nombres"  CssClass="form-control" ></asp:TextBox>  
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Apellidos</label>
                                                            <asp:TextBox runat="server" ID="txt_apellidos"  CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                             <table>
                                                                 <tr>
                                                                     <td>
                                                                         <label for="exampleInputEmail2">Fecha Nacimiento</label>                                                             
                                                                          <asp:TextBox runat="server" ID="txt_fecha_nacimiento"  placeHolder="dd/MM/yyyy" CssClass="form-control"  ></asp:TextBox>
                                                                     </td>
                                                                     <td style="vertical-align:bottom">
                                                                          <img src="../img/icono_calendario.png" id="IMG_FECHA" width="35" />  
                                                                            <ajaxtoolkit:CalendarExtender runat="server" id="CalendarExtendfer1"  TargetControlID="txt_fecha_nacimiento" Format="dd/MM/yyyy"  PopupButtonID="IMG_FECHA">
                                                                            </ajaxtoolkit:CalendarExtender>
                                                                     </td>
                                                                 </tr>
                                                             </table>  
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="exampleInputEmail2">Email</label>                                                            
                                                            <asp:TextBox runat="server" ID="txt_Email" placeholder="jane.doe@example.com"  CssClass="form-control" ></asp:TextBox>  

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Sexo</label><br />
                                                            <asp:RadioButtonList CssClass="checkbox3 checkbox-inline checkbox-check checkbox-light" RepeatDirection="Horizontal" runat="server" ID="rdo_Sexo">
                                                                   <asp:ListItem Value="1" Selected="True">
                                                                        Masculino
                                                                   </asp:ListItem>
                                                                   <asp:ListItem Value="2">
                                                                        Femenino
                                                                   </asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                       
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    <strong style="color:maroon;text-decoration:underline">DIRECCION </strong>
                                                    <hr />
                                                          <div class="form-group">
                                                            <label for="exampleInputName2">Departamento</label>
                                                            <asp:TextBox runat="server" ID="txt_Departamento"   CssClass="form-control" ></asp:TextBox>  
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Provincia</label>
                                                             <asp:TextBox runat="server" ID="txt_provincia"   CssClass="form-control" ></asp:TextBox>  
                                                        </div>
                                                       <div class="form-group">
                                                            <label for="exampleInputEmail2">Distrito</label>
                                                            <asp:TextBox runat="server" ID="txt_Distrito"   CssClass="form-control" ></asp:TextBox> 
                                                        </div>
                                                       <div class="form-group">
                                                            <label for="exampleInputEmail2">Direccion</label>
                                                            <asp:TextBox runat="server" ID="txt_direccion"   CssClass="form-control" ></asp:TextBox> 
                                                        </div>
                                                       <div class="form-group">
                                                            <label for="exampleInputEmail2">Telefono-Celular</label>
                                                            <asp:TextBox runat="server" ID="txt_telefono"   CssClass="form-control" ></asp:TextBox>
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
                                                   <strong style="color:maroon;text-decoration:underline">DATOS EMPRESA</strong>
                                                    <hr />
                                                        <div class="form-group">
                                                            <label for="exampleInputName2">Cargo </label>
                                                            <asp:TextBox runat="server" ID="txt_cargo"  CssClass="form-control" ></asp:TextBox>                                                            
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Alias</label>
                                                            <asp:TextBox runat="server" ID="txt_Alias"  CssClass="form-control" ></asp:TextBox>  
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Usuario Sistema</label>
                                                            <asp:TextBox runat="server" ID="txt_usuario"  CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="exampleInputEmail2">Contraseña Sistema</label>
                                                            <asp:TextBox runat="server" ID="txt_contrasena"   CssClass="form-control"  ></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="exampleInputEmail2">Email Empresa</label>                                                            
                                                            <asp:TextBox runat="server" ID="txt_email_empresa" placeholder="jane.doe@alochelita.com"  CssClass="form-control" ></asp:TextBox>  

                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">ESTADO</label><br />
                                                            <asp:RadioButtonList CssClass="checkbox3 checkbox-inline checkbox-check checkbox-light" RepeatDirection="Horizontal" runat="server" ID="rdo_Estado">
                                                                   <asp:ListItem Value="1" Selected="True">
                                                                        Activo
                                                                   </asp:ListItem>
                                                                   <asp:ListItem Value="0">
                                                                        Inactivo
                                                                   </asp:ListItem>
                                                                    <asp:ListItem Value="2">
                                                                        Externo
                                                                   </asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                       
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    <br />
                                                    <br />
                                                    <br />
                                                       <div class="form-group">
                                                             <table>
                                                                 <tr>
                                                                     <td>
                                                                         <label for="exampleInputEmail2">Fecha Ingreso</label>                                                             
                                                                          <asp:TextBox runat="server" ID="txt_Fecha_Ingreso"  CssClass="form-control"  ></asp:TextBox>
                                                                     </td>
                                                                     <td style="vertical-align:bottom">
                                                                          <img src="../img/icono_calendario.png" id="IMG_FECHA1" width="35" />  
                                                                            <ajaxtoolkit:CalendarExtender runat="server" id="CalendarExtender1"  TargetControlID="txt_Fecha_Ingreso" Format="dd/MM/yyyy"  PopupButtonID="IMG_FECHA1">
                                                                            </ajaxtoolkit:CalendarExtender>
                                                                     </td>
                                                                 </tr>
                                                             </table>  
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail2">Foto</label>
                                                            <asp:Image  GenerateEmptyAlternateText="true"   AlternateText="No se ha cargado ninguna imagen." height="300" width="400" runat="server" CssClass="img-responsive" ID="img_personal" />                                                            
                                                            
                                                            <br />
                                                            <asp:FileUpload runat="server" ID="img_file" />

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
                      
                               <asp:Button  runat="server"  ID="btn_Cancelar" Text="CANCELAR" Width="150" CssClass="btn btn-danger" OnClick="btn_Cancelar_Click"  />
                                <asp:Button  runat="server"  ID="btn_Grabar" Text="GRABAR" Width="150" CssClass="btn btn-success" OnClick="btn_Grabar_Click"  />                                                 

                                       

                      </div>
                   

                    </div>
                  </div>
    
</asp:Content>
