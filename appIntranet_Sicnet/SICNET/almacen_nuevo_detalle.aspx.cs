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
    public partial class almacen_nuevo_detalle : System.Web.UI.Page
    {
        #region "DECLARACIONES

        claseLotes claseLotes = new claseLotes();
        claseItems claseItems = new claseItems();
        claseUtilitarios claseUtilitarios = new claseUtilitarios();
        public DataTable oDs_Datos;

        #endregion

        #region "PROCEDIIENTOS"

        public void MENSAJE_EVENTO(string tipo, string mensaje)
        {
            if (tipo == "1")
            {
                div_confirmacion.Visible = true;
                div_error.Visible = false;
                div_confirmacion.Text = claseUtilitarios.Confirmacion_Evento(mensaje);
            }
            else
            {
                div_confirmacion.Visible = false;
                div_error.Visible = true;
                div_error.Text = claseUtilitarios.Error_Evento(mensaje);
            }
        }

        public void mostrar_datos_item(String a_COD_ITEM)
        {
            oDs_Datos = claseItems.public_Mostrar_Datos_ITEMS(a_COD_ITEM);
            
            if(oDs_Datos.Rows.Count > 0)
            {
                if(oDs_Datos.Rows[0]["COD_ITEM"].ToString() != null)
                {
                    lbl_cod_item.Text = oDs_Datos.Rows[0]["COD_ITEM"].ToString();
                }
                else
                {
                    lbl_cod_item.Text = "";
                }
                if(oDs_Datos.Rows[0]["DES_ITEM"].ToString() != null)
                {
                    txt_Item.Text = oDs_Datos.Rows[0]["DES_ITEM"].ToString();
                }
                else
                {
                    txt_Item.Text = "";
                }

            }
        }
        
        public void mostrar_datos_lote(String a_COD_LOTE)
        {
            oDs_Datos = claseLotes.public_Mostrar_Datos_LOTE(a_COD_LOTE);

            if(oDs_Datos.Rows.Count > 0)
            {
                if(oDs_Datos.Rows[0]["COD_LOTE"] != null){
                    lbl_COD_Lote.Text = oDs_Datos.Rows[0]["COD_LOTE"].ToString();
                }else{
                    lbl_COD_Lote.Text = "";
                }

                if (oDs_Datos.Rows[0]["COD_ITEM"] != null)
                {
                   lbl_cod_item.Text = oDs_Datos.Rows[0]["COD_ITEM"].ToString().Trim();
                }else {
                    
                }
                if (oDs_Datos.Rows[0]["DES_LOTE"] != null)
                {
                    txt_Comentarios.Text = oDs_Datos.Rows[0]["DES_LOTE"].ToString().Trim();
                }
                else {
                    txt_Comentarios.Text = "";
                }
                if (oDs_Datos.Rows[0]["EST_LOTE"] != null){
                    cbo_Estado.SelectedValue = oDs_Datos.Rows[0]["EST_LOTE"].ToString().Trim();
                }else{
                    cbo_Estado.SelectedIndex = 0;
                }
                if (oDs_Datos.Rows[0]["CANTIDAD_TOTAL"] != null)
                {
                    txt_cantidad.Text = oDs_Datos.Rows[0]["CANTIDAD_TOTAL"].ToString().Replace(",",".");
                }
                else {
                    txt_cantidad.Text = "";
                }
                if (oDs_Datos.Rows[0]["PRECIO_LOTE"] != null)
                {
                    txt_precio_lote.Text = oDs_Datos.Rows[0]["PRECIO_LOTE"].ToString().Replace(",", ".");
                }
                else {
                    txt_precio_lote.Text = "";
                }
                if (oDs_Datos.Rows[0]["UTILIDAD_U"] != null)
                {
                    txt_Utilidad.Text = oDs_Datos.Rows[0]["UTILIDAD_U"].ToString().Replace(",", ".");
                }
                else {
                    txt_Utilidad.Text = "";
                }
                if (oDs_Datos.Rows[0]["PRECIO_UNIDAD"] != null)
                {
                    txt_precio_unidad.Text = oDs_Datos.Rows[0]["PRECIO_UNIDAD"].ToString().Replace(",", ".");
                }
                else {
                    txt_precio_unidad.Text = "";
                }
                if (oDs_Datos.Rows[0]["PRECIO_VENTA_U"] != null)
                {
                    txt_precio_venta.Text = oDs_Datos.Rows[0]["PRECIO_VENTA_U"].ToString().Replace(",", ".");
                }
                else {
                    txt_precio_venta.Text = "";
                }
                if (oDs_Datos.Rows[0]["IND_OFERTA"] != null)
                {
                    cbo_oferta.Text = oDs_Datos.Rows[0]["IND_OFERTA"].ToString();
                }
                else {
                    cbo_oferta.Text = "";
                }





            }


        }

        public void estado_controles(Boolean EST_)
        {

            txt_Codigo.Enabled = EST_;
            txt_Comentarios.Enabled = EST_;
            //cbo_Estado.Enabled = EST_;
            txt_cantidad.Enabled = EST_;
            txt_precio_lote.Enabled = EST_;
            txt_Utilidad.Enabled = EST_;
            txt_precio_unidad.Enabled = EST_;
            txt_precio_venta.Enabled = EST_;
            cbo_oferta.Enabled = EST_;
            img_agregar_item.Enabled = EST_;

            btn_NUEVO.Enabled = !EST_;
            btn_Editar.Enabled = !EST_;
            btn_Imprimir.Enabled = !EST_;
            btn_Email.Enabled = !EST_;

            btn_Grabar.Enabled = EST_;
            btn_Cancelar.Enabled = EST_;
            


            if (EST_ == true)
            {



                txt_Codigo.ForeColor = System.Drawing.Color.SteelBlue;
                txt_Comentarios.ForeColor = System.Drawing.Color.Indigo;
                cbo_Estado.ForeColor = System.Drawing.Color.Indigo;
                txt_cantidad.ForeColor = System.Drawing.Color.Indigo;
                txt_precio_lote.ForeColor = System.Drawing.Color.Indigo;
                txt_Utilidad.ForeColor = System.Drawing.Color.Indigo;
                txt_precio_unidad.ForeColor = System.Drawing.Color.Indigo;
                txt_precio_venta.ForeColor = System.Drawing.Color.Indigo;
                cbo_oferta.ForeColor = System.Drawing.Color.Indigo;






            }
            else
            {
                txt_Codigo.ForeColor = System.Drawing.Color.Black;
                txt_Comentarios.ForeColor = System.Drawing.Color.Black;
                cbo_Estado.ForeColor = System.Drawing.Color.Black;
                txt_cantidad.ForeColor = System.Drawing.Color.Black;
                txt_precio_lote.ForeColor = System.Drawing.Color.Black;
                txt_Utilidad.ForeColor = System.Drawing.Color.Black;
                txt_precio_unidad.ForeColor = System.Drawing.Color.Black;
                txt_precio_venta.ForeColor = System.Drawing.Color.Black;
                cbo_oferta.ForeColor = System.Drawing.Color.Black;




            }

        }
        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["cod_item"] != null)
                {
                    mostrar_datos_item(Request.QueryString["cod_item"]);
                    estado_controles(true);
                }

                if(Request.QueryString["cod_lote"] != null)
                {
                    mostrar_datos_lote(Request.QueryString["cod_lote"]);
                    mostrar_datos_item(lbl_cod_item.Text);
                    estado_controles(false);
                }
                else
                {
                    estado_controles(true);
                }
                
            }

        }

        protected void btn_Grabar_Click(object sender, EventArgs e)
        {

            if (txt_Item.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                  "alert('Seleccione el item de ingreso,haciendo click en el boton de con el simbolo de + ');", true);
                return;
            }
            if (txt_cantidad.Text == "" || txt_cantidad.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                  "alert('Ingrese la cantidad del nuevo lote');", true);
                return;
            }
            if (txt_precio_lote.Text == "" || txt_precio_lote.Text == "0.00")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                  "alert('Ingrese el precio del nuevo lote');", true);
                return;
            }


            try {


                if (Request.QueryString["cod_lote"] != null)
                {
                    String codigo = claseLotes.public_Mantenimiento_Lotes("2", lbl_COD_Lote.Text, txt_Comentarios.Text, lbl_cod_item.Text.Trim(), int.Parse(txt_cantidad.Text), cbo_oferta.SelectedValue,
                                                                   cbo_Estado.SelectedValue, txt_precio_lote.Text, txt_precio_unidad.Text, txt_Utilidad.Text, txt_precio_venta.Text);
                    MENSAJE_EVENTO("1", "Datos guardatos satisfactoriamente!");
                    mostrar_datos_lote(lbl_COD_Lote.Text);
                    estado_controles(false);
                }
                else {
                    String codigo = claseLotes.public_Mantenimiento_Lotes("1", txt_Codigo.Text, txt_Comentarios.Text, lbl_cod_item.Text.Trim(), int.Parse(txt_cantidad.Text), cbo_oferta.SelectedValue,
                                                                          cbo_Estado.SelectedValue, txt_precio_lote.Text, txt_precio_unidad.Text, txt_Utilidad.Text, txt_precio_venta.Text);
                    Response.Redirect("almacen.aspx?sus=1");
                }
            }
            catch (Exception ex) {
                txt_Item.Text = ex.Message;
            }

        }

        protected void img_agregar_item_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("utilitarios/busqueda.aspx");
        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("almacen_nuevo_detalle.aspx");
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            div_confirmacion.Visible = false;
            div_error.Visible = false;
            estado_controles(true);
            
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cod_lote"] != null) {
                estado_controles(false);
                div_confirmacion.Visible = false;
                div_error.Visible = false;
            }
            else
            {
                Response.Redirect("almacen.aspx");
            }
        }
    }
}