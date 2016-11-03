using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bibliotecaClases
{
    public class claseClientes
    {

        claseConexion cn = new claseConexion();


        #region "LISTA DE CLIENTES"

        public DataTable public_Lista_Clientes(String A_DESCRIPCION)
        {
            return private_Lista_Clientes(A_DESCRIPCION);
        }

        private DataTable private_Lista_Clientes(String A_DESCRIPCION)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_MAE_CLIENTES_LISTAR_CAB", cn.getcn);
            //cmd.Parameters.Add(new SqlParameter("@DES_ITEM", A_DESCRIPCION));
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
