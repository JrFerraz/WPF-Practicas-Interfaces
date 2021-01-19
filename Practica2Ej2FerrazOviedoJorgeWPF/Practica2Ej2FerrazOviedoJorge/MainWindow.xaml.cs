using System;
using System.Collections;
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

namespace Practica2Ej2FerrazOviedoJorge
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public ArrayList locCor = new ArrayList();
        public ArrayList locLugo = new ArrayList();
        public ArrayList locOren = new ArrayList();
        public ArrayList locPont = new ArrayList();
        public MainWindow()
        {
            InitializeComponent();
            localidadesIniciales();

        }

        private void EjecutarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AñadirRadButton.IsChecked == true && LocalidadTextBox.Text == "")
            {
                MessageBox.Show("Rellena la localidad");
            }
            else if (AñadirRadButton.IsChecked == true)
            {
                añadirLoc();
            }
            if (EliminarRadButton.IsChecked == true)
            {
                borrarLoc();
            }
        }
        public void añadirLoc()
        {
            if (ProvinciaComboBox.SelectedIndex == 0)
            {
                locCor.Add(LocalidadTextBox.Text);
                LocalidadComboBox.Items.Add(LocalidadTextBox.Text);
            }
            if (ProvinciaComboBox.SelectedIndex == 1)
            {
                locLugo.Add(LocalidadTextBox.Text);
                LocalidadComboBox.Items.Add(LocalidadTextBox.Text);
            }
            if (ProvinciaComboBox.SelectedIndex == 2)
            {
                locOren.Add(LocalidadTextBox.Text);
                LocalidadComboBox.Items.Add(LocalidadTextBox.Text);
            }
            if (ProvinciaComboBox.SelectedIndex == 3)
            {
                locPont.Add(LocalidadTextBox.Text);
                LocalidadComboBox.Items.Add(LocalidadTextBox.Text);
            }
            MessageBox.Show("Se añadió correctamente");
        }
        public void borrarLoc()
        {
            if (ProvinciaComboBox.SelectedIndex == 0)
            {
                locCor.Remove(LocalidadComboBox.SelectedItem);
                LocalidadComboBox.Items.Remove(LocalidadComboBox.SelectedItem);
            }
            if (ProvinciaComboBox.SelectedIndex == 1)
            {
                locLugo.Remove(LocalidadComboBox.SelectedItem);
                LocalidadComboBox.Items.Remove(LocalidadComboBox.SelectedItem);
            }
            if (ProvinciaComboBox.SelectedIndex == 2)
            {
                locOren.Remove(LocalidadComboBox.SelectedItem);
                LocalidadComboBox.Items.Remove(LocalidadComboBox.SelectedItem);
            }
            if (ProvinciaComboBox.SelectedIndex == 3)
            {
                locPont.Remove(LocalidadComboBox.SelectedItem);
                LocalidadComboBox.Items.Remove(LocalidadComboBox.SelectedItem);
            }
            MessageBox.Show("Se borró correctamente");
        }
        public void localidadesIniciales()
        {
            locCor.Add("Ferrol");
            locCor.Add("Betanzos");
            locLugo.Add("Monforte de Lemos");
            locLugo.Add("Barreiros");
            locOren.Add("O Barco");
            locOren.Add("Viana do Bolo");
            locPont.Add("Villagarcía da Arousa");
            locPont.Add("Mondaríz");
        }

        private void ProvinciaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboLoc();
        }
        public void comboLoc()
        {
            if (ProvinciaComboBox.SelectedIndex == 0)
            {
                LocalidadComboBox.Items.Clear();
                for (int i = 0; i < locCor.Count; i++)
                {
                    LocalidadComboBox.Items.Add(locCor[i]);
                }
            }
            if (ProvinciaComboBox.SelectedIndex == 1)
            {
                LocalidadComboBox.Items.Clear();
                for (int i = 0; i < locLugo.Count; i++)
                {
                    LocalidadComboBox.Items.Add(locLugo[i]);
                }
            }
            if (ProvinciaComboBox.SelectedIndex == 2)
            {
                LocalidadComboBox.Items.Clear();
                for (int i = 0; i < locOren.Count; i++)
                {
                    LocalidadComboBox.Items.Add(locOren[i]);
                }
            }
            if (ProvinciaComboBox.SelectedIndex == 3)
            {
                LocalidadComboBox.Items.Clear();
                for (int i = 0; i < locPont.Count; i++)
                {
                    LocalidadComboBox.Items.Add(locPont[i]);
                }
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
