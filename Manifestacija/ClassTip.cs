using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;
using System.IO;

namespace Manifestacija
{
    [Serializable]
   public class ClassTip : INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]    
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(info));
            }
        }
    
        private string idtipa;
        public string IDtipa
        {
            get { return this.idtipa; }
            set
            {
                if (value != idtipa)
                {
                    this.idtipa = value;
                    OnPropertyChanged("IDtipa");
                }
            }
        }

        private string ImeTipa;
        public string imetipa
        {
            get { return this.ImeTipa; }
            set
            {
                if (value != ImeTipa)
                {
                    this.ImeTipa = value;
                    OnPropertyChanged("imetipa");
                }
            }
        }

        private string OpisTipa;
        public string opistipa
        {
            get { return this.OpisTipa; }
            set
            {
                if (value != OpisTipa)
                {
                    this.OpisTipa = value;
                    OnPropertyChanged("opistipa");
                }
            }
        }

        public String getIDTipa()
        {
            return this.IDtipa;
        }
        [NonSerialized]
        private ImageSource ikonica;

        public ImageSource Ikonica
        {
            get { return ikonica; ; }
            set
            {
                if (ikonica != value)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
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

            this.ikonica = biImg as ImageSource;
        }

        /*public void setImage(System.Windows.Media.ImageSource img)
        {
            ikonica = img;
        }*/

        public void setIcon(ImageSource img)
        {
            this.ikonica = img;
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

        public ImageSource getSlika()
        {
            return ikonica;
        }

        
    }
}
