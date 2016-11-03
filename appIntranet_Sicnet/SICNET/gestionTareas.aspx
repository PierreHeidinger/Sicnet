<%@ Page Title="" Language="C#" MasterPageFile="~/SICNET/master.Master" AutoEventWireup="true" CodeBehind="gestionTareas.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.gestionGerencial"  ViewStateEncryptionMode="Always" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titlePage" runat="server">
    ADMINISTRACION
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyweb" runat="server">

       
    <script src="../tools/dist/lib/js/jquery.min.js"></script>
    <!--script-->

    <script type="text/javascript">

        function iniciar() {
            $(window).load(function () {
                $('#nuevaTarea').modal('show');
            });
        };
        function iniciarT() {
            $(window).load(function () {
                $('#listadoTarea').modal('show');
            });
        };

        function ocultar() {
            $(window).load(function () {
                $('#nuevaTarea').modal('hide');
            });
        };

        function ocultarBoton() {
            document.getElementById('btn_cancelar').style.display = 'none';
        }

        function validacion() {
            
            var fec1 = document.getElementById('<%= txt_Fecha_inicio.ClientID %>').value;
            var fec2 = document.getElementById('<%= txt_fEcha_seleccionada.ClientID %>').value


            if (Date.parse(fec1) > Date.parse(fec2)) {
                alert('La fecha de termino no pude ser menor a la fecha de finalizacion de la tarea!');
                return false;
            }else{

                if (document.getElementById('<%= txt_Nombre.ClientID %>').value == '') {
                    alert('Ingrese el nombre de la tarea!');
                    return false;
                
                } else {

                     if (document.getElementById('<%= txt_Descripcion_completa.ClientID %>').value == '') {
                    alert('Ingrese la Descricion de la tarea!');
                    return false;
                
                     }
                }
            }

        }

        
        $(document).ready(function() {

          $("#<%=gw_tareas.ClientID%> tr:has(td)").hover(function() {

              $(this).css("background-color", "#8EC3B1");

           }, function() {

           $(this).css("background-color", "#ffffff");

          });

        })

        

      

        </script>


       
     
     
    


    <div class="container-fluid">

                <div class="side-body">
                     <div class="page-title">                       
                        <asp:Button  runat="server"  ID="btn_Proyectos" Text="Proyectos" Width="150" CssClass="btn btn-primary"   />                       
                        <asp:Button  runat="server"  ID="btn_Tareas" Text="Tareas" Width="150" CssClass="btn btn-primary"  />
                         <asp:Button  runat="server"  ID="btn_Reporte" Text="Email" Width="150" CssClass="btn btn-primary"  />
                          <asp:Button  runat="server"  ID="btn_Excel" Text="Excel"  Width="150" CssClass="btn btn-success"  />

                         <asp:Literal runat="server"  ID="div_error" Visible="false"></asp:Literal> 
                         <asp:Literal runat="server"  ID="div_confirmacion" Visible="false"></asp:Literal> 
                    </div>
                    <div >
                        <div class="col-xs-12">
                            <div class="card" >
                                
                               
                               

                                <div class="card-body">
                                 
                                <label for="exampleInputName2">AÑO :</label>
                                <asp:DropDownList runat="server" ID="year"  CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="year_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="2016">--2016--</asp:ListItem>
                                    <asp:ListItem Value="2017">--2017--</asp:ListItem>
                                    <asp:ListItem Value="2018">--2018--</asp:ListItem>
                                </asp:DropDownList>
                                    <label for="exampleInputName2">MES :</label>
                                <asp:DropDownList runat="server" ID="month"  CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="month_SelectedIndexChanged"  AutoPostBack="True">
                                    <asp:ListItem Value="01">--Enero--</asp:ListItem>
                                    <asp:ListItem Value="02">--Febrero--</asp:ListItem>
                                    <asp:ListItem Value="03">--Marzo--</asp:ListItem>
                                    <asp:ListItem Value="04">--Abril--</asp:ListItem>
                                    <asp:ListItem Value="05">--Mayo--</asp:ListItem>
                                    <asp:ListItem Value="06">--Junio--</asp:ListItem>
                                    <asp:ListItem Value="07">--Julio--</asp:ListItem>
                                    <asp:ListItem Value="08">--Agosto--</asp:ListItem>
                                    <asp:ListItem Value="09">--Setiembre--</asp:ListItem>
                                    <asp:ListItem Value="10">--Octubre--</asp:ListItem>
                                    <asp:ListItem Value="11">--Noviembre--</asp:ListItem>
                                    <asp:ListItem Value="12">--Diciembre--</asp:ListItem>
                                </asp:DropDownList>
                                    &nbsp;
                                    &nbsp;
                                    &nbsp;
                                <hr />
                                    &nbsp;
                                    &nbsp;

                                 

                                    <asp:Button runat="server" ID="btn_Agregar_Tarea"  Text="Agregar Tarea" OnClick="btn_Agregar_Tarea_Click" class="btn btn-primary btn-info" style="width:150px"/>

                                   <center>                              
                                         <asp:Calendar id="Calendar1" Caption="Agenda Administrativa" runat="server" Width="70%"  Font-Names="Verdana" Font-Size="8pt"
															ForeColor="Black" Height="300px" BackColor="White" DayNameFormat="Full" FirstDayOfWeek="Monday" TitleFormat="MonthYear" TitleStyle-Font-Size="Small" ShowGridLines="true"   DayStyle-HorizontalAlign="Left" DayStyle-VerticalAlign="Top" DayStyle-Height="75" DayStyle-Width="100"
                                                            BorderColor="#999999" OtherMonthDayStyle-BackColor="Cornsilk"
															CellPadding="4" OnSelectionChanged="Cl1_SelectionChanged"  OnDayRender="Calendar1_DayRender"  >
															<TodayDayStyle ForeColor="Black"></TodayDayStyle>
															<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
															<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
															<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
															<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="PowderBlue"></SelectedDayStyle>
															<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
															<OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
														</asp:Calendar>
	
                                    
                                
                                    <hr />

                                   
                                                            
                                                                                               </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>





            <!--MODAL NUEVA TAREA-->

        <div class="modal fade modal-primary" id="nuevaTarea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" style="width:800px">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title" id="myModalLabel"><asp:Label ID="lbl_des_modal" runat="server"></asp:Label></h4>
                                                    </div>
                                                    <div class="modal-body">  
                                                     
                                                                                            
                                                        <asp:Label runat="server" ID="lbl_grabado" Text=""></asp:Label>
                                                 <table>
                                                     <tr>
                                                         <td style="border-right:solid 1px gray;vertical-align:top">
                                                       <table>
                                                             <tr>
                                                                
                                                               <td>
                                                                    &nbsp;
                                                                    &nbsp;
                                                               </td>
                                                               <td>
                                                                    <asp:TextBox runat="server" BackColor="MediumSeaGreen"  ID="txt_Fecha_inicio" CssClass="form-control"   onkeydown = "return (event.keyCode!=13);" ></asp:TextBox>                                                                                                                       
                                                                     <ajaxtoolkit:CalendarExtender runat="server" id="CalendarExtender1"  TargetControlID="txt_Fecha_inicio" Format="dd/MM/yyyy"  PopupButtonID="IMG_FECHA_I">
                                                                   </ajaxtoolkit:CalendarExtender>                                                               
                                                                    &nbsp;
                                                               </td>

                                                                <td> &nbsp;
                                                                    <img src="../img/icono_calendario.png" id="IMG_FECHA_I" width="25" />      
                                                                    &nbsp;  
                                                                </td>
                                                               <td>
                                                                   <label for="exampleInputName2" style="color:darkred">*Fecha de actual(inicio)! </label>
                                                                    &nbsp;
                                                               </td>
                                                            </tr>
                                                            <tr>
                                                                <td>                                                                   
                                                                    
                                                               </td>
                                                            </tr>
                                                           <tr>
                                                                
                                                               <td>
                                                                    &nbsp;
                                                                    &nbsp;
                                                               </td>
                                                               <td>
                                                                    <asp:TextBox runat="server"   ID="txt_fEcha_seleccionada" BackColor="RosyBrown" CssClass="form-control"   onkeydown = "return (event.keyCode!=13);" ></asp:TextBox>                                                                                                                       
                                                                     <ajaxtoolkit:CalendarExtender runat="server" id="CaFec1" TargetControlID="txt_fEcha_seleccionada" Format="dd/MM/yyyy"  PopupButtonID="IMG_FECHA">
                                                                   </ajaxtoolkit:CalendarExtender>                                                   
                                                                    &nbsp;
                                                               </td>
                                                               <td> 
                                                                   &nbsp;
                                                                   <img src="../img/icono_calendario.png" id="IMG_FECHA" width="25" />                                                                                                                                  
                                                                     &nbsp;
                                                                   
                                                               </td>
                                                               <td>
                                                                   
                                                                   <label for="exampleInputName2" style="color:darkred">*Fecha de termino! </label>
                                                                    &nbsp;
                                                               </td>
                                                            </tr>
                                                            <tr>
                                                                <td>                                                                   
                                                                    
                                                               </td>
                                                            </tr>
                                                            <tr>
                                                               
                                                               <td>
                                                                    &nbsp;
                                                                    &nbsp;
                                                               </td>
                                                               <td>
                                                                    <asp:TextBox runat="server"  ID="txt_Nombre" placeHolder="Nombre Tarea..." style="text-transform:uppercase"  CssClass="form-control"  onkeydown = "return (event.keyCode!=13);"    ></asp:TextBox>
                                                                    &nbsp;
                                                                    &nbsp;
                                                               </td>
                                                           </tr>
                                                             <tr>
                                                                <td>                                                                   
                                                                    
                                                               </td>
                                                            </tr>
                                                          
                                                        </table>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                    &nbsp;
                                                               </td>
                                                               <td> 
                                                                      
                                                                   <asp:TextBox runat="server"  ID="txt_Descripcion_completa" placeHolder="Descripcion Detallada..."  style="resize:none;text-transform:uppercase" Width="350" Height="100" CssClass="form-control"  onkeydown = "return (event.keyCode!=13);"     TextMode="MultiLine"></asp:TextBox>  
                                                                   <br />
                                                                                                                             
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                    &nbsp;
                                                                </td>
                                                                
                                                              
                                                           </tr>

                                                       </table>
                                                             </td>
                                                              <td>
                                                                  &nbsp;
                                                                    &nbsp;
                                                                  &nbsp;
                                                                    &nbsp;
                                                              </td>
                                                               <td style="vertical-align:top">
                                                                   <label for="exampleInputName2" style="color:darkred">Responsable :  </label>
                                                               </td>
                                                                <td>
                                                                  &nbsp;
                                                                    &nbsp;
                                                                  &nbsp;
                                                                    &nbsp;
                                                              </td>

                                                              <td style="vertical-align:top">
                                                                  
                                                                  <div style="overflow:auto;height:300px;width:200px">
                                                                    
                                                                    <asp:RadioButtonList runat="server" ID="rdo_responsable" CssClass="checkbox3 checkbox-inline checkbox-check checkbox-light"  RepeatDirection="Vertical">
                                                                      
                                                                        
                                                                    </asp:RadioButtonList>
                                                                  </div>
                                                                </td>
                                                     </tr>
                                                     </table>

                                                        

                                                        <!--   </ContentTemplate>

                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btn_grabar_Tarea" EventName="Click" />
                                                        </Triggers>

                                                    </asp:UpdatePanel>   -->

                                                        <div class="modal-footer">
                                                        <asp:Button runat="server" ID="btn_Salir"  CssClass="btn btn-info" OnClick="btn_Salir_Click" Text="Salir" Visible="false" />
                                                        <button type="button" class="btn btn-danger" id="btn_cancelar" data-dismiss="modal">Cancelar</button>
                                                        <asp:Button runat="server" ID="btn_grabar_Tarea" OnClientClick="return validacion();" OnClick="btn_grabar_Tarea_Click" CssClass="btn btn-info" Text="Grabar" />
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                            </div>

           
         <!--MODAL LITADO TAREA-->

        <div class="modal fade modal-danger" id="listadoTarea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" style="width:800px">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title" id="myModalLabel1"><asp:Label ID="lbl_des_modal2" runat="server"></asp:Label></h4>
                                                    </div>
                                                    <div class="modal-body">  
                                                     
                                                           <div style="overflow:auto;height:100%;width:100%">
                                                                   
                                                                <asp:GridView style="Z-INDEX: 0" id="gw_tareas" runat="server" Width="100%" Font-Size="Small"
																Font-Names="Verdana" PageSize="19" AutoGenerateColumns="False" OnRowCommand="gw_tareas_RowCommand" BorderWidth="1px" BorderColor="Black" HeaderStyle-Height="30" CellPadding="3"
																GridLines="Both" BackColor="White" >
																<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
																
																<AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
																<RowStyle ForeColor="#000066"></RowStyle>
																<HeaderStyle Font-Bold="True"  ForeColor="White" BackColor="GrayText" BorderColor="Black" ></HeaderStyle>
																<Columns>

                                                                   
																	<asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton runat="server" ImageUrl="~/img/warning.gif" Width="25" CommandArgument='<%# Eval("COD_TAREA") %>' CommandName="mostrar_Datos" ToolTip='<%# Eval("COD_TAREA") %>'  />
                                                                        </ItemTemplate>
																	</asp:TemplateField>                                                                   

                                                                    <asp:BoundField  DataField="NOM_TAREA" ItemStyle-HorizontalAlign="Left" ShowHeader="true" HeaderText="TAREA" />

                                                                    
                                                                    <asp:BoundField  DataField="FECHA_INI" ItemStyle-HorizontalAlign="Left" HeaderText="FEC-INI" />

                                                                   
                                                                    <asp:BoundField  DataField="FECHA_FIN" ItemStyle-HorizontalAlign="Left" HeaderText="FEC-FIN" /> 

                                                                    <asp:BoundField  DataField="PERSONAL" ItemStyle-HorizontalAlign="Left" HeaderText="P.REGISTRO" /> 
                                                                    <asp:BoundField  DataField="ASIGNADO" ItemStyle-HorizontalAlign="Left" HeaderText="P.ASIGNADO" />	
																    
																   
																</Columns>
                                                                 <EmptyDataTemplate>
                                                                    <label for="exampleInputName2" style="color:darkred">NO HAY TAREAS PARA ESTA FECHA (: </label>
                                                                 </EmptyDataTemplate>
                                                              
															</asp:GridView></div>  
                                                        
                                                         

                                                        <div class="modal-footer">
                                                        <asp:Button runat="server" ID="Button1"  CssClass="btn btn-info" Text="Salir"  />

                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                            </div>
                    <div id="app_message" runat="server"></div>

     <br />




            
</asp:Content>
