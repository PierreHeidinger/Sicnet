using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bibliotecaClases;

namespace appIntranet_Sicnet.SICNET
{
    public partial class ventas_nuevo_detalle : System.Web.UI.Page
    {
        #region "Declaraciones"
        claseItems claseItems = new claseItems();
        claseVentas claseVentas = new claseVentas();
        public DataTable oDs_Datos;

        #endregion
        #region "Procedimientos"

        public void cargar_detall(String a_COD_VENTA)
        {
            oDs_Datos = claseVentas.public_Mostrar_Datos_VENTA_DETALLE(a_COD_VENTA);
            gw_datos_venta.DataSource = oDs_Datos;
            gw_datos_venta.DataBind();

            gw_Items_Venta.Visible = false;
            gw_datos_venta.Visible = true;
        }
        public void cargar_datos_venta(String a_COD_VENTA)
        {
            oDs_Datos = claseVentas.public_Mostrar_Datos_VENTA(a_COD_VENTA);

            if(oDs_Datos.Rows.Count > 0)
            {

                if(oDs_Datos.Rows[0]["COD_VENTA"] != null)
                {
                    txt_Codigo.Text = oDs_Datos.Rows[0]["COD_VENTA"].ToString();
                }
                if (oDs_Datos.Rows[0]["FECHA"] != null)
                {
                    txt_Fecha_Registro.Text = oDs_Datos.Rows[0]["FECHA"].ToString();
                }

                if (oDs_Datos.Rows[0]["C_TOTAL"] != null)
                {
                    txt_Cantidad_Total.Text = oDs_Datos.Rows[0]["C_TOTAL"].ToString();
                }
                if (oDs_Datos.Rows[0]["TOTAL_COSTO_COMERCIAL"] != null)
                {
                    txt_TOTAL_P_COSTO.Text = oDs_Datos.Rows[0]["TOTAL_COSTO_COMERCIAL"].ToString();
                }

                if (oDs_Datos.Rows[0]["TOTAL_UTILIDAD"] != null)
                {
                    txt_T_UTILIDAD.Text = oDs_Datos.Rows[0]["TOTAL_UTILIDAD"].ToString();
                }

                if (oDs_Datos.Rows[0]["TOTAL_VENTA"] != null)
                {
                    txt_TOTAL_VENTA.Text = oDs_Datos.Rows[0]["TOTAL_VENTA"].ToString();
                }

                cargar_detall(txt_Codigo.Text.Trim());
            }

        }

        public void listar_items_busqueda(String a_DES)
        {
            oDs_Datos = claseVentas.public_Lista_ITEMS(a_DES);
            gw_items.DataSource = oDs_Datos;
            gw_items.DataBind();
        }


        public void cargar_grid_ventas(String cods)
        {
            oDs_Datos = claseVentas.public_cargar_Items(cods);
            gw_Items_Venta.DataSource = oDs_Datos;
            gw_Items_Venta.DataBind();
        }


        public void calcular_totales()
        {
            Decimal can = 0;
            Decimal total_v = 0;
            Decimal total_c = 0;
            Decimal total_u = 0;
            foreach (GridViewRow row in gw_Items_Venta.Rows)
            {
                
                TextBox cantidad = (TextBox)gw_Items_Venta.Rows[row.RowIndex].Cells[2].FindControl("txt_Cantida_r");
               Label precio_t = (Label)gw_Items_Venta.Rows[row.RowIndex].Cells[6].FindControl("lbl_Total");
                string precio_c = gw_Items_Venta.Rows[row.RowIndex].Cells[3].Text;
                string precio_u = gw_Items_Venta.Rows[row.RowIndex].Cells[4].Text;

                Decimal t_precio_c = decimal.Parse(precio_c) * int.Parse(cantidad.Text);
                decimal t_precio_u = decimal.Parse(precio_u) * int.Parse(cantidad.Text);

                can += decimal.Parse(cantidad.Text);
                // total_c += decimal.Parse(precio_c);
                total_c += t_precio_c;
                total_v += decimal.Parse(precio_t.Text);
                // total_u += decimal.Parse(precio_u);
                total_u += t_precio_u;
            }
            txt_Cantidad_Total.Text = can.ToString();
            txt_TOTAL_P_COSTO.Text = total_c.ToString();
            txt_T_UTILIDAD.Text = total_u.ToString();
            txt_TOTAL_VENTA.Text = total_v.ToString();
        }

        public void generar_codigo()
        {
            String codigoPrin;
            string cod1 = DateTime.Now.Year.ToString();            
            string cod2 = DateTime.Now.Millisecond.ToString();
            string cod3 = DateTime.Now.Minute.ToString();
            string cod4 = DateTime.Now.Second.ToString();

            codigoPrin = cod1 + cod2  +cod3+cod4;
            txt_Codigo.Text = codigoPrin;

        }

        public void estado_controles(bool _est)
        {
            btn_NUEVO.Enabled = !_est;
            btn_Preview.Enabled = !_est; 
            btn_Generar.Enabled = !_est;

            
            btn_Grabar.Enabled = _est;
            btn_Cancelar.Enabled = _est;


        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["cod_venta"] != null)
                {
                    cargar_datos_venta(Request.QueryString["cod_venta"].ToString());
                    estado_controles(false);
                    btn_Buscar.Enabled = false;
                    txt_bus_nombre.Enabled = false;
                    btn_Cargar.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                     "disableButton();", true);
                }
                else { 
                generar_codigo();
                txt_Fecha_Registro.Text = DateTime.Now.ToString("dd/MM/yyyy");

                listar_items_busqueda("%");
                estado_controles(true);

                    btn_Buscar.Enabled = true;
                    txt_bus_nombre.Enabled = true;
                    btn_Cargar.Enabled = true;
                }
            }
        }

  

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            try { 

            listar_items_busqueda(txt_bus_nombre.Text.Trim());
            }
            catch (Exception ex){
                txt_bus_nombre.Text = ex.Message;
            }
        }

        protected void btn_Cargar_Click(object sender, EventArgs e)
        {
            try { 
            CheckBox chk_I1 = new CheckBox();
            string cod = "";
            string v_Final= "";

           foreach (GridViewRow row in gw_items.Rows)
            {
                if(row.RowType == DataControlRowType.DataRow)
                {
                    chk_I1 = (row.Cells[0].FindControl("chkItem") as CheckBox);

                    if (chk_I1.Checked)
                    {
                        string cods = row.Cells[0].Text;

                        cod += (cods + "','");
                    }
                }

            }

            v_Final = "'" + cod;
            int c = v_Final.Length;
            string seg = v_Final.Substring(0, c - 2);

                

                if(txt_CODIGOS.Text == "")
                {
                    txt_CODIGOS.Text = seg;
                    
                }
                else
                {
                    txt_CODIGOS.Text = txt_CODIGOS.Text + "," + seg;
                }




                //CARGAR GRID_VENTAS
                cargar_grid_ventas(txt_CODIGOS.Text.Trim());



                //QUITAR LOS CHECKS

                foreach (GridViewRow row in gw_items.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        chk_I1 = (row.Cells[0].FindControl("chkItem") as CheckBox);

                        if (chk_I1.Checked)
                        {
                            chk_I1.Checked = false;
                        }
                    }

                }

                calcular_totales();
            }
            catch(Exception EX)
            {
                txt_Fecha_Registro.Text = "CARGAR ITEMS EXCEPTION : " + EX.Message;
            }

          

        }

        protected void txt_Cantidad_TextChanged(object sender, EventArgs e)
        {
       
        }

        protected void btn_Grabar_Click(object sender, EventArgs e)
        {

            if(gw_Items_Venta.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                      "alert('No a ingresado ningun producto para la venta');", true);
                return;
            }





            try {

              

                
                foreach (GridViewRow row in gw_Items_Venta.Rows)
                {


                    




                    Label Codigo_item = (Label)row.Cells[7].FindControl("lbl_cod_item");
                    string codigo_lote = row.Cells[0].Text;
                    TextBox cantidad = (TextBox)row.Cells[2].FindControl("txt_Cantida_r");
                    string p_costo = row.Cells[3].Text;
                    string utilidad = row.Cells[4].Text;
                    Label p_total = (Label)row.Cells[6].FindControl("lbl_Total");

                    float t_precio_c = float.Parse(p_costo) * int.Parse(cantidad.Text);
                    float t_precio_u = float.Parse(utilidad) * int.Parse(cantidad.Text);




                    //VALIDAD QUE HAYA ACTUALIZADO LOS PRECIOS

                    float var1 = (float.Parse(p_costo) + float.Parse(utilidad));
                    float var2 = (float.Parse(p_total.Text) /(int.Parse(cantidad.Text)));
                   
                    if(var1 != var2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                       "alert('No a realizado la actualizacion de precios del lote :  "+ codigo_lote+"');", true);
                        generar_codigo();
                        return;


                    }

                     String detalle = claseVentas.public_Mantenimiento_Detalle_V(txt_Codigo.Text.Trim(), Codigo_item.Text,cantidad.Text,t_precio_c,t_precio_u,0,float.Parse(p_total.Text),codigo_lote);

                }

                String evento = claseVentas.public_Mantenimiento_Venta(txt_Codigo.Text.Trim(),"0" , Session["COD_PERSONAL"].ToString(), float.Parse(txt_TOTAL_P_COSTO.Text), float.Parse(txt_T_UTILIDAD.Text), float.Parse(txt_IGV_TOTAL.Text), float.Parse(txt_TOTAL_VENTA.Text));


                Response.Redirect("ventas.aspx?sus=1");
            }catch(Exception ex)
            {
                txt_Fecha_Registro.Text = "Boton Grabar : excepcion" + ex.Message;
                generar_codigo();
            }

        }

     

        protected void gw_Items_Venta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                /*
                TextBox cantidad = (TextBox)gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[2].FindControl("txt_Cantida_r");
                Label precio = (Label)gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[6].FindControl("lbl_Total");
                Label precio_e = (Label)gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[5].FindControl("lbl_Total_I");

                int can = int.Parse(cantidad.Text) + 1;
                double pre = double.Parse(precio_e.Text);
                double total = can * pre;
                txt_Fecha_Registro.Text = cantidad.Text + "," + precio.Text;

                cantidad.Text = can.ToString();
                precio.Text = total.ToString() ;

                */
                string codigo_lote = gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[0].Text;
                TextBox cantidad = (TextBox)gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[2].FindControl("txt_Cantida_r");
                Label precio = (Label)gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[6].FindControl("lbl_Total");
                Label precio_e = (Label)gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[5].FindControl("lbl_Total_I");

                if(cantidad.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                      "alert('La cantidad tiene que ser mayor a 0');", true);
                    return;
                }
                if (cantidad.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                      "alert('Ingrese la cantidad');", true);
                    return;
                }

                string valida = valida = claseVentas.public_Validad_cantidad(codigo_lote, cantidad.Text, "     ");

                if(valida == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                      "alert('Actualmente no se cuenta con el stock que solicita,pruebe con otro lote ');", true);
                    cantidad.Text = "1";
                    
                }


                int can = int.Parse(cantidad.Text);
                Decimal pre = Decimal.Parse(precio_e.Text);
                Decimal total = can * pre;
                precio.Text = total.ToString();

                calcular_totales();

            }


            if(e.CommandName == "eliminar")
            {

                string codigo = gw_Items_Venta.Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[0].Text;
                //txt_Fecha_Registro.Text = codigo;
                string newc = txt_CODIGOS.Text.Replace(codigo.Trim(), "0");
                txt_CODIGOS.Text = newc;

                cargar_grid_ventas(txt_CODIGOS.Text);


                calcular_totales();
            }

        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ventas_nuevo_detalle");
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cod_venta"] != null)
            {
                estado_controles(false);
            }
            else
            {
                Response.Redirect("ventas.aspx");
            }



        }

        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["cod_venta"] != null){ 

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                   "openPreview("+txt_Codigo.Text.Trim()+");", true);
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage1",
                    "disableButton();", true);
        }
    }
}