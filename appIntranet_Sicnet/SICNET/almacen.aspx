<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="almacen.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.almacen" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titlePage" runat="server">
    ALMACEN
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyweb" runat="server">

    
      
 <div class="container-fluid">
                <div class="side-body">
                     <div class="page-title">
                       
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo Lote" Width="150" CssClass="btn btn-primary" OnClick="btn_NUEVO_Click"   />                       
                        <asp:Button  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"  />
                         <asp:Button  runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-primary"  />
                          <asp:Button  runat="server"  ID="btn_Excel" Text="Excel" OnClick="btn_Excel_Click" Width="150" CssClass="btn btn-success"  />
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                
                                
                                <div class="card-body">

                                    <!-- FILTROS RAPIDOS -->
                                    <table>
                                        <tr>
                                            <td>
                                                <label for="exampleInputName2">ITEM :</label>
                                                  <asp:TextBox runat="server" placeholder="N0MBRE DEL ITEM" ID="txt_Item"  OnTextChanged="txt_Item_TextChanged" CssClass="form-control" Width="150" AutoCompleteType="Disabled"></asp:TextBox>
                                              
                                            </td>
                                             <td>
                                                 &nbsp;
                                                 &nbsp;
                                             </td>
                                            <td>                                                 
                                               <label for="exampleInputName2">DESDE :</label>
                                              <asp:TextBox runat="server" ID="txt_fecha1" CssClass="form-control" OnTextChanged="txt_fecha1_TextChanged" Width="250"></asp:TextBox>
                                              
                                            </td>
                                            <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>
                                             
                                            <td>                                                 
                                               <label for="exampleInputName2">HASTA :</label>
                                              <asp:TextBox runat="server" ID="txt_fecha2" CssClass="form-control" OnTextChanged="txt_fecha2_TextChanged" Width="250"></asp:TextBox>
                                              
                                            </td>
                                             <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>
                                            <td>
                                                 <label for="exampleInputName2">ESTADO :</label> <br />
                                                 <asp:DropDownList runat="server" ID="cbo_Estado" CssClass="btn btn-default dropdown-toggle"  OnSelectedIndexChanged="cbo_Estado_SelectedIndexChanged" Width="250" Height="30" AutoPostBack="True">
                                                     <asp:ListItem Value="%">--TODOS--</asp:ListItem>
                                                     <asp:ListItem Value="1">VIGENTE</asp:ListItem>
                                                      <asp:ListItem Value="2">AGOTADO</asp:ListItem>
                                                 </asp:DropDownList>
                                            </td>
                                           
                                           
                                          
                                            
                                        </tr>
                                    </table>
                                   <!-- // FILTROS RAPIDOS -->
                                    <hr />
                                    
                                         <div style="overflow:auto;height:100%;width:100%">
                                                                                              <asp:DataGrid ID="dg_listado_lotes" runat="server" Width="100%"   Enabled="false" Font-Size="11" style="font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif"
                                                                                                  PageSize="19" GridLines="Both"  BorderWidth="0px" AutoGenerateColumns="false"  HeaderStyle-Height="30" BorderStyle="Solid" BorderColor="Gray" ItemStyle-Height="30" >
                                                                                                  <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE" />
                                                                                                  <SelectedItemStyle  Font-Bold="true" ForeColor="#F7F7F7" BackColor="#738A9C" />
                                                                                                  <AlternatingItemStyle BackColor="WhiteSmoke" />
                                                                                                  <ItemStyle ForeColor="#000066" />
                                                                                                  <HeaderStyle  Font-Bold="true" HorizontalAlign="center" ForeColor="White" BackColor="#1ABC9C"/>
                                                                                                  <Columns>
                                                                                                      <asp:TemplateColumn HeaderText="CODIGO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="4%" ForeColor="White" BackColor="#738A9C"  />
                                                                                                          <ItemTemplate>
                                                                                                              <a   href="almacen_nuevo_detalle.aspx?cod_lote=<%# Eval("COD_LOTE") %>">
                                                                                                                   LT2016-<%# Eval("COD_LOTE") %>
                                                                                                              </a>
                                                                                                  

                                                                                                          </ItemTemplate>


                                                                                                      </asp:TemplateColumn>
                                                                                                      <asp:TemplateColumn HeaderText="FEC ENT">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="3%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%#   Eval("FECHA") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="ITEM">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="9%" />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("ITEM") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                       
                                                                                                       
                                                                                                          <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="CANTIDAD REST.">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("CANTIDAD_ENTRADA") %>   U.                                                                                              
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                          
                                                                                                          <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="ESTADO">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                  <%# Eval("ESTADO") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                       <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="PRECIO S/. LOTE">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                S/.   <%# Eval("PRECIO_LOTE") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                       <asp:TemplateColumn  HeaderStyle-HorizontalAlign="Left" HeaderText="PRE. U. VENTA">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                S/.   <%# Eval("PRECIO_VENTA_U") %>                                                                                                 
                                                                                                  

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
