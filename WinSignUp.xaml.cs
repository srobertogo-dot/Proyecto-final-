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

using System.Windows.Shapes;

using System.Text.RegularExpressions;

using System.IO;
using System.Security.Principal;

namespace proyecto_final

{

    /// <summary>

    /// Lógica de interacción para WinSignUp.xaml

    /// </summary>

    public partial class WinSignUp : Window

    {

        private readonly string rutaYnombreArch = "C:\\Logins\\Logins.txt";

        public WinSignUp()

        {

            InitializeComponent();

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)

        {

            txtNombre.Text = "";

            txtApPat.Text = "";

            txtApMat.Text = "";

            txtCi.Text = "";

            txtCel.Text = "";

            txtDireccion.Text = "";

            txBResultado.Text = "";

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)

        {

            if (txtNombre.Text == "" || txtApPat.Text == "" || txtApMat.Text == "" || txtCi.Text == "" || txtCel.Text == "" || txtDireccion.Text == "")

            {

                lblMensajes.Content = "Deb completar TODOS los datos";

                lblMensajes.Foreground = Brushes.Red;


            }


            else

            {

                try

                {

                    lblMensajes.Content = "Bienvenido al sistema NN" + txtNombre.Text + "..";

                    txBResultado.Text = txtNombre.Text + "," + txtApPat.Text + "," +

                        txtApMat.Text + "," + txtCi.Text + ","

                        + txtCel.Text + "," + txtDireccion.Text + ","

                       ;

                    string datos = txBResultado.Text;

                    File.AppendAllText(rutaYnombreArch, datos);
                    WinPrincipal winP = new WinPrincipal();

                    winP.Show();

                    this.Close();

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al guardar el archivo " + ex.Message);

                }


            }

        }



        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {

            Regex regexNombre = new Regex("^[a-zA-Z ]$");

            e.Handled = !regexNombre.IsMatch(e.Text);

        }



        private void txtCel_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {

            Regex regexCelular = new Regex("^[0-9-]+$");

            e.Handled = !char.IsDigit(e.Text, 0);

        }

        private void txtApPat_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {

            Regex regexApPat = new Regex("^[a-zA-Z ]$");

            e.Handled = !regexApPat.IsMatch(e.Text);

        }

        private void txtApMat_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {

            Regex regexApMat = new Regex("^[a-zA-Z ]$");

            e.Handled = !regexApMat.IsMatch(e.Text);

        }


        private void txtCi_TextChanged(object sender, TextChangedEventArgs e)

        {

            Regex regexCi = new Regex("^[0-9-]+$");

            e.Handled = !char.IsDigit(e.ToString(), 0);

        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)

        {

            Regex regexDireccion = new Regex("^[a-zA-Z0-9- ]$");

            e.Handled = regexDireccion.IsMatch(e.ToString());

        }

    }

}


