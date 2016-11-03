using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bibliotecaClases;
using System.Data;

namespace appIntranet_Sicnet.SICNET
{
    public partial class personal : System.Web.UI.Page
    {
        #region "Declaraciones"

        clasePersonal clasePersonal = new clasePersonal();
        claseUtilitarios claseUtilitarios = new claseUtilitarios();

        DataTable oDs_Datos;

        #endregion


        #region "Procedimientos"


        public void listar_personal()
        {
            oDs_Datos = clasePersonal.public_Lista_Personal("");
            dg_listado_personal.DataSource = oDs_Datos;
            dg_listado_personal.DataBind();
        }

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

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["cod_s"] != null)
                {
                    MENSAJE_EVENTO("1", "NUEVO PERSONAL GUARDADO SATISFACTORIAMENTE!");
                    
                }

                listar_personal();
            }
        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("personal_nuevo_detalle.aspx");
        }
    }
}