using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using Microsoft.Maps.MapControl.WPF;

namespace Manifestacija
{
   [Serializable]
    public class ClassManifestacija : INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private ClassTip TipManifestacije;
        public ClassTip timpanifestacije
        {
            get { return this.TipManifestacije; }
            set { this.TipManifestacije = value; }
        }

        private List<ClassEtiketa> novaListaEtiketa;

        public List<ClassEtiketa> listaEtiketa
        {
            get { return novaListaEtiketa; }
            set { novaListaEtiketa = value; }
        }

        private List<double> pointiX;

        public List<double> pointix
        {
            get { return pointiX; }
            set { pointiX = value; }
        }

       

        private List<double> pointiY;

        public List<double> pointiy
        {
            get { return pointiY; }
            set { pointiY = value; }
        }

       
        private string IDmanifestacije;
        public string idmanifestacije
        {
            get { return this.IDmanifestacije; }
            set
            {
                if (value != IDmanifestacije)
                {
                    IDmanifestacije = value;
                    OnPropertyChanged("idmanifestacije");
                }
            }
        }

        private string ImeManifestacije;
        public string imemanifestacije
        {
            get { return this.ImeManifestacije; }
            set
            {
                if (value != ImeManifestacije)
                {
                    ImeManifestacije = value;
                    OnPropertyChanged("imemanifestacije");
                }
            }
        }

        private string OpisManifestacije;
        public string opismanifestacije
        {
            get { return this.OpisManifestacije; }
            set
            {
                if (value != OpisManifestacije)
                {
                    OpisManifestacije = value;
                    OnPropertyChanged("opismanifestacije");
                }
            }
        }

        private string StatusAlkohol;
        public string statusalkohol
        {
            get { return this.StatusAlkohol; }
            set
            {
                if (value != StatusAlkohol)
                {
                    StatusAlkohol = value;
                    OnPropertyChanged("statusalkohol");
                }
            }
        }

        private string StatusHendikep;
        public string statushendikep
        {
            get { return this.StatusHendikep; }
            set
            {
                if (value != StatusHendikep)
                {
                    StatusHendikep = value;
                    OnPropertyChanged("statushendikep");
                }
            }
        }

        private string StatusPusenje;
        public string statuspusenje
        {
            get { return this.StatusPusenje; }
            set
            {
                if (value != StatusPusenje)
                {
                    StatusPusenje = value;
                    OnPropertyChanged("statuspusenje");
                }
            }
        }

        private string MestoOdrzavanja;
        public string mestoodrzavanja
        {
            get { return this.MestoOdrzavanja; }
            set
            {
                if (value != MestoOdrzavanja)
                {
                    MestoOdrzavanja = value;
                    OnPropertyChanged("mestoodrzavanja");
                }
            }
        }

        private string Cena;
        public string cena
        {
            get { return this.Cena; }
            set
            {
                if (value != Cena)
                {
                    Cena = value;
                    OnPropertyChanged("cena");
                }
            }
        }

        private string Publika;
        public string publika
        {
            get { return this.Publika; }
            set
            {
                if (value != Publika)
                {
                    Publika = value;
                    OnPropertyChanged("publika");
                }
            }
        }

        private string Datum;
        public string datum
        {
            get { return this.Datum; }
            set
            {
                if (value != Datum)
                {
                    Datum = value;
                    OnPropertyChanged("datum");
                }
            }
        }
        [NonSerialized]
        private ImageSource slicica;

        public ImageSource Slicica
        {
            get { return slicica; }
            set
            {
                if (value != slicica)
                {
                    slicica = value;
                }
            }
        }

        private byte[] bytes;

       [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(bytes);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            this.slicica = biImg as ImageSource;
        }
       
        

        public void setEtiketa(List<ClassEtiketa> etiket)
        {
            this.listaEtiketa = etiket;
        }

        public void setIcon(ImageSource img)
        {
            this.slicica = img;
            bytes = null;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            var bitmapSource = img as BitmapSource;

            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }

            }
        }
    }
}
