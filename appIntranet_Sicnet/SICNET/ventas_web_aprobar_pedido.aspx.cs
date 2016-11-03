using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bibliotecaClases;

namespace appIntranet_Sicnet.SICNET
{
    public partial class ventas_web_aprobar_pedido : System.Web.UI.Page
    {
        #region "DECLARACIONES"


        clasePedidosWeb web = new clasePedidosWeb();

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 

                if(Request.QueryString["COD_PEDIDO"]!= null)
                {
                    web.public_Mantenimiento_Aprobar_anular(Request.QueryString["COD_PEDIDO"],Request.QueryString["COD_ESTADO"]);

                    if(Request.QueryString["COD_ESTADO"].ToString() == "2")
                    {
                        img_personal.ImageUrl = "http://accentsenglishacademy.com/wp-content/uploads/2013/01/aprobado.png";
                    }
                    else
                    {
                        img_personal.ImageUrl = "http://1.bp.blogspot.com/-zkVm1ho0aZo/USztochJZQI/AAAAAAAAA48/WiyfrcUmo3g/s1600/anulada.png";
                    }
                }

                
            }
        }
    }
}