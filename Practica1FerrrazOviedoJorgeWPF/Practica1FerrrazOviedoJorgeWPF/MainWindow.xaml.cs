using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica1FerrrazOviedoJorgeWPF
{
    struct Persona
    {
        public string DNI;
        public string Nombre;
        public string Apellido1;
        public string Apellido2;
        public string sexo;
        public Boolean permisoA;
        public Boolean permisoB;
        public Boolean permisoC;
        public Boolean permisoD;
        public Boolean permisoE;
        public string Formacion;
    }
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persona[] Pers = new Persona[10];
        int aux = 0;
        public MainWindow()
        {
            InitializeComponent();
            OtrosTextBox.IsEnabled = false;
        }
        public void validacionTotal()
        {
            if (DNItextbox.Text.Length == 0 || Apellido1Textbox.Text.Length == 0 || Apellido2Textbox.Text.Length == 0 || NombreTextbox.Text.Length == 0)
            {
                MessageBox.Show("Error, no se ha rellenado alguna de las siguientes casillas: DNI, Apellidos, Nombre");
            }
            else if (MujerRadioButton.IsChecked == false && HombreRadioButton.IsChecked == false)
            {
                MessageBox.Show("Error, no se especifico el sexo");
            }
            else if (NingunaRadioButton.IsChecked == false && OtraRadioButton.IsChecked == false && UniversitariaRadioButton.IsChecked == false && ESORadioButton.IsChecked == false && BachilleratoRadioButton.IsChecked == false && FPRadioButton.IsChecked == false)
            {
                MessageBox.Show("Error, no se ha especificado la titulación");
            }
            else if (OtrosTextBox.Text.Length == 0 && OtraRadioButton.IsChecked == true)
            {
                MessageBox.Show("Error, no se ha rellenado el apartado (otros) ");
            }
            else if (detectarDuplicados(DNItextbox.Text))
            {
                MessageBox.Show("Error, el DNI esta repetido");
            }
            else 
            {
                añadirPersona();
                MessageBox.Show("Datos añadidos");
                aux++;
                limpiarFormulario();
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            validacionTotal();
        }

        private void DNItextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OtraCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (OtraRadioButton.IsChecked == true)
            {
                OtrosTextBox.IsEnabled = true;
            }
        }
        private void añadirPersona()
        {
            Pers[aux].DNI = DNItextbox.Text;
            Pers[aux].Nombre = NombreTextbox.Text;
            Pers[aux].Apellido1 = Apellido1Textbox.Text;
            Pers[aux].Apellido2 = Apellido2Textbox.Text;
            if (HombreRadioButton.IsChecked == true)
            {
                Pers[aux].sexo = "Hombre";
            }
            else
            {
                Pers[aux].sexo = "Mujer";
            }
            if (OtraRadioButton.IsChecked == true)
            {
                Pers[aux].Formacion = OtrosTextBox.Text;
            }
            if (NingunaRadioButton.IsChecked == true)
            {
                Pers[aux].Formacion = "Ninguna";
            }
            if (ESORadioButton.IsChecked == true)
            {
                Pers[aux].Formacion = "ESO";
            }
            if (FPRadioButton.IsChecked == true)
            {
                Pers[aux].Formacion = "FP";
            }
            if (BachilleratoRadioButton.IsChecked == true)
            {
                Pers[aux].Formacion = "Bachiller";
            }
            if (UniversitariaRadioButton.IsChecked == true)
            {
                Pers[aux].Formacion = "Universidad";
            }
            if (ACheckBox.IsChecked == true)
            {
                Pers[aux].permisoA = true;
            }
            if (BCheckBox.IsChecked == true)
            {
                Pers[aux].permisoB = true;
            }
            if (CCheckBox.IsChecked == true)
            {
                Pers[aux].permisoC = true;
            }
            if (DCheckBox.IsChecked == true)
            {
                Pers[aux].permisoD = true;
            }
            if (ECheckBox.IsChecked == true)
            {
                Pers[aux].permisoE = true;
            }
        }
        private void limpiarFormulario()
        {
            DNItextbox.Text = "";
            Apellido1Textbox.Text = "";
            Apellido2Textbox.Text = "";
            NombreTextbox.Text = "";
            OtrosTextBox.Text = "";
            ACheckBox.IsChecked = false;
            BCheckBox.IsChecked = false;
            CCheckBox.IsChecked = false;
            DCheckBox.IsChecked = false;
            ECheckBox.IsChecked = false;
            MujerRadioButton.IsChecked = false;
            HombreRadioButton.IsChecked = false;
            NingunaRadioButton.IsChecked = false;
            ESORadioButton.IsChecked = false;
            BachilleratoRadioButton.IsChecked = false;
            UniversitariaRadioButton.IsChecked = false;
            FPRadioButton.IsChecked = false;
            OtraRadioButton.IsChecked = false;
            OtrosTextBox.IsEnabled = false;
        }
        private Boolean detectarDuplicados(string x)
        {
            string detector = x;
            for (int i = 0; i < Pers.Length; i++)
            {
                if (Pers[i].DNI == x)
                {
                    return true;
                }
            }
            return false;
        }
        private int buscarDNI(string x)
        {
            string detector = x;
            for (int i = 0; i < Pers.Length; i++)
            {
                if (Pers[i].DNI == x)
                {
                    return i;
                }
            }
            return 100;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int x;
            if (BuscarTextBox.Text == "")
            {
                MessageBox.Show("No se ha escrito ningun DNI a buscar");
            }
            else if (buscarDNI(BuscarTextBox.Text) <= aux)
            {
                x = buscarDNI(BuscarTextBox.Text);
                MessageBox.Show("Se encontró el DNI, los datos son los siguientes:");
                NombreTextbox.Text = Pers[x].Nombre;
                Apellido1Textbox.Text = Pers[x].Apellido1;
                Apellido2Textbox.Text = Pers[x].Apellido2;
                DNItextbox.Text = Pers[x].DNI;
                if (Pers[x].sexo == "Hombre")
                {
                    HombreRadioButton.IsChecked = true;
                }
                else
                {
                    MujerRadioButton.IsChecked = true;
                }
                if (Pers[x].permisoA)
                {
                    ACheckBox.IsChecked = true;
                }
                if (Pers[x].permisoB)
                {
                    BCheckBox.IsChecked = true;
                }
                if (Pers[x].permisoA)
                {
                    CCheckBox.IsChecked = true;
                }
                if (Pers[x].permisoD)
                {
                    DCheckBox.IsChecked = true;
                }
                if (Pers[x].permisoE)
                {
                    ECheckBox.IsChecked = true;
                }
                if (Pers[x].Formacion == "Ninguna")
                {
                    NingunaRadioButton.IsChecked = true;
                }
                else if (Pers[x].Formacion == "ESO")
                {
                    ESORadioButton.IsChecked = true;
                }
                else if (Pers[x].Formacion == "FP")
                {
                    FPRadioButton.IsChecked = true;
                }
                else if (Pers[x].Formacion == "Bachiller")
                {
                    BachilleratoRadioButton.IsChecked = true;
                }
                else if (Pers[x].Formacion == "Universidad")
                {
                    UniversitariaRadioButton.IsChecked = true;
                }
                else
                {
                    OtraRadioButton.IsChecked = true;
                    OtrosTextBox.Text = Pers[x].Formacion;
                }
            }
            else
            {
                MessageBox.Show("No se encontró el DNI");
            }
        }

        private void OtraRadioButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void NingunaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OtrosTextBox.IsEnabled = false;
        }

        private void ESORadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OtrosTextBox.IsEnabled = false;
        }

        private void UniversitariaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OtrosTextBox.IsEnabled = false;
        }

        private void FPRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OtrosTextBox.IsEnabled = false;
        }

        private void BachilleratoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OtrosTextBox.IsEnabled = false;
        }
    }
}
