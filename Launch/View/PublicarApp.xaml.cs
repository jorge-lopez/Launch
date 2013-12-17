using BuisenessLogic;
using Commons;
using Launch.ViewModel;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Launch.View
{
    /// <summary>
    /// Interaction logic for PublicarApp.xaml
    /// </summary>
    public partial class PublicarApp : MetroWindow
    {
        private int _errors = 0;
        IUsuario _dev;
        byte[] _imagen;
        public PublicarApp(IUsuario Desarrollador)
        {
            InitializeComponent();
            _dev = Desarrollador;
            this.DataContext = new ModeloPublicarApp();
        }
        private void btn_publicar_Click(object sender, RoutedEventArgs e)
        {
            if (Aplicaciones.Publicar(_dev.Correo, txtBox_nombre.Text, txtBox_categoria.Text, txtBox_descripcion.Text, _imagen))
                MessageBox.Show("Aplicacion publicada con exito");
            else
                MessageBox.Show("Ya existe una aplicacion con ese nombre");
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;

            if (_errors == 0)
                btn_publicar.IsEnabled = true;
            else
                btn_publicar.IsEnabled = false;
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_imagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            ofd.Title = "Por favor seleccione una imagen.";
            if(ofd.ShowDialog() == true)
                imageToByteArray(ofd);
        }
        public void imageToByteArray(OpenFileDialog ofd)
        {

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(new Uri(ofd.FileName)));
            encoder.QualityLevel = 100;
            byte[] bit = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create(new Uri(ofd.FileName)));
                encoder.Save(stream);
                bit = stream.ToArray();
                stream.Close();
            }
            

            var image = new BitmapImage();
            using (var mem = new MemoryStream(bit))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.DecodePixelWidth = 100;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();


            JpegBitmapEncoder encoder2 = new JpegBitmapEncoder();
            encoder2.Frames.Add(BitmapFrame.Create(image));
            encoder2.QualityLevel = 100;
            using (MemoryStream stream = new MemoryStream())
            {
                encoder2.Frames.Add(BitmapFrame.Create(image));
                encoder2.Save(stream);
                _imagen = stream.ToArray();
                stream.Close();
            }

            byteArrayToImage(_imagen);

        }

        public void byteArrayToImage(byte[] byteArrayIn)
        {

            var image = new BitmapImage();
            using (var mem = new MemoryStream(byteArrayIn))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;                
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();

            img.Source = image;
            return;

        }





    }
}
