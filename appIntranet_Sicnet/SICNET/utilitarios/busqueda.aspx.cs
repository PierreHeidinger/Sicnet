using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bibliotecaClases;

namespace appIntranet_Sicnet.SICNET.utilitarios
{
    public partial class busqueda : System.Web.UI.Page
    {

        #region "Declaraciones"

        claseItems claseItems = new claseItems();
        claseLotes claseLotes = new claseLotes();
        public DataTable odS_Datos;
        #endregion

        #region "Procedimientos"

        public void mostrar_items(String a_DESCRIPCION)
        {
            odS_Datos = claseLotes.public_Lista_ITEMS(a_DESCRIPCION);
            gw_items.DataSource = odS_Datos;
            gw_items.DataBind();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    mostrar_items("");
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }
            }
        }

        protected void txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            mostrar_items(txt_Descripcion.Text.Trim());
        }

        protected void gw_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row;

                row = gw_items.SelectedRow;

                lbl_codigo_item.Text = row.Cells[1].Text;

                btnCargar.Enabled = true;

               
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../almacen_nuevo_detalle.aspx?cod_item=" + lbl_codigo_item.Text.Trim());

        }

        protected void btn_REGRESAR_Click(object sender, EventArgs e)
        {
            Response.Redirect("../almacen_nuevo_detalle.aspx");
        }
    }
}