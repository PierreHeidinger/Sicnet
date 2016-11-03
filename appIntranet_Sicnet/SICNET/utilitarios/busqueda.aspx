<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busqueda.aspx.cs" Inherits="appIntranet_Sicnet.SICNET.utilitarios.busqueda" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BUSQUEDA | SICNET </title>
    <link rel="icon" type="image/png" href="../../img/logoSis.png" />
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana;
            font-size: xx-small;
            color: #4169E1;
        }
    </style>

  
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <center>
				<table>
					<TR>
						<TD align="left"><div id="Panel1" style="width:868px;">
	
								<TABLE style="WIDTH: 956px" id="Table1" border="0" cellSpacing="1" cellPadding="1" width="856">
									<TR>
										<TD>
											<a id="HyperLink4" style="font-family:Arial;font-size:large;font-weight:bold;">BUSQUEDA : <asp:Label runat="server" ID="lbl_Tipo_Busqueda"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</TD>
										<TD align="right">
											<input type="submit" name="btn_Default" value="." id="btn_Default" style="color:RoyalBlue;font-family:Verdana;font-size:XX-Small;font-weight:bold;height:1px;width:1px;" /></TD>
									</TR>
								</TABLE>
							
</div></TD>
					</TR>
					<tr>
						<td>
							<hr>
						</td>
					</tr>
					<TR>
						<TD><div id="Panel3" style="width:868px;">
	
								<table style="WIDTH: 852px; HEIGHT: 24px" id="Table2" border="0" cellSpacing="1" cellPadding="1">
									<tr>
										<td align="left">&nbsp;&nbsp;&nbsp;
											<span style="font-size:large">ITEM:</span>
											<asp:TextBox runat="server" ID="txt_Descripcion" OnTextChanged="txt_Descripcion_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                        <td style="width:360px">
                                            <asp:Label runat="server" ID="lbl_codigo_item" Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" Text="CARGAR" ForeColor="Red" Font-Bold="true" ID="btnCargar" Width="200" OnClick="btnCargar_Click" />
                                        </td>
									</tr>
								</table>
							
</div></TD>
					</TR>
					<tr>
						<td>
							<hr>
						</td>
					</tr>
					<TR>
						<TD>

                            <div style="BORDER-BOTTOM-STYLE: inset; BORDER-RIGHT-STYLE: inset; WIDTH: 860px; BORDER-TOP-STYLE: inset; HEIGHT: 100px; BORDER-LEFT-STYLE: inset; overflow-x: hidden;overflow-y:auto"
															id="div_segopp">
															<asp:GridView style="Z-INDEX: 0" id="gw_items" runat="server" Width="100%" Font-Size="Small"
																Font-Names="Verdana" PageSize="19" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="3"
																GridLines="None" BackColor="White" OnSelectedIndexChanged="gw_items_SelectedIndexChanged" >
																<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
																<SelectedRowStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedRowStyle>
																<AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
																<RowStyle ForeColor="#000066"></RowStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="DarkCyan"></HeaderStyle>
																<Columns>

                                                                   <asp:CommandField ShowSelectButton="True" SelectImageUrl="~/img/warning.gif" ControlStyle-Width="15" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" ButtonType="Image" />
																	 <asp:BoundField DataField="COD_ITEM"  ItemStyle-HorizontalAlign="Center"  HeaderText="CODIGO"/>
                                                                    <asp:BoundField  DataField="DES_ITEM" HeaderText="DESCRIPCION ITEM "/>
                                                                    <asp:BoundField  DataField="FECHA_REGISTRO" ItemStyle-HorizontalAlign="Center" HeaderText="FECHA DE REGISTRO" />
                                                                   
																	
																    
																   
																   
																    
																   
																    
																</Columns>
                                                                <EmptyDataTemplate>
                                                                    <b>sin datos</b>
                                                                </EmptyDataTemplate>
															</asp:GridView></div>

						</TD>
					</TR>
					<tr>
						<td>
							<hr>
						</td>
					</tr>
					<TR>
						<TD><div id="Panel5" style="width:868px;">
	
								<TABLE style="WIDTH: 952px" id="Table3" border="0" cellSpacing="1" cellPadding="1" width="952">
									<TR>
										
                                        <asp:Button runat="server" OnClick="btn_REGRESAR_Click" ID="btn_REGRESAR" ForeColor="LightSeaGreen" Text="REGRESAR" />
										
									</TR>
								</TABLE>
							
</div></TD>
					</TR>
				</table>
			</center>


        

    
    </div>
    </form>
</body>
</html>
