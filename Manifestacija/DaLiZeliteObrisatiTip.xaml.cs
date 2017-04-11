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

namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for DaLiZeliteObrisatiTip.xaml
    /// </summary>
    public partial class DaLiZeliteObrisatiTip : Window
    {
        public MainWindow mw;
        public DaLiZeliteObrisatiTip(MainWindow m)
        {
            this.mw = m;
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mw.TipTable.UnselectAll();
            bool uspesno = false;
            var copy = new ObservableCollection<ClassTip>(mw.listatipova);
            foreach (ClassTip item in copy)
            {
                if (item.IDtipa == mw.selektovanID) //prolazim kroz listu tipova i uzimam 
                {
                    mw.tip = item;
                    foreach (ClassManifestacija manif in mw.ListaManifestacija) //prolazim kroz manifestacije i pitam koja ima taj tip
                    {
                        if (manif.timpanifestacije.IDtipa == mw.selektovanID)
                        {
                            mw.ListaManifestacijaSaTipom.Add(manif); //lista manifestacija sa tim tipom

                        }
                    }
                    /*this.listatipova.Remove(item);
                    uspesno = true;
                    UspesnoObrisani uc = new UspesnoObrisani();
                    uc.ShowDialog();
                    break;*/
                }

            }
            if (mw.ListaManifestacijaSaTipom.Count() == 0 && mw.selektovanID != null)
            {
                mw.listatipova.Remove(mw.tip);
                uspesno = true;
                UspesnoObrisani uc = new UspesnoObrisani();
                uc.ShowDialog();
            }
            if (mw.ListaManifestacijaSaTipom.Count() != 0 && mw.selektovanID != null)
            {

                ManifestacijeSadrzeTip m = new ManifestacijeSadrzeTip(mw);
                uspesno = true;
                m.ShowDialog();
            }

            mw.selektovanID = null;

            if (!uspesno)
            {
                NeuspesnoBrisanje nb = new NeuspesnoBrisanje();
                nb.ShowDialog();
            }
        }
    }
}
