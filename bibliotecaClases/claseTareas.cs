using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bibliotecaClases
{
    public class claseTareas
    {

        claseConexion cn = new claseConexion();

        #region "LISTA DE Tareas"

        public DataTable public_Lista_Tareas(String a_DES_ITEM, DateTime a_FECHA, DateTime a_FECHA2, String a_EST_LOTE)
        {
            return private_Lista_Tareas(a_DES_ITEM, a_FECHA, a_FECHA2, a_EST_LOTE);
        }

        private DataTable private_Lista_Tareas(String a_DES_ITEM, DateTime a_FECHA, DateTime a_FECHA2, String a_EST_LOTE)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_TAREAS_CAB_MOSTRAR_LISTA", cn.getcn);
            //cmd.Parameters.Add(new SqlParameter("@DES_ITEM", a_DES_ITEM));
            cmd.Parameters.Add(new SqlParameter("@FECHA", a_FECHA));
            //cmd.Parameters.Add(new SqlParameter("@FEC2", a_FECHA2));
            //cmd.Parameters.Add(new SqlParameter("@EST_LOTE", a_EST_LOTE));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "MANTENIMIENTO TAREAS"

        public String public_Mantenimiento_TAREAS(String IND_A, String a_NOM_TAREA, String a_DES_TAREA, DateTime a_FECHA_INI, DateTime a_FECHA_FIN, String a_COD_PERSONAL, String a_COD_RESPONSABLE)
        {
            return private_Mantenimiento_TAREAS( IND_A,  a_NOM_TAREA,  a_DES_TAREA,  a_FECHA_INI,  a_FECHA_FIN,  a_COD_PERSONAL, a_COD_RESPONSABLE);
        }

        private String private_Mantenimiento_TAREAS(String IND_A, String a_NOM_TAREA, String a_DES_TAREA, DateTime a_FECHA_INI, DateTime a_FECHA_FIN, String a_COD_PERSONAL,String a_COD_RESPONSABLE)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_TAREAS_MANT", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IND_A", IND_A));
            cmd.Parameters.Add(new SqlParameter("@NOM_TAREA", a_NOM_TAREA));
            cmd.Parameters.Add(new SqlParameter("@DES_TAREA", a_DES_TAREA));
            cmd.Parameters.Add(new SqlParameter("@FECHA_INICIO", a_FECHA_INI));
            cmd.Parameters.Add(new SqlParameter("@FECHA_FIN", a_FECHA_FIN));
            cmd.Parameters.Add(new SqlParameter("@COD_PERSONAL", a_COD_PERSONAL));
            cmd.Parameters.Add(new SqlParameter("@COD_RESPONSABLE", a_COD_RESPONSABLE));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion

        #region "MOSTRAR DATOS TAREA"

        public DataTable public_Mostrar_Datos_TAREA(String I_COD)
        {
            return private_Mostrar_Datos_TAREA(I_COD);
        }

        private DataTable private_Mostrar_Datos_TAREA(String I_COD)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("MAE_TAREAS_MOSTRAR_DATOS", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_TAREA", I_COD));
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

        #region "LISTA DE Tareas RENDER"

        public DataTable public_Lista_Tareas_render()
        {
            return private_Lista_Tareas_render();
        }

        private DataTable private_Lista_Tareas_render()
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_TAREAS_CAB_MOSTRAR_LISTA_RENDER", cn.getcn);
            //cmd.Parameters.Add(new SqlParameter("@DES_ITEM", a_DES_ITEM));
           // cmd.Parameters.Add(new SqlParameter("@FECHA", a_FECHA));
            //cmd.Parameters.Add(new SqlParameter("@FEC2", a_FECHA2));
            //cmd.Parameters.Add(new SqlParameter("@EST_LOTE", a_EST_LOTE));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "LISTA DE USUARIOS-TAREAS"

        public DataTable public_Lista_USUARIOS()
        {
            return private_Lista_USUARIOS();
        }

        private DataTable private_Lista_USUARIOS()
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_TAREAS_LISTAR_USUARIOS", cn.getcn);
            //cmd.Parameters.Add(new SqlParameter("@DES_ITEM", a_DES_ITEM));
            // cmd.Parameters.Add(new SqlParameter("@FECHA", a_FECHA));
            //cmd.Parameters.Add(new SqlParameter("@FEC2", a_FECHA2));
            //cmd.Parameters.Add(new SqlParameter("@EST_LOTE", a_EST_LOTE));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

       

        #endregion


    }

}
