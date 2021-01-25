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

namespace Practica4FerrazOviedoJorgeWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listProvincias = new List<string>();
        List<string> listProfesiones = new List<string>();
        List<trabajador> listTrabajadores = new List<trabajador>();
        public MainWindow()
        {
            InitializeComponent();
        }
        class trabajador
        {
            public string DNI;
            public string Nombre;
            public string Apellido1;
            public string Apellido2;
            public string provincia;
            public string trabajo;
        }
        private void EliminarProvinciaButton_Click(object sender, RoutedEventArgs e)
        {
            eliminarProvincia();
        }
        public void eliminarProvincia()
        {
            try
            {
                listProvincias.RemoveAt(ProvinciaComboBox.SelectedIndex);
                ProvinciaComboBox.Items.RemoveAt(ProvinciaComboBox.SelectedIndex);
                ProvinciaComboBox.Text = "";
                MessageBox.Show("Provincia removida correctamente");
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("No seleccionaste ninguna provincia");
            }
        }

        private void TraballadoresListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetallesListBox.Items.Clear();
            foreach (MyItem lista in TraballadoresListView.SelectedItems)
            {
                verDatos();
            }
        }
        public void verDatos()
        {
             DetallesListBox.Items.Add("DNI: " + listTrabajadores[TraballadoresListView.SelectedIndex].DNI);
             DetallesListBox.Items.Add("NOME: " + listTrabajadores[TraballadoresListView.SelectedIndex].Nombre);
             DetallesListBox.Items.Add("APELIDO1: " + listTrabajadores[TraballadoresListView.SelectedIndex].Apellido1);
             DetallesListBox.Items.Add("APELIDO2: " + listTrabajadores[TraballadoresListView.SelectedIndex].Apellido2);
             DetallesListBox.Items.Add("PROVINCIA: " + listTrabajadores[TraballadoresListView.SelectedIndex].provincia);
             DetallesListBox.Items.Add("PROFESION: " + listTrabajadores[TraballadoresListView.SelectedIndex].trabajo);
                
            
        }

        private void CerrarAplicacionButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EngadirProvinciaButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (comprobarProvRepetida())
            {
                añadirProvincia();
                AñadirProvinciaTextBox.Clear();
            }
        }
        public void añadirProvincia()
        {
            if (AñadirProvinciaTextBox.Text != "")
            {
                listProvincias.Add(AñadirProvinciaTextBox.Text);
                ProvinciaComboBox.Items.Add(AñadirProvinciaTextBox.Text);
                MessageBox.Show("Provincia Añadida");
            }
            else
            {
                MessageBox.Show("No has escrito ninguna provincia");
            }
        }
        public Boolean comprobarProvRepetida()
        {
            for (int i = 0; i < listProvincias.Count; i++)
            {
                if (AñadirProvinciaTextBox.Text.Equals(listProvincias[i]))
                {
                    MessageBox.Show("Esta provincia ya está añadida");
                    AñadirProvinciaTextBox.Clear();
                    AñadirProvinciaTextBox.Focus();
                    return false;
                }
            }
            return true;
        }
        public Boolean comprobarTrabajoRepetido()
        {
            for (int i = 0; i < listProfesiones.Count; i++)
            {
                if (ProfesionTextBox.Text.Equals(listProfesiones[i]))
                {
                    MessageBox.Show("Esta profesion ya está añadida");
                    ProfesionTextBox.Clear();
                    ProfesionTextBox.Focus();
                    return false;
                }
            }
            return true;
        }

        private void EngadirProfesionButton_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarTrabajoRepetido())
            {
                añadirProfesion();
            }
        }
        public void añadirProfesion()
        {
            if (ProfesionTextBox.Text != "")
            {
                listProfesiones.Add(ProfesionTextBox.Text);
                ProfesionListBox.Items.Add(ProfesionTextBox.Text);
                ProfesionTextBox.Clear();
                MessageBox.Show("Profesión añadida");
            }
            else
            {
                MessageBox.Show("No has escrito ninguna profesion");
            }
        }
        public void eliminarProfesion()
        {
            try
            {
                listProfesiones.RemoveAt(ProfesionListBox.SelectedIndex);
                ProfesionListBox.Items.RemoveAt(ProfesionListBox.SelectedIndex);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("No seleccionaste ninguna profesion");
            }
        }

        private void EliminarProfesionButton_Click(object sender, RoutedEventArgs e)
        {
            eliminarProfesion();
        }
        public Boolean validarVacios()
        {
            if (Apellido1TextBox.Text == "")
            {
                MessageBox.Show("Apellido 1 no se puede dejar vacío");
                Apellido1TextBox.Focus();
                return false;
            }
            else if (NameTextBox.Text == "")
            {
                MessageBox.Show("Nombre no se puede dejar vacío");
                NameTextBox.Focus();
                return false;
            }
            else if(Apellido2TextBox.Text == "")
            {
                MessageBox.Show("Apellido 2 no se puede dejar vacío");
                Apellido2TextBox.Focus();
                return false;
            }
            else if (DNITextBox.Text == "")
            {
                MessageBox.Show("DNI no se puede dejar vacío");
                DNITextBox.Focus();
                return false;
            }
            return true;
        }

        private void EngadirTraballadorButton_Click(object sender, RoutedEventArgs e)
        {
            if (validarVacios())
            {
                validarTrabajador();
            }
        }
        public void validarTrabajador()
        {
            Boolean aux = true;
            if (ProvinciaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una provincia");
                aux = false;
            }
            else if (ProfesionListBox.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una profesion");
                aux = false;
            }
            if (aux)
            {
                //letrasmayusculas
                //Char.ToUpper(NomeTextBox.Text.ToCharArray()[0]);
                mayusculas();
                listTrabajadores.Add(new trabajador()
                {
                    DNI = DNITextBox.Text,
                    Nombre = NameTextBox.Text,
                    Apellido1 = Apellido1TextBox.Text,
                    Apellido2 = Apellido2TextBox.Text,
                    provincia = ProvinciaComboBox.SelectedItem.ToString(),
                    trabajo = ProfesionListBox.SelectedItem.ToString(),
                });
                string nomAp = listTrabajadores[listTrabajadores.Count - 1].Nombre + " " + listTrabajadores[listTrabajadores.Count - 1].Apellido1 + " " + listTrabajadores[listTrabajadores.Count - 1].Apellido2;
                
                /*TraballadoresListView.Items.Add(new ListViewItem(new string[]{
                    nomAp,
                    listTrabajadores[listTrabajadores.Count - 1].provincia,
                    listTrabajadores[listTrabajadores.Count - 1].trabajo
                }));
                */
                var gridView = new GridView();
                this.TraballadoresListView.View = gridView;
                gridView.Columns.Add(new GridViewColumn { 
                    Header="Nombre e Apellidos", DisplayMemberBinding = new Binding("nom")
                    
                });
                
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Provincia",
                    DisplayMemberBinding = new Binding("prov")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Profesion",
                    DisplayMemberBinding = new Binding("prof")
                });
                gridView.Columns[0].Width = 125;
                gridView.Columns[1].Width = 125;
                gridView.Columns[2].Width = 125;
                this.TraballadoresListView.Items.Add(new MyItem { nom = nomAp, prov = listTrabajadores[listTrabajadores.Count - 1].provincia, prof = listTrabajadores[listTrabajadores.Count - 1].trabajo });
                MessageBox.Show("Trabajador añadido con éxito");
                limpiarFormulario();
            }
            else MessageBox.Show("No se añadió porque no cumplia los requisitos");
        }
        public class MyItem
        {
            public string nom { get; set; }

            public string prov { get; set; }
            public string prof { get; set; }
        }
        public void mayusculas()
        {
            char x = Char.ToUpper(NameTextBox.Text.ToCharArray()[0]);
            char y = Char.ToUpper(Apellido1TextBox.Text.ToCharArray()[0]);
            char z = Char.ToUpper(Apellido2TextBox.Text.ToCharArray()[0]);
            NameTextBox.Text = x + NameTextBox.Text.Substring(1);
            Apellido1TextBox.Text = y + Apellido1TextBox.Text.Substring(1);
            Apellido2TextBox.Text = z + Apellido2TextBox.Text.Substring(2);
        }
        public void limpiarFormulario()
        {
            DNITextBox.Clear();
            NameTextBox.Clear();
            Apellido1TextBox.Clear();
            Apellido2TextBox.Clear();
            ProvinciaComboBox.Text = "";
        }

        private void EliminarTraballadorButton_Click(object sender, RoutedEventArgs e)
        {
            eliminarTrabajador();
            TraballadoresListView.Items.Remove(TraballadoresListView.SelectedItem);
        }
        public void eliminarTrabajador()
        {
           listTrabajadores.RemoveAt(TraballadoresListView.SelectedIndex);
        }
    }
}
