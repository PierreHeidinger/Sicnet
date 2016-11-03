<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlePage" runat="server">
    CLIENTES
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyweb" runat="server">

   <div class="container-fluid">
                <div class="side-body">
                     <div class="page-title">
                       
                        <asp:Button style="font-family:'Comic Sans MS'"  runat="server"  ID="btn_NUEVO" Text="Nuevo" Width="150" CssClass="btn btn-primary"    />                       
                        <asp:Button style="font-family:'Comic Sans MS'"  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"  />
                         <asp:Button  style="font-family:'Comic Sans MS'" runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-primary"  />
                          <asp:Button style="font-family:'Comic Sans MS'"  runat="server"  ID="btn_Excel" Text="Excel"  Width="150" CssClass="btn btn-success"  />

                         <asp:Literal runat="server"  ID="div_error" Visible="false"></asp:Literal> 
                         <asp:Literal runat="server"  ID="div_confirmacion" Visible="false"></asp:Literal> 
                      
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                
                                
                                <div class="card-body">

                                    <!-- FILTROS RAPIDOS -->
                                    <table>
                                        <tr>

                                            <td>
                                                
                                                <div class="form-group">
                                                            <label for="exampleInputName2" style="font-family:'Comic Sans MS'" >NOMBRES APELLIDOS <*></label>
                                                            <asp:TextBox runat="server" style="font-family:'Comic Sans MS'"  ID="txt_nombres"   CssClass="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
                                                </div>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                   <!-- // FILTROS RAPIDOS -->
                                    <hr />
                                    
                                         <div style="overflow:auto;height:100%;width:100%">
                                                                                              <asp:DataGrid ID="dg_listado_personal" runat="server"  CssClass="datatable table table-striped" style="font-family:'Comic Sans MS'" CellPadding="0" Width="100%" AutoGenerateColumns="false" >
                                                                                                        <HeaderStyle BackColor="#1ABC9C" Font-Bold="true" ForeColor="WhiteSmoke" />                                                                                         
                                                                                                  <Columns>

                                                                                                      <asp:TemplateColumn HeaderText="CODIGO" HeaderStyle-HorizontalAlign="Center">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="2%" BackColor="LightGoldenrodYellow" Font-Bold="true" />
                                                                                                          <ItemTemplate>
                                                                                                              <a   href="personal_nuevo_detalle.aspx?cod_personal=<%# Eval("COD_CLIENTE") %>">
                                                                                                                   <%# Eval("COD_CLIENTE") %>

                                                                                                              </a>
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>    
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="CLIENTE" >
                                                                                                          <ItemStyle HorizontalAlign="Left"  Width="3%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("NOMBRES") %>

                                                                                                             
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="E-MAIL">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="2%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("EMAIL_CLIENTE") %>

                                                                                                             
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>

                                                                                                      <asp:TemplateColumn HeaderText="DIRECCION">
                                                                                                          <ItemStyle HorizontalAlign="Left" Width="6%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   
                                                                                                              <%# Eval("DIRECCION") %>
                                                                                                             
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>    
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="F.REG" HeaderStyle-HorizontalAlign="Center">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="3%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("FECHA_REG") %>

                                                                                                             
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
