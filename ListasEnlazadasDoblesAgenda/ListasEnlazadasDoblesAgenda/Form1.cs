using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListasEnlazadasDoblesAgenda
{
    public partial class Form1 : Form
    {
        Contactos contactos = new Contactos();
        public Form1()
        {
            InitializeComponent();
        }
        public void limpiarTXT()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtFecha.Text = "";
        }
        public bool vacio()
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtFecha.Text == "")
                return true;
            else
                return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                string vTelefono = txtTelefono.Text;
                string vCorreo = txtCorreo.Text;
                string vFecha = txtFecha.Text;

                if (contactos.buscar(vCodigo) != null)
                    MessageBox.Show("Contacto ya existente");
                else
                    contactos.agregar(new Persona(vCodigo, vNombre, vTelefono, vCorreo, vFecha));
                limpiarTXT();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a buscar.");
            else
                if (contactos.buscar(Convert.ToInt16(txtCodigo.Text)) == null)
                MessageBox.Show("El Contacto no existe");
            else
                txtShow.Text = contactos.buscar(Convert.ToInt16(txtCodigo.Text)).ToString();
            limpiarTXT();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del contacto.");
            else
            {
                if (contactos.eliminar(Convert.ToInt16(txtCodigo.Text)))
                {
                    MessageBox.Show("Contacto eliminado");
                    txtShow.Text = contactos.mostrar();
                }
                else
                    MessageBox.Show("El contacto no existe");
            }
            limpiarTXT();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            txtShow.Text = contactos.mostrar();
        }

        private void btnListarInverso_Click(object sender, EventArgs e)
        {
            txtShow.Text = contactos.inverso();
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            if (contactos.eliminarPrimero())
            {
                MessageBox.Show("Contacto Eliminado!");
                txtShow.Text = contactos.mostrar();
            }
            else
                MessageBox.Show("Agenda vacia!!");
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            if (contactos.eliminarUltimo())
            {
                MessageBox.Show("Contacto Eliminado!");
                txtShow.Text = contactos.mostrar();
            }
            else
                MessageBox.Show("Agenda vacia!!");
        }
    }
}
