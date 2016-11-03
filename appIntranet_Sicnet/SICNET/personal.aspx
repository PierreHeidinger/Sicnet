<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="personal.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.personal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlePage" runat="server">
    PERSONAL
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyweb" runat="server">

     <div class="container-fluid">
                <div class="side-body">
                     <div class="page-title">
                       
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo" Width="150" CssClass="btn btn-primary"  OnClick="btn_NUEVO_Click"   />                       
                        <asp:Button  runat="server"  ID="btn_Imprimir" Text="Imprimir" Width="150" CssClass="btn btn-primary"  />
                         <asp:Button  runat="server"  ID="btn_Email" Text="Email" Width="150" CssClass="btn btn-primary"  />
                          <asp:Button  runat="server"  ID="btn_Excel" Text="Excel"  Width="150" CssClass="btn btn-success"  />

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
                                                            <label for="exampleInputName2">NOMBRES APELLIDOS :</label>
                                                            <asp:TextBox runat="server" placeholder="N0MBRES y/o APELLIDOS" ID="txt_nombres"   CssClass="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
                                                </div>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                   <!-- // FILTROS RAPIDOS -->
                                    <hr />
                                    
                                         <div style="overflow:auto;height:100%;width:100%">
                                                                                              <asp:DataGrid ID="dg_listado_personal" runat="server" Width="100%"  Font-Names="Verdana" Enabled="false" Font-Size="11" style="font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif"
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
                                                                                                              <a   href="personal_nuevo_detalle.aspx?cod_personal=<%# Eval("COD_PERSONAL") %>">
                                                                                                                   <%# Eval("COD_PERSONAL_X") %>

                                                                                                              </a>
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>    
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="NOMBRES Y APELLIDOS">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="4%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("NOMBRES_X") %>

                                                                                                             
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="CARGO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="4%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("CARGO_EMPRESA") %>

                                                                                                             
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="F.INGRESO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="4%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("FECHA_INGRESO") %>

                                                                                                             
                                                                                                          </ItemTemplate>
                                                                                                      </asp:TemplateColumn>
                                                                                                      
                                                                                                      <asp:TemplateColumn HeaderText="ESTADO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="4%"   />
                                                                                                          <ItemTemplate>
                                                                                                              
                                                                                                                   <%# Eval("ESTADO") %>

                                                                                                             
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
