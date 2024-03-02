using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaTicket
{
    public partial class CambiarContra : Form
    {
        //CONEXIÓN
        //CONEXIÓN
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True");
        public CambiarContra()
        {
            InitializeComponent();
        }

        private void Cambiar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtnom.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (String.IsNullOrEmpty(txtcon.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else
            {
                try
                {

                    string query = "UPDATE Usuarios SET Contraseña=@contraseña WHERE Nombre=@usuario";
                    conexion.Open();
                    SqlCommand modifica = new SqlCommand(query, conexion);
                    modifica.Parameters.AddWithValue("@usuario", txtnom.Text);
                    modifica.Parameters.AddWithValue("@contraseña", txtcon.Text);
                    modifica.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Contraseña actualizada");
                    txtnom.Clear();
                    txtcon.Clear();
                    txtnom.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar los datos " + ex);
                }
            }

        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void vercontra_Click(object sender, EventArgs e)
        {
            Ocultar.BringToFront();
            txtcon.PasswordChar = '\0';
        }

        private void Ocultar_Click(object sender, EventArgs e)
        {
            vercontra.BringToFront();
            txtcon.PasswordChar = '*';
        }
    }
}
