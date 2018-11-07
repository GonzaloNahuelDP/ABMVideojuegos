using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsVideojuegos.EstructuraModelo
{
    class DAO
    {
        private Conexion conexion;

        public DAO()
        {
            this.conexion = new Conexion();
        }

        //OPERACIONES CRUD (CREATE, READ, UPDATE, DELETE)

        //CREATE (INSERT)
        public void AgregarVideojuego(Videojuego nuevoVideojuego)
        {
            String insert = "insert into TRIPLE_A values('"+nuevoVideojuego.Id+"','"+nuevoVideojuego.Titulo+"','"+nuevoVideojuego.Precio+"')";
            this.EjecutarSentenciaSQL(insert);
        }

        //READ (SELECT)
        public Videojuego BuscarVideojuegoPorID(String ID)
        {
            Videojuego encontrado = null;
            String select = "select * from TRIPLE_A where ID = '"+ID+"'";
            SqlConnection conexionSQL = this.conexion.ConexionSql;

            conexionSQL.Open();
            SqlCommand comandoSQL = new SqlCommand(select, conexionSQL);
            SqlDataReader lectorDatosSQL = comandoSQL.ExecuteReader();

            if (lectorDatosSQL.Read())
            {
                String IDEncontrado = lectorDatosSQL["ID"].ToString();
                String tituloEncontrado = lectorDatosSQL["TITULO"].ToString();
                String precioEncontrado = lectorDatosSQL["PRECIO"].ToString();

                encontrado = new Videojuego(IDEncontrado, tituloEncontrado, precioEncontrado);
            }

            conexionSQL.Close();

            return encontrado;
        }

        //UPDATE (UPDATE)
        public void ActualizarVideojuego(Videojuego videojuego)
        {
            String update = "update TRIPLE_A set TITULO = '"+videojuego.Titulo+"', PRECIO = '"+videojuego.Precio+"' where ID = '"+videojuego.Id+"'";
            this.EjecutarSentenciaSQL(update);
        }

        //DELETE (DELETE)
        public void BorrarVideojuegoPorID(String ID)
        {
            String delete = "delete from TRIPLE_A where ID = '"+ID+"'";
            this.EjecutarSentenciaSQL(delete);
        }

        private void EjecutarSentenciaSQL(String sentenciaSQL)
        {
            SqlConnection conexionSQL = this.conexion.ConexionSql;
            conexionSQL.Open();
            SqlCommand comandoSQL = new SqlCommand(sentenciaSQL, conexionSQL);
            comandoSQL.ExecuteNonQuery();
            conexionSQL.Close();
        }
    }
}