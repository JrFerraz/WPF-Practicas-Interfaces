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
    public partial class EliminarClienteForm : Window
    {
        public EliminarClienteForm()
        {
            InitializeComponent();
            rellenarComboClientes();
        }

        public SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\INTERFACES; Initial Catalog=practica9; Integrated Security = True");
        DataTable datosClientes;

        private void Window_Activated(object sender, EventArgs e)
        {
            rellenarComboClientes();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            eliminarCliente();
            refrescarCombo();
        }
        private void rellenarComboClientes()
        {
            datosClientes = new DataTable();
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM CLIENTES;", conexion);
            adaptador.Fill(datosClientes);
            ClientesComboBox.ItemsSource = datosClientes.DefaultView;
            datosClientes.Columns.Add(
                "DatosClientes",
                typeof(string),
                "nombre + ' ' + apellido1 + ' ' + apellido2 + '-TLF: ' + telefono"
            );
            conexion.Close();
        }
        private void eliminarCliente()
        {
            try
            {
                conexion.Open();
                SqlCommand miComando = new SqlCommand("DELETE FROM CLIENTES WHERE dniCliente = @ID", conexion);
                miComando.Parameters.AddWithValue("@ID", datosClientes.Rows[ClientesComboBox.SelectedIndex][0]);
                miComando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se ha eliminado el cliente");
            }
            catch (Exception)
            {
                conexion.Close();
                MessageBox.Show("No se puede borrar ese cliente debido a que tiene agregadas RESERVAS");
            }

        }
        private void refrescarCombo()
        {
            rellenarComboClientes();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.bajaCliente = false;
        }
    }
}
