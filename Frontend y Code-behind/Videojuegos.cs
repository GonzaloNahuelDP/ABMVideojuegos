using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsVideojuegos.EstructuraModelo;

namespace WindowsFormsVideojuegos
{
    public partial class Videojuegos : Form
    {
        private DAO dao;

        public Videojuegos()
        {
            InitializeComponent();
            this.dao = new DAO();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String ID = txtID.Text;
            Videojuego encontrado = this.dao.BuscarVideojuegoPorID(ID);

            if (encontrado != null && ID != "")
            {
                txtTitulo.Text = encontrado.Titulo;
                txtPrecio.Text = encontrado.Precio;

                //CAMPOS DE TEXTO
                txtID.Enabled = false;
                txtTitulo.Enabled = true;
                txtPrecio.Enabled = true;

                //BOTONES
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnBuscar.Enabled = false;
            }
            else if(ID != "")
            {
                //CAMPOS DE TEXTO
                txtID.Enabled = false;
                txtTitulo.Enabled = true;
                txtPrecio.Enabled = true;

                //BOTONES
                btnAgregar.Enabled = true;
                btnBuscar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.VolverComponentesALaNormalidad();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            String ID = txtID.Text;
            String titulo = txtTitulo.Text;
            String precio = txtPrecio.Text;

            if (ID != "" && titulo != "" && precio !="")
            {
                Videojuego videojuego = new Videojuego(ID, titulo, precio);
                this.dao.AgregarVideojuego(videojuego);
                this.VolverComponentesALaNormalidad();

                MessageBox.Show(videojuego.Titulo + " se agregó correctamente");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String nuevoTitulo = txtTitulo.Text;
            String nuevoPrecio = txtPrecio.Text;

            if (nuevoTitulo != "" && nuevoPrecio != "")
            {
                String ID = txtID.Text;
                Videojuego videojuegoActualizado = new Videojuego(ID, nuevoTitulo, nuevoPrecio);
                this.dao.ActualizarVideojuego(videojuegoActualizado);
                this.VolverComponentesALaNormalidad();

                MessageBox.Show(videojuegoActualizado.Titulo + " se actualizó correctamente");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String ID = txtID.Text;
            String titulo = txtTitulo.Text;
            this.dao.BorrarVideojuegoPorID(ID);
            this.VolverComponentesALaNormalidad();

            MessageBox.Show(titulo + " se eliminó correctamente");
        }

        private void VolverComponentesALaNormalidad()
        {
            //CAMPOS DE TEXTO
            txtID.Text = "";
            txtID.Enabled = true;
            txtID.Focus();

            txtTitulo.Text = "";
            txtTitulo.Enabled = false;

            txtPrecio.Text = "";
            txtPrecio.Enabled = false;

            //BOTONES
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = true;
        }

        private void Videojuegos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'vIDEOJUEGOS_BDDataSet.TRIPLE_A' Puede moverla o quitarla según sea necesario.
            this.tRIPLE_ATableAdapter.Fill(this.vIDEOJUEGOS_BDDataSet.TRIPLE_A);
        }
    }
}