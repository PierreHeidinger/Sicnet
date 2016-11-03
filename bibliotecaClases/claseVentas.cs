using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace bibliotecaClases
{
    public class claseVentas
    {

        claseConexion cn = new claseConexion();

        #region "LISTA DE VENTAS"

        public DataTable public_Lista_VENTAS(String a_COD_VENTA, String A_APE, DateTime FECHA1, DateTime FECHA2)
        {
            return private_Lista_VENTAS(a_COD_VENTA, A_APE, FECHA1, FECHA2);
        }

        private DataTable private_Lista_VENTAS(String a_COD_VENTA, String A_APE, DateTime FECHA1, DateTime FECHA2)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_LISTAR_CAB", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_VENTA", a_COD_VENTA));
            //cmd.Parameters.Add(new SqlParameter("@A_APE", A_APE));
            cmd.Parameters.Add(new SqlParameter("@FEC1", FECHA1));
            cmd.Parameters.Add(new SqlParameter("@FEC2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "CARGAR DE ITEMS-DETALLE-VENTA"

        public DataTable public_cargar_Items(String a_CODS)
        {
            return private_cargar_Items(a_CODS);
        }

        private DataTable private_cargar_Items(String a_CODS)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_CARGAR_ITEMS", cn.getcn);
             cmd.Parameters.Add(new SqlParameter("@COD_LOTE", a_CODS));
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

        #region "MANTENIMIENTO  VENTAS"

        public String public_Mantenimiento_Venta(String a_COD_VENTA, String a_COD_CLIENTE, String a_COD_PERSONAL, float a_TOTAL_COSTO_COM, float a_TOTAL_UTIL, float a_TOTAL_IGV, float a_TOTAL_VENTA)
        {
            return private_Mantenimiento_Venta(a_COD_VENTA, a_COD_CLIENTE, a_COD_PERSONAL, a_TOTAL_COSTO_COM, a_TOTAL_UTIL, a_TOTAL_IGV, a_TOTAL_VENTA);
        }

        private String private_Mantenimiento_Venta(String a_COD_VENTA, String a_COD_CLIENTE, String a_COD_PERSONAL, float a_TOTAL_COSTO_COM, float a_TOTAL_UTIL, float a_TOTAL_IGV, float a_TOTAL_VENTA)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_MANT", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@COD_VENTA", a_COD_VENTA));
            cmd.Parameters.Add(new SqlParameter("@COD_CLIENTE", a_COD_CLIENTE));
            cmd.Parameters.Add(new SqlParameter("@COD_PERSONAL", a_COD_PERSONAL));
            cmd.Parameters.Add(new SqlParameter("@TOTAL_COSTO_COMERCIAL", a_TOTAL_COSTO_COM));
            cmd.Parameters.Add(new SqlParameter("@TOTAL_UTILIDAD", a_TOTAL_UTIL));
            cmd.Parameters.Add(new SqlParameter("@TOTAL_IGV", a_TOTAL_IGV));
            cmd.Parameters.Add(new SqlParameter("@TOTAL_VENTA", a_TOTAL_VENTA));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion

        #region "MANTENIMIENTO DETALLE VENTAS"

        public String public_Mantenimiento_Detalle_V(String a_COD_VENTA, String a_COD_ITEM, String a_CANTIDAD, float a_PRECIO_COSTO, float a_UTILIDAD, float a_IGV, float a_PRECIO_VENTA,String a_COD_LOTE)
        {
            return private_Mantenimiento_Detalle_V(a_COD_VENTA, a_COD_ITEM, a_CANTIDAD, a_PRECIO_COSTO, a_UTILIDAD, a_IGV, a_PRECIO_VENTA, a_COD_LOTE);
        }

        private String private_Mantenimiento_Detalle_V(String a_COD_VENTA, String a_COD_ITEM, String a_CANTIDAD, float a_PRECIO_COSTO, float a_UTILIDAD, float a_IGV, float a_PRECIO_VENTA,String a_COD_LOTE)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_AGREGAR_DETALLE", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@COD_VENTA", a_COD_VENTA));
            cmd.Parameters.Add(new SqlParameter("@COD_ITEM", a_COD_ITEM));
            cmd.Parameters.Add(new SqlParameter("@CANTIDAD_ITEM", a_CANTIDAD));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_COSTO", a_PRECIO_COSTO));
            cmd.Parameters.Add(new SqlParameter("@UTILIDAD", a_UTILIDAD));
            cmd.Parameters.Add(new SqlParameter("@IGV", a_IGV));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_VENTA", a_PRECIO_VENTA));
            cmd.Parameters.Add(new SqlParameter("@COD_LOTE", a_COD_LOTE));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion


        #region "LISTA DE ITEMS-VENTA"

        public DataTable public_Lista_ITEMS(String A_DESCRIPCION)
        {
            return private_Lista_ITEMS(A_DESCRIPCION);
        }

        private DataTable private_Lista_ITEMS(String A_DESCRIPCION)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_LISTAR_VENTAS", cn.getcn);
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

        #region "VALIDAR CANTIDAD"

        public String public_Validad_cantidad(String a_COD_LOTE, String a_CANTIDAD,String a_RES)
        {
            return private_Validad_cantidad(a_COD_LOTE, a_CANTIDAD, a_RES);
        }

        private String private_Validad_cantidad(String a_COD_VENTA, String a_CANTIDAD, String a_RES)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_VALIDAR_CANTIDAD", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@COD_LOTE", a_COD_VENTA));
            cmd.Parameters.Add(new SqlParameter("@CANTIDAD", a_CANTIDAD));
            cmd.Parameters.Add(new SqlParameter("@RES", a_RES)).Direction = ParameterDirection.InputOutput;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return cmd.Parameters["@RES"].Value.ToString();
        }


        #endregion

        #region "MOSTRAR DATOS VENTA"

        public DataTable public_Mostrar_Datos_VENTA(String a_COD_VENTA)
        {
            return private_Mostrar_Datos_VENTA(a_COD_VENTA);
        }

        private DataTable private_Mostrar_Datos_VENTA(String a_COD_VENTA)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_MOSTRAR_DATOS", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_VENTA", a_COD_VENTA));
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

        #region "MOSTRAR DATOS VENTA DETALLE"

        public DataTable public_Mostrar_Datos_VENTA_DETALLE(String a_COD_VENTA)
        {
            return private_Mostrar_Datos_VENTA_DETALLE(a_COD_VENTA);
        }

        private DataTable private_Mostrar_Datos_VENTA_DETALLE(String a_COD_VENTA)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_VENTAS_MOSTRAR_DET", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_VENTA", a_COD_VENTA));
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

    }
}
