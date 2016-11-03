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
    }
}