using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bibliotecaClases;
using System.Data;
using System.Collections;

namespace appIntranet_Sicnet.SICNET
{
    public partial class gestionGerencial : System.Web.UI.Page
    {

        #region "DECLARACIONES"

        claseTareas claseTareas = new claseTareas();
        claseUtilitarios claseUtilitarios = new claseUtilitarios();
        public DataTable oDs_Datos;


        #endregion


        #region "PROCEDIMIENTOS"


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
        public void setear_calendarios_x_meses(int year, int month)
        {
            Calendar1.VisibleDate = new DateTime(year, month, 1);
            Calendar1.ShowNextPrevMonth = false;
        }



        public void setearUsuarios()
        {
            oDs_Datos = claseTareas.public_Lista_USUARIOS();
            rdo_responsable.DataSource = oDs_Datos;
            rdo_responsable.DataValueField = "COD_PERSONAL";
            rdo_responsable.DataTextField = "NOM_PER";
            rdo_responsable.DataBind();
            rdo_responsable.SelectedIndex = 0;

        }



        public void mostrar_lista_tareas(DateTime FECHA)
        {

            oDs_Datos = claseTareas.public_Lista_Tareas("", FECHA, DateTime.Now, null);
            gw_tareas.DataSource = oDs_Datos;
            gw_tareas.DataBind();

            
            Session["fecha"] = oDs_Datos.Rows[0]["FECHA_FIN"];
            
        }

        public void mostrar_datos_tarea(String codigo)
        {
            oDs_Datos = claseTareas.public_Mostrar_Datos_TAREA(codigo);

            if(oDs_Datos.Rows.Count > 0)
            {
                if(oDs_Datos.Rows[0]["NOM_TAREA"] != null)
                {
                    txt_Nombre.Text = oDs_Datos.Rows[0]["NOM_TAREA"].ToString().Trim();
                }
                if (oDs_Datos.Rows[0]["DES_TAREA"] != null)
                {
                    txt_Descripcion_completa.Text = oDs_Datos.Rows[0]["DES_TAREA"].ToString().Trim();
                }
                if(oDs_Datos.Rows[0]["COD_RESPONSABLE"] != null)
                {
                    rdo_responsable.SelectedValue = oDs_Datos.Rows[0]["COD_RESPONSABLE"].ToString();
                }
                if (oDs_Datos.Rows[0]["FECHA_INI"] != null)
                {
                    txt_Fecha_inicio.Text= oDs_Datos.Rows[0]["FECHA_INI"].ToString();
                }
                if (oDs_Datos.Rows[0]["FECHA_FIN"] != null)
                {
                   txt_fEcha_seleccionada.Text = oDs_Datos.Rows[0]["FECHA_FIN"].ToString();
                }

            }
        }

        public void estado_controles(Boolean _flag)
        {
            txt_Nombre.Enabled = _flag;
            txt_Descripcion_completa.Enabled = _flag;
            rdo_responsable.Enabled = _flag;
            btn_Salir.Visible = !_flag;
            txt_Fecha_inicio.Enabled = _flag;
            txt_fEcha_seleccionada.Enabled = _flag;
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                txt_fEcha_seleccionada.Text = DateTime.Today.AddDays(2).ToShortDateString();
                year.SelectedValue = DateTime.Now.Year.ToString();
                month.SelectedValue = DateTime.Now.Month.ToString();

                setear_calendarios_x_meses(int.Parse(year.SelectedValue), int.Parse(month.SelectedValue));
                //mostrar_lista_tareas(DateTime.Now);
                txt_Fecha_inicio.Text = DateTime.Now.ToShortDateString();
                setearUsuarios();
            }
            

        }

        protected void Cl1_SelectionChanged(object sender, EventArgs e)
        {
            try {
                btn_grabar_Tarea.Visible = false;
                mostrar_lista_tareas(Calendar1.SelectedDate);

                txt_fEcha_seleccionada.Text = Calendar1.SelectedDate.ToShortDateString();

                DateTime fec = DateTime.Parse(Session["fecha"].ToString());

                String dia_Week = fec.ToString("dddd");
                String dia_n = fec.ToString("dd");
                String month_ = fec.ToString("MMMM");
                String year_ = fec.ToString("yyyy");

                lbl_des_modal2.Text = "TAREAS  --- " + dia_Week + " " + dia_n + " de " + month_ + " del " + year_;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                        "iniciarT();", true);

                estado_controles(false);
                Calendar1.SelectedDate = DateTime.Parse("01/01/1990");
                

            }
            catch (Exception ex)
            {
            }
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                setear_calendarios_x_meses(int.Parse(year.SelectedValue), int.Parse(month.SelectedValue));
                Calendar1.SelectedDate = new DateTime();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                   "alert('" + ex.Message + "');", true);
                return;
            }
        }

        protected void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                setear_calendarios_x_meses(int.Parse(year.SelectedValue), int.Parse(month.SelectedValue));
                Calendar1.SelectedDate = new DateTime();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                   "alert('" + ex.Message + "');", true);
                return;
            }
        }

        protected void btn_Agregar_Tarea_Click(object sender, EventArgs e)
        {
            try {

                btn_grabar_Tarea.Visible = true;
                lbl_des_modal.Text = "Nueva Tarea";

            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                    "iniciar();", true);
            
            txt_Nombre.Text = "";
            txt_Descripcion_completa.Text = "";
            estado_controles(true);

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                   "alert('" + ex.Message + "');", true);
                return;
            }
        }

        protected void btn_grabar_Tarea_Click(object sender, EventArgs e)
        {
            
            try {
                


                String res = claseTareas.public_Mantenimiento_TAREAS("1", txt_Nombre.Text.Trim().ToUpper(), txt_Descripcion_completa.Text.Trim().ToUpper(), DateTime.Parse(txt_Fecha_inicio.Text), DateTime.Parse(txt_fEcha_seleccionada.Text), Session["COD_PERSONAL"].ToString(),rdo_responsable.SelectedValue);

                    txt_Nombre.Text = "";
                    txt_Descripcion_completa.Text = "";
                   // mostrar_lista_tareas(Calendar1.SelectedDate);

                MENSAJE_EVENTO("1", "Tarea Asignada al usuario " + rdo_responsable.SelectedItem + " Satisfactoriamente");
               

            }catch(Exception ex)
            {
                    ScriptManager.RegisterStartupScript(this, GetType(), "message",
                        "alert('"+ex.Message+"')", true);
                    return;
            }
            

        }

        protected void gw_tareas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try { 

                if (e.CommandName == "mostrar_Datos")
                {
                    lbl_des_modal.Text = "Tarea";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                    "iniciar();", true);

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage1",
                    "ocultarBoton();", true);

                    mostrar_datos_tarea(e.CommandArgument.ToString().Trim());
                    estado_controles(false);                    
                }
            }
            catch (Exception)
            {
                
            }
        }

        
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try { 
            Hashtable ds = new Hashtable();

            oDs_Datos = claseTareas.public_Lista_Tareas_render();

                if(oDs_Datos.Rows.Count > 0)
                {

                    for (int i = 0; i < oDs_Datos.Rows.Count; i++)
                    {

                        ds[oDs_Datos.Rows[i]["FECHA_FIN"].ToString()] = "TAREAS";                       

                    }

                    if (ds[e.Day.Date.ToShortDateString()] != null)
                    {
                       
                        Literal lit = new Literal();
                        lit.Text = "<br/>";
                        e.Cell.Controls.Add(lit);
                        Label lb = new Label();
                        lb.Text = "Dia con tareas Programadas";
                        lb.Font.Size = new FontUnit(FontSize.Small);
                        lb.ForeColor = System.Drawing.Color.Red;
                        e.Cell.Controls.Add(lb);
                        e.Cell.BackColor = System.Drawing.Color.RosyBrown;
                        
                    }


                    //ds["25/10/2016"] = "TAREAS";



                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "message",
                        "alert('" + ex.Message + "')", true);
            }

        }

        protected void btn_Salir_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                    "iniciarT();", true);
        }
    }
}