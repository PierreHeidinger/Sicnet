using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace bibliotecaClases
{
    public class claseUtilitarios
    {
        claseConexion cn = new claseConexion();
        String confirmacion;


        #region "LOGIN"

        public DataTable public_Login(String a_USUARIO, String a_PWD)
        {
            return private_Login(a_USUARIO, a_PWD);
        }

        private DataTable private_Login(String a_USUARIO, String a_PWD)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_LOGIN_SESSION", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@USUARIO", a_USUARIO));
            cmd.Parameters.Add(new SqlParameter("@CONTRASENA", a_PWD));
            //cmd.Parameters.Add(new SqlParameter("@FECHA1", FECHA1));
            // cmd.Parameters.Add(new SqlParameter("@FECHA2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "MOSTRAR DATOS PERSONAL"

        public DataTable public_Mostrar_Datos_PERSONAL(String I_COD)
        {
            return private_Mostrar_Datos_PERSONAL(I_COD);
        }

        private DataTable private_Mostrar_Datos_PERSONAL(String I_COD)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_LOGIN_MOSTRAR_DATOS_USUARIO", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@USU_PERSONAL", I_COD));
            // cmd.Parameters.Add(new SqlParameter("@FECHA1", FECHA1));
            //  cmd.Parameters.Add(new SqlParameter("@FECHA2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "MOSTRAR DATOS INDEX"

        public DataTable public_Mostrar_Datos_INDEX(String a_IND)
        {
            return private_Mostrar_Datos_INDEX(a_IND);
        }

        private DataTable private_Mostrar_Datos_INDEX(String a_IND)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_UTILITARIOS_INDEX", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@IND_A", a_IND));
            // cmd.Parameters.Add(new SqlParameter("@FECHA1", FECHA1));
            //  cmd.Parameters.Add(new SqlParameter("@FECHA2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion


        #region "MOSTRAR DATOS PERSONAL"

        public DataTable public_Mostrar_Datos_Chat()
        {
            return private_Mostrar_Datos_Chat();
        }

        private DataTable private_Mostrar_Datos_Chat()
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_UTILITATIOS_CHAT_INDEX", cn.getcn);
            // cmd.Parameters.Add(new SqlParameter("@COD_PERSONAL", I_COD));
            // cmd.Parameters.Add(new SqlParameter("@FECHA1", FECHA1));
            //  cmd.Parameters.Add(new SqlParameter("@FECHA2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "MANTENIMIENTO ITEMS"
        public String public_Mantenimiento_Items(String a_COD_PERSONAL, String a_DES_PERSONAL)
        {
            return private_Mantenimiento_Items(a_COD_PERSONAL, a_DES_PERSONAL);
        }

        private String private_Mantenimiento_Items(String a_COD_PERSONAL, String a_DES_PERSONAL)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_UTILITARIOS_CHAT_MAT", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@COD_PERSONAL", a_COD_PERSONAL));
            cmd.Parameters.Add(new SqlParameter("@DES_MENSAJE", a_DES_PERSONAL));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion


        #region "CONFIRMACION DE FORM"
        public String Confirmacion_Evento(String Mensaje) { 

                confirmacion = "<div class='alert alert-success' role='alert'>";
                confirmacion += "<strong>Exelente!</strong> " + Mensaje;
                confirmacion += "</div>";

            
                                                    
                                                
            
                                                    
                                                
            return confirmacion;
        }
        #endregion

        #region "MENSAJE DE ERROR"

        public String Error_Evento(String Mensaje)
        {

            confirmacion = "<div class='alert alert-danger' role='alert'>";
            confirmacion += "<strong>Cuidado!</strong> " + Mensaje;
            confirmacion += "</div>";

            return confirmacion;
        }


        #endregion
    }
}
