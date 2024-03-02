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
    public partial class ProblemasFrecuentes : Form
    {
        //CONEXIÓN
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True");

        public ProblemasFrecuentes()
        {
            InitializeComponent();
            CargarProblemas();
        }

        private void CargarProblemas()
        {
            try
            {
                // Abrir conexión
                conexion.Open();

                // Consulta SQL para recuperar los problemas
                string query = "SELECT Problema FROM ProblemasFrecuentes";

                // Crear comando y ejecutar la consulta
                SqlCommand command = new SqlCommand(query, conexion);
                SqlDataReader reader = command.ExecuteReader();

                // Limpiar el ComboBox antes de agregar los nuevos elementos
                problemas.Items.Clear();

                // Recorrer los resultados y agregar los problemas al ComboBox
                while (reader.Read())
                {
                    problemas.Items.Add(reader["Problema"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los problemas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar conexión
                conexion.Close();
            }
        }

        private void GenerarTicket(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                GenerarTicket ticket = new GenerarTicket();
                ticket.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la ventana para generar ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void problemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el problema seleccionado
            string problemaSeleccionado = problemas.SelectedItem as string;

            try
            {
                // Abrir conexión
                conexion.Open();

                // Consulta SQL para obtener la solución del problema seleccionado
                string query = "SELECT Solucion FROM ProblemasFrecuentes WHERE Problema = @problema";

                // Crear comando y ejecutar la consulta
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@problema", problemaSeleccionado);
                string solucion = (string)command.ExecuteScalar();

                // Mostrar la solución en el Label
                labelSolucion.Text = solucion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la solución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar conexión
                conexion.Close();
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Soporte reg = new Soporte();
            reg.Show();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login salir = new Login();
            salir.Show();
        }
    }
}

