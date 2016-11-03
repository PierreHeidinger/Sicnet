<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="ventas_web.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.ventas_web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlePage" runat="server">
    PEDIDOS-WEB
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyweb" runat="server">


    
    
 <div class="container-fluid">
                <div class="side-body">
                     <div class="page-title">
                         
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo Venta?" Width="150" CssClass="btn btn-primary"  ToolTip="REGISTRE  UNA NUEVA VENTA" />
                         <asp:Button  runat="server"  ID="btn_IMPRIMIR" Text="Imprimir?" Width="150" CssClass="btn btn-primary"  ToolTip="IMPRIMA EL LISTADO VISTO EN PANTALLA" />
                       <asp:Button  runat="server"  ID="btn_EXCEL"  Text="Exportar Excel" Width="150" CssClass="btn btn-success" Enabled="True" ToolTip="EXPORTE A EXCEL EL LISTADO VISTO EN PANTALLA" />
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                              
                                
                                <div class="card-body">

                                    <!-- FILTROS RAPIDOS -->
                                    <table>
                                        <tr>
                                            
                                            <td>  
                                                <label for="exampleInputName2">Nº VEN :</label>                                               
                                                 <asp:TextBox runat="server" placeholder="CODIGO" ID="txt_N_v" onKeyPress="return checkIt(event)" CssClass="form-control" Width="150" ></asp:TextBox>                                              
                                              
                                            </td>
                                             <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>
                                            <td> 
                                                 <label for="exampleInputName2">DESDE :</label>                                            
                                                 <asp:TextBox runat="server" ID="txt_Fec1"  CssClass="form-control" Width="150"></asp:TextBox>
                                               
                                            </td>
                                           
                                               <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>                                        
                                            <td>  
                                                <label for="exampleInputName2">HASTA :</label>                                               
                                                 <asp:TextBox runat="server" ID="txt_Fec2"  CssClass="form-control" Width="150"></asp:TextBox>
                                             
                                            </td>
                                          
                                            
                                        </tr>
                                    </table>
                                   <!-- // FILTROS RAPIDOS -->
                                    <hr />
                                      <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                      <ContentTemplate>
                                      <asp:ScriptManager runat="server"></asp:ScriptManager>
                                         <div style="overflow:auto;height:400px;width:100%">
                                                                                              <asp:DataGrid ID="dg_listado_al"  runat="server" Width="100%"  Font-Names="Verdana" Enabled="false" Font-Size="11" style="font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif"
                                                                                                  PageSize="19" GridLines="Both"  BorderWidth="0px" AutoGenerateColumns="false"  HeaderStyle-Height="30" BorderStyle="Solid" BorderColor="Gray" ItemStyle-Height="30" OnItemDataBound="dg_listado_al_ItemDataBound"  >
                                                                                                  <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE" />
                                                                                                  <SelectedItemStyle  Font-Bold="true" ForeColor="#F7F7F7" BackColor="#738A9C"  />
                                                                                                  <AlternatingItemStyle BackColor="WhiteSmoke" />
                                                                                                  <ItemStyle ForeColor="#000066" />
                                                                                                  <HeaderStyle  Font-Bold="true" HorizontalAlign="center" ForeColor="White" BackColor="#1ABC9C"/>
                                                                                                  <Columns>

                                                                                                      <asp:TemplateColumn HeaderText="CODIGO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%" ForeColor="White"  BackColor="#738A9C"  />
                                                                                                          <ItemTemplate>
                                                                                                              <a   href="ventas_nuevo_detalle.aspx?cod_venta=<%# Eval("COD_PED_WEB") %>">
                                                                                                                  2016VW - <%# Eval("COD_PED_WEB") %>
                                                                                                              </a>
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                      <asp:TemplateColumn HeaderText="FEC-H-REG">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>
                                                                                                             
                                                                                                                  <%# Eval("REGISTRO") %>
                                                                                                            
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                      <asp:TemplateColumn HeaderText="T. VENTA">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>
                                                                                                             
                                                                                                                S/.  <%# Eval("TOTAL_VENTA") %>
                                                                                                            
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                       <asp:TemplateColumn HeaderText="ESTADO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>
                                                                                                             

                                                                                                              <asp:Label runat="server" ID="lbl_estado" Text ='<%# Eval("ESTADO") %>'></asp:Label>
                                                                                                                  
                                                                                                            
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                      <asp:TemplateColumn HeaderText="CONDICION">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>
                                                                                                             

                                                                                                              <asp:Label runat="server" ID="lbl_CONDICION" Text ='<%# Eval("CONDICION_X") %>'></asp:Label>
                                                                                                                  
                                                                                                            
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                  </Columns>
                                                                                 
                                                                                              </asp:DataGrid>
                                        </div>
                                     &nbsp;
                                     &nbsp;
                                     <div style="width:100%;text-align:right">
                                           <label for="exampleInputName2">TOTAL VENTAS : S/. <asp:Label Text="0" Font-Size="Larger" ForeColor="red" runat="server" ID="Total_Lista"></asp:Label></label>   
                                              
                                            
                                     </div>


                                </div>
                                 </ContentTemplate>
                                <Triggers>                                    
                                     <asp:AsyncPostBackTrigger ControlID="txt_Fec1" EventName="TextChanged" />
                                </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
      


</asp:Content>
