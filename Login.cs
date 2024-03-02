using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EscuelaTicket
{
    public partial class Login : Form
    {
        // CONEXIÓN
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarUsuario registro = new RegistrarUsuario();
            registro.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CambiarContra cambiarcontra = new CambiarContra();
            cambiarcontra.Show();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            string usuario = txtnom.Text;
            string contraseña = txtcontra.Text;

            string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @usuario AND Contraseña = @contraseña";

            try
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        string queryNombre = "SELECT Nombre FROM Usuarios WHERE Nombre = @usuario";
                        using (SqlCommand commandNombre = new SqlCommand(queryNombre, conexion))
                        {
                            commandNombre.Parameters.AddWithValue("@usuario", usuario);
                            string nombre = (string)commandNombre.ExecuteScalar();

                            if (nombre == "Soporte")
                            {
                                Soporte soporte = new Soporte();
                                this.Hide();
                                soporte.ShowDialog();
                            }
                            else
                            {
                                ProblemasFrecuentes pf = new ProblemasFrecuentes();
                                this.Hide();
                                pf.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vercontra_Click(object sender, EventArgs e)
        {
            Ocultar.BringToFront();
            txtcontra.PasswordChar = '\0';
        }

        private void Ocultar_Click(object sender, EventArgs e)
        {
            vercontra.BringToFront();
            txtcontra.PasswordChar = '*';
        }
    }
}
