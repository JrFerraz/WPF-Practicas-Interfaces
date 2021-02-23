using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica9FerrazOviedoJorgeWPF
{
    public partial class EliminarFiestaForm : Window
    {
        public EliminarFiestaForm()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\INTERFACES; Initial Catalog=practica9; Integrated Security = True");
        List<string> IDsReservas = new List<string>();
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                borrarFiesta();
                MessageBox.Show("Se ha eliminado correctamente la fiesta");
                IDsReservas.Clear();
                FiestasComboBox.Items.Clear();
                FiestasComboBox.Text = "";
                rellenarComboFiestas();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Selecciona una fiesta que borrar");
                conexion.Close();
            }
            conexion.Close();
        }

        private void EliminarFiestaForm1_Closed(object sender, EventArgs e)
        {
            MainWindow.bajaFiesta = false;
        }

        private void rellenarComboFiestas()
        {
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM RESERVAS INNER JOIN CLIENTES ON RESERVAS.dniCliente = CLIENTES.dniCliente;", conexion);
            DataTable datosFiestas = new DataTable();
            adaptador.Fill(datosFiestas);
            //Rellenar lista de ID
            for (int i = 0; i < datosFiestas.Rows.Count; i++)
            {
                IDsReservas.Add(datosFiestas.Rows[i][0].ToString());
            }
            datosFiestas.Columns.Add(
                "DatosFiestas",
                typeof(string),
                "nombre + ' ' + apellido1 + ' ' + apellido2 + '-SALA ' + sala"
            );
            for (int i = 0; i < datosFiestas.Rows.Count; i++)
            {
                FiestasComboBox.Items.Add(datosFiestas.Rows[i][1].ToString().Substring(0, 10) + "-" + datosFiestas.Rows[i][10]);
            }
            conexion.Close();
        }
        private void borrarFiesta()
        {
            conexion.Open();
            SqlCommand miComando = new SqlCommand("DELETE FROM RESERVAS WHERE codReserva = @ID", conexion);
            miComando.Parameters.AddWithValue("@ID", IDsReservas[FiestasComboBox.SelectedIndex]);
            miComando.ExecuteNonQuery();
            conexion.Close();
        }

        private void EliminarFiestaForm1_Activated(object sender, EventArgs e)
        {
            FiestasComboBox.Items.Clear();
            rellenarComboFiestas();
        }
    }
}
