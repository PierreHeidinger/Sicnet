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
    public partial class almacen : System.Web.UI.Page
    {
        #region "DECLARACIONES"
        claseLotes claseLotes = new claseLotes();
        public DataTable Ods_Datos;

        #endregion

        #region "PROCEDIMIENTOS"



        public void listar_lotes()
        {
            try {
                Ods_Datos = claseLotes.public_Lista_Lotes(txt_Item.Text.Trim(), DateTime.Parse(txt_fecha1.Text), DateTime.Parse(txt_fecha2.Text), cbo_Estado.SelectedValue);
                dg_listado_lotes.DataSource = Ods_Datos;
                dg_listado_lotes.DataBind();
            } catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('" + ex.Message + "')", true);
            }
        }


        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["sus"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                      "alert('El lote fue ingresado de manera satisfactoria,Salud');", true);


                }

                txt_fecha1.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                txt_fecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");


                listar_lotes();
            }
        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("almacen_nuevo_detalle.aspx");
        }

        protected void txt_Item_TextChanged(object sender, EventArgs e)
        {
            listar_lotes();
        }

        protected void txt_fecha1_TextChanged(object sender, EventArgs e)
        {
            listar_lotes();
        }

        protected void txt_fecha2_TextChanged(object sender, EventArgs e)
        {
            listar_lotes();
        }

        protected void cbo_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            listar_lotes();
        }

        protected void btn_Excel_Click(object sender, EventArgs e)
        {
            try
            {

                if (dg_listado_lotes.Items.Count > 0)
                {

                    StringWriter stringWriter = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
                    dg_listado_lotes.RenderControl(htmlWriter);

                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment; filename= " + "Export to Sicnet Almacen -" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Charset = "";

                    Response.Write(stringWriter.ToString());
                    Response.End();


                }


            }
            catch (Exception ex)
            {

            }
        }

    }
}