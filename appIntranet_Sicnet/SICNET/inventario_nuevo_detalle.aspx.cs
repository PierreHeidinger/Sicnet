using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bibliotecaClases;
using System.IO;

namespace appIntranet_Sicnet.SICNET
{
    public partial class inventario_nuevo_detalle : System.Web.UI.Page
    {
        #region "DECLARACIONES"
        public DataTable odsDatos;
        claseItems claseItems = new claseItems();
        claseUtilitarios claseUtilitarios = new claseUtilitarios();



        #endregion


        #region "Procedimientos"

        public void mostrar_datos_item(String i_cod)
        {
            odsDatos = claseItems.public_Mostrar_Datos_ITEMS(i_cod);


            if (odsDatos.Rows.Count > 0)
            {



                if (odsDatos.Rows[0]["COD_ITEM"].ToString() != null)
                {
                    txt_Codigo.Text = odsDatos.Rows[0]["COD_ITEM"].ToString();
                }
                else {
                    txt_Codigo.Text = "";
                }

                if (odsDatos.Rows[0]["TIP_ITEM"].ToString() != null)
                {
                    cbo_Tipo.SelectedValue = odsDatos.Rows[0]["TIP_ITEM"].ToString();
                }
                else {
                    cbo_Tipo.SelectedIndex = 0;
                }

                if (odsDatos.Rows[0]["CAT_ITEM"].ToString() != null)
                {
                    cbo_categoria.SelectedValue = odsDatos.Rows[0]["CAT_ITEM"].ToString();

                }
                else {
                    cbo_categoria.SelectedIndex = 0;
                }

                if (odsDatos.Rows[0]["SUB_CAT_ITEM"].ToString() != null)
                {
                    cbo_sub_categoria.SelectedValue = odsDatos.Rows[0]["SUB_CAT_ITEM"].ToString();

                }
                else {
                    cbo_sub_categoria.SelectedIndex = 0;
                }
                if (odsDatos.Rows[0]["MARCA_ITEM"].ToString() != null)
                {
                    cbo_Marca.SelectedValue = odsDatos.Rows[0]["MARCA_ITEM"].ToString();
                }
                else {
                    cbo_Marca.SelectedIndex = 0;
                }

                if (odsDatos.Rows[0]["DES_ITEM"].ToString() != null)
                {
                    txt_Descripcion.Text = odsDatos.Rows[0]["DES_ITEM"].ToString();
                }
                else {
                    txt_Descripcion.Text = "";
                }
                if (odsDatos.Rows[0]["COM_ITEM"].ToString() != null)
                {
                    txt_Comentarios.Text = odsDatos.Rows[0]["COM_ITEM"].ToString();
                }
                else {
                    txt_Comentarios.Text = "";
                }
                if (odsDatos.Rows[0]["COD_COM_ITEM"].ToString() != null)
                {
                    txt_Cod_Comercial.Text = odsDatos.Rows[0]["COD_COM_ITEM"].ToString();
                }
                else {
                    txt_Cod_Comercial.Text = "";
                }
                if (odsDatos.Rows[0]["STOCK_ITEM"].ToString() != null)
                {
                    txt_Stock.Text = odsDatos.Rows[0]["STOCK_ITEM"].ToString();
                }
                else {
                    txt_Stock.Text = "";
                }
                if (odsDatos.Rows[0]["EST_ITEM"].ToString() != null)
                {
                    cbo_Estado.SelectedValue = odsDatos.Rows[0]["EST_ITEM"].ToString();
                }
                else {
                    cbo_Estado.SelectedIndex = 0;
                }

                if (odsDatos.Rows[0]["FEC_REG_ITEM"].ToString() != null)
                {
                    lbl_Fecha_registo.Text = odsDatos.Rows[0]["FEC_REG_ITEM"].ToString();
                }
                else {
                    lbl_Fecha_registo.Text = "";
                }
                if (odsDatos.Rows[0]["COSTO_ITEM"].ToString() != null)
                {
                    txt_Costo_Item.Text = odsDatos.Rows[0]["COSTO_ITEM"].ToString().Replace(",", ".");
                }
                else {
                    txt_Costo_Item.Text = "";
                }
                if (odsDatos.Rows[0]["UTILIDAD_ITEM"].ToString() != null)
                {
                    txt_Porc_Utilidad.Text = odsDatos.Rows[0]["UTILIDAD_ITEM"].ToString().Replace(",", ".");
                }
                else {
                    txt_Porc_Utilidad.Text = "";
                }
                if (odsDatos.Rows[0]["COSTO_SETVICIO"].ToString() != null)
                {
                    txt_costo_servicio.Text = odsDatos.Rows[0]["COSTO_SETVICIO"].ToString().Replace(",", ".");
                }
                else {
                    txt_costo_servicio.Text = "";
                }

                if (odsDatos.Rows[0]["PRECIO_VENTA"].ToString() != null)
                {
                    txt_Precio_venta.Text = odsDatos.Rows[0]["PRECIO_VENTA"].ToString().Replace(",", ".");
                }
                else {
                    txt_Precio_venta.Text = "";
                }
                if (odsDatos.Rows[0]["DES_WEB_ITEM"].ToString() != null)
                {
                    txt_Descripcion_web.Text = odsDatos.Rows[0]["DES_WEB_ITEM"].ToString();
                }
                else {
                    txt_Descripcion_web.Text = "";
                }
                if (odsDatos.Rows[0]["DISP_WEB"].ToString() != null)
                {
                    cbo_Disp_Web.SelectedValue = odsDatos.Rows[0]["DISP_WEB"].ToString();
                }
                else {
                    cbo_Disp_Web.SelectedIndex = 0;
                }
                if (odsDatos.Rows[0]["RUTA_IMG"].ToString() != null)
                {
                    img_Web.ImageUrl = odsDatos.Rows[0]["RUTA_IMG"].ToString();
                }
                else {
                    img_Web.ImageUrl = "";
                }
                if (odsDatos.Rows[0]["PRECIO_WEB"].ToString() != null)
                {
                    txt_Precio_web.Text = odsDatos.Rows[0]["PRECIO_WEB"].ToString().Replace(",",".");
                }
                else {
                    txt_Precio_web.Text = "0.00";
                }



            }


            estado_controles(false);

        }

        public void MENSAJE_EVENTO(string tipo , string mensaje)
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

        public void estado_controles(Boolean EST_)
        {

            txt_Codigo.Enabled = EST_;
            cbo_Tipo.Enabled = EST_;
            cbo_categoria.Enabled = EST_;
            cbo_sub_categoria.Enabled = EST_;
            cbo_Marca.Enabled = EST_;
            txt_Descripcion.Enabled = EST_;
            txt_Comentarios.Enabled = EST_;
            txt_Cod_Comercial.Enabled = EST_;
            txt_Stock.Enabled = EST_;
            cbo_Estado.Enabled = EST_;
            txt_Costo_Item.Enabled = EST_;
            txt_Porc_Utilidad.Enabled = EST_;
            txt_costo_servicio.Enabled = EST_;
            txt_Precio_venta.Enabled = EST_;
            txt_Descripcion_web.Enabled = EST_;
            cbo_Disp_Web.Enabled = EST_;
            txt_Precio_web.Enabled = EST_;

            btn_NUEVO.Enabled = !EST_;
            btn_Editar.Enabled = !EST_;
            btn_Imprimir.Enabled = !EST_;
            btn_Email.Enabled = !EST_;

            btn_Grabar.Enabled = EST_;
            btn_Cancelar.Enabled = EST_;
            img_File.Enabled = EST_;


            if (EST_ == true)
            {



                txt_Codigo.ForeColor = System.Drawing.Color.SteelBlue;
                cbo_Tipo.ForeColor = System.Drawing.Color.Indigo;
                cbo_categoria.ForeColor = System.Drawing.Color.Indigo;
                cbo_sub_categoria.ForeColor = System.Drawing.Color.Indigo;
                cbo_Marca.ForeColor = System.Drawing.Color.Indigo;
                txt_Descripcion.ForeColor = System.Drawing.Color.Indigo;
                txt_Comentarios.ForeColor = System.Drawing.Color.Indigo;
                txt_Cod_Comercial.ForeColor = System.Drawing.Color.Indigo;
                txt_Stock.ForeColor = System.Drawing.Color.Indigo;
                cbo_Estado.ForeColor = System.Drawing.Color.Indigo;
                txt_Costo_Item.ForeColor = System.Drawing.Color.Indigo;
                txt_Porc_Utilidad.ForeColor = System.Drawing.Color.Indigo;
                txt_costo_servicio.ForeColor = System.Drawing.Color.Indigo;
                txt_Precio_venta.ForeColor = System.Drawing.Color.Indigo;
                txt_Descripcion_web.ForeColor = System.Drawing.Color.Indigo;
                cbo_Disp_Web.ForeColor = System.Drawing.Color.Indigo;
                txt_Precio_web.ForeColor = System.Drawing.Color.Indigo;





            }
            else
            {
                txt_Codigo.ForeColor = System.Drawing.Color.Black;
                cbo_Tipo.ForeColor = System.Drawing.Color.Black;
                cbo_categoria.ForeColor = System.Drawing.Color.Black;
                cbo_sub_categoria.ForeColor = System.Drawing.Color.Black;
                cbo_Marca.ForeColor = System.Drawing.Color.Black;
                txt_Descripcion.ForeColor = System.Drawing.Color.Black;
                txt_Comentarios.ForeColor = System.Drawing.Color.Black;
                txt_Cod_Comercial.ForeColor = System.Drawing.Color.Black;
                txt_Stock.ForeColor = System.Drawing.Color.Black;
                cbo_Estado.ForeColor = System.Drawing.Color.Black;
                txt_Costo_Item.ForeColor = System.Drawing.Color.Black;
                txt_Porc_Utilidad.ForeColor = System.Drawing.Color.Black;
                txt_costo_servicio.ForeColor = System.Drawing.Color.Black;
                txt_Precio_venta.ForeColor = System.Drawing.Color.Black;
                txt_Descripcion_web.ForeColor = System.Drawing.Color.Black;
                cbo_Disp_Web.ForeColor = System.Drawing.Color.Black;
                txt_Precio_web.ForeColor = System.Drawing.Color.Black;



            }

        }

        public void setear_categorias()
        {
            odsDatos = claseItems.public_Listar_categorias();
            cbo_categoria.DataSource = odsDatos;
            cbo_categoria.DataTextField = "DES_CAT";
            cbo_categoria.DataValueField = "COD_CAT";
            cbo_categoria.DataBind();
        }

        public void setear_sub_categorias(String a_COD_CAT)
        {

            odsDatos = claseItems.public_Listar_sub_categorias(a_COD_CAT);
            cbo_sub_categoria.DataSource = odsDatos;
            cbo_sub_categoria.DataTextField = "DES_SUB_CATEGORIA";
            cbo_sub_categoria.DataValueField = "COD_SUB_CATEGORIA";
            cbo_sub_categoria.DataBind();

        }

        public void setear_sub_marcas(String a_COD_SUB_CAT)
        {

            odsDatos = claseItems.public_Listar_marcas(a_COD_SUB_CAT);
            cbo_Marca.DataSource = odsDatos;
            cbo_Marca.DataTextField = "DES_MARCA";
            cbo_Marca.DataValueField = "COD_MARCA";
            cbo_Marca.DataBind();

        }

        public void mostrar_historial(String a_COD_ITEM)
        {
            odsDatos = claseItems.public_Mostrar_Datos_HISTORIAL(a_COD_ITEM);
            gw_items_historial.DataSource = odsDatos;
            gw_items_historial.DataBind();
        }


        public string cargar_imagen()
        {
            //GUARDAR EN SERVIDOR
            if (img_File.FileName != null && img_File.FileName != "") {
                String v_Ruta_Local = img_File.PostedFile.FileName;
                String v_Ruta_Servidor = Path.Combine(@"C:\inetpub\wwwroot\intranet\SICNET\source_item\", img_File.FileName);
                img_File.PostedFile.SaveAs(v_Ruta_Servidor);

                //MOSTRAR_RUTA_ARCHIVO

                String v_Ruta_archivo_x = Path.Combine(@"http://aloochelita.sytes.net/intranet/SICNET/source_item/" + img_File.FileName);

                return v_Ruta_archivo_x.ToString();
            }
            else {
                return "";
            }
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                setear_categorias();
                setear_sub_categorias("");
                setear_sub_marcas("");

                if (Request.QueryString["cod_item"] != null)
                {

                    mostrar_datos_item(Request.QueryString["cod_item"]);
                    mostrar_historial(txt_Codigo.Text.Trim());
                    estado_controles(false);


                }
                else {

                    estado_controles(true);
                }

            }


        }






        protected void btn_Grabar_Click(object sender, EventArgs e)
        {

            try {


                String codigo_out = "";

                if (cbo_Tipo.SelectedIndex == 0) {                    
                    MENSAJE_EVENTO("2", "DEBE DE SELECCIONAR UN TIPO!");
                    return;
                }
                if (cbo_categoria.SelectedIndex == 0) {                   
                    MENSAJE_EVENTO("2", "Debe seleccionar la categoria!");
                    return;
                }
                if (cbo_sub_categoria.SelectedIndex == 0) {                   
                    MENSAJE_EVENTO("2", "Debe seleccionar alguna sub categoria");
                    return;
                }
                if (cbo_Marca.SelectedIndex == 0) {
                    
                    MENSAJE_EVENTO("2", "Debe seleccionar la marca el Item");
                    
                    return;
                }
                if (txt_Descripcion.Text == "") {
                    
                    MENSAJE_EVENTO("2", "Escriba la descriccion del Producto!");
                    
                    return;
                }



                if (cbo_Disp_Web.SelectedIndex == 0)
                {
                    if (txt_Descripcion_web.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                          "alert('Si el item estara disponible via web , es nesesario la descricion de publicacion');", true);
                        return;
                    }
                    if(img_Web.ImageUrl == "") { 
                        if (img_File.FileName == null || img_File.FileName == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                            "alert('Si el item estara disponible via web , es nesesario ingresar una imagen');", true);
                            return;
                        }
                    }
                    if (txt_Precio_web.Text == "" || txt_Precio_web.Text == "0.00")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                          "alert('Si el item estara disponible via web , es nesesario el precio de publicacion');", true);
                        return;
                    }
                   
                }
                String ruta;
                    if (img_Web.ImageUrl == "") {
                    ruta = cargar_imagen();
                }
                else
                {
                    if(img_File.FileName != null && img_File.FileName != "") {
                        ruta = cargar_imagen();
                    }
                    else
                    {
                        ruta = img_Web.ImageUrl;

                    }
                }


                if (Request.QueryString["cod_item"] != null)
                    {
                        codigo_out = claseItems.public_Mantenimiento_Items("2", txt_Codigo.Text.Trim(), cbo_Tipo.SelectedValue, cbo_categoria.SelectedValue, cbo_sub_categoria.SelectedValue, cbo_Marca.SelectedValue
                                                                           , txt_Descripcion.Text, txt_Comentarios.Text, txt_Cod_Comercial.Text, txt_Stock.Text, cbo_Estado.SelectedValue,
                                                                           txt_Costo_Item.Text, txt_Porc_Utilidad.Text, txt_costo_servicio.Text, txt_Precio_venta.Text,
                                                                           txt_Descripcion_web.Text, cbo_Disp_Web.SelectedValue, txt_Precio_web.Text, ruta);
                     mostrar_datos_item(txt_Codigo.Text.Trim());


                    MENSAJE_EVENTO("1", "CAMBIOS GUARDADOS SATISFACTORIAMENTE!");
                        
                    }
                    else
                    {

                        codigo_out = claseItems.public_Mantenimiento_Items("1", "", cbo_Tipo.SelectedValue, cbo_categoria.SelectedValue, cbo_sub_categoria.SelectedValue, cbo_Marca.SelectedValue
                                                                           , txt_Descripcion.Text, txt_Comentarios.Text, txt_Cod_Comercial.Text, txt_Stock.Text, cbo_Estado.SelectedValue,
                                                                           txt_Costo_Item.Text, txt_Porc_Utilidad.Text, txt_costo_servicio.Text, txt_Precio_venta.Text,
                                                                           txt_Descripcion_web.Text, cbo_Disp_Web.SelectedValue, txt_Precio_web.Text, ruta);



                        Response.Redirect("inventario.aspx?sus=1");

                    }


                }catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                          "alert('"+EX.Message+"');", true);
                return;
            }
        } 

        
        

    

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("inventario_nuevo_detalle.aspx");
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            estado_controles(true);
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cod_item"] != null)
            {
                estado_controles(false);
            }
            else
            {
                Response.Redirect("inventario.aspx");
            }
        }

        protected void cbo_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            setear_sub_categorias(cbo_categoria.SelectedValue);
            setear_sub_marcas("9");
        }

        protected void cbo_sub_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            setear_sub_marcas(cbo_sub_categoria.SelectedValue);
        }

        protected void btn_Pruebita_Click(object sender, EventArgs e)
        {
            string pruebita = cargar_imagen();

            ScriptManager.RegisterStartupScript(this, GetType(), "m", "alert('" + pruebita + "')", true);
        }
    }
}