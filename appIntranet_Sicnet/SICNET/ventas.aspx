<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.ventas" %>




<asp:Content runat="server" ContentPlaceHolderID="titlePage">
     <a href="ventas.aspx"> VENTAS </a> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyweb" runat="server">



    <script>

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
                         
                        <asp:Button  runat="server"  ID="btn_NUEVO" Text="Nuevo Venta?" Width="150" CssClass="btn btn-primary"  ToolTip="REGISTRE  UNA NUEVA VENTA" OnClick="btn_NUEVO_Click" />
                         <asp:Button  runat="server"  ID="btn_IMPRIMIR" Text="Imprimir?" Width="150" CssClass="btn btn-primary"  ToolTip="IMPRIMA EL LISTADO VISTO EN PANTALLA" />
                       <asp:Button  runat="server"  ID="btn_EXCEL" OnClick="btn_EXCEL_Click" Text="Exportar Excel" Width="150" CssClass="btn btn-success" Enabled="True" ToolTip="EXPORTE A EXCEL EL LISTADO VISTO EN PANTALLA" />
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
                                                 <asp:TextBox runat="server" placeholder="CODIGO" ID="txt_N_v" onKeyPress="return checkIt(event)" CssClass="form-control" Width="150" OnTextChanged="txt_N_v_TextChanged"></asp:TextBox>                                              
                                              
                                            </td>
                                             <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>
                                            <td> 
                                                 <label for="exampleInputName2">DESDE :</label>                                            
                                                 <asp:TextBox runat="server" ID="txt_Fec1" OnTextChanged="txt_Fec1_TextChanged"  CssClass="form-control" Width="150"></asp:TextBox>
                                               
                                            </td>
                                           
                                               <td>
                                                &nbsp;
                                                &nbsp;
                                            </td>                                        
                                            <td>  
                                                <label for="exampleInputName2">HASTA :</label>                                               
                                                 <asp:TextBox runat="server" ID="txt_Fec2" OnTextChanged="txt_Fec2_TextChanged" CssClass="form-control" Width="150"></asp:TextBox>
                                             
                                            </td>
                                          
                                            
                                        </tr>
                                    </table>
                                   <!-- // FILTROS RAPIDOS -->
                                    <hr />
                                      <asp:UpdatePanel runat="server">
                                      <ContentTemplate>
                                      <asp:ScriptManager runat="server"></asp:ScriptManager>
                                         <div style="overflow:auto;height:100%;width:100%">
                                                                                              <asp:DataGrid ID="dg_listado_al"  runat="server" Width="100%"  Font-Names="Verdana" Enabled="false" Font-Size="11" style="font-family:Helvetica Neue, Roboto, Arial,Droid Sans, sans-serif"
                                                                                                  PageSize="19" GridLines="Both"  BorderWidth="0px" AutoGenerateColumns="false"  HeaderStyle-Height="30" BorderStyle="Solid" BorderColor="Gray" ItemStyle-Height="30" >
                                                                                                  <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE" />
                                                                                                  <SelectedItemStyle  Font-Bold="true" ForeColor="#F7F7F7" BackColor="#738A9C" />
                                                                                                  <AlternatingItemStyle BackColor="WhiteSmoke" />
                                                                                                  <ItemStyle ForeColor="#000066" />
                                                                                                  <HeaderStyle  Font-Bold="true" HorizontalAlign="center" ForeColor="White" BackColor="#1ABC9C"/>
                                                                                                  <Columns>
                                                                                                      <asp:TemplateColumn HeaderText="CODIGO">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%" ForeColor="White"  BackColor="#738A9C"  />
                                                                                                          <ItemTemplate>
                                                                                                              <a   href="ventas_nuevo_detalle.aspx?cod_venta=<%# Eval("CODIGO") %>">
                                                                                                                  VNT - <%# Eval("CODIGO") %>
                                                                                                              </a>
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                        <asp:TemplateColumn HeaderText="FEC. VEN.">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("FECHA") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                      <asp:TemplateColumn HeaderText="T. CANTIDAD">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("CANTIDAD_T") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                       
                                                                                                        <asp:TemplateColumn HeaderText="P. COSTO ">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                               S/.    <%#  Math.Round(decimal.Parse(Eval("TOTAL_COSTO_COMERCIAL").ToString()),2) %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>
                                                                                                          <asp:TemplateColumn HeaderText="T. UTILIDAD S/.">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("TOTAL_UTILIDAD") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                          
                                                                                                          <asp:TemplateColumn HeaderText="T. IGV S/.">
                                                                                                          <ItemStyle HorizontalAlign="Center" Width="5%"  />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                                   <%# Eval("TOTAL_IGV") %>                                                                                                 
                                                                                                  

                                                                                                          </ItemTemplate>

                                                                                                      </asp:TemplateColumn>

                                                                                                        <asp:TemplateColumn HeaderText="T. VENTA">
                                                                                                          <ItemStyle BackColor="YellowGreen" HorizontalAlign="Center" Width="5%"   />
                                                                                                          <ItemTemplate>                                                                                                 
                                                                                                               S/.    <%#   Math.Round (Decimal.Parse(Eval("TOTAL_VENTA").ToString()),2) %>                                                                                             
                                                                                                  

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
