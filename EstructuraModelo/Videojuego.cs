using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsVideojuegos.EstructuraModelo
{
    class Videojuego
    {
        private String ID;
        private String titulo;
        private String precio;

        public Videojuego(String ID, String titulo, String precio)
        {
            this.ID = ID;
            this.titulo = titulo;
            this.precio = precio;
        }

        //ID {Get, Set}
        public String Id{
            get { return this.ID; }
            set { this.ID = value; }
        }

        //Titulo {Get, Set}
        public String Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        //Precio {Get, Set}
        public String Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
    }
}