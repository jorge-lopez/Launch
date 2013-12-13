using MahApps.Metro.Controls;
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
using BuisenessLogic;
using System.ComponentModel;

namespace Launch
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Register
    {
        ModeloRegistro Mreg;
        int _errors = 0;
        public Register()
        {
            InitializeComponent();
            rdoBtn_usuario.IsChecked = true;
            Mreg = new ModeloRegistro();
            DataContext = Mreg;
        }

        private void rdoBtn_usuario_Checked(object sender, RoutedEventArgs e)
        {
            rdoBtn_usuario.Background = new SolidColorBrush(Color.FromArgb(100, 227, 145, 44));
            rdoBtn_desarrollador.Background = null;
        }

        private void rdoBtn_desarrollador_Checked(object sender, RoutedEventArgs e)
        {
            rdoBtn_desarrollador.Background = new SolidColorBrush(Color.FromArgb(100, 227, 145, 44));
            rdoBtn_usuario.Background = null;
        }

        private void pwdBox_verificaContrasegna_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwdBox_contrasegna.Password == pwdBox_verificaContrasegna.Password)
                lbl_verificaContrasegna_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_verificaContrasegna_error.Visibility = System.Windows.Visibility.Visible;
        }


        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {

            if ((bool)rdoBtn_usuario.IsChecked)
            {
                if (Cliente.Registrar(txtBox_nombre.Text, txtBox_apellido.Text, txtBox_correo.Text, pwdBox_contrasegna.Password))
                {
                    MessageBox.Show("Cliente Añadido");
                    this.Close();
                }                    
                else
                    MessageBox.Show("Error al registrar usuario");
                
            }
            else
            {
                //Make a Developer and send it to the service
                MessageBox.Show("Desarrollador Añadido");
                this.Close();
            }
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;

            if (_errors == 0)
                btn_registrar.IsEnabled = true;
            else
                btn_registrar.IsEnabled = false;
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public static class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password",
            typeof(string), typeof(PasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
            typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        private static readonly DependencyProperty IsUpdatingProperty =
           DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
           typeof(PasswordHelper));


        public static void SetAttach(DependencyObject dp, bool value)
        {
            dp.SetValue(AttachProperty, value);
        }

        public static bool GetAttach(DependencyObject dp)
        {
            return (bool)dp.GetValue(AttachProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        private static bool GetIsUpdating(DependencyObject dp)
        {
            return (bool)dp.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject dp, bool value)
        {
            dp.SetValue(IsUpdatingProperty, value);
        }

        private static void OnPasswordPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            passwordBox.PasswordChanged -= PasswordChanged;

            if (!(bool)GetIsUpdating(passwordBox))
            {
                passwordBox.Password = (string)e.NewValue;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void Attach(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
                return;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);
        }
    }





}
