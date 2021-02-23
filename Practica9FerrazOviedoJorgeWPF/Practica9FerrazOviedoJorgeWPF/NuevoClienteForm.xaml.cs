using System;
using System.Collections.Generic;
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
    public partial class NuevoClienteForm : Window
    {
        public NuevoClienteForm()
        {
            InitializeComponent();
        }
        public SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\INTERFACES; Initial Catalog=practica9; Integrated Security = True");

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkCampos())
            {
                añadirCliente();

            }
            else
            {
                MessageBox.Show("No has completado alguno de los campos");
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Boolean checkCampos()
        {
            if (DNITextBox.Text.Equals("") || NombreTextBox.Text.Equals("") || ApellidoTextBox.Text.Equals("") || Apellido2TextBox.Text.Equals("") || TelefonoTextBox.Text.Equals(""))
            {
                return false;
            }
            return true;
        }
        private void añadirCliente()
        {
            conexion.Open();
            SqlCommand miComando = new SqlCommand("INSERT INTO CLIENTES (dniCliente, nombre, apellido1, apellido2, telefono) VALUES (@DNI, @nom, @ap1, @ap2, @tel)", conexion);
            miComando.Parameters.AddWithValue("@DNI", DNITextBox.Text);
            miComando.Parameters.AddWithValue("@nom", NombreTextBox.Text);
            miComando.Parameters.AddWithValue("@ap1", ApellidoTextBox.Text);
            miComando.Parameters.AddWithValue("@ap2", Apellido2TextBox.Text);
            miComando.Parameters.AddWithValue("@tel", TelefonoTextBox.Text);

            try
            {
                miComando.ExecuteNonQuery();
                MessageBox.Show("Cliente añadido");
            }
            catch (Exception)
            {
                MessageBox.Show("Ese DNI no es válido porque ya existe un cliente con el mismo");
            }
            conexion.Close();

        }
        private void validarTelefono()
        {
            if (TelefonoTextBox.Text == "") { MessageBox.Show("Telefono vacío, rellena"); TelefonoTextBox.Focus(); }
            if (TelefonoTextBox.Text.Length < 9) { MessageBox.Show("Telefono Incompleto"); }
            if (TelefonoTextBox.Text.Length > 9)
            {
                MessageBox.Show("Demasiados caracteres para un numero de telefono");
            }
        }
        private Boolean validarDNI()
        {
            int x;
            string letrasPosibles = "TRWAGMYFPDXBNJZSQVHLCKE";
            int numsDNI = 0; int resto = 0; string auxDNI = DNITextBox.Text;
            try { auxDNI = auxDNI.Substring(0, 8); }
            catch (System.ArgumentOutOfRangeException) { MessageBox.Show("Introduce la longitud de caracteres correcta"); }
            if (Int32.TryParse(auxDNI, out x)) { numsDNI = Int32.Parse(auxDNI); }
            else { MessageBox.Show("Pon el formato DNI bien"); return false; }
            resto = numsDNI % 23; char letra = letrasPosibles.ToCharArray()[resto];
            try
            {
                if (letra.Equals(DNITextBox.Text.ToCharArray()[8])) { MessageBox.Show("Coincidencia de letra, DNI correcto"); return true; }
                else { MessageBox.Show("Fallo al escribir DNI"); return false; }
            }
            catch (Exception)
            {
                MessageBox.Show("Fallo al escribir DNI");
            }
            return false;

        }
    }
}
