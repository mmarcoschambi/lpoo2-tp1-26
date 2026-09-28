using System;
using System.Windows;

namespace Vistas
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Password;

            string rol = null;

            if (usuario == "admin" && password == "admin123")
            {
                rol = "Admin";
            }
            else if (usuario == "vendedor" && password == "vend123")
            {
                rol = "Vendedor";
            }

            if (rol == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Clear();
                txtUsuario.Focus();
                return;
            }

            MainWindow menu = new MainWindow(usuario, rol);
            Application.Current.MainWindow = menu;
            menu.Show();
            Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
