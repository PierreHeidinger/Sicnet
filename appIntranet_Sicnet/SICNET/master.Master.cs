using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using bibliotecaClases;
using System.Data;

namespace appIntranet_Sicnet.SICNET
{
    public partial class master : System.Web.UI.MasterPage
    {

        #region "Declarariones"
        claseUtilitarios claseUtilitarios = new claseUtilitarios();
        clasePedidosWeb clasePw = new clasePedidosWeb();
        DataTable oDS_Datos; 
       
        #endregion

        #region "Procediminetos"

        public void mostrar_datos_personal(String a_cod)
        {
            oDS_Datos = claseUtilitarios.public_Mostrar_Datos_PERSONAL(a_cod);

            if(oDS_Datos.Rows.Count > 0)
            {
                lbl_Nombre_personal.Text =  oDS_Datos.Rows[0]["NOMBRES"].ToString();
                lbl_User.Text = oDS_Datos.Rows[0]["USUARIO"].ToString().ToUpper();
                lbl_email.Text = oDS_Datos.Rows[0]["EMAIL_PERSONAL"].ToString();

                if(oDS_Datos.Rows[0]["RUTA_IMG"] != null)
                {
                    img_personal.ImageUrl = oDS_Datos.Rows[0]["RUTA_IMG"].ToString();
                }

                Session["COD_PERSONAL"] = oDS_Datos.Rows[0]["COD_PERSONAL"].ToString();
            }
        }


        public void Notificaciones()
        {

            String pendientes_out = "         ";
            String emtregados_out = "         ";
            String anulados_out = "         ";

            lbl_pep_pendientes.Text = clasePw.public_Lista_VENTAS_WEB_NOT("1",pendientes_out);
            lbl_entregados_sin_reg.Text = clasePw.public_Lista_VENTAS_WEB_NOT("2", emtregados_out);
            lbl_anulados.Text = clasePw.public_Lista_VENTAS_WEB_NOT("3", anulados_out);

           
            lbl_total_not_i.Text = (int.Parse(lbl_pep_pendientes.Text) + int.Parse(lbl_entregados_sin_reg.Text) + int.Parse(lbl_anulados.Text)).ToString();
            lbl_total_not.Text = lbl_total_not_i.Text;


        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                mostrar_datos_personal(this.Page.User.Identity.Name.Trim());
                Notificaciones();

            }
        }

        protected void btn_Profiles_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Salir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../login/login.aspx");
        }

    

        protected void hp_Ventas_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("ventas.aspx");
            
        }

        protected void hp_Ventas_web_Click(object sender, EventArgs e)
        {
            Response.Redirect("ventas_web.aspx");
        }

        protected void Tm_notificaciones_Tick(object sender, EventArgs e)
        {
            Notificaciones();
        }
    }
}