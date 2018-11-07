using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsVideojuegos.EstructuraModelo
{
    class Conexion
    {
        SqlConnection conexionSQL;

        public Conexion()
        {
            this.conexionSQL = new SqlConnection(
                "Data Source = localhost; " +
                "Initial Catalog = VIDEOJUEGOS_BD; " +
                "User id = GNAHUEL; " +
                "Password = gndp93");
        }

        public SqlConnection ConexionSql
        {
            get { return this.conexionSQL; }
        }
    }
}