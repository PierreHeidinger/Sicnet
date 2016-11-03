using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace bibliotecaClases
{
    public class claseConexion
    {
        
        //SqlConnection cn = new SqlConnection("server=PIERRE-PC\\PIERRE; database=BD_SICNET; uid=sa; pwd=sql");
        //SqlConnection cn = new SqlConnection("server=DFSD\\DATASERVER; database=BD_SICNET; uid=sa; pwd=sql");
        //SqlConnection cn = new SqlConnection("server=PRUEBRASDEMO.mssql.somee.com; database=PRUEBRASDEMO; uid=pieroxa2012_SQLLogin_1; pwd=zimvpi3mrp");
       SqlConnection cn = new SqlConnection("server=(local); database=BD_SICNET;Trusted_Connection=Yes");
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
