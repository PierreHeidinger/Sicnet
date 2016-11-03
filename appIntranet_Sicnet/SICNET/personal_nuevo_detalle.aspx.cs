using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bibliotecaClases;
using System.IO;

namespace appIntranet_Sicnet.SICNET
{
    public partial class personal_nuevo_detalle : System.Web.UI.Page
    {

        #region "Declaraciones"

        clasePersonal clasePersonal = new clasePersonal();
        claseUtilitarios claseUtilitarios = new claseUtilitarios();
        DataTable oDs_Datos = new DataTable();
        #endregion

        #region "Procedimientos"


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

        public string cargar_imagen()
        {
            //GUARDAR EN SERVIDOR
            if (img_file.FileName != null && img_file.FileName != "")
            {
                String v_Ruta_Local = img_file.PostedFile.FileName;
                String v_Ruta_Servidor = Path.Combine(@"C:\inetpub\wwwroot\intranet\SICNET\source_personal\", img_file.FileName);
                img_file.PostedFile.SaveAs(v_Ruta_Servidor);

                //MOSTRAR_RUTA_ARCHIVO

                String v_Ruta_archivo_x = Path.Combine(@"http://aloochelita.sytes.net/intranet/SICNET/source_personal/" + img_file.FileName);

                return v_Ruta_archivo_x.ToString();
            }
            else {
                return "";
            }



        }

        public void cargar_datos(String codigo)
        {
            oDs_Datos = clasePersonal.public_Mostrar_Datos_Personal(codigo);

            if(oDs_Datos.Rows.Count > 0)
            {
                if (oDs_Datos.Rows[0]["COD_PERSONAL"] != null)
                {
                    txt_codigo.Text = oDs_Datos.Rows[0]["COD_PERSONAL"].ToString();
                }
                if (oDs_Datos.Rows[0]["NOM_PER"] != null)
                {
                    txt_nombres.Text = oDs_Datos.Rows[0]["NOM_PER"].ToString();
                }
                if (oDs_Datos.Rows[0]["APE_P_PER"] != null)
                {
                    txt_apellidos.Text = oDs_Datos.Rows[0]["APE_P_PER"].ToString();
                }
                if (oDs_Datos.Rows[0]["FEC_NAC"] != null)
                {
                    txt_fecha_nacimiento.Text = DateTime.Parse(oDs_Datos.Rows[0]["FEC_NAC"].ToString()).ToString("dd/MM/yyyy"); ;
                }
                if (oDs_Datos.Rows[0]["EMAIL_PERSONAL"] != null)
                {
                    txt_Email.Text = oDs_Datos.Rows[0]["EMAIL_PERSONAL"].ToString();
                }
                if (oDs_Datos.Rows[0]["SEXO"] != null)
                {
                    rdo_Sexo.SelectedValue = oDs_Datos.Rows[0]["SEXO"].ToString();
                }
                if (oDs_Datos.Rows[0]["DEPARTAMENTO"] != null)
                {
                    txt_Departamento.Text = oDs_Datos.Rows[0]["DEPARTAMENTO"].ToString();
                }
                if (oDs_Datos.Rows[0]["PROVINCIA"] != null)
                {
                    txt_provincia.Text = oDs_Datos.Rows[0]["PROVINCIA"].ToString();
                }
                if (oDs_Datos.Rows[0]["DISTRITO"] != null)
                {
                    txt_Distrito.Text = oDs_Datos.Rows[0]["DISTRITO"].ToString();
                }
                if (oDs_Datos.Rows[0]["DIRECCION"] != null)
                {
                    txt_direccion.Text = oDs_Datos.Rows[0]["DIRECCION"].ToString();
                }
                if (oDs_Datos.Rows[0]["CELULAR"] != null)
                {
                    txt_telefono.Text = oDs_Datos.Rows[0]["CELULAR"].ToString();
                }
                if (oDs_Datos.Rows[0]["CARGO_EMPRESA"] != null)
                {
                    txt_cargo.Text = oDs_Datos.Rows[0]["CARGO_EMPRESA"].ToString();
                }
                if (oDs_Datos.Rows[0]["ALIAS"] != null)
                {
                    txt_Alias.Text = oDs_Datos.Rows[0]["ALIAS"].ToString();
                }
                if (oDs_Datos.Rows[0]["ALIAS"] != null)
                {
                    txt_Alias.Text = oDs_Datos.Rows[0]["ALIAS"].ToString();
                }
                if (oDs_Datos.Rows[0]["USUARIO"] != null)
                {
                    txt_usuario.Text = oDs_Datos.Rows[0]["USUARIO"].ToString();
                }
                if (oDs_Datos.Rows[0]["CONTRASENA"] != null)
                {
                    txt_contrasena.Text = oDs_Datos.Rows[0]["CONTRASENA"].ToString();
                }
                if(oDs_Datos.Rows[0]["EMAIL_EMPRESA"] != null)
                {
                    txt_email_empresa.Text = oDs_Datos.Rows[0]["EMAIL_EMPRESA"].ToString();
                }
                if (oDs_Datos.Rows[0]["COD_ESTADO"] != null)
                {
                    rdo_Estado.SelectedValue = oDs_Datos.Rows[0]["COD_ESTADO"].ToString();
                }
                if (oDs_Datos.Rows[0]["RUTA_IMG"] != null)
                {
                    img_personal.ImageUrl = oDs_Datos.Rows[0]["RUTA_IMG"].ToString();
                }
                if (oDs_Datos.Rows[0]["FEC_ING"] != null)
                {
                    txt_Fecha_Ingreso.Text = oDs_Datos.Rows[0]["FEC_ING"].ToString();
                }


            }

        }

        public void estado_controles(bool _est)
        {
            txt_nombres.Enabled     = _est;
            txt_apellidos.Enabled    = _est;
            txt_fecha_nacimiento.Enabled = _est;
            txt_Email.Enabled = _est;
            rdo_Sexo.Enabled = _est;
            txt_Departamento.Enabled = _est;
            txt_provincia.Enabled = _est;
            txt_Distrito.Enabled = _est;
            txt_direccion.Enabled = _est;
            txt_telefono.Enabled = _est;
            txt_cargo.Enabled = _est;
            txt_Alias.Enabled = _est;
            txt_usuario.Enabled = _est;
            txt_contrasena.Enabled = _est;
            txt_email_empresa.Enabled = _est;
            rdo_Estado.Enabled = _est;
            txt_Fecha_Ingreso.Enabled = _est;
            img_file.Enabled = _est;
            
          
                

                btn_NUEVO.Enabled = !_est;
                btn_Editar.Enabled = !_est;
                btn_Email.Enabled = !_est;
                btn_Imprimir.Enabled = !_est;
                btn_Grabar.Enabled = _est;
                btn_Cancelar.Enabled = _est;
            
            

        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["cod_personal"] != null)
                {
                    cargar_datos(Request.QueryString["cod_personal"]);
                    estado_controles(false);

                    if (Session["cod_personal"].ToString() == Request.QueryString["cod_personal"] || Session["cod_personal"].ToString()=="2002")
                    {
                        btn_Editar.Enabled = true;
                        
                    }
                    else
                    {
                        btn_Editar.Enabled = false;
                        txt_contrasena.Text = "*********";
                    }
                }
                else{
                    estado_controles(true);
                    txt_Fecha_Ingreso.Text = DateTime.Now.ToShortDateString();

                }


                
            }
        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("personal_nuevo_detalle.aspx");
            
        }

        protected void btn_Grabar_Click(object sender, EventArgs e)
        {
            String ruta;



            if (txt_nombres.Text == "")
            {
                MENSAJE_EVENTO("2", "DEBE DE INGRESAR EL NOMBRE !");
                return;
            }
            if (txt_apellidos.Text == "")
            {
                MENSAJE_EVENTO("2", "DEBE DE INGRESAR LOS APELLIDOS !");
                return;
            }

            if (txt_fecha_nacimiento.Text == "")
            {
                MENSAJE_EVENTO("2", "DEBE DE INGRESAR LA FECHA DE NACIMIENTO !");
                return;
            }
            if (txt_cargo.Text == "")
            {
                MENSAJE_EVENTO("2", "DEBE DE INGRESAR EL CARGO QUE OCUPA !");
                return;
            }
            if (txt_usuario.Text == "")
            {
                MENSAJE_EVENTO("2", "DEBE DE INGRESAR EL USUARIO !");
                return;
            }
            if (txt_contrasena.Text == "")
            {
                MENSAJE_EVENTO("2", "DEBE DE INGRESAR LA CONTRASEÑA !");
                return;
            }




            if (img_personal.ImageUrl == "")
            {
                ruta = cargar_imagen();
            }
            else
            {
                if (img_file.FileName != null && img_file.FileName != "")
                {
                    ruta = cargar_imagen();
                }
                else
                {
                    ruta = img_personal.ImageUrl;

                }
            }






            try
            {

                if(Request.QueryString["cod_personal"] != null)
                {
                    clasePersonal.public_Mantenimiento_Personal("2",txt_codigo.Text ,txt_nombres.Text, txt_apellidos.Text, "", DateTime.Parse(txt_Fecha_Ingreso.Text), DateTime.Parse(txt_fecha_nacimiento.Text), rdo_Sexo.SelectedValue, txt_Email.Text, txt_email_empresa.Text, txt_Departamento.Text
                                                             , txt_provincia.Text, txt_Distrito.Text, txt_direccion.Text, txt_telefono.Text, txt_cargo.Text, txt_Alias.Text, txt_usuario.Text, txt_contrasena.Text, rdo_Estado.SelectedValue, ruta);

                    cargar_datos(txt_codigo.Text);
                    MENSAJE_EVENTO("1", "LOS DATOS SE GUARDARON CON EXITO!");
                    estado_controles(false);
                }
                else
                {
                    clasePersonal.public_Mantenimiento_Personal("1", txt_codigo.Text,txt_nombres.Text, txt_apellidos.Text, "", DateTime.Parse(txt_Fecha_Ingreso.Text), DateTime.Parse(txt_fecha_nacimiento.Text), rdo_Sexo.SelectedValue, txt_Email.Text, txt_email_empresa.Text, txt_Departamento.Text
                                                             , txt_provincia.Text, txt_Distrito.Text, txt_direccion.Text, txt_telefono.Text, txt_cargo.Text, txt_Alias.Text, txt_usuario.Text, txt_contrasena.Text, rdo_Estado.SelectedValue, ruta);

                    Response.Redirect("personal.aspx?cod_s=1");

                }
                
            }
            catch (Exception ex)

            {
                MENSAJE_EVENTO("2", ex.Message);

            }
        }

        protected void btn_Editar_Click(object sender, EventArgs e)
        {
            estado_controles(true);
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {

            if(Request.QueryString["cod_personal"] != null) { 
            cargar_datos(txt_codigo.Text);
            estado_controles(false);
            }
            else
            {
                Response.Redirect("personal.aspx");
            }
        }
    }
}