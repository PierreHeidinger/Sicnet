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
    public partial class clientes : System.Web.UI.Page
    {

        #region "Declaraciones"

        claseClientes claseClientes = new claseClientes();
        DataTable oDT_Datos;


        #endregion

        #region "Procedimientos"


        private void listar_clientes()
        {
            oDT_Datos = claseClientes.public_Lista_Clientes("");
            dg_listado_personal.DataSource = oDT_Datos;
            dg_listado_personal.DataBind();
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                listar_clientes();

            }

        }
    }
}