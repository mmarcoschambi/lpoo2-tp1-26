using System.Windows;
using ClasesBase;

namespace Vistas
{
    public partial class VendedorWindow : Window
    {
        private Vendedor oVendedor;

        public VendedorWindow()
        {
            InitializeComponent();
            ModoConsulta();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos(); HabilitarCampos(true); HabilitarBotonesEdicion(true); txtLegajo.Focus();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtLegajo.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos.", "Validación",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea guardar los datos?", "Confirmar",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                oVendedor = new Vendedor();
                oVendedor.Legajo = txtLegajo.Text.Trim();
                oVendedor.Apellido = txtApellido.Text.Trim();
                oVendedor.Nombre = txtNombre.Text.Trim();

                MessageBox.Show("Legajo: " + oVendedor.Legajo +
                    "\nApellido: " + oVendedor.Apellido +
                    "\nNombre: " + oVendedor.Nombre,
                    "Datos guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                ModoConsulta();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos(); ModoConsulta();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Close();
        }

        private void LimpiarCampos()
        {
            txtLegajo.Clear(); txtApellido.Clear(); txtNombre.Clear();
        }

        private void HabilitarCampos(bool valor)
        {
            txtLegajo.IsEnabled = valor; txtApellido.IsEnabled = valor; txtNombre.IsEnabled = valor;
        }

        private void ModoConsulta()
        {
            HabilitarCampos(false); HabilitarBotonesEdicion(false);
        }

        private void HabilitarBotonesEdicion(bool editando)
        {
            btnGuardar.IsEnabled = editando; btnCancelar.IsEnabled = editando;
            btnNuevo.IsEnabled = !editando; btnModificar.IsEnabled = !editando; btnEliminar.IsEnabled = !editando;
            btnPrimero.IsEnabled = !editando; btnAnterior.IsEnabled = !editando;
            btnSiguiente.IsEnabled = !editando; btnUltimo.IsEnabled = !editando;
        }
    }
}
