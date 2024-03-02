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
    public partial class RegistrarUsuario : Form
    {
        //CONEXIÓN
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True");
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            //ALTAS / REGISTRAR
            if (String.IsNullOrEmpty(txtnom.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (String.IsNullOrEmpty(txtid.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (String.IsNullOrEmpty(txtcon.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else
            {
                SqlCommand Altas = new SqlCommand("insert into Usuarios(IDUsuario,Nombre,Contraseña) values(@id_usuario,@usuario,@contraseña)", conexion);


                //Se pasan los valores de los text box a las variables temporales
                Altas.Parameters.AddWithValue("id_usuario", txtid.Text);
                Altas.Parameters.AddWithValue("usuario", txtnom.Text);
                Altas.Parameters.AddWithValue("contraseña", txtcon.Text);
                //Abriendo conexion
                conexion.Open();

                Altas.ExecuteNonQuery();

                //Cerrando conexion
                conexion.Close();

                //mensaje de exito
                MessageBox.Show("Registro logrado con exito");

                txtnom.Clear();
                txtid.Clear();
                txtcon.Clear();
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

        }
    }
}
