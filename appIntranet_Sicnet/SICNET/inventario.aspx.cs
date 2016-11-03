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
    public partial class inventario : System.Web.UI.Page
    {

        #region "DECLARACIONES"
        claseItems claseitems = new claseItems();
        public DataTable Ods_Datos;

        #endregion

        #region "PROCEDIMIENTOS"

        public void listarItems(String a_COD_ITEM, String A_DESCRIPCION, String a_WEB)
        {
            Ods_Datos = claseitems.public_Lista_ITEMS(a_COD_ITEM ,A_DESCRIPCION,a_WEB);
            dg_listado_items.DataSource = Ods_Datos;
            dg_listado_items.DataBind();
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["sus"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                     "alert('Item grabado con exito, Salud!');", true);
                }

                if (Request.QueryString["web"] != null)
                {
                    listarItems("%", "%", "1");
                    cbo_web.SelectedIndex = 1;
                }
                else
                {
                    listarItems("%", "%", "%");
                }

                
            }
            
        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("inventario_nuevo_detalle.aspx");
           
        }



       

        protected void btn_Excel_Click(object sender, EventArgs e)
        {


            //    Try
            //    dg_EXCEL_X.DataSource = objCot.fPub_SP_OPP_CAB_MOSTRAR_LISTADO_EXCEL(Session("txt_N_OPP_CONDICION_OPP1"), Session("txt_Fec1_CONDICION_OPP1"), Session("txt_Fec2_CONDICION_OPP1"), Session("cbo_Medio_CONDICION_OPP1"), Session("cbo_Estado_CONDICION_OPP1"), Session("cbo_Personal_CONDICION_OPP1"), Session("cbo_EJECUTIVO_CONDICION_OPP1"), Session("txt_CLIENTE_X_CONDICION_OPP1"), Session("txt_ASUNTO_CONDICION_OPP1"), Session("cbo_REGISTRADO_CONDICION_OPP1"), Session("cbo_REVISADO_CONDICION_OPP1"), Session("cbo_NIVEL_CONDICCION_OPP1"), Session("cbo_MARCA_CONDICCION_OPP1"))
            //    dg_EXCEL_X.DataBind()

            //    Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter
            //    Dim htmlWriter As HtmlTextWriter = New HtmlTextWriter(stringWriter)
            //    dg_EXCEL_X.RenderControl(htmlWriter)

            //    Response.Buffer = True
            //    Response.ContentType = "application/vnd.ms-excel"
            //    Response.AddHeader("content-disposition", "attachment; filename=Export.xls")
            //    Response.ContentEncoding = System.Text.Encoding.UTF8
            //    Response.Charset = ""

            //    Response.Write(stringWriter.ToString())
            //    Response.End()
            //Catch ex As Exception

            //End Try


            try
            {

                if(dg_listado_items.Items.Count > 0)
                {

                    StringWriter stringWriter = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
                    dg_listado_items.RenderControl(htmlWriter);

                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment; filename= "+"Export to Sicnet Inventario -" +DateTime.Now.ToString("dd/MM/yyyy")+".xls");
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Charset = "";

                    Response.Write(stringWriter.ToString());
                    Response.End();


                }

                
            }catch(Exception ex)
            {

            }
        }

        

        
        protected void txt_Codigo_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                listarItems(txt_Codigo.Text, txt_Descripcion.Text, cbo_web.SelectedValue);
            }
            catch (Exception ex)
            {

            }
        }

        protected void txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listarItems(txt_Codigo.Text, txt_Descripcion.Text, cbo_web.SelectedValue);
            }
            catch (Exception ex)
            {

            }
        }

        protected void cbo_web_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listarItems(txt_Codigo.Text, txt_Descripcion.Text, cbo_web.SelectedValue);
            }
            catch (Exception ex)
            {

            }
        }
    }
}