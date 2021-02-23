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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica9FerrazOviedoJorgeWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            checkConnection();
        }
        public SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\INTERFACES; Initial Catalog=practica9; Integrated Security = True");
        
        public static Boolean nuevaFiesta = false;
        public static Boolean bajaFiesta = false;
        public static Boolean bajaCliente = false;
        NuevaFiestaForm newParty;
        EliminarFiestaForm deleteParty;
        NuevoClienteForm newClient;
        EliminarClienteForm deleteClient;
        private void Practica9wpfWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void AltaFiestaClick(object sender, RoutedEventArgs e)
        {
            if (!nuevaFiesta)
            {
                newParty = new NuevaFiestaForm();
                nuevaFiesta = true;
                newParty.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Ya estás añadiendo una fiesta");
            }
        }
        private void BajaFiestaClick(object sender, RoutedEventArgs e)
        {
            if (!bajaFiesta)
            {
                deleteParty = new EliminarFiestaForm();
                bajaFiesta = true;
                deleteParty.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Ya estás eliminando una fiesta");
            }
        }
        private void AltaClienteClick(object sender, RoutedEventArgs e)
        {
            newClient = new NuevoClienteForm();
            newClient.Show();
        }
        private void BajaClienteClick(object sender, RoutedEventArgs e)
        {
            if (!bajaCliente)
            {
                deleteClient = new EliminarClienteForm();
                bajaCliente = true;
                deleteClient.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Ya estás eliminando un cliente");
            }
        }
        private void checkConnection()
        {
            if (tryConection())
            {
                System.Windows.MessageBox.Show("Conexión establecida con la base de datos");
            }
            else
            {
                System.Windows.MessageBox.Show("Conexión no establecida");
            }
        }
        public Boolean tryConection()
        {
            try
            {
                SqlCommand comando = new SqlCommand();

                comando.CommandText = "SELECT * FROM CLIENTES";
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void obtenerFiestas()
        {
            string todasFiestas = "SELECT * FROM RESERVAS INNER JOIN CLIENTES ON RESERVAS.dniCliente = CLIENTES.dniCliente;";
            SqlDataAdapter adaptador = new SqlDataAdapter(todasFiestas, conexion);
            DataTable datosReservas = new DataTable();
            adaptador.Fill(datosReservas);

            datosReservas.Columns.Add(
                "Cliente",
                typeof(string),
                "nombre + ' ' + apellido1 + ' ' + apellido2"
            );
            FiestasDataGridView.ItemsSource = datosReservas.DefaultView;
            FiestasDataGridView.Columns[0].Header = "Cod. Fiesta";
            FiestasDataGridView.Columns[1].Header = "Fecha";
            FiestasDataGridView.Columns[2].Header = "Sala";
            FiestasDataGridView.Columns[3].Header = "Num. invitados";
            FiestasDataGridView.Columns[4].Visibility = Visibility.Hidden;
            FiestasDataGridView.Columns[5].Visibility = Visibility.Hidden;
            FiestasDataGridView.Columns[6].Visibility = Visibility.Hidden;
            FiestasDataGridView.Columns[7].Visibility = Visibility.Hidden; 
            FiestasDataGridView.Columns[8].Visibility = Visibility.Hidden;
            FiestasDataGridView.Columns[9].Visibility = Visibility.Hidden;
            FiestasDataGridView.Columns[10].Width = 200; 
            FiestasDataGridView.Columns[1].Width = 200; 
            FiestasDataGridView.Columns[2].Width = 200; 
        }
        private void GestionClick(object sender, RoutedEventArgs e)
        {

        }

        private void FiestasDataGridView_Loaded(object sender, RoutedEventArgs e)
        {
            obtenerFiestas();
        }

        private void Practica9wpfWindow_Activated(object sender, EventArgs e)
        {
            obtenerFiestas();
        }
    }
}
