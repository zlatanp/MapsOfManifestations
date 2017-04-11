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
    /// Interaction logic for ManifestacijeSadrzeTip.xaml
    /// </summary>
    public partial class ManifestacijeSadrzeTip : Window
    {
        
        public MainWindow mw;

        public ManifestacijeSadrzeTip(MainWindow m)
        {
            InitializeComponent();
            this.DataContext = m;
            this.mw = m;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mw.ListaManifestacijaSaTipom.Clear();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var copy = new ObservableCollection<ClassManifestacija>(mw.ListaManifestacija);
            foreach (ClassManifestacija manif in copy)
            { //velika lista
                for (int i = 0; i < mw.ListaManifestacijaSaTipom.Count(); i++)
                { //manif koje treba obrisati

                    if (manif.idmanifestacije == mw.ListaManifestacijaSaTipom[i].idmanifestacije)
                    {
                        mw.ListaManifestacija.Remove(manif);

                        for (int j = 0; j < mw.listaPinovaImena.Count(); j++)
                        {
                            for (int k = 0; k < mw.brojac; k++)
                            {
                                if ((string)mw.listaPinovaImena[j].ContentStringFormat == (manif.idmanifestacije + k))
                                {
                                    Pushpin pin = mw.listaPinovaImena.ElementAt(j);
                                    //listaPinovaImena.RemoveAt(i);
                                    mw.Mapa.Children.Remove(pin);
                                }
                            }
                        }
                    }
                }
            }
            mw.listatipova.Remove(mw.tip);
            mw.ListaManifestacijaSaTipom.Clear();
            UspesnoObrisani uc = new UspesnoObrisani();
            uc.ShowDialog();
            this.Close();
        }

               
       
    }
}
