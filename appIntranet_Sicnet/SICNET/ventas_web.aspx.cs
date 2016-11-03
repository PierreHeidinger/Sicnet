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
    public partial class ventas_web : System.Web.UI.Page
    {
        #region "Declaraciones"

        clasePedidosWeb clasePedidos = new clasePedidosWeb();
        public DataTable oDt_Datos ;


        #endregion

        #region "Procedimientos"


        public void listar_pep()
        {
            oDt_Datos = clasePedidos.public_Lista_VENTAS("",DateTime.Now);
            dg_listado_al.DataSource = oDt_Datos;
            dg_listado_al.DataBind();

           


        }



        private void colores_filas()
        {
            Label estado = new Label();

            for (int i = 0; i < dg_listado_al.Items.Count; i++)
            {
                estado = (Label)dg_listado_al.Items[i].FindControl("lbl_estado");

                if (estado.Text == "PENDIENTE")
                {
                    dg_listado_al.Items[i].Cells[3].BackColor = System.Drawing.Color.DarkGray;
                }
                else if (estado.Text == "ENTREGADO")
                {
                    dg_listado_al.Items[i].BackColor = System.Drawing.Color.MediumSeaGreen;
                }
                else if (estado.Text == "ANULADO")
                {
                    dg_listado_al.Items[i].BackColor = System.Drawing.Color.Tomato;
                }
                

            }
        }


        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listar_pep();
            }
        }






       

        protected void dg_listado_al_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            colores_filas();

        }

      
    }
}