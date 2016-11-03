using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bibliotecaClases
{
    public class clasePersonal
    {
        claseConexion cn = new claseConexion();

        #region "LISTA DE PERSONAL"

        public DataTable public_Lista_Personal(String A_DESCRIPCION)
        {
            return private_Lista_Personal(A_DESCRIPCION);
        }

        private DataTable private_Lista_Personal(String A_DESCRIPCION)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_MAE_PERSONAL_LISTADO_CAB", cn.getcn);
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

        #region "MANTENIMIENTO PERSONAL"
        public String public_Mantenimiento_Personal(String IND_A,String a_COD_PERSONAL, String V_NOM_PER, String V_APE_P_PER, String V_APE_M_PER, DateTime V_FEC_ING, DateTime V_FEC_NAC, String V_SEXO, String V_EMAIL_PERSONAL, String V_EMAIL_EMPRESA, String V_DEPARTAMENTO, String V_PROVINCIA, String V_DISTRITO, String V_DIRECCION, String V_CELULAR, String V_CARGO_EMPRESA, String V_ALIAS, String V_USUARIO, String V_CONTRASENA, String V_COD_ESTADO, String V_RUTA_IMG)
        {
            return private_Mantenimiento_Personal( IND_A, a_COD_PERSONAL, V_NOM_PER,  V_APE_P_PER,  V_APE_M_PER,  V_FEC_ING,  V_FEC_NAC,  V_SEXO,  V_EMAIL_PERSONAL,  V_EMAIL_EMPRESA,  V_DEPARTAMENTO,  V_PROVINCIA,  V_DISTRITO,  V_DIRECCION,  V_CELULAR,  V_CARGO_EMPRESA,  V_ALIAS,  V_USUARIO,  V_CONTRASENA,  V_COD_ESTADO,  V_RUTA_IMG);
        }

        private String private_Mantenimiento_Personal(String IND_A, String a_COD_PERSONAL, String V_NOM_PER, String V_APE_P_PER, String V_APE_M_PER, DateTime V_FEC_ING, DateTime V_FEC_NAC, String V_SEXO, String V_EMAIL_PERSONAL, String V_EMAIL_EMPRESA, String V_DEPARTAMENTO, String V_PROVINCIA, String V_DISTRITO, String V_DIRECCION, String V_CELULAR, String V_CARGO_EMPRESA, String V_ALIAS, String V_USUARIO, String V_CONTRASENA, String V_COD_ESTADO,String V_RUTA_IMG)
        {



            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_MAE_PERSONAL_MANTENIMIENTO", cn.getcn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IND_A", IND_A));
            cmd.Parameters.Add(new SqlParameter("@COD_PERSONAL", a_COD_PERSONAL));
            cmd.Parameters.Add(new SqlParameter("@NOM_PER", V_NOM_PER));
            cmd.Parameters.Add(new SqlParameter("@APE_P_PER", V_APE_P_PER));
            cmd.Parameters.Add(new SqlParameter("@APE_M_PER", V_APE_M_PER));
            cmd.Parameters.Add(new SqlParameter("@FEC_ING", V_FEC_ING));
            cmd.Parameters.Add(new SqlParameter("@FEC_NAC", V_FEC_NAC));
            cmd.Parameters.Add(new SqlParameter("@SEXO", V_SEXO));
            cmd.Parameters.Add(new SqlParameter("@EMAIL_PERSONAL", V_EMAIL_PERSONAL));
            cmd.Parameters.Add(new SqlParameter("@EMAIL_EMPRESA", V_EMAIL_EMPRESA));
            cmd.Parameters.Add(new SqlParameter("@DEPARTAMENTO", V_DEPARTAMENTO));
            cmd.Parameters.Add(new SqlParameter("@PROVINCIA", V_PROVINCIA));
            cmd.Parameters.Add(new SqlParameter("@DISTRITO", V_DISTRITO));
            cmd.Parameters.Add(new SqlParameter("@DIRECCION", V_DIRECCION));
            cmd.Parameters.Add(new SqlParameter("@CELULAR", V_CELULAR));
            cmd.Parameters.Add(new SqlParameter("@CARGO_EMPRESA", V_CARGO_EMPRESA));
            cmd.Parameters.Add(new SqlParameter("@ALIAS", V_ALIAS));
            cmd.Parameters.Add(new SqlParameter("@USUARIO", V_USUARIO));
            cmd.Parameters.Add(new SqlParameter("@CONTRASENA", V_CONTRASENA));
            cmd.Parameters.Add(new SqlParameter("@COD_ESTADO", V_COD_ESTADO));
            cmd.Parameters.Add(new SqlParameter("@RUTA_IMG", V_RUTA_IMG));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int i = cmd.ExecuteNonQuery();
            cn.getcn.Close();
            return i.ToString();
        }


        #endregion


        #region "MOSTRAR DATOS PERSONAL"

        public DataTable public_Mostrar_Datos_Personal(String a_COD_PERSONAL)
        {
            return private_Mostrar_Datos_Personal(a_COD_PERSONAL);
        }

        private DataTable private_Mostrar_Datos_Personal(String a_COD_PERSONAL)
        {
            cn.getcn.Open();

            SqlCommand cmd = new SqlCommand("SP_PERSONAL_MOSTRAR_DATOS", cn.getcn);
            cmd.Parameters.Add(new SqlParameter("@COD_PERSONAL", a_COD_PERSONAL));
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
