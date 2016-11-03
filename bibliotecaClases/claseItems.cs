using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bibliotecaClases
{
    public class claseItems
    {

        claseConexion cn = new claseConexion();


        #region "MANTENIMIENTO ITEMS"
        public String public_Mantenimiento_Items(String IND_A, String  I_COD, String I_TIP, String I_CAT, String I_SUB_CAT, String I_MARCA, String I_DES, String I_COM, String I_COD_COM, String I_STOCK, String I_ESTADO, String I_COSTO, String I_UTI, String I_COS_SER, String I_PRE_VENTA, String I_DES_WEB, String I_DISP_WEB, String I_PRECIO_WEB, String I_RUTA_IMG)
        {
            return private_Mantenimiento_Items( IND_A,   I_COD,  I_TIP,  I_CAT,  I_SUB_CAT,I_MARCA,  I_DES,  I_COM,  I_COD_COM,  I_STOCK,  I_ESTADO,  I_COSTO,  I_UTI,  I_COS_SER,  I_PRE_VENTA,  I_DES_WEB,  I_DISP_WEB,  I_PRECIO_WEB,  I_RUTA_IMG);
        }

        private String private_Mantenimiento_Items(String IND_A, String I_COD, String I_TIP, String I_CAT, String I_SUB_CAT, String I_MARCA, String I_DES, String I_COM, String I_COD_COM, String I_STOCK, String I_ESTADO, String I_COSTO, String I_UTI, String I_COS_SER, String  I_PRE_VENTA, String I_DES_WEB, String I_DISP_WEB,String I_PRECIO_WEB,String I_RUTA_IMG)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_MANT", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IND_I", IND_A));
            cmd.Parameters.Add(new SqlParameter("@COD_ITEM", I_COD));
            cmd.Parameters.Add(new SqlParameter("@TIP_ITEM", I_TIP));
            cmd.Parameters.Add(new SqlParameter("@CAT_ITEM", I_CAT));
            cmd.Parameters.Add(new SqlParameter("@SUB_CAT_ITEM", I_SUB_CAT));
            cmd.Parameters.Add(new SqlParameter("@MARCA_ITEM", I_MARCA));
            cmd.Parameters.Add(new SqlParameter("@DES_ITEM", I_DES));
            cmd.Parameters.Add(new SqlParameter("@COM_ITEM", I_COM));
            cmd.Parameters.Add(new SqlParameter("@COD_COM_ITEM", I_COD_COM));
            cmd.Parameters.Add(new SqlParameter("@STOCK_ITEM", I_STOCK));
            cmd.Parameters.Add(new SqlParameter("@EST_ITEM", I_ESTADO));
            cmd.Parameters.Add(new SqlParameter("@COSTO_ITEM", I_COSTO));
            cmd.Parameters.Add(new SqlParameter("@UTILIDAD_ITEM", I_UTI));
            cmd.Parameters.Add(new SqlParameter("@COSTO_SETVICIO", I_COS_SER));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_VENTA", I_PRE_VENTA));
            cmd.Parameters.Add(new SqlParameter("@DES_WEB_ITEM", I_DES_WEB));
            cmd.Parameters.Add(new SqlParameter("@DISP_WEB", I_DISP_WEB));
            cmd.Parameters.Add(new SqlParameter("@PRECIO_WEB", I_PRECIO_WEB));
            cmd.Parameters.Add(new SqlParameter("@IMG_RUTA", I_RUTA_IMG));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion


        #region "LISTA DE ITEMS"

        public DataTable public_Lista_ITEMS(String a_COD_ITEM, String A_DESCRIPCION, String a_WEB)
        {
            return private_Lista_ITEMS( a_COD_ITEM,  A_DESCRIPCION,  a_WEB);
        }

        private DataTable private_Lista_ITEMS(String a_COD_ITEM,String A_DESCRIPCION,String a_WEB)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_LISTAR_CAB", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@DES_ITEM", A_DESCRIPCION));
            cmd.Parameters.Add(new SqlParameter("@COD_ITEM", a_COD_ITEM));
            cmd.Parameters.Add(new SqlParameter("@WEB", a_WEB));
            // cmd.Parameters.Add(new SqlParameter("@FECHA2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion


        #region "MOSTRAR DATOS ITEMS"

        public DataTable public_Mostrar_Datos_ITEMS(String I_COD)
        {
            return private_Mostrar_Datos_ITEMS(I_COD);
        }

        private DataTable private_Mostrar_Datos_ITEMS(String I_COD)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_MOSTRAR_DATOS", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_ITEM", I_COD));
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

        #region "LISTAR CATEGORIAS "

        public DataTable public_Listar_categorias()
        {
            return private_Listar_categorias();
        }

        private DataTable private_Listar_categorias()
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_LISTAR_CATEGORIAS", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();

            DataRow fila_inicial = ds.NewRow();
            fila_inicial["COD_CAT"] = "0";
            fila_inicial["DES_CAT"] = "--Seleccione--";
            ds.Rows.InsertAt(fila_inicial, 0);

            return ds;


        }

        #endregion

        #region "LISTAR SUB CATEGORIAS "

        public DataTable public_Listar_sub_categorias(String a_COD_SUB_CAT)
        {
            return private_Listar_sub_categorias(a_COD_SUB_CAT);
        }

        private DataTable private_Listar_sub_categorias(String a_COD_SUB_CAT)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_LISTAR_SUB_CATEGORIAS", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_CAT", a_COD_SUB_CAT));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();

            DataRow fila_inicial = ds.NewRow();
            fila_inicial["COD_SUB_CATEGORIA"] = "0";
            fila_inicial["DES_SUB_CATEGORIA"] = "--Seleccione--";
            ds.Rows.InsertAt(fila_inicial, 0);

            return ds;


        }

        #endregion

        #region "LISTAR MARCAS "

        public DataTable public_Listar_marcas(String a_COD_SUB_CAT)
        {
            return private_Listar_marcas(a_COD_SUB_CAT);
        }

        private DataTable private_Listar_marcas(String a_COD_SUB_CAT)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_LISTAR_MARCAS_PROD", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_SUB_CATEGORIA", a_COD_SUB_CAT));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();

            DataRow fila_inicial = ds.NewRow();
            fila_inicial["COD_MARCA"] = "0";
            fila_inicial["DES_MARCA"] = "--Seleccione--";
            ds.Rows.InsertAt(fila_inicial, 0);

            return ds;


        }

        #endregion

        #region "MOSTRAR DATOS HISTORIAL"

        public DataTable public_Mostrar_Datos_HISTORIAL(String I_COD)
        {
            return private_Mostrar_Datos_HISTORIAL(I_COD);
        }

        private DataTable private_Mostrar_Datos_HISTORIAL(String I_COD)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_ITEMS_HISTORIAL_LISTAR", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_ITEM", I_COD));
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
