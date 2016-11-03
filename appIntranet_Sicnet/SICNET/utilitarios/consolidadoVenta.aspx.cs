using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bibliotecaClases;
using System.Data;

namespace appIntranet_Sicnet.SICNET.utilitarios
{
    public partial class consolidadoVenta : System.Web.UI.Page
    {
        #region "Declaraciones"
        claseItems claseItems = new claseItems();

        claseVentas claseVentas = new claseVentas();

        public DataTable oDs_Datos;
        public DataTable oDs_Detalle;

        #endregion
        #region "Procedimientos"


        public void mostrar_datos_venta()
        {
            oDs_Datos = claseVentas.public_Mostrar_Datos_VENTA(Request.QueryString["cod_venta"].Trim());

            if(oDs_Datos.Rows.Count > 0)
            {

                if(oDs_Datos.Rows[0]["COD_VENTA"].ToString() != null)
                {
                    lbl_CodigoVenta.Text = oDs_Datos.Rows[0]["COD_VENTA"].ToString();
                }
                if (oDs_Datos.Rows[0]["TOTAL_VENTA"].ToString() != null)
                {
                    lbl_sub_total.Text = oDs_Datos.Rows[0]["TOTAL_VENTA"].ToString();
                }
                if (oDs_Datos.Rows[0]["TOTAL_VENTA"].ToString() != null)
                {
                    lbl_Total_venta.Text = oDs_Datos.Rows[0]["TOTAL_VENTA"].ToString();
                }
                if (oDs_Datos.Rows[0]["FECHA"].ToString() != null)
                {
                    lbl_Fecha_Venta.Text = oDs_Datos.Rows[0]["FECHA"].ToString();
                }

               


            }

        }



        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mostrar_datos_venta();
                // Response.Write("<script>javascript:window.print();</script>");
                //Response.Write(oDs_Detalle.Rows.Count.ToString());
                oDs_Detalle = claseVentas.public_Mostrar_Datos_VENTA_DETALLE(Request.QueryString["cod_venta"].Trim());
                //Response.Write(oDs_Detalle.Rows[0]["COD_LOTE"].ToString());

            }
        }
    }
}