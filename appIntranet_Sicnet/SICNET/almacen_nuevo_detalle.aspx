<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="almacen_nuevo_detalle.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.almacen_nuevo_detalle" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titlePage" runat="server">
    <a href="almacen.aspx">ALMACEN</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyweb" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    
    <script type="text/javascript">

        function Calcular() {
           
            var a = $("#<%=txt_cantidad.ClientID%>").val();
            var b = $("#<%=txt_precio_lote.ClientID%>").val();
            var c = $("#<%=txt_precio_unidad.ClientID%>").val();
            var g = $("#<%=txt_Utilidad.ClientID%>").val();
           
            var d = parseFloat(a);
            var e = parseFloat(b);
            var f = parseFloat(c);
            var h = parseFloat(g);
            

            document.getElementById("<%= txt_precio_lote.ClientID %>").value.fixed(2);

            document.getElementById("<%= txt_precio_unidad.ClientID %>").value = ((e/d)).toFixed(2);
            
            document.getElementById("<%= txt_precio_venta.ClientID %>").value = ((e/d) + h ).toFixed(2);

          
        };

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
                     
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo Item?" Width="150" CssClass="btn btn-primary" OnClick="btn_NUEVO_Click"   />                       
                        <asp:Button  runat="server"  ID="btn_Editar" Text="Editar" Width="150" CssClass="btn btn-primary" OnClick="btn_Editar_Click"  />
                         <asp:Button  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"   />
                          <asp:Button  runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-success"  />
                                                  
                           
                        <asp:Literal runat="server"  ID="div_error" Visible="false"></asp:Literal> 
                         <asp:Literal runat="server"  ID="div_confirmacion" Visible="false"></asp:Literal> 
                    </div>
      
                    
                    


                  <!-- MIGRACION -->


                <div class="row">
                        <div class="col-xs-12">
                            <div class="card">                                

                                <div class="card-body">
                                    <div class="row no-margin">
                                       
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                   <strong style="color:maroon;text-decoration:underline">PRODUCTO  </strong>
                                                    <hr />
                                                        <div class="form-group">
                                                            <label for="exampleInputName2" >CODIGO  &nbsp;&nbsp</label><br />
                                                            <asp:TextBox runat="server" ID="txt_Codigo" ReadOnly="true" style="border-top:solid 1px black;border-left:solid 1px black" onkeydown = "return (event.keyCode!=13);" Width="400" CssClass="form-control" Visible="false" AutoCompleteType="Disabled"></asp:TextBox>
                                                            <label>PR2016-</label><asp:Label runat="server"  ID="lbl_COD_Lote" CssClass="text-danger"></asp:Label>                                                            
                                                        </div>
                                                        <div class="form-group">
                                                             <label for="exampleInputName2" >PRODUCTO  &nbsp;&nbsp</label>
                                                            <table>                                                                 
                                                                <tr>                                                                  
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txt_Item" ReadOnly="true" style="border-top:solid 1px black;border-left:solid 1px black" onkeydown = "return (event.keyCode!=13);"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                                        <asp:Label runat="server" ID="lbl_cod_item" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:ImageButton runat="server" ImageUrl="~/img/mas.png" Width="25" ID="img_agregar_item" OnClick="img_agregar_item_Click" />
                                                                    </td>
                                                                </tr> 
                                                            </table>
                                                        </div>
                                                        <div class="form-group">                                                            
                                                            <label for="exampleInputName2" >COMENTARIOS  &nbsp;&nbsp</label>                          
                                                            <asp:TextBox runat="server" ID="txt_Comentarios"  style="resize:none" onkeydown = "return (event.keyCode!=13);" CssClass="form-control" AutoCompleteType="Disabled" TextMode="MultiLine"></asp:TextBox>                      
                                                        </div>
                                                         <div class="form-group">
                                                             <label for="exampleInputName2" >ESTADO : &nbsp;&nbsp; </label>    <br />                                             
                                                             <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"  ID="cbo_Estado" Enabled="false" >                                                         
                                                                 <asp:ListItem Selected="True"  Value="1">VIGENTE</asp:ListItem>
                                                                 <asp:ListItem  Value="2">AGOTADO</asp:ListItem>
                                                             </asp:DropDownList> 
                                                        </div>
                                                         
                                                       
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="card">                                                
                                                <div class="card-body">
                                                    <strong style="color:maroon;text-decoration:underline">DATOS S/. </strong>
                                                    <hr />
                                                        <div class="form-group">
                                                             <label for="exampleInputName2" >CANTIDAD ENTRANTE &nbsp;&nbsp</label>                                                
                                                             <asp:TextBox style="text-align:right;background-color:darkseagreen" Text="0" onkeydown = "return (event.keyCode!=13);" onKeyPress="return checkIt(event)" onkeyup="Calcular()" runat="server" ID="txt_cantidad"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">                                                            
                                                             <label for="exampleInputName2" >PRECIO DE LOTE : &nbsp;&nbsp</label>
                                                             <asp:TextBox runat="server"  ID="txt_precio_lote" onkeydown = "return (event.keyCode!=13);" onkeyup="Calcular()" onKeyPress="return checkIt(event)" Text="0.00" style="text-align:right" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                              
                                                        </div>
                                                       <div class="form-group">                                                           
                                                              <label for="exampleInputName2" >UTILIDAD S/.  : &nbsp;&nbsp</label>                                             
                                                              <asp:TextBox style="text-align:right" Text="0.00" onkeydown = "return (event.keyCode!=13);" onkeyup="Calcular()" onKeyPress="return checkIt(event)" runat="server" ID="txt_Utilidad"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                                 
                                                        </div>
                                                       <div class="form-group">
                                                              <label for="exampleInputName2" >PRECIO UNIDAD : &nbsp;&nbsp; </label>                                                   
                                                              <asp:TextBox runat="server" ID="txt_precio_unidad"  onkeydown = "return (event.keyCode!=13);" onKeyPress="return checkIt(event)" text="0.00" style="text-align:right;background-color:lightgray"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                                  
                                                        </div>
                                                       <div class="form-group">
                                                            <label for="exampleInputName2" >PRECIO VENTA : &nbsp;&nbsp; </label>
                                                            <asp:TextBox runat="server" ID="txt_precio_venta" onkeydown = "return (event.keyCode!=13);" onKeyPress="return checkIt(event)" text="0.00" style="text-align:right;background-color:lightgray"  CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>                                                                                         

                                                        </div>
                                                         <div class="form-group">
                                                            <label for="exampleInputName2" >OFERTAR : &nbsp;&nbsp; </label><br />                                                    
                                                             <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle"  ID="cbo_oferta" Width="190" >                                                         
                                                                 <asp:ListItem  Value="1">SI</asp:ListItem>
                                                                 <asp:ListItem Selected="True" Value="2">NO</asp:ListItem>
                                                             </asp:DropDownList>
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
                                                        <asp:Button  runat="server"  ID="btn_Grabar" Text="GRABAR" Width="150" CssClass="btn btn-success" OnClick="btn_Grabar_Click" />
                                                         
                  

                     
                                        <!-- Modal Error -->

                      </div>
            </div>
        



        </div>


</asp:Content>
