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

namespace Practica6FerrazOviedoJorgeWPF
{
    public partial class MainWindow : Window
    {
        //BindingSource listVentanas = new BindingSource();
        List<ventana> misVentanas = new List<ventana>();
        List<int> indicesSeleccionados = new List<int>();
        int numVentanasA = 0;
        int numVentanasB = 0;
        int numVentanasC = 0;
        int numHijos = 0;
        public MainWindow()
        {
            InitializeComponent();
            //listVentanas.DataSource = misVentanas;
            //VentanasListBox.DataSource = listVentanas;
            //VentanasListBox.DisplayMember = "nombre";
        }
        public class ventana
        {
            public Window vent;
            public string nombre { get; set; }
        }

        private void refrescarListBox()
        {
            VentanasListBox.Items.Clear();
            for (int i = 0; i < misVentanas.Count; i++)
            {
                VentanasListBox.Items.Add(misVentanas[i].nombre);
            }
        }
        private void HijaAButton_Click(object sender, RoutedEventArgs e)
        {
            generarVentana(crearNombre(1));
        }
        public string crearNombre(int tipoVentana)
        {
            string nombreVentana;
            if (tipoVentana == 1)
            {
                numVentanasA++;
                return nombreVentana = "A-" + numVentanasA.ToString();
            }
            else if (tipoVentana == 2)
            {
                numVentanasB++;
                return nombreVentana = "B-" + numVentanasB.ToString();
            }
            else
            {
                numVentanasC++;
                return nombreVentana = "C-" + numVentanasC.ToString();
            }
        }
        private void generarVentana(string contadorVentanas)
        {
            NumHijosLabel.Content = "Número de hijos actuales: ";
            Window window = new Window();
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
            window.Owner = this;
            window.Title = contadorVentanas;
            Label windowLabel = new Label();
            stackPanel.Children.Add(windowLabel);
            window.Content = stackPanel;
            centrarLabels(window, windowLabel);
            misVentanas.Add(new ventana()
            {
                vent = window,
                nombre = "VENTANA " + contadorVentanas
            });
            refrescarListBox();
            //listVentanas.ResetBindings(false);
            windowLabel.Content = "VENTANA TIPO " + contadorVentanas.Substring(0, 1);
            numHijos++;
            NumHijosLabel.Content = NumHijosLabel.Content.ToString() + numHijos;
            window.Show();
        }
        public static void centrarLabels(Control padre, Control hijo)
        {
            double x = 0;
            double y = 0;
            x = (padre.Width / 2) - (hijo.Width / 2);
            y = (padre.Height / 2) - (hijo.Height / 2);
            //hijo.Margin = new Point(x, y);
        }

        private void HijaBButton_Click(object sender, RoutedEventArgs e)
        {
            generarVentana(crearNombre(2));
        }

        private void HijaCButton_Click(object sender, RoutedEventArgs e)
        {
            generarVentana(crearNombre(3));
        }

        private void MostrarMostrarButton_Click(object sender, RoutedEventArgs e)
        {
            mostrarVentanasRads();
        }
        public void mostrarVentanasRads()
        {
            string aux = "";
            if (TipoAMostrarRadioButton.IsChecked == true) aux = "A";
            if (TipoBMostrarRadioButton.IsChecked == true) aux = "B";
            if (TipoCMostrarRadioButton.IsChecked == true) aux = "C";
            if (TodasMostrarRadioButton.IsChecked == true) aux = "X";

            for (int i = 0; i < misVentanas.Count; i++)
            {
                if (aux == "X")
                {
                    misVentanas[i].vent.WindowState = WindowState.Normal;
                    misVentanas[i].nombre = "VENTANA " + misVentanas[i].vent.Title;
                }
                else if (misVentanas[i].vent.Title.Substring(0, 1).Equals(aux))
                {
                    misVentanas[i].vent.WindowState = WindowState.Normal;
                    misVentanas[i].nombre = "VENTANA " + misVentanas[i].vent.Title;
                }
            }
            refrescarListBox();
            //listVentanas.ResetBindings(false);
        }
        public void ocultarVentanasRads()
        {
            string aux = "";
            if (TipoAOcultarRadioButton.IsChecked == true) aux = "A";
            if (TipoBOcultarRadioButton.IsChecked == true) aux = "B";
            if (TipoCOcultarRadioButton.IsChecked == true) aux = "C";
            if (TodasRadioButton.IsChecked == true) aux = "X";

            for (int i = 0; i < misVentanas.Count; i++)
            {
                if (aux == "X")
                {
                    misVentanas[i].nombre = "VENTANA " + misVentanas[i].vent.Title;
                    misVentanas[i].vent.WindowState = WindowState.Minimized;
                    misVentanas[i].nombre = misVentanas[i].nombre + " (oculto)";
                }
                else if (misVentanas[i].vent.Title.Substring(0, 1).Equals(aux))
                {
                    misVentanas[i].nombre = "VENTANA " + misVentanas[i].vent.Title;
                    misVentanas[i].vent.WindowState = WindowState.Minimized;
                    misVentanas[i].nombre = misVentanas[i].nombre + " (oculto)";
                }
            }
            refrescarListBox();
            //listVentanas.ResetBindings(false);
        }

        private void OcultarOcultarButton_Click(object sender, RoutedEventArgs e)
        {
            ocultarVentanasRads();
        }

        private void MostrarButton_Click(object sender, RoutedEventArgs e)
        {
            agregarIndices();
            for (int i = 0; i < VentanasListBox.SelectedItems.Count; i++)
            {
                misVentanas[indicesSeleccionados[i]].vent.WindowState = WindowState.Normal;
                misVentanas[indicesSeleccionados[i]].nombre = "VENTANA " + misVentanas[indicesSeleccionados[i]].vent.Title;
           
            }
            refrescarListBox();
            //listVentanas.ResetBindings(false);
        }

        private void VentanasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void agregarIndices()
        {
            indicesSeleccionados.Clear();
            foreach (var item in VentanasListBox.SelectedItems)
            {
                indicesSeleccionados.Add(VentanasListBox.Items.IndexOf(item));
            }
            indicesSeleccionados.Sort();
        }

        private void OcultarButton_Click(object sender, RoutedEventArgs e)
        {
            agregarIndices();
            for (int i = 0; i < VentanasListBox.SelectedItems.Count; i++)
            {

                misVentanas[indicesSeleccionados[i]].nombre = "VENTANA " + misVentanas[indicesSeleccionados[i]].vent.Title;
                misVentanas[indicesSeleccionados[i]].vent.WindowState = WindowState.Minimized;
                misVentanas[indicesSeleccionados[i]].nombre = misVentanas[indicesSeleccionados[i]].nombre + " (oculto)";
            }
            refrescarListBox();
            //listVentanas.ResetBindings(false);
        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            agregarIndices();
            for (int i = VentanasListBox.SelectedItems.Count - 1; i >= 0; i--)
            {
                misVentanas[indicesSeleccionados[i]].vent.Close();
                misVentanas.RemoveAt(indicesSeleccionados[i]);
                numHijos--;
            }
            NumHijosLabel.Content = "Número de hijos actuales: ";
            NumHijosLabel.Content = NumHijosLabel.Content + " " + numHijos;
            refrescarListBox();
            //listVentanas.ResetBindings(false);
        }
    }
}
