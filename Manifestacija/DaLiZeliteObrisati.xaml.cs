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
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;

namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for DaLiZeliteObrisati.xaml
    /// </summary>
    public partial class DaLiZeliteObrisati : Window
    {
        public MainWindow mw;
        public DaLiZeliteObrisati(MainWindow m)
        {
            InitializeComponent();
            this.mw = m;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mw.ManifTable.UnselectAll();
            bool uspesno = false;
            var copy = new ObservableCollection<ClassManifestacija>(mw.ListaManifestacija);
            {

                foreach (ClassManifestacija item in copy)
                {

                    if (item.idmanifestacije == mw.selektovanID)
                    {
                        for (int i = 0; i < mw.listaPinovaImena.Count(); i++)
                        {
                            for (int j = 0; j < mw.brojac; j++)
                            {
                                if ((string)mw.listaPinovaImena[i].ContentStringFormat == (item.idmanifestacije + j))
                                {
                                    Pushpin pin = mw.listaPinovaImena.ElementAt(i);
                                    //listaPinovaImena.RemoveAt(i);
                                    mw.Mapa.Children.Remove(pin);
                                }
                            }
                        }
                        mw.ListaManifestacija.Remove(item);
                        uspesno = true;
                        UspesnoObrisani uc = new UspesnoObrisani();
                        uc.ShowDialog();
                        break;
                    }

                }
            }
            if (!uspesno)
            {
                NeuspesnoBrisanje nb = new NeuspesnoBrisanje();
                nb.ShowDialog();
            }
        }
    }
}
