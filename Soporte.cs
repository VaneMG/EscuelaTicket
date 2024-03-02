using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EscuelaTicket
{
    public partial class Soporte : Form
    {
        //CONEXIÓN
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True");

        public Soporte()
        {
            InitializeComponent();

            comboBox1.Items.Add("Sin revisar");
            comboBox1.Items.Add("En proceso");
            comboBox1.Items.Add("Completado");

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Problemas", conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la tabla" + ex);
            }
        }

        private void GuardarProblema_Click(object sender, EventArgs e)
        {
            this.Hide();
            SoporteProblemas SopPro = new SoporteProblemas();
            SopPro.Show();
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Cells["IDUsuario"].Value != null)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtiduser.Text = row.Cells["IDUsuario"].Value.ToString();
                txtproblem.Text = row.Cells["Problema"].Value.ToString();

                // Verificar si la celda de estado es nula
                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();
                    Console.WriteLine("Valor de estado: " + estado); // Depuración
                    comboBox1.SelectedItem = estado;
                }
                else
                {
                    comboBox1.SelectedItem = null; // O establecer un valor predeterminado
                }
            }
            else
            {
                // Si no hay filas seleccionadas o las celdas están vacías, limpiar los campos
                txtiduser.Text = "";
                txtproblem.Text = "";
                comboBox1.SelectedItem = null;
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login salir = new Login();
            salir.Show();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtiduser.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (String.IsNullOrEmpty(txtproblem.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else
            {
                try
                {

                    string query = "UPDATE Problemas SET IDUsuario=@IDUsuario,Problema=@Problema,Estado=@Estado WHERE Problema=@Problema AND IDUsuario=@IDUsuario";
                    conexion.Open();
                    SqlCommand modifica = new SqlCommand(query, conexion);
                    modifica.Parameters.AddWithValue("@IDUsuario", txtiduser.Text);
                    modifica.Parameters.AddWithValue("@Problema", txtproblem.Text);
                    modifica.Parameters.AddWithValue("@Estado", comboBox1.Text);
                    modifica.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Problema actualizado");
                    txtproblem.Clear();
                    txtiduser.Clear();
                    comboBox1.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar los datos " + ex);
                }
                //MOSTRAMOS LOS DATOS EN EL DATAGRIDVIEW
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Problemas", conexion);
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

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtproblem.Text))
            {
                MessageBox.Show("El campo de problema debe ser llenado");
            }
            else
            {
                try
                {
                    // Abrir conexión
                    conexion.Open();

                    // Construir consulta SQL con parámetro
                    string consulta = "SELECT * FROM Problemas WHERE Problema = @problema";
                    Console.WriteLine("Consulta SQL: " + consulta); // Depuración

                    // Crear comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar parámetro
                    comando.Parameters.AddWithValue("@problema", txtproblem.Text);
                    Console.WriteLine("Valor del parámetro @problema: " + txtproblem.Text); // Depuración

                    // Ejecutar consulta y cargar datos en el DataGridView
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dataGridView1.DataSource = tabla;

                    // Cerrar conexión
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar datos en la tabla: " + ex.Message);
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtproblem.Text))
            {
                MessageBox.Show("El campo de problema debe ser llenado");
            }
            else
            {
                try
                {
                    // Abrir conexión
                    conexion.Open();

                    // Construir consulta SQL con parámetro
                    string consulta = "DELETE FROM Problemas WHERE Problema = @problema";
                    Console.WriteLine("Consulta SQL: " + consulta); // Depuración

                    // Crear comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar parámetro
                    comando.Parameters.AddWithValue("@problema", txtproblem.Text);
                    Console.WriteLine("Valor del parámetro @problema: " + txtproblem.Text); // Depuración

                    // Ejecutar consulta
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Cerrar conexión
                    conexion.Close();

                    // Verificar si se eliminó correctamente
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Problema eliminado exitosamente");

                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter("Select * from Problemas", conexion);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al mostrar la tabla" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún problema con ese nombre");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar problema: " + ex.Message);
                }
            }
        }
    }
}
