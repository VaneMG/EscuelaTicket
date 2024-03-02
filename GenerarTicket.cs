using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EscuelaTicket
{
    public partial class GenerarTicket : Form
    {
        // CONEXIÓN
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-8RBGU1S;Initial Catalog=EscuelaTicket;Integrated Security=True");

        public GenerarTicket()
        {
            InitializeComponent();
        }

        private void Generar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                string queryLastID = "SELECT MAX(IDProblema) FROM Problemas";
                SqlCommand commandLastID = new SqlCommand(queryLastID, conexion);
                object lastIDResult = commandLastID.ExecuteScalar();

                int lastID;
                if (lastIDResult != DBNull.Value)
                {
                    lastID = Convert.ToInt32(lastIDResult);
                }
                else
                {
                    lastID = 0; 
                }

                int newID = lastID + 1;

                int idUsuario = Convert.ToInt32(txtid.Text); 
                string problema = txtproblema.Text; 

                string queryInsert = "INSERT INTO Problemas (IDProblema, IDUsuario, Problema, Estado) VALUES (@IDProblema, @IDUsuario, @Problema, 'Sin revisar')";
                SqlCommand commandInsert = new SqlCommand(queryInsert, conexion);
                commandInsert.Parameters.AddWithValue("@IDProblema", newID);
                commandInsert.Parameters.AddWithValue("@IDUsuario", idUsuario);
                commandInsert.Parameters.AddWithValue("@Problema", problema);
                commandInsert.ExecuteNonQuery();

                conexion.Close();

                MessageBox.Show("Ticket generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProblemasFrecuentes pf = new ProblemasFrecuentes();
            pf.Show();
        }
    }
}

