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
    /// Interaction logic for DaLiZeliteObrisatiEtiketu.xaml
    /// </summary>
    public partial class DaLiZeliteObrisatiEtiketu : Window
    {
        public MainWindow mw;
        public DaLiZeliteObrisatiEtiketu(MainWindow m)
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
            mw.EtiketTable.UnselectAll();
            bool uspesno = false;
            var copy = new ObservableCollection<ClassEtiketa>(mw.listaetiketa);
            foreach (ClassEtiketa item in copy)
            {
                if (item.IDetikete == mw.selektovanID)
                {
                    mw.listaetiketa.Remove(item);
                    uspesno = true;
                    UspesnoObrisani uc = new UspesnoObrisani();
                    uc.ShowDialog();
                    break;
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
