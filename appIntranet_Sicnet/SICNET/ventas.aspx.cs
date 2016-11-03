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
    public partial class ventas : System.Web.UI.Page
    {


        #region "DECLARACIONES"

        claseVentas claseVentas = new claseVentas();
        DataTable oDs_Datos;

        #endregion


        #region "PROCEDIMIENTOS"

        public void Listar_VENTAS()
        {
            try { 
            oDs_Datos = claseVentas.public_Lista_VENTAS("","",DateTime.Parse(txt_Fec1.Text), DateTime.Parse(txt_Fec2.Text));
            dg_listado_al.DataSource = oDs_Datos;
            dg_listado_al.DataBind();

              float total = 0;
            for(int i = 0;  i < oDs_Datos.Rows.Count; i++)
                {
                    float tot = float.Parse(oDs_Datos.Rows[i]["TOTAL_VENTA"].ToString());
                    total += tot;
                }

                Total_Lista.Text = total.ToString();
           
            }catch(Exception ex)
            {
               // txt_N_v.Text = ex.Message;
            }
        }

       

        #endregion


        claseVentas c = new claseVentas();
        public DataTable ODS;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                if(Request.QueryString["sus"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
                      "alert('Venta generada satisfactoriamente,Salud');", true);
                }

                DateTime fec = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
                txt_Fec1.Text = fec.ToString("dd/MM/yyyy");
                txt_Fec2.Text = fec.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");

                Listar_VENTAS();

               



            }

           
        

        }

        protected void txt_N_v_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_NUEVO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ventas_nuevo_detalle.aspx");
        }

        protected void btn_EXCEL_Click(object sender, EventArgs e)
        {
            try
            {

                if (dg_listado_al.Items.Count > 0)
                {

                    StringWriter stringWriter = new StringWriter();
                    HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
                    dg_listado_al.RenderControl(htmlWriter);

                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment; filename= " + "Export to Sicnet Ventas -" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Charset = "";

                    Response.Write(stringWriter.ToString());
                    Response.End();


                }


            }
            catch (Exception ex)
            {

            }


        }

        protected void txt_Fec1_TextChanged(object sender, EventArgs e)
        {
            Listar_VENTAS();
        }

        protected void txt_Fec2_TextChanged(object sender, EventArgs e)
        {
            Listar_VENTAS();
        }
    }
}