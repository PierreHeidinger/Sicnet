using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bibliotecaClases;
using System.Web.Security;

namespace appIntranet_Sicnet.login
{
    public partial class login : System.Web.UI.Page
    {

        #region "Declaraciones"

        claseUtilitarios claseUtilitarios = new claseUtilitarios();
        public DataTable oDS_DatosM;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }

        protected void login_Authenticate(object sender, AuthenticateEventArgs e)
        {

            
            bool Autenticado = false;
            Autenticado = LoginCorrecto(login1.UserName, login1.Password);
            e.Authenticated = Autenticado;if (Autenticado)
            {
                FormsAuthentication.RedirectFromLoginPage(login1.UserName, false);              
            }
            
            
            
        }


        public bool LoginCorrecto(String usuario, String contrasena)
        {
            oDS_DatosM = claseUtilitarios.public_Login(usuario, contrasena);

            if (oDS_DatosM.Rows.Count == 1)
            {
             
                return true;
            }
            else
            {
                return false;
            }
                
                
        }
    }
}