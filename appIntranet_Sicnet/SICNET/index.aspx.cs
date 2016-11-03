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
    public partial class index : System.Web.UI.Page
    {


        #region "Declarariones"
        claseUtilitarios claseUtilitarios = new claseUtilitarios();
        public DataTable oDS_Datos_chat = new DataTable();
        

        #endregion

        public void listar_chat()
        {
            oDS_Datos_chat = claseUtilitarios.public_Mostrar_Datos_Chat();
        }


        #region "Procediminetos"
        
        
        private void cargar_gatgets() {
            //VENTAS POR MES 
            DataTable oDS_Datos_ven_mes = claseUtilitarios.public_Mostrar_Datos_INDEX("1");
            lbl_ventas_sem.Text = oDS_Datos_ven_mes.Rows[0]["VENTAS_MES"].ToString();
            DataTable oDS_Datos_Total = claseUtilitarios.public_Mostrar_Datos_INDEX("2");
            lbl_Total_Productos.Text = oDS_Datos_Total.Rows[0]["TOTAL"].ToString();
            DataTable oDS_Datos_Total_web = claseUtilitarios.public_Mostrar_Datos_INDEX("3");
            lbl_total_productos_web.Text = oDS_Datos_Total_web.Rows[0]["TOTAL"].ToString();
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lbl_mes.Text = DateTime.Now.ToString("MMMM").ToUpper();


                //CHAT


                listar_chat();
                cargar_gatgets();

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            cargar_gatgets();
                    listar_chat();
        }

        protected void txt_chat_TextChanged(object sender, EventArgs e)
        {

          
        }

     
    }
}