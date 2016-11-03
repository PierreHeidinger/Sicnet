using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace bibliotecaClases
{
    public class clasePedidosWeb
    {


        claseConexion cn = new claseConexion();

        #region "LISTA DE VENTAS"

        public DataTable public_Lista_VENTAS(String a_COD_VENTA,  DateTime FECHA1)
        {
            return private_Lista_VENTAS(a_COD_VENTA, FECHA1);
        }

        private DataTable private_Lista_VENTAS(String a_COD_VENTA, DateTime FECHA1)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_PEDIDOS_WEB_LISTAR_CAB", cn.getcn);
           // cmd.Parameters.Add(new SqlParameter("@COD_VENTA", a_COD_VENTA));
            //cmd.Parameters.Add(new SqlParameter("@A_APE", A_APE));
            //cmd.Parameters.Add(new SqlParameter("@FEC1", FECHA1));
            //cmd.Parameters.Add(new SqlParameter("@FEC2", FECHA2));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cn.getcn.Close();
            return ds;


        }

        #endregion

        #region "aprobar-anular"

        public String public_Mantenimiento_Aprobar_anular(String a_COD_PEDIDO, String a_COD_ESTADO)
        {
            return private_Mantenimiento_Aprobar_anular( a_COD_PEDIDO,  a_COD_ESTADO);
        }

        private String private_Mantenimiento_Aprobar_anular(String a_COD_PEDIDO, String a_COD_ESTADO)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_PEDIDOS_WEB_ACTUALIZAR_ESTADO", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@COD_PEDIDO", a_COD_PEDIDO));
            cmd.Parameters.Add(new SqlParameter("@COD_ESTADO", a_COD_ESTADO));
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion

    }
}
