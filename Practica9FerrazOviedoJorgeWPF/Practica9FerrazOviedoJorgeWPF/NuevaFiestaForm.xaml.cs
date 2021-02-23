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
    public partial class NuevaFiestaForm : Window
    {
        public NuevaFiestaForm()
        {
            InitializeComponent();
            añadirMeses();
            añadirAños();
            AñoComboBox.SelectedIndex = 0;
            controlarMaxGente();
            llamarClientes();
        }
        int[] diasMes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        int[] mesesAño = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int[] años = { 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022 };
        SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\INTERFACES; Initial Catalog=practica9; Integrated Security = True");

        public void controlarMaxGente()
        {
            int numeroPersonas =Convert.ToInt32(txtNum.Text);
            if (AmarillaVioletaLabel.Content.Equals("AMARILLA") && numeroPersonas >= 15)
            {
                txtNum.Text = 15 + "";
            }
            else if (AmarillaVioletaLabel.Content.Equals("VIOLETA") && numeroPersonas >= 30)
            {
                txtNum.Text = 30 + "";
            }
            if (numeroPersonas < 0)
            {
                txtNum.Text = 0 + "";
            }
        }

        public void añadirDiasMeses(int numDias)
        {
            DiaComboBox.Items.Clear();
            for (int i = 0; i < numDias; i++)
            {
                DiaComboBox.Items.Add(diasMes[i]);
            }
        }
        public void añadirMeses()
        {
            for (int i = 0; i < mesesAño.Length; i++)
            {
                MesComboBox.Items.Add(mesesAño[i]);
            }
        }

        public void añadirAños()
        {
            for (int i = 0; i < años.Length; i++)
            {
                AñoComboBox.Items.Add(años[i]);
            }
        }


        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            int numActual = Convert.ToInt32(txtNum.Text);
            numActual++;
            txtNum.Text = numActual + "";
            controlarMaxGente();
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            int numActual = Convert.ToInt32(txtNum.Text);
            numActual--;
            txtNum.Text = numActual + "";
            controlarMaxGente();
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!controlTiempo())
            {
                agregarFiesta();
            }
            else
            {
                MessageBox.Show("Este día ya hay programada una fiesta en esta sala");
            }
        }

        private void MesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (añoBisiesto())
            {
                añadirDiasMeses(29);
            }
            else if (MesComboBox.SelectedIndex + 1 == 2)
            {
                añadirDiasMeses(28);
            }
            else if (MesComboBox.SelectedIndex + 1 == 1 || MesComboBox.SelectedIndex + 1 == 3 || MesComboBox.SelectedIndex + 1 == 5 || MesComboBox.SelectedIndex + 1 == 7 || MesComboBox.SelectedIndex + 1 == 8 || MesComboBox.SelectedIndex + 1 == 10 || MesComboBox.SelectedIndex + 1 == 12)
            {
                añadirDiasMeses(31);
            }
            else
            {
                añadirDiasMeses(30);
            }
        }

        private void AñoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (añoBisiesto())
            {
                añadirDiasMeses(29);
            }
        }
        public Boolean añoBisiesto()
        {

            if (int.Parse(AñoComboBox.SelectedItem.ToString()) % 4 == 0 && MesComboBox.SelectedIndex + 1 == 2)
            {
                return true;
            }
            return false;
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void setToAmarilla(object sender, RoutedEventArgs e)
        {
            AmarillaVioletaLabel.Content = "AMARILLA";
            controlarMaxGente();
        }

        private void setToVioleta(object sender, RoutedEventArgs e)
        {
            AmarillaVioletaLabel.Content = "VIOLETA";
            controlarMaxGente();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow.nuevaFiesta = false;
        }

        private void ClienteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        List<String> clientes = new List<string>();
        private void llamarClientes()
        {
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM CLIENTES", conexion);
            DataTable datosTabla = new DataTable();
            adaptador.Fill(datosTabla);
            ClienteComboBox.ItemsSource = datosTabla.DefaultView;
            datosTabla.Columns.Add(
                "DatosCliente",
                typeof(string),
                "nombre + ' ' + apellido1 + ' ' + apellido2 + ' (' + telefono + ')'"
            );

            for (int i = 0; i < datosTabla.Rows.Count; i++)
            {
                clientes.Add(datosTabla.Rows[i][0].ToString());
            }


            conexion.Close();
        }
        private void agregarFiesta()
        {
            if (obtenerFecha() == "")
            {

            }
            else
            {
                conexion.Open();
                string sql = "INSERT INTO RESERVAS (fecha, sala, invitados, dniCliente) VALUES ( '" + obtenerFecha() + "'," + "'" + AmarillaVioletaLabel.Content + "'," + "'" + Convert.ToInt32(txtNum.Text) + "'," + "'" + clientes[ClienteComboBox.SelectedIndex] + "');";
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @sql;
                if (comando.ExecuteNonQuery() > 0)
                {
                    conexion.Close();
                    MessageBox.Show("Reserva añadida");
                }
                else
                {
                    conexion.Close();
                    MessageBox.Show("Error");
                }

            }

        }
        private string obtenerFecha()
        {
            if (MesComboBox.SelectedItem == null || DiaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Porfavor, rellena día y mes");
            }
            else
            {
                int mes = MesComboBox.SelectedIndex + 1;
                return AñoComboBox.SelectedItem.ToString() + "-" + mes.ToString() + "-" + DiaComboBox.SelectedItem.ToString();
            }
            return "";
        }
        private Boolean controlTiempo()
        {
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT fecha, sala FROM RESERVAS", conexion);
            DataTable datosTabla = new DataTable();
            adaptador.Fill(datosTabla);
            conexion.Close();
            for (int i = 0; i < datosTabla.Rows.Count; i++)
            {
                if (contrastarFechas(datosTabla.Rows[i][0].ToString()) && datosTabla.Rows[i][1].ToString().StartsWith(AmarillaVioletaLabel.Content.ToString().Substring(0, 1)))
                {
                    return true;
                }
            }
            return false;
        }
        private Boolean contrastarFechas(string fechaComparada)
        {
            int numCoincidencias = 0;
            int x = Convert.ToInt32(fechaComparada.Substring(0, 2));
            if (Convert.ToInt32(DiaComboBox.SelectedItem) == x)
            {
                numCoincidencias++;
            }
            int y = Convert.ToInt32(fechaComparada.Substring(3, 2));
            if (Convert.ToInt32(MesComboBox.SelectedItem) == y)
            {
                numCoincidencias++;
            }
            int z = Convert.ToInt32(fechaComparada.Substring(6, 4));
            if (Convert.ToInt32(AñoComboBox.SelectedItem) == z)
            {
                numCoincidencias++;
            }
            return numCoincidencias == 3;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            llamarClientes();
        }
    }
}
