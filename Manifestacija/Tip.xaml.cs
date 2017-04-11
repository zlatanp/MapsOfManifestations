using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for Tip.xaml
    /// </summary>
    public partial class Tip : Window
    {
        ClassTip tip = new ClassTip();

        private MainWindow mw;
        private bool izmena;
        private int? selektovani;
        private String ID;

        public Tip(MainWindow m, bool menjam, int? sel, String identifikacija)
        {
            this.mw = m;
            this.izmena = menjam;
            this.selektovani = sel;
            this.ID = identifikacija;
            InitializeComponent();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int provera = mw.nadjIDtipa(textBox1.Text);
            if (!izmena && provera == 1)
            {
                textBox1.BorderBrush = Brushes.Red;
                label5.Content = "Uneli ste postojeci ID";
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BorderBrush = Brushes.Red;
                label5.Content = "Morate uneti ID!";
                return;

            }


            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
                label6.Content = "Morate uneti ime tipa!";
                return;
            }


            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BorderBrush = Brushes.Red;
                label7.Content = "Morate uneti opis tipa!";
                return;
            }

            if (image1.Source == null)
            {
                label8.Content = "Morate uneti ikonicu.";
                return;
            }
            

            tip.IDtipa = textBox1.Text;
            tip.imetipa = textBox2.Text;
            tip.opistipa = textBox3.Text;
            tip.setIcon(image1.Source);


            if (izmena)
            {

                int rbr = selektovani.GetValueOrDefault();
                mw.listatipova[rbr] = tip;
                Uspesno uc = new Uspesno();
                uc.ShowDialog();
            }
            else
            {
                mw.AddList(tip);
                Uspesno uc = new Uspesno();
                uc.ShowDialog();
            }

            
            this.Close();
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BorderBrush = Brushes.Red;
                label5.Content = "Morate uneti ID!";


            }
            else
            {
                textBox1.BorderBrush = Brushes.Green;
                label5.Content = "";
            }
        }

        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
                label6.Content = "Morate uneti ime tipa!";
            }
            else
            {
                textBox2.BorderBrush = Brushes.Green;
                label6.Content = "";
            }
        }

        private void textBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BorderBrush = Brushes.Red;
                label7.Content = "Morate uneti opis tipa!";
            }
            else
            {
                textBox3.BorderBrush = Brushes.Green;
                label7.Content = "";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string path;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg";
            if (open.ShowDialog() == true)
            {
                path = open.FileName;
                var uri = new Uri(path, UriKind.RelativeOrAbsolute);
                JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource2 = decoder2.Frames[0];
                image1.Source = bitmapSource2;
            }

        }

    }
}