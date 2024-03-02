using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EscuelaTicket
{
    public partial class SoporteProblemas : Form
    {
        // CONEXIÓN
        string connectionString = "Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True";
        SqlConnection conexion;

        public SoporteProblemas()
        {
            InitializeComponent();
            conexion = new SqlConnection(connectionString);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from ProblemasFrecuentes", conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la tabla" + ex);
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Soporte reg = new Soporte();
            reg.Show();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text) || string.IsNullOrEmpty(txtproblema.Text) || string.IsNullOrEmpty(txtsolucion.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
                return;
            }

            int idProblema;
            if (!int.TryParse(txtid.Text, out idProblema))
            {
                MessageBox.Show("El ID del problema debe ser un número entero");
                return;
            }

            string query = "INSERT INTO ProblemasFrecuentes (IDProblemaFrecuente, Problema, Solucion) VALUES (@idProblema, @problema, @solucion)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProblema", idProblema);
                        command.Parameters.AddWithValue("@problema", txtproblema.Text);
                        command.Parameters.AddWithValue("@solucion", txtsolucion.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Problema guardado con éxito");

                txtid.Clear();
                txtproblema.Clear();
                txtsolucion.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el problema: " + ex.Message);
            }
            // MOSTRAMOS LOS DATOS EN EL DATAGRIDVIEW
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ProblemasFrecuentes", conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la tabla" + ex);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtid.Text))
            {
                MessageBox.Show("El campo de id debe ser llenado");
            }
            else
            {
                try
                {
                    string baja = "DELETE FROM ProblemasFrecuentes WHERE IDProblemaFrecuente = @IDProblemaFrecuente";
                    conexion.Open();

                    SqlCommand cmdIns = new SqlCommand(baja, conexion);
                    cmdIns.Parameters.Add("IDProblemaFrecuente", txtid.Text);
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Dispose();
                    cmdIns = null;
                    txtid.Clear();

                    conexion.Close();
                    MessageBox.Show("Problema eliminado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar los datos " + ex);
                }
                // MOSTRAMOS LOS DATOS EN EL DATAGRIDVIEW
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ProblemasFrecuentes", conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar la tabla" + ex);
                }
            }
        }
    }
}
