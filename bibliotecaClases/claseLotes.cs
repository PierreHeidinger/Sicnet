using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bibliotecaClases
{
    public class claseLotes
    {
        claseConexion cn = new claseConexion();


        #region "LISTA DE LOTES"

        public DataTable public_Lista_Lotes(String a_DES_ITEM, DateTime a_FECHA1, DateTime a_FECHA2, String a_EST_LOTE)
        {
            return private_Lista_Lotes( a_DES_ITEM,  a_FECHA1,  a_FECHA2,  a_EST_LOTE);
        }

        private DataTable private_Lista_Lotes(String a_DES_ITEM,DateTime a_FECHA1,DateTime a_FECHA2,String a_EST_LOTE)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_LOTES_LISTAR_CAB", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@DES_ITEM", a_DES_ITEM));
            cmd.Parameters.Add(new SqlParameter("@FEC1", a_FECHA1));
            cmd.Parameters.Add(new SqlParameter("@FEC2", a_FECHA2));
            cmd.Parameters.Add(new SqlParameter("@EST_LOTE", a_EST_LOTE));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "MANTENIMIENTO LOTES"

        public String public_Mantenimiento_Lotes(String IND_A, String a_COD_LOTE, String a_DES_LOTE, String a_COD_ITEM, int a_CANTIDAD, String a_IND_OFERTA, String a_EST_LOTE, String a_PRECIO_LOTE, String a_PRECIO_UNIDAD, String a_UTILIDAD, String a_PRECIO_V)
        {
            return private_Mantenimiento_Lotes(IND_A, a_COD_LOTE, a_DES_LOTE, a_COD_ITEM, a_CANTIDAD, a_IND_OFERTA, a_EST_LOTE,a_PRECIO_LOTE, a_PRECIO_UNIDAD, a_UTILIDAD, a_PRECIO_V);
        }

        private String private_Mantenimiento_Lotes(String IND_A, String a_COD_LOTE, String a_DES_LOTE, String a_COD_ITEM, int a_CANTIDAD, String a_IND_OFERTA, String a_EST_LOTE, String a_PRECIO_LOTE, String a_PRECIO_UNIDAD, String a_UTILIDAD, String a_PRECIO_V)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_LOTES_MANT", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IND_A", IND_A));
            cmd.Parameters.Add(new SqlParameter("@COD_LOTE", a_COD_LOTE));
            cmd.Parameters.Add(new SqlParameter("@DES_LOTE", a_DES_LOTE));
            cmd.Parameters.Add(new SqlParameter("@COD_ITEM", a_COD_ITEM));
            cmd.Parameters.Add(new SqlParameter("@CANTIDAD_ENTRADA", a_CANTIDAD));
            cmd.Parameters.Add(new SqlParameter("@IND_OFERTA", a_IND_OFERTA));
            cmd.Parameters.Add(new SqlParameter("@EST_LOTE", a_EST_LOTE));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_LOTE", a_PRECIO_LOTE));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_UNIDAD", a_PRECIO_UNIDAD));
            cmd.Parameters.Add(new SqlParameter("@UTILIDAD_U", a_UTILIDAD));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_VENTA_U", a_PRECIO_V));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion

        #region "MOSTRAR DATOS LOTE"

        public DataTable public_Mostrar_Datos_LOTE(String a_COD_LOTE)
        {
            return private_Mostrar_Datos_LOTE(a_COD_LOTE);
        }

        private DataTable private_Mostrar_Datos_LOTE(String a_COD_LOTE)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_LOTES_MOSTRAR_DATOS", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_LOTE", a_COD_LOTE));
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

        #region "LISTA DE ITEMS"

        public DataTable public_Lista_ITEMS(String A_DESCRIPCION)
        {
            return private_Lista_ITEMS(A_DESCRIPCION);
        }

        private DataTable private_Lista_ITEMS(String A_DESCRIPCION)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_LOTES_LISTAR_ITEMS_DISP", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@DES_ITEM", A_DESCRIPCION));
            //cmd.Parameters.Add(new SqlParameter("@A_APE", A_APE));
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
    }
}
