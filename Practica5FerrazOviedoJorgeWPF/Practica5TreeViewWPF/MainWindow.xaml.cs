using System;
using System.Collections.Generic;
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

namespace Practica5TreeViewWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<trabajador> trabajadoresList = new List<trabajador>();
        string[] tiposCargo = new string[] { "Jefe", "Oficial de Primera", "Oficial de segunda" };
        ImageList misImagenes = new ImageList();
        public MainWindow()
        {
            añadirImagenes();
            InitializeComponent();

            PracticaTreeView.ImageList = misImagenes;

        }
        private void añadirImagenes()
        {

            System.Drawing.Image img0;
            img0 = System.Drawing.Image.FromFile("..\\CarpetaAbierta.png");
            misImagenes.Images.Add(img0);
            misImagenes.ImageSize = new System.Drawing.Size(32, 32);
            System.Drawing.Image img1;
            img1 = System.Drawing.Image.FromFile("..\\CarpetaAbierta.png");
            misImagenes.Images.Add(img1);
            System.Drawing.Image img2;
            img2 = System.Drawing.Image.FromFile("..\\CarpetaAbierta.png");
            misImagenes.Images.Add(img2);
        }
        public class trabajador
        {
            public string localidad;
            public string nombre;
            public string apellidos;
            public string cargo;
        }
        private void AltaLocalidadButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocalidadTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("No has escrito una localidad");
            }
            else if (detectarProvincias(PracticaTreeView.Nodes[0].Nodes, LocalidadTextBox.Text))
            {
                System.Windows.MessageBox.Show("Esta localidad ya se añadió");
                LocalidadTextBox.Clear();
            }
            else
            {
                PracticaTreeView.Nodes[0].Nodes.Add("Localidad: " + LocalidadTextBox.Text);
                LocalidadesComboBox.Items.Add(LocalidadTextBox.Text);
                LocalidadTextBox.Clear();
            }
        }
        private Boolean detectarProvincias(TreeNodeCollection nodos, string aux)
        {
            Boolean flag = false;
            foreach (TreeNode x in nodos)
            {
                string loc = x.Text.Substring(11);
                if (aux.Equals(loc)) flag = true;
            }
            return flag;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            PracticaTreeView.Nodes.Add("Cuadrillas");
        }

        private void AltaEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarCamposTrabajador())
            {
                if (!generarOficialSegunda())
                {
                    if (!generarOficialPrimera()) comprobarJefe();
                }

            }
            NombreTextBox.Clear();
            ApellidoTextBox.Clear();
        }
        private Boolean comprobarCamposTrabajador()
        {
            if (NombreTextBox.Text == "" || ApellidoTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("Nombre o Apellido sin rellenar");
                return false;
            }
            return true;
        }
        private void añadirTrabajador(string loc, string nom, string ap, int carg)
        {
            trabajadoresList.Add(new trabajador()
            {
                localidad = loc,
                nombre = nom,
                apellidos = ap,
                cargo = tiposCargo[carg]
            });
        }
        private void comprobarJefe()
        {

            if (PracticaTreeView.SelectedNode.Nodes.Count == 0 && !PracticaTreeView.SelectedNode.Text.Substring(0, 2).Equals("2º") && PracticaTreeView.SelectedNode.Text != "Cuadrillas")
            {
                string trab = NombreTextBox.Text + " " + ApellidoTextBox.Text;
                PracticaTreeView.SelectedNode.Nodes.Add("Jefe: " + trab);
                PracticaTreeView.SelectedNode.Text.Substring(11);
                añadirTrabajador(PracticaTreeView.SelectedNode.Text.Substring(11), NombreTextBox.Text, ApellidoTextBox.Text, 0);
            }
            else
            {
                System.Windows.MessageBox.Show("Esta localidad ya posee un jefe, ya no puedes añadir más rangos o no seleccionaste un valor");
            }
        }
        private Boolean generarOficialPrimera()
        {
            if (PracticaTreeView.SelectedNode.Text.Substring(0, 4).Equals("Jefe"))
            {
                string trabajador = NombreTextBox.Text + " " + ApellidoTextBox.Text;
                PracticaTreeView.SelectedNode.Nodes.Add("1º Oficial: " + trabajador);
                añadirTrabajador(PracticaTreeView.SelectedNode.Parent.Text.Substring(11), NombreTextBox.Text, ApellidoTextBox.Text, 1);
                return true;
            }
            else return false;
        }
        private Boolean generarOficialSegunda()
        {
            if (PracticaTreeView.SelectedNode.Text.Substring(0, 2).Equals("1º"))
            {
                string trabajador = NombreTextBox.Text + " " + ApellidoTextBox.Text;
                PracticaTreeView.SelectedNode.Nodes.Add("2º Oficial: " + trabajador);
                añadirTrabajador(PracticaTreeView.SelectedNode.Parent.Parent.Text.Substring(11), NombreTextBox.Text, ApellidoTextBox.Text, 2);
                return true;
            }
            else return false;
        }

        private void TrabajadoresButton_Click(object sender, RoutedEventArgs e)
        {
            pintarTrabajadores();
        }
        private void pintarTrabajadores()
        {
            MiListView.Items.Clear();
            var gridView = new GridView();
            this.MiListView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Nombre",
                DisplayMemberBinding = new System.Windows.Data.Binding("nom")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Apellidos",
                DisplayMemberBinding = new System.Windows.Data.Binding("app")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Cargo",
                DisplayMemberBinding = new System.Windows.Data.Binding("carg")
            });
            gridView.Columns[0].Width = 150;
            gridView.Columns[1].Width = 150;
            gridView.Columns[2].Width = 150;
            for (int i = 0; i < trabajadoresList.Count; i++)
            {
                try
                {
                    if (LocalidadesComboBox.SelectedItem.ToString().Equals(trabajadoresList[i].localidad))
                    {
                        this.MiListView.Items.Add(new MyItem { nom = trabajadoresList[i].nombre, app = trabajadoresList[i].apellidos, carg = trabajadoresList[i].cargo });
                    }
                }
                catch (System.NullReferenceException)
                {
                    System.Windows.MessageBox.Show("Elige alguna provincia en el combo");
                }
            }
        }
        public class MyItem
        {
            public string nom { get; set; }

            public string app { get; set; }
            public string carg { get; set; }
        }
        private void soloLetras(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                System.Windows.MessageBox.Show("Solo son válidas letras");
                e.Handled = true;
                return;
            }
        }

        private void LocalidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void generarImagenes2Click()
        {
            if (PracticaTreeView.SelectedNode.IsSelected && PracticaTreeView.SelectedNode.Nodes.Count != 0 && PracticaTreeView.SelectedNode.ImageIndex == 0)
            {
                PracticaTreeView.SelectedNode.ImageIndex = 2;
                PracticaTreeView.SelectedNode.SelectedImageIndex = 2;
            }
            else
            {
                PracticaTreeView.SelectedNode.ImageIndex = 0;
                PracticaTreeView.SelectedNode.SelectedImageIndex = 0;
            }
            if (PracticaTreeView.SelectedNode.Text.Substring(0, 2).Equals("2º"))
            {
                PracticaTreeView.SelectedNode.SelectedImageIndex = 1;
                PracticaTreeView.SelectedNode.ImageIndex = 1;
            }
        }
        private void generarImagenes()
        {
            
            if (PracticaTreeView.SelectedNode.IsExpanded)
            {
                PracticaTreeView.SelectedNode.ImageIndex = 2;
                PracticaTreeView.SelectedNode.SelectedImageIndex = 2;
            }
            else if (PracticaTreeView.SelectedNode.Text.Substring(0, 2).Equals("2º") && PracticaTreeView.SelectedNode.IsSelected)
            {
                PracticaTreeView.SelectedNode.ImageIndex = 1;
                PracticaTreeView.SelectedNode.SelectedImageIndex = 1;
            }
            else
            {
                PracticaTreeView.SelectedNode.ImageIndex = 0;
                PracticaTreeView.SelectedNode.SelectedImageIndex = 0;
            }
        }

        private void PracticaTreeView_DoubleClick(object sender, EventArgs e)
        {
         //   generarImagenes2Click();
        }

        private void PracticaTreeView_Click(object sender, EventArgs e)
        {
            //generarImagenes();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
