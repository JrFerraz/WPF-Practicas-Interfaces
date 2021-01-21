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
using Microsoft.Win32;
using System.IO;

namespace Practica3FerrazOviedoJorgeWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<personas> miLista = new List<personas>();
        Boolean newButtonFlag = false;
        
        public class personas
        {
            public string nombre { get; set; }
            public string teléfono { get; set; }
            public string email { get; set; }
            public ImageSource IDFoto { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AñadirButton_Click(object sender, RoutedEventArgs e)
        {
            if (!newButtonFlag)
            {
                NombreTextBox.IsEnabled = true;
                TelefonoTextBox.IsEnabled = true;
                EmailTextBox.IsEnabled = true;
                NombreTextBox.Text = "";
                TelefonoTextBox.Text = "";
                EmailTextBox.Text = "";
                AñadirButton.Content = "Añadir";
                ModificarButton.IsEnabled = false;
                EliminarButton.IsEnabled = false;
                AñadirFotoButton.IsEnabled = true;
                FotoPictureBox.Visibility = Visibility.Visible;
                FotoPictureBox.Source= null;
                newButtonFlag = true;
            }
            else
            {
                if (validarVacios() && validarTelefono() && validarNombre())
                {
                    if (!validarEmail())
                    {
                        MessageBox.Show("Email erroneo");
                    }
                    else
                    {
                        añadirPersona();
                        NombreTextBox.IsEnabled = false;
                        TelefonoTextBox.IsEnabled = false;
                        EmailTextBox.IsEnabled = false;
                        NombreTextBox.Text = "";
                        TelefonoTextBox.Text = "";
                        EmailTextBox.Text = "";
                        ModificarButton.IsEnabled = true;
                        EliminarButton.IsEnabled = true;
                        AñadirFotoButton.IsEnabled = false;
                        AñadirButton.Content = "Nuevo";
                        FotoPictureBox.Source = null;
                        newButtonFlag = false;
                    }
                    
                }

            }
        }
        private Boolean validarVacios()
        {
            if (EmailTextBox.Text == "" || NombreTextBox.Text == "" || TelefonoTextBox.Text == "")
            {
                MessageBox.Show("Alguno(s) campos no están completos");
                return false;
            }
            else return true;
        }
        public void añadirPersona()
        {
            miLista.Add(new personas()
            {
                nombre = NombreTextBox.Text,
                email = EmailTextBox.Text,
                teléfono = TelefonoTextBox.Text,
                IDFoto = FotoPictureBox.Source

            });
            refrescarListBox();
        }
        private void refrescarListBox()
        {
            MiListBox.Items.Clear();
            for (int i = 0; i < miLista.Count; i++)
            {
                MiListBox.Items.Add(miLista[i].nombre);
            }
        }
        public void modificarPersona()
        {
            miLista.RemoveAt(MiListBox.SelectedIndex);
            miLista.Insert(MiListBox.SelectedIndex, new personas()
            {
                nombre = NombreTextBox.Text,
                email = EmailTextBox.Text,
                teléfono = TelefonoTextBox.Text,
                IDFoto = FotoPictureBox.Source
            });
            refrescarListBox();
        }
        public void eliminarPersona()
        {
            try
            {
                miLista.RemoveAt(MiListBox.SelectedIndex);
                NombreTextBox.Text = "";
                TelefonoTextBox.Text = "";
                EmailTextBox.Text = "";
                FotoPictureBox.Source = null;
                refrescarListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay personas que eliminar");
            }
        }
        private Boolean validarTelefono()
        {
            int output;
            if (!Int32.TryParse(TelefonoTextBox.Text, out output) || TelefonoTextBox.Text.Length !=9)
            {
                MessageBox.Show("Formato de telefono incorrecto");
                return false;
            }
            return true;
        }
        private Boolean validarEmail()
        {
            if (EmailTextBox.Text.StartsWith(".") || EmailTextBox.Text.StartsWith("@"))
            {
                return false;
            }
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            for (int i = 0; i < EmailTextBox.Text.Length; i++)
            {
                if (EmailTextBox.Text.Substring(i, 1).Equals(".") && count==0)
                {
                    return false;
                }
                if (EmailTextBox.Text.Substring(i,1).Equals("@"))
                {
                    count++;
                }
                if (count == 1 && EmailTextBox.Text.Substring(i, 1).Equals(".") && EmailTextBox.Text.Substring(i-1, 1).Equals("@"))
                {
                    return false;
                }
                if (count == 1 && EmailTextBox.Text.Substring(i,1).Equals("."))
                {
                    count2++;
                }
            }
            if (count > 1)
            {
                return false;
            }
            if (EmailTextBox.Text.Substring(EmailTextBox.Text.Length-4,1).Equals(".") || EmailTextBox.Text.Substring(EmailTextBox.Text.Length - 3, 1).Equals("."))
            {
                count3++;
            }
            return count + count2 +count3 == 3;
        }
        private Boolean validarNombre()
        {
           
            for (int i = 0; i < miLista.Count; i++)
            {
                if (NombreTextBox.Text.Equals(miLista[i].nombre))
                {
                    MessageBox.Show("Nombre no válido(repetido)");
                    NombreTextBox.Clear();
                    NombreTextBox.Focus();
                    return false;
                }
            }
            return true;
        }
        private void NombreTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TelefonoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NombreTextBox_DragLeave(object sender, DragEventArgs e)
        {
            
        }

        private void NombreTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void MiListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                NombreTextBox.Text = miLista[MiListBox.SelectedIndex].nombre;
                TelefonoTextBox.Text = miLista[MiListBox.SelectedIndex].teléfono;
                EmailTextBox.Text = miLista[MiListBox.SelectedIndex].email;
                FotoPictureBox.Source = miLista[MiListBox.SelectedIndex].IDFoto;
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!newButtonFlag)
            {
                NombreTextBox.IsEnabled = true;
                TelefonoTextBox.IsEnabled = true;
                EmailTextBox.IsEnabled = true;
                EliminarButton.IsEnabled = false;
                AñadirFotoButton.IsEnabled = true;
                AñadirButton.IsEnabled = false;
                newButtonFlag = true;
            }
            else
            {
                modificarPersona();
                NombreTextBox.IsEnabled = false;
                TelefonoTextBox.IsEnabled = false;
                EmailTextBox.IsEnabled = false;
                AñadirFotoButton.IsEnabled = false;
                EliminarButton.IsEnabled = true;
                AñadirButton.IsEnabled = true;
                FotoPictureBox.Source = null;
                NombreTextBox.Text = "";
                TelefonoTextBox.Text = "";
                EmailTextBox.Text = "";
                newButtonFlag = false;
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            eliminarPersona();
        }

        private void FotoPictureBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void AñadirFotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivos (*.jpg)(*.png)|*.jpg;*png";
            Nullable<bool> result = open.ShowDialog();
            if (result == true)
            {
                Uri fileUri = new Uri(open.FileName);
                FotoPictureBox.Source = new BitmapImage(fileUri);
            }
        }
    }
}
