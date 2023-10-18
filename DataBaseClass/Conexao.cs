using System;
using System.Data.SqlClient;

namespace DataBaseClass
{
    public class Conexao
    {
        readonly SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-61L2M0C\SQLEXPRESS;integrated security=SSPI;initial Catalog=teste";
            con.Open();
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
                con.Open();
            return con;
        }

        public SqlConnection Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return con;
        }  
    }
}