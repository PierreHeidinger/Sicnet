<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="inventario.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.inventario" MaintainScrollPositionOnPostback="true"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="titlePage" runat="server">
    INVENTARIO
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyweb" runat="server">
     <script src="../tools/dist/lib/js/jquery.min.js"></script>
      
    <script>

        
        <%--  $(document).ready(function() {

          $("#<%= dg_listado_items.ClientID%> tr:has(td)").hover(function() {

              $(this).css("background-color", "#8EC3B1");

           }, function() {

           $(this).css("background-color", "#ffffff");

          });

        })--%>




    </script>

    

 <div class="container-fluid">
                <div class="side-body">
                     <div class="page-title">                 
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo Item?" Width="150" CssClass="btn btn-primary"    OnClick="btn_NUEVO_Click" />                       
                        <asp:Button  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"  />
                         <asp:Button  runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-primary"   />
                          <asp:Button  runat="server"  ID="btn_Excel" Text="Excel" OnClick="btn_Excel_Click" Width="150" CssClass="btn btn-success"   />
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                
                                
                                <div class="card-body">

                                    <!-- FILTROS RAPIDOS -->
                                    <div class="form-group">

                                        <table>
                                          <tr>
                                              <td>
                                                  
                                                  <asp:TextBox runat="server" ID="txt_Codigo"  placeHolder="Codigo..."  CssClass="form-control" OnTextChanged="txt_Codigo_TextChanged1" ></asp:TextBox>                                           
                                              </td>
                                              <td>
                                                  &nbsp;
                                                  &nbsp;
                                              </td>
                                              <td>
                                                  
                                                  <asp:TextBox runat="server" ID="txt_Descripcion" placeHolder="Descripcion..." CssClass="form-control"   AutoCompleteType="Disabled" OnTextChanged="txt_Descripcion_TextChanged"></asp:TextBox>
                                              </td>
                                              <td>
                                                  &nbsp;
                                                  &nbsp;
                                              </td>
                                              <td>                                                  
                                                   <asp:DropDownList runat="server" ID="cbo_web" CssClass="checkbox3 checkbox-inline checkbox-check checkbox-light" AutoPostBack="true" OnSelectedIndexChanged="cbo_web_SelectedIndexChanged">
                                                       <asp:ListItem Value="%">-- DISP WEB--</asp:ListItem>
                                                       <asp:ListItem Value="1">SI</asp:ListItem>
                                                       <asp:ListItem Value="0">NO</asp:ListItem>
                                                   </asp:DropDownList>
                                              </td>
                                          </tr>
                                         </table>                                                                                  
                                    </div>

                                    
                                   <!-- // FILTROS RAPIDOS -->
                                    <hr />
                                    
                                         <div style="overflow:auto;height:100%;width:100%">
                                                                                              <asp:DataGrid ID="dg_listado_items" runat="server" Width="100%"   Font-Names="Verdana" Enabled="false" Font-Size="11" style="font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif"
                                                                                                  PageSize="2"  GridLines="Both"  BorderWidth="0px" AutoGenerateColumns="false"  HeaderStyle-Height="30" BorderStyle="Solid" BorderColor="Gray" ItemStyle-Height="30" >
                                                                                                  <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE" />
                                                                                                  <SelectedItemStyle  Font-Bold="true" ForeColor="#F7F7F7" BackColor="#738A9C" />
                                                                                                  <AlternatingItemStyle BackColor="WhiteSmoke" />
                                                                                                  <ItemStyle ForeColor="#000066" />
                                                                                                  <HeaderStyle  Font-Bold="true" HorizontalAlign="center" ForeColor="White" BackColor="#1ABC9C"/>
                                                                                                  <Columns>
                                                                                                      <asp:TemplateColumn HeaderText="CODIGO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="4%" ForeColor="White" BackColor="#738A9C"  />
                                                                                                          <ItemTemplate>
                                                                                                              <a   href="inventario_nuevo_detalle.aspx?cod_item=<%# Eval("COD_ITEM") %>">
                                                                                                                  PR2016-<%#  Eval("COD_ITEM") %></a>
                                                                                                  

                                                                                                          </ItemTemplate>


                                                                                                      </asp:TemplateColumn>
                                                                                                      <asp:TemplateColumn HeaderText="FEC REG">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="3%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%#   Eval("FECHA_REGISTRO") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                       <asp:TemplateColumn HeaderText="CATEGORIA">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="3%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%#   Eval("CATEGORIA") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                    <asp:TemplateColumn HeaderText="SUB-CATEGORIA">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="3%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%#   Eval("SUB_CATEGORIA") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="DESCRIPCION">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="9%" />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("DES_ITEM") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="STOCK">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("STOCK") %>    U.                                                                                             
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                       
                                                                                                       
                                                                                                          <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="PRECIO COMPRA">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="3%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                  S/. <%# Eval("COSTO_ITEM") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                          
                                                                                                          <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="PRECIO VENTA">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="3%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                  S/.  <%# Eval("PRECIO_VENTA") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                       <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="UTILIDAD S/.">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                S/.   <%# Eval("GES") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                    
                                                                                                       <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Center" HeaderText="WEB">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="1%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("WEB") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                        

                                                                                                  </Columns>
                                                                                 
                                                                                              </asp:DataGrid>
                                                                                               </div>

                                        


                                </div>
                            </div>
                        </div>

                          
                    </div>



                   

                </div>
            </div>
        
      





</asp:Content>
