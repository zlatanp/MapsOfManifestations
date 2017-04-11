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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Maps.MapControl.WPF;
using System.Data;
using System.Timers;
using System.Windows.Threading;

namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Boolean ctrl = false;
        public int brojac = 0;
        public Point startPos = new Point();
        Vector mouseToMarker;
        private bool dragPin;
        public Pushpin SelectedPushpin { get; set; }
        public List<Pushpin> listaPinovaImena { get; set; }
        public Pushpin pinz { get; set; }
        public ClassTip tip = null;

        public String selektovanID = null;
        private String pathEtiketa = @".\..\..\Files\etikete";
        private String pathTip = @".\..\..\Files\tipovi";
        private String pathManifestacija = @".\..\..\Files\Manifestacije";

        public ObservableCollection<ClassTip> listatipova
        {
            get;
            set;
        }

        public ObservableCollection<ClassEtiketa> listaetiketa
        {
            get;
            set;
        }

        public ObservableCollection<ClassManifestacija> ListaManifestacija
        {
            get;
            set;
        }

        public ObservableCollection<ClassManifestacija> manifestacijeSort
        {
            get;
            set;
        }

        public ObservableCollection<ClassTip> tipoviSort
        {
            get;
            set;
        }

        public ObservableCollection<ClassEtiketa> etiketeSort
        {
            get;
            set;
        }

        public ObservableCollection<ClassManifestacija> ListaManifestacijaSaTipom
        {
            get;
            set;
        }



        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            listatipova = new ObservableCollection<ClassTip>();
            listaetiketa = new ObservableCollection<ClassEtiketa>();
            ListaManifestacija = new ObservableCollection<ClassManifestacija>();
            ListaManifestacijaSaTipom = new ObservableCollection<ClassManifestacija>();
            manifestacijeSort = new ObservableCollection<ClassManifestacija>();
            tipoviSort = new ObservableCollection<ClassTip>();
            etiketeSort = new ObservableCollection<ClassEtiketa>();
            listaPinovaImena = new List<Pushpin>();
            AddHandler(Keyboard.KeyDownEvent, (KeyEventHandler)HandleKeyDownEvent);
        }

        internal ClassTip gettip(string idtipa)
        {
            for (int i = 0; i < listatipova.Count; i++)
            {
                if (listatipova[i].IDtipa == idtipa)
                    return listatipova[i];
            }
            return null;
        }

        internal ClassEtiketa getetiketa(string id)
        {
            for (int i = 0; i < listaetiketa.Count; i++)
            {
                if (listaetiketa[i].IDetikete == id)
                    return listaetiketa[i];
            }
            return null;
        }

        internal void AddList(ClassTip tip)
        {
            this.listatipova.Add(tip);
        }

        internal void AddEtiketa(ClassEtiketa etiketa)
        {
            this.listaetiketa.Add(etiketa);
        }

        internal void AddManifestaciju(ClassManifestacija manif)
        {
            this.ListaManifestacija.Add(manif);
        }

        internal int nadjIDmanifestacije(string s)
        {
            for (int i = 0; i < ListaManifestacija.Count; i++)
            {
                if (ListaManifestacija[i].idmanifestacije == s)
                    return 1;
            }
            return 0;
        }

        internal int nadjIDtipa(string s)
        {
            for (int i = 0; i < listatipova.Count; i++)
            {
                if (listatipova[i].IDtipa == s)
                    return 1;
            }
            return 0;
        }

        internal int nadjiIDetikete(string s)
        {
            for (int i = 0; i < listaetiketa.Count; i++)
            {
                if (listaetiketa[i].IDetikete == s)
                    return 1;
            }
            return 0;
        }




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DodajManifestaciju unosmanifestacije = new DodajManifestaciju(this, false, (int?)null, null, null, null);
            for (int i = 0; i < listatipova.Count; i++)
                unosmanifestacije.comboBox3.Items.Add(listatipova[i].IDtipa);

            for (int i = 0; i < listaetiketa.Count; i++)
                unosmanifestacije.listBox1.Items.Add(this.listaetiketa[i].IDetikete);

            unosmanifestacije.Top = 100;
            unosmanifestacije.Left = 400;
            unosmanifestacije.ShowDialog();
        }

       

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            UnderConstruction uc = new UnderConstruction();
            uc.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Tip tipwindow = new Tip(this, false, (int?)null, null);
            tipwindow.Top = 100;
            tipwindow.Left = 400;
            tipwindow.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Etiketa etiketawindow = new Etiketa(this, false, (int?)null, null);
            etiketawindow.Top = 100;
            etiketawindow.Left = 400;
            etiketawindow.ShowDialog();
        }



        private void button7_Click(object sender, RoutedEventArgs e)
        {
            /* if (ManifTable.SelectedIndex > -1)
             {
                 this.ListaManifestacija.RemoveAt(ManifTable.SelectedIndex);
             }
             */

            DaLiZeliteObrisati dijalog = new DaLiZeliteObrisati(this);
            dijalog.ShowDialog();

        }


        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (ManifTable.SelectedIndex > -1)
            {
                ClassManifestacija mm = ListaManifestacija[ManifTable.SelectedIndex];

                DodajManifestaciju unosmanifestacije = new DodajManifestaciju(this, true, ManifTable.SelectedIndex, mm.idmanifestacije, mm.pointix, mm.pointiy);

                for (int i = 0; i < listatipova.Count; i++)
                    unosmanifestacije.comboBox3.Items.Add(listatipova[i].IDtipa);

                for (int i = 0; i < listaetiketa.Count; i++)
                    unosmanifestacije.listBox1.Items.Add(listaetiketa[i].IDetikete);


                ClassManifestacija m = ListaManifestacija[ManifTable.SelectedIndex];

                unosmanifestacije.textBox1.Text = m.idmanifestacije;
                unosmanifestacije.textBox1.IsReadOnly = true;
                unosmanifestacije.textBox2.Text = m.imemanifestacije;
                unosmanifestacije.textBox3.Text = m.opismanifestacije;
                unosmanifestacije.comboBox3.SelectedItem = m.timpanifestacije.getIDTipa();
                unosmanifestacije.listBox1.SelectedItem = m.listaEtiketa;
                //unosmanifestacije.comboBox4.Text = m.listaEtiketa(0);
                unosmanifestacije.datePicker1.Text = m.datum;
                unosmanifestacije.textBox6.Text = Convert.ToString(m.publika);
                unosmanifestacije.comboBox1.Text = m.statusalkohol;
                unosmanifestacije.comboBox2.Text = m.cena;
                // unosmanifestacije.Slika.Source = m.Slicica;
                unosmanifestacije.image1.Source = m.Slicica;

                if (m.statushendikep.Equals("Da"))
                {
                    unosmanifestacije.radioButton1.IsChecked = true;
                }
                if (m.statushendikep.Equals("Ne"))
                {
                    unosmanifestacije.radioButton2.IsChecked = true;
                }

                if (m.statuspusenje.Equals("Da"))
                {
                    unosmanifestacije.radioButton3.IsChecked = true;
                }

                if (m.statuspusenje.Equals("Ne"))
                {
                    unosmanifestacije.radioButton4.IsChecked = true;
                }

                if (m.mestoodrzavanja.Equals("Napolju"))
                {
                    unosmanifestacije.radioButton5.IsChecked = true;
                }

                if (m.mestoodrzavanja.Equals("Unutra"))
                {
                    unosmanifestacije.radioButton6.IsChecked = true;
                }



                unosmanifestacije.Top = 100;
                unosmanifestacije.Left = 400;
                unosmanifestacije.ShowDialog();



            } else {
                neuspesnaSelekcija nb = new neuspesnaSelekcija();
                nb.ShowDialog();
            }
        }

        private void ManifTable_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (var item in e.AddedCells)
            {
                var col = item.Column as DataGridColumn;
                var fc = col.GetCellContent(item.Item);

                /*if (fc is CheckBox)
                {
                    Console.WriteLine("Values" + (fc as CheckBox).IsChecked);
                }*/
                if (fc is TextBlock)
                {
                    selektovanID = (fc as TextBlock).Text;
                }
                break;
            }
        }

        private void OpenFileManifestacija(object sender, RoutedEventArgs e)
        {
            var binaryFormatter = new BinaryFormatter();
            if (File.Exists(pathManifestacija))
            {
                using (FileStream s = File.Open(pathManifestacija, FileMode.Open))
                {

                    while (s.Position != s.Length)
                    {

                        ClassManifestacija obj = (ClassManifestacija)binaryFormatter.Deserialize(s);
                        ListaManifestacija.Add(obj);

                    }
                }
            }
        }

        private void SaveFileManifestacija(object sender, RoutedEventArgs e)
        {

            using (Stream stream = File.Open(pathManifestacija, FileMode.Create))
            {
                var binaryFormater = new BinaryFormatter();
                foreach (ClassManifestacija m in this.ListaManifestacija)
                    binaryFormater.Serialize(stream, m);

            }
        }



        private void OpenFileTip(object sender, RoutedEventArgs e)
        {
            var binaryFormatter = new BinaryFormatter();
            if (File.Exists(pathTip))
            {
                using (FileStream s = File.Open(pathTip, FileMode.Open))
                {

                    while (s.Position != s.Length)
                    {

                        ClassTip obj = (ClassTip)binaryFormatter.Deserialize(s);
                        listatipova.Add(obj);

                    }
                }
            }
        }

        private void SaveFileTip(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open(pathTip, FileMode.Create))
            {
                var binaryFormater = new BinaryFormatter();
                foreach (ClassTip m in this.listatipova)
                    binaryFormater.Serialize(stream, m);

            }
        }

        private void OpenFileEtiketa(object sender, RoutedEventArgs e)
        {

            var binaryFormatter = new BinaryFormatter();
            if (File.Exists(pathEtiketa))
            {
                using (FileStream s = File.Open(pathEtiketa, FileMode.Open))
                {

                    while (s.Position != s.Length)
                    {

                        ClassEtiketa obj = (ClassEtiketa)binaryFormatter.Deserialize(s);
                        listaetiketa.Add(obj);

                    }
                }
            }

        }

        private void SaveFileEtiketa(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open(pathEtiketa, FileMode.Create))
            {
                var binaryFormater = new BinaryFormatter();
                foreach (ClassEtiketa m in this.listaetiketa)
                    binaryFormater.Serialize(stream, m);

            }
        }
        //OTVARANJEEEEEEEEEEEEEEEEEEEEEEEEEEE
        private void OtvoriPinove(object sender, RoutedEventArgs e)
        {
            var copy = new ObservableCollection<ClassManifestacija>(ListaManifestacija);
            foreach (ClassManifestacija item in copy)
            {
                for (int i = 0; i < item.pointix.Count(); i++)
                {
                    if (item.pointix.Count() == 0)
                        return;

                    Point mapPoint = new Point(0, 0);
                    Location pinLocation = Mapa.ViewportPointToLocation(mapPoint);

                    pinLocation.Latitude = item.pointix[i];
                    pinLocation.Longitude = item.pointiy[i];
                    Pushpin pin = new Pushpin();
                    pin.Location = pinLocation;

                    ImageBrush ib = new ImageBrush();
                    ib.ImageSource = item.Slicica;
                    pin.Background = ib;

                    StackPanel stack = new StackPanel();
                    Image img = new Image();
                    img.Source = item.Slicica;

                    TextBlock text = new TextBlock();
                    text.Text = "ID Manifestacije : " + item.imemanifestacije + "\n" + "Opis Manifestacije: " + item.opismanifestacije + "\n" + "Datum održavanja: " + item.datum;
                    img.Height = 200;
                    img.Width = 200;
                    img.SnapsToDevicePixels = true;

                    stack.Orientation = Orientation.Vertical;
                    stack.Children.Add(img);
                    stack.Children.Add(text);
                    ToolTipService.SetToolTip(pin, stack);

                    pin.ContentStringFormat = item.idmanifestacije + brojac;
                    brojac++;


                    pin.Content = item.imemanifestacije;


                    //pin.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(pin_PreviewMouseLeftButtonDown);
                    // pin.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(pin_PreviewMouseLeftButtonUp);
                    pin.PreviewMouseDoubleClick += new MouseButtonEventHandler(pin_PreviewMouseDoubleClick);
                    pin.PreviewMouseRightButtonDown += new MouseButtonEventHandler(pin_RightMouseDown);
                    listaPinovaImena.Add(pin);
                    Mapa.Children.Add(pin);
                }
            }
        }


        private void Otvori(object sender, RoutedEventArgs e)
        {
            OpenFileTip(sender, e);
            OpenFileEtiketa(sender, e);
            OpenFileManifestacija(sender, e);
            OtvoriPinove(sender, e);
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            SaveFileTip(sender, e);
            SaveFileEtiketa(sender, e);
            SaveFileManifestacija(sender, e);
            UnderConstruction uc = new UnderConstruction();
            uc.ShowDialog();
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {

            DaLiZeliteObrisatiTip t = new DaLiZeliteObrisatiTip(this);
            t.ShowDialog();

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            DaLiZeliteObrisatiEtiketu dijalogEtiketu = new DaLiZeliteObrisatiEtiketu(this);
            dijalogEtiketu.ShowDialog();

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (TipTable.SelectedIndex > -1)
            {
                ClassTip type = listatipova[TipTable.SelectedIndex];

                Tip unostip = new Tip(this, true, TipTable.SelectedIndex, type.IDtipa);


                ClassTip tip = listatipova[TipTable.SelectedIndex];

                unostip.textBox1.Text = tip.IDtipa;
                unostip.textBox1.IsReadOnly = true;
                unostip.textBox2.Text = tip.imetipa;
                unostip.textBox3.Text = tip.opistipa;
                unostip.image1.Source = tip.Ikonica;


                unostip.ShowDialog();



            }
            else
            {
                neuspesnaSelekcija nb = new neuspesnaSelekcija();
                nb.ShowDialog();
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if (EtiketTable.SelectedIndex > -1)
            {
                ClassEtiketa mm = listaetiketa[EtiketTable.SelectedIndex];

                Etiketa unosetikete = new Etiketa(this, true, EtiketTable.SelectedIndex, mm.IDetikete);


                ClassEtiketa et = listaetiketa[EtiketTable.SelectedIndex];

                unosetikete.textBox1.Text = et.IDetikete;
                unosetikete.textBox1.IsReadOnly = true;
                unosetikete.textBox2.Text = et.opis;
                unosetikete.comboBox1.Text = et.boja;



                unosetikete.Top = 100;
                unosetikete.Left = 400;
                unosetikete.ShowDialog();



            }else {
                neuspesnaSelekcija nb = new neuspesnaSelekcija();
                nb.ShowDialog();
            }
        }

        //DRAG N DROP ***********************************************************************************************************************************************************************

        private void Map_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("manif") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Map_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("manif"))
            {

                Point mapPoint = e.GetPosition(Mapa);
                Location pinLocation = Mapa.ViewportPointToLocation(mapPoint);

                //double x = mapPoint.X;
                //double y = mapPoint.Y;

                Pushpin pin = new Pushpin();

                pin.Location = pinLocation;

                ClassManifestacija manif = e.Data.GetData("manif") as ClassManifestacija;

                manif.pointix.Add(pinLocation.Latitude);
                manif.pointiy.Add(pinLocation.Longitude);

                //slicica u pinu
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = manif.Slicica;
                pin.Background = ib;

                //slicica u tultipu
                StackPanel stack = new StackPanel();
                Image img = new Image();
                img.Source = manif.Slicica;

                TextBlock text = new TextBlock();
                text.Text = "ID Manifestacije : " + manif.imemanifestacije + "\n" + "Opis Manifestacije: " + manif.opismanifestacije + "\n" + "Datum održavanja: " + manif.datum;
                img.Height = 200;
                img.Width = 200;
                img.SnapsToDevicePixels = true;

                stack.Orientation = Orientation.Vertical;
                stack.Children.Add(img);
                stack.Children.Add(text);
                ToolTipService.SetToolTip(pin, stack);

                pin.ContentStringFormat = manif.idmanifestacije + brojac;
                brojac++;

                pin.Content = manif.imemanifestacije;


                //pin.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(pin_PreviewMouseLeftButtonDown);
                //pin.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(pin_PreviewMouseLeftButtonUp);
                pin.PreviewMouseDoubleClick += new MouseButtonEventHandler(pin_PreviewMouseDoubleClick);
                pin.PreviewMouseRightButtonDown += new MouseButtonEventHandler(pin_RightMouseDown);

                Mapa.Children.Add(pin);
                listaPinovaImena.Add(pin);
            }
        }

        private void pin_RightMouseDown(object sender, MouseEventArgs e)
        {
            pinz = sender as Pushpin;
            ContextMenu menu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Header = "Delete";
            item.Tag = pinz.Location.Latitude;
            item.Click += new RoutedEventHandler(item_Click);
            menu.Items.Add(item);
            pinz.ContextMenu = menu;
            pinz.ContextMenu.IsOpen = true;
        }


        private void item_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            double latitud = (double)item.Tag;

            var copy = new ObservableCollection<ClassManifestacija>(ListaManifestacija);
            foreach (ClassManifestacija manif in copy)
            {


                for (int i = 0; i < manif.pointix.Count(); i++)
                {
                    for (double z = -1; z < 1; z += 0.01)
                    {

                        if ((manif.pointix[i] + z) == latitud)
                        {
                            manif.pointix.Remove(manif.pointix[i]);
                            manif.pointiy.Remove(manif.pointiy[i]);
                            break;
                        }

                    }
                }
            }
            

            Mapa.Children.Remove(pinz);
            listaPinovaImena.Remove(pinz);

        }

        private void pin_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            e.Handled = true;

            SelectedPushpin = sender as Pushpin;
            if (SelectedPushpin == null)
                return;
            Point obrisan = e.GetPosition(Mapa);

            Mapa.Children.Remove(SelectedPushpin);



            var copy = new ObservableCollection<ClassManifestacija>(ListaManifestacija);
            foreach (ClassManifestacija item in copy)
            {


                for (int i = 0; i < item.pointix.Count(); i++)
                {
                    for (double z = -1; z < 1; z += 0.01)
                    {

                        if ((item.pointix[i] + z) == SelectedPushpin.Location.Latitude)
                        {
                            item.pointix.Remove(item.pointix[i]);
                            item.pointiy.Remove(item.pointiy[i]);
                            Console.WriteLine("o" + SelectedPushpin.Location.Longitude);
                            Console.WriteLine("o" + SelectedPushpin.Location.Latitude);
                            break;
                        }

                    }
                }
            }




            dragPin = false;
            listaPinovaImena.Remove(SelectedPushpin);


        }

        private void pin_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            SelectedPushpin = sender as Pushpin;

            if (SelectedPushpin == null)
                return;

            dragPin = true;
            mouseToMarker = Point.Subtract(
             Mapa.LocationToViewportPoint(SelectedPushpin.Location),
                 e.GetPosition(Mapa));



        }

        private void pin_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dragPin = false;
        }

        private void Mapa_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (dragPin && SelectedPushpin != null)
                {
                    SelectedPushpin.Location = Mapa.ViewportPointToLocation(
                     Point.Add(e.GetPosition(Mapa), mouseToMarker));
                    e.Handled = true;
                }

            }
        }

        private void ManifTable_GotFocus(object sender, RoutedEventArgs e)
        {
            TipTable.UnselectAll();
            EtiketTable.UnselectAll();
        }

        private void ManifTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    if (!row.IsMouseOver)
                    {
                        (row as DataGridRow).IsSelected = false;

                    }
                }
                TipTable.UnselectAll();
                EtiketTable.UnselectAll();
            }
        }

        private void ManifTable_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(null);
            Vector vek = startPos - mousePoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
            (Math.Abs(vek.X) > SystemParameters.MinimumHorizontalDragDistance ||
            Math.Abs(vek.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                DataGrid table = sender as DataGrid;
                DataGridRow row = FindRow<DataGridRow>((DependencyObject)e.OriginalSource);

                if (row == null)
                    return;


                ClassManifestacija manif = (ClassManifestacija)table.ItemContainerGenerator.ItemFromContainer(row);

                if (manif == null)
                    return;


                DataObject drag = new DataObject("manif", manif);
                DragDrop.DoDragDrop(row, drag, DragDropEffects.Copy);

            }

        }

        private static T FindRow<T>(DependencyObject obj) where T : DependencyObject
        {
            do
            {
                if (obj is T)
                    return (T)obj;


                obj = VisualTreeHelper.GetParent(obj);


            } while (obj != null);
            return null;
        }

        private void ManifTable_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPos = e.GetPosition(null);
        }

        private void TipTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    if (!row.IsMouseOver)
                    {
                        (row as DataGridRow).IsSelected = false;

                    }
                }
            }
        }

        private void TipTable_GotFocus(object sender, RoutedEventArgs e)
        {
            ManifTable.UnselectAll();
            EtiketTable.UnselectAll();
        }

        private void EtiketTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    if (!row.IsMouseOver)
                    {
                        (row as DataGridRow).IsSelected = false;

                    }
                }
            }
        }

        private void EtiketTable_GotFocus(object sender, RoutedEventArgs e)
        {
            ManifTable.UnselectAll();
            TipTable.UnselectAll();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da izađete iz aplikacije?", "Izlaz", MessageBoxButton.YesNo);


            if (result == MessageBoxResult.No)
                e.Cancel = true;
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Prikaz p = new Prikaz(this);

            p.ShowDialog();

        }


        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            manifestacijeSort.Clear();
            var copy = new ObservableCollection<ClassManifestacija>(ListaManifestacija);
            foreach (ClassManifestacija item in copy)
            {
                ManifTable.ItemsSource = manifestacijeSort;
                if (item.imemanifestacije.Contains(textBox1.Text))
                {
                    manifestacijeSort.Add(item);
                    ManifTable.ItemsSource = manifestacijeSort;
                }
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            tipoviSort.Clear();
            var copy = new ObservableCollection<ClassTip>(listatipova);
            foreach (ClassTip item in copy)
            {
                TipTable.ItemsSource = tipoviSort;
                if (item.imetipa.Contains(textBox2.Text))
                {
                    tipoviSort.Add(item);
                    TipTable.ItemsSource = tipoviSort;
                }
            }
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            etiketeSort.Clear();
            var copy = new ObservableCollection<ClassEtiketa>(listaetiketa);
            foreach (ClassEtiketa item in copy)
            {
                EtiketTable.ItemsSource = etiketeSort;
                if (item.IDetikete.Contains(textBox3.Text))
                {
                    etiketeSort.Add(item);
                    EtiketTable.ItemsSource = etiketeSort;
                }
            }
        }


        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                button7_Click(sender, e);
            }
        }



        private void HandleKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.T && (Keyboard.Modifiers & (ModifierKeys.Control)) == ModifierKeys.Control)
            {
                button2_Click(sender, e);
            }

            if (e.Key == Key.E && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                button3_Click(sender, e);
            }

            if (e.Key == Key.M && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                button1_Click(sender, e);
            }

            if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Sacuvaj(sender, e);
            }

            if (e.Key == Key.I && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                button8_Click(sender, e);
            }

            if (e.Key == Key.F1)
            {
                MenuItem_Click(sender, e);
            }

            if (e.Key == Key.F2)
            {
                MenuItem_Click_2(sender, e);
            }
        }
    }

}
