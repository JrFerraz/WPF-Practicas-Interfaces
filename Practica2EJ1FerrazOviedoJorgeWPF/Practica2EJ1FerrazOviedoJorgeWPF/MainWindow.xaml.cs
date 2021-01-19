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

namespace Practica2EJ1FerrazOviedoJorgeWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    struct listaAlfombras
    {
        public string modelo;
        public string color;
        public int altura;
        public int anchura;
    }
    public partial class MainWindow : Window
    {
        List<listaAlfombras> list = new List<listaAlfombras>();
        int contador = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void infoAlfombraButton_Click(object sender, RoutedEventArgs e)
        {
            if (alfombrasComboBox.Text == "")
            {
                MessageBox.Show("Selecciona una alfombra");
            }
            else
            {
                if (infoAlfombraButton.IsEnabled && list.Any())
                {
                    MessageBox.Show("MODELO: " + list[alfombrasComboBox.SelectedIndex].modelo + "\nCOR: " + list[alfombrasComboBox.SelectedIndex].color + "\nANCHO: " + list[alfombrasComboBox.SelectedIndex].anchura + " cm \nALTO: " + list[alfombrasComboBox.SelectedIndex].altura + " cm");
                }
                else
                {
                    MessageBox.Show("La lista esta vacía");
                }
            }
            
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (eliminarButton.IsEnabled)
            {
                alfombrasComboBox.Items.RemoveAt(alfombrasComboBox.SelectedIndex);
                list.RemoveAt(alfombrasComboBox.SelectedIndex + 1);
                contador--;
                MessageBox.Show("Se elimina la alfombra");
            }
        }

        private void eliminarTodasButton_Click(object sender, RoutedEventArgs e)
        {
            if (eliminarTodasButton.IsEnabled)
            {
                alfombrasComboBox.Items.Clear();
                list.Clear();
                contador = 0;
                MessageBox.Show("Se eliminan todas");
            }

        }

        private void añadirButton_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarAlfombra()) añadirAlfombra();
        }
        public Boolean comprobarAlfombra()
        {
            int x = 0;
            if (modeloTextBox.Text == "")
            {
                MessageBox.Show("Modelo Desconocido");
                return false;
            }
            else if (colorTextBox.Text == "")
            {
                MessageBox.Show("Color No válido");
                return false;
            }
            else if (!Int32.TryParse(altoTextBox.Text, out x))
            {
                MessageBox.Show("Altura no válida");
                return false;
            }
            else if (!Int32.TryParse(anchoTextBox.Text, out x))
            {
                MessageBox.Show("Anchura no válida");
                return false;
            }
            else
            {
                MessageBox.Show("Datos correctos, se añadirá la alfombra");
                return true;
            }
        }
        public void añadirAlfombra()
        {
            list.Add(new listaAlfombras()
            {
                modelo = modeloTextBox.Text,
                color = colorTextBox.Text,
                altura = Int32.Parse(altoTextBox.Text),
                anchura = Int32.Parse(anchoTextBox.Text),
            });
            alfombrasComboBox.Items.Add("MODELO " + list[contador].modelo + " - COR " + list[contador].color);
            contador++;
        }
    }
}
