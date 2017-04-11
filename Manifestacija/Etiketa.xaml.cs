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
using System.ComponentModel;
using System.Windows.Resources;

namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for Etiketa.xaml
    /// </summary>
    public partial class Etiketa : Window
    {
        ClassEtiketa etiketa = new ClassEtiketa();

        private MainWindow mw;
        private bool izmena;
        private int? selektovani;
        private String ID;

        public Etiketa(MainWindow m, bool menjam, int? sel, String identifikacija)
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

            int provera = mw.nadjiIDetikete(textBox1.Text);
            if ( !izmena && provera == 1)
            {
                textBox1.BorderBrush = Brushes.Red;
                label4.Content = "Uneli ste postojeci ID";
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BorderBrush = Brushes.Red;
                label4.Content = "Morate uneti ID!";
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
                label5.Content = "Morate uneti opis etikete!";
                return;
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label6.Content = "Morate uneti boju etikete!";
                return;
            }

            etiketa.IDetikete = textBox1.Text;
            etiketa.opis = textBox2.Text;
            etiketa.boja = comboBox1.Text;

            if (izmena)
            {

                int rbr = selektovani.GetValueOrDefault();
                mw.listaetiketa[rbr] = etiketa;
                Uspesno uc = new Uspesno();
                uc.ShowDialog();
            }
            else
            {
                mw.AddEtiketa(etiketa);
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
                label4.Content = "Morate uneti ID!";
               
                
            }
            else
            {
                textBox1.BorderBrush = Brushes.Green;
                label4.Content = "";
            }
        }

        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
                label5.Content = "Morate uneti opis etikete!";
            }
            else
            {
                textBox2.BorderBrush = Brushes.Green;
                label5.Content = "";
            }
        }



        private void comboBox1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label6.Content = "Morate uneti boju etikete!";
            }
            else
            {
                label6.Content = "";
            }
        }

        
    }
}
