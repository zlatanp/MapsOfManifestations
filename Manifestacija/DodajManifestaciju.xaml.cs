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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for DodajManifestaciju.xaml
    /// </summary>
    public partial class DodajManifestaciju : Window
    {
        ClassManifestacija manifestacija = new ClassManifestacija();

        private MainWindow mw;
        private bool izmena;
        private int? selektovani;
        private String ID;
        private List<double> X;
        private List<double> Y;
        public ObservableCollection<ClassEtiketa> etiketaSort
        {
            get;
            set;
        }

        public ObservableCollection<ClassTip> tipSort
        {
            get;
            set;
        }

        public DodajManifestaciju(MainWindow m, bool menjanje, int? sel, String identifikacija, List<double> x, List<double> y)
        {
            this.mw = m;
            this.izmena = menjanje;
            this.selektovani = sel;
            this.ID = identifikacija;
            this.X = x;
            this.Y = y;
            this.etiketaSort = new ObservableCollection<ClassEtiketa>();
            this.tipSort = new ObservableCollection<ClassTip>();
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            int provera = mw.nadjIDmanifestacije(textBox1.Text);
            if ((provera == 1))
            {
                if (izmena && ID.Equals(textBox1.Text))
                {
                    textBox1.BorderBrush = Brushes.Green;
                }
                else
                {
                    textBox1.BorderBrush = Brushes.Red;
                    label15.Content = "Uneli ste postojeci ID";
                    return;
                }
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BorderBrush = Brushes.Red;
                label15.Content = "Morate uneti ID!";
                return;

            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
                label16.Content = "Morate uneti Naziv!";
                return;

            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BorderBrush = Brushes.Red;
                label17.Content = "Morate uneti Opis!";
                return;

            }

            if (comboBox3.SelectedItem == null)
            {
                label18.Content = "Morate izabrati tip!";
                return;
            }

            if (string.IsNullOrEmpty(datePicker1.Text))
            {
                label27.Content = "Morate uneti datum";
                return;
            }

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.BorderBrush = Brushes.Red;
                label20.Content = "Morate uneti publiku!";
                return;

            }

            if (comboBox1.SelectedItem == null)
            {
                label21.Content = "Morate izabrati status!";
                return;
            }

            if ((radioButton5.IsChecked == false) && (radioButton6.IsChecked == false))
            {

                label24.Content = "Morate izabrati status!";
                return;
            }

            if ((radioButton3.IsChecked == false) && (radioButton4.IsChecked == false))
            {

                label24.Content = "Morate izabrati status!";
                return;
            }

            if ((radioButton1.IsChecked == false) && (radioButton2.IsChecked == false))
            {

                label25.Content = "Morate izabrati status!";
                return;
            }

            if (comboBox2.SelectedItem == null)
            {
                label22.Content = "Morate izabrati kategoriju cena!";
                return;
            }

            manifestacija.idmanifestacije = textBox1.Text;

            manifestacija.imemanifestacije = textBox2.Text;
            manifestacija.opismanifestacije = textBox3.Text;
            manifestacija.datum = datePicker1.Text;
            manifestacija.publika = textBox6.Text;
            manifestacija.statusalkohol = comboBox1.Text;
            manifestacija.cena = comboBox2.Text;
            manifestacija.timpanifestacije = mw.gettip(comboBox3.Text);
            
            String strItem = null;
            List<ClassEtiketa> pomocna = new List<ClassEtiketa>();
            foreach (Object selecteditem in listBox1.SelectedItems)
            {

                strItem = selecteditem.ToString();
                Console.WriteLine(strItem);
                ClassEtiketa temp = mw.getetiketa(strItem);
                pomocna.Add(temp);
                
              
            }

            if ( !izmena && image1.Source == null)
            {
                manifestacija.setIcon(manifestacija.timpanifestacije.getSlika());
            }
            else
            {
                manifestacija.setIcon(image1.Source);
            }

            if (izmena)
            {
                manifestacija.setIcon(image1.Source);
            }
            

            manifestacija.listaEtiketa = pomocna;
            

            if (radioButton1.IsChecked == true)
            {
                manifestacija.statushendikep = "Da";
            }

            if (radioButton2.IsChecked == true)
            {
                manifestacija.statushendikep = "Ne";
            }

            if (radioButton3.IsChecked == true)
            {
                manifestacija.statuspusenje = "Da";
            }

            if (radioButton4.IsChecked == true)
            {
                manifestacija.statuspusenje = "Ne";
            }

            if (radioButton5.IsChecked == true)
            {
                manifestacija.mestoodrzavanja = "Napolju";
            }

            if (radioButton6.IsChecked == true)
            {
                manifestacija.mestoodrzavanja = "Unutra";
            }

            //manifestacija.ikona = image1.
            if (izmena)
            {

                manifestacija.pointix = X;
                manifestacija.pointiy = Y;
                int rbr = selektovani.GetValueOrDefault();
                mw.ListaManifestacija[rbr] = manifestacija;
                Uspesno uc = new Uspesno();
                uc.ShowDialog();
            }
            else
            {
                manifestacija.pointix = new List<double>();
                manifestacija.pointiy = new List<double>(); 
                mw.AddManifestaciju(manifestacija);
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
                label15.Content = "Morate uneti ID!";


            }
            else
            {
                textBox1.BorderBrush = Brushes.Green;
                label15.Content = "";
            }

            
            
        }

        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
                label16.Content = "Morate uneti Naziv!";


            }
            else
            {
                textBox2.BorderBrush = Brushes.Green;
                label16.Content = "";
            }

           
        }

        private void textBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BorderBrush = Brushes.Red;
                label17.Content = "Morate uneti Opis!";


            }
            else
            {
                textBox3.BorderBrush = Brushes.Green;
                label17.Content = "";
            }
            
        }

        private void comboBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                label18.Content = "Morate izabrati tip!";

            }
            else
            {
                label18.Content = "";
            }
           
        }

        private void comboBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if ((!string.IsNullOrEmpty(textBox1.Text)) && (!string.IsNullOrEmpty(textBox2.Text)) && (!string.IsNullOrEmpty(textBox3.Text)) && (!string.IsNullOrEmpty(textBox6.Text)) && (comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null)
                && (comboBox3.SelectedItem != null) && (!string.IsNullOrEmpty(datePicker1.Text)))
            {
                if (radioButton1.IsChecked == true || radioButton2.IsChecked == true)
                {
                    if (radioButton3.IsChecked == true || radioButton4.IsChecked == true)
                    {
                        if (radioButton5.IsChecked == true || radioButton6.IsChecked == true)
                        {

                            button1.IsEnabled = true;
                        }
                    }
                }
            }

            else
            {
                button1.IsEnabled = false;
            }
        }

        private void textBox6_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.BorderBrush = Brushes.Red;
                label20.Content = "Morate uneti publiku!";


            }
            else
            {
                foreach (char c in textBox6.Text)
                {
                    if (!char.IsDigit(c) && c != '.' && c != '-')
                    {

                        textBox6.BorderBrush = Brushes.Red;
                        label20.Content = "Morate uneti broj";
                    }


                    else
                    {
                        textBox6.BorderBrush = Brushes.Green;
                        label20.Content = "";
                    }
                }


            }
            
        }

        private void comboBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                label21.Content = "Morate izabrati status!";

            }
            else
            {
                label21.Content = "";
            }
           
        }

        private void comboBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                label22.Content = "Morate izabrati kategoriju cena!";

            }
            else
            {
                label22.Content = "";
            }
            
        }

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((radioButton5.IsChecked == false) && (radioButton6.IsChecked == false))
            {

                label24.Content = "Morate izabrati status!";
            }
            else
            {
                label24.Content = "";
            }
           
        }

        private void Grid_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if ((radioButton3.IsChecked == false) && (radioButton4.IsChecked == false))
            {

                label24.Content = "Morate izabrati status!";
            }
            else
            {
                label24.Content = "";
            }
           
        }

        private void Grid_LostFocus_2(object sender, RoutedEventArgs e)
        {
            if ((radioButton1.IsChecked == false) && (radioButton2.IsChecked == false))
            {

                label25.Content = "Morate izabrati status!";
            }
            else
            {
                label25.Content = "";
            }
           
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg";
            if (open.ShowDialog() == true)
            {

                Uri myUri = new Uri(open.FileName, UriKind.RelativeOrAbsolute);
                JpegBitmapDecoder decoder2 = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource2 = decoder2.Frames[0];

                // Draw the Image
                image1.Source = bitmapSource2;
            }
        }

        private void textBox7_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox8_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void datePicker1_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(datePicker1.Text))
            {
                label27.Content = "Morate uneti datum";
                return;
            }
            if (!string.IsNullOrEmpty(datePicker1.Text))
            {
                label27.Content = "";
                return;
            }

            

        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            etiketaSort.Clear();
            var copy = new ObservableCollection<ClassEtiketa>(mw.listaetiketa);
            foreach (ClassEtiketa item in copy)
            {
                if (item.IDetikete.Contains(textBox4.Text))
                {
                    etiketaSort.Add(item);
                }
            }
            if (etiketaSort.Count() != 0)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < etiketaSort.Count(); i++)
                    listBox1.Items.Add(etiketaSort[i].IDetikete);
            }
        }

       

        private void textBox5_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            comboBox3.IsDropDownOpen = true;
            tipSort.Clear();
            var copy = new ObservableCollection<ClassTip>(mw.listatipova);
            foreach (ClassTip item in copy)
            {
                if (item.IDtipa.Contains(textBox5.Text))
                {
                    tipSort.Add(item);
                }
            }

            if (tipSort.Count() != 0)
            {
                comboBox3.Items.Clear();
                for (int i = 0; i < tipSort.Count(); i++)
                    comboBox3.Items.Add(tipSort[i].IDtipa);
            }
        }

       

    }
}

