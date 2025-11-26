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
using System.Text.RegularExpressions;
using System.IO;


namespace proyecto_final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaYnombreArch = "C:\\Logins\\Logins.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtTelefono.Text = "";
            txtCi.Password = "";

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCi.Password.Length >= 6)
            {
                MessageBox.Show("Contraseña válida.", "Éxito", MessageBoxButton.OK);
            }

            else
            {
                MessageBox.Show("El CI ingresado tiene que tener 6 caracteres o mas.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (txtTelefono.Text == "" || txtCi.Password == "")
            {
                lblMensajes.Content = "Deb completar TODOS los datos";
                lblMensajes.Foreground = Brushes.Red;
            }


            else
            {
                try
                {
                    string telefono = txtTelefono.Text.ToString();
                    string contra = txtCi.Password;
                    //MessageBox.Show("Correo: " + correo + "\nContraseña : " + contra);
                    if (!File.Exists(rutaYnombreArch))
                    {
                        lblMensajes.Foreground = Brushes.Red;
                        lblMensajes.Content = "La ruta o nombre del archivo no existe!!";
                        return;
                    }

                    //Ler el archivo
                    var lineas = File.ReadAllLines(rutaYnombreArch);
                    bool encontrado = false;
                    foreach (var unaLinea in lineas)
                    {
                        var partes = unaLinea.Split(',');
                        if (telefono.Equals(partes[3]) && contra.Equals(partes[6]))
                        {
                            encontrado = true;
                        }
                    }

                    if (encontrado)
                    {
                        lblMensajes.Content = "Bienvenido al sistema NN" + "..";
                        lblMensajes.Foreground = Brushes.Black;
                        WinPrincipal winP = new WinPrincipal();
                        winP.Show();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado");
                        txtTelefono.Clear();
                        txtCi.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo" + ex.Message);
                }
            }
        }



        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexNombre = new Regex("^[a-zA-Z ]$");
            e.Handled = !regexNombre.IsMatch(e.Text);
        }

        private void txtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[a-zA-Z0-9@.]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
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

        private void txtAñoNac_PreviewTextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexCelular = new Regex("^[0-9-]+$");
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            WinSignUp winSignUp = new WinSignUp();
            winSignUp.Show();

            this.Close();
        }

        private void txtTelefono_PreviewTextChanged(object sender, TextCompositionEventArgs e)
        {
            Regex regexTelefono = new Regex("^[0-9-]+$");
            e.Handled = !char.IsDigit(e.Text, 0);

        }
        private void txtCi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexCi = new Regex("^[0-9-]+$");
            e.Handled = !e.Text.All(char.IsDigit);
        }

    }
}