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

namespace proyecto_final

{

    /// <summary>

    /// Lógica de interacción para RegistrarEmpresa.xaml

    /// </summary>

    public partial class RegistroUsuario : Window

    {

        private readonly string rutaYnombreArch = "C:\\Logins\\Logins.txt";

        public RegistroUsuario()

        {

            InitializeComponent();

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)

        {

            txtNIT.Clear();

            txtCIRepresentante.Clear();

            txtNombreRepresentante.Clear();

            txtPoder.Clear();

            txtFundempresa.Clear();

            txtDomicilioLaboral.Clear();

            txtDocDomicilio.Clear();

            txtContratos.Clear();

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)

        {

            // Comprobación simple de campos vacíos

            if (txtNIT.Text == "" || txtCIRepresentante.Text == "" || txtNombreRepresentante.Text == "" || txtPoder.Text == "" || txtFundempresa.Text == "" || txtDomicilioLaboral.Text == "" || txtDocDomicilio.Text == "" || txtContratos.Text == "")

            {

                MessageBox.Show("Oye, falta llenar algún campo. Por favor completa todo antes de seguir.", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;

            }

            // Armo el mensaje con los datos

            string info = "¡Listo! Estos son los datos que registraste:\n\n" +

                          "NIT: " + txtNIT.Text + "\n" +

                          "CI del representante: " + txtCIRepresentante.Text + "\n" +

                          "Nombre del representante: " + txtNombreRepresentante.Text + "\n" +

                          "Poder del representante: " + txtPoder.Text + "\n" +

                          "Matrícula FUNDEMPRESA: " + txtFundempresa.Text + "\n" +

                          "Domicilio laboral: " + txtDomicilioLaboral.Text + "\n" +

                          "Doc. de domicilio: " + txtDocDomicilio.Text + "\n" +

                          "Contratos de trabajo: " + txtContratos.Text;

            // Mostrar en TextBlock si existe

            var resultado = this.FindName("txBResultado") as TextBlock;

            if (resultado != null)

            {

                resultado.Text = info;

            }

            else

            {

                MessageBox.Show(info, "Datos guardados", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            // Guardar datos en archivo

            try

            {

                string rutaYnombreArch = @"C:\TuRuta\DatosEmpresas.txt";  // Cambia esta ruta por la tuya

                string datosParaGuardar = info + Environment.NewLine + Environment.NewLine;

                System.IO.File.AppendAllText(rutaYnombreArch, datosParaGuardar);

            }

            catch (Exception ex)

            {

                MessageBox.Show("Error al guardar el archivo: " + ex.Message);

            }

        }

    }

}
