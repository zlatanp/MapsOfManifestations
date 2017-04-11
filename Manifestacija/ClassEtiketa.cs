using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Manifestacija
{
    [Serializable]
    public class ClassEtiketa
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private string idetikete;
        public string IDetikete
        {
            get { return this.idetikete; }
            set
            {
                if (value != idetikete)
                {
                    this.idetikete = value;
                    OnPropertyChanged("IDetikete");
                }
            }
        }

        private string Opis;
        public string opis
        {
            get { return this.Opis; }
            set
            {
                if (value != Opis)
                {
                    this.Opis = value;
                    OnPropertyChanged("opis");
                }
            }
        }

        
        private string Boja;
        public string boja
        {
            get { return this.Boja; }
            set
            {
                if (value != Boja)
                {
                    this.Boja = value;
                    OnPropertyChanged("boja");
                }
            }
        }

        public String getIDetikete()
        {
            return this.IDetikete;
        }
    }
}
