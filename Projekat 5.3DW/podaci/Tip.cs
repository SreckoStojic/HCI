using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Projekat_5._3DW.podaci
{
    [Serializable]
    public class Tip : INotifyPropertyChanged
    {
        
   
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _oznaka;
        private String _naziv;
        private String _opis;

        private Uri _ikonicaPath;

        [field: NonSerialized]
        private BitmapImage _ikonica;

        public BitmapImage Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    _ikonicaPath = _ikonica.UriSource;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public Uri IkonicaPath
        {
            get
            {
                return _ikonicaPath;
            }
            set
            {
                if (value != _ikonicaPath)
                {
                    _ikonicaPath = value;
                    Ikonica = new BitmapImage(_ikonicaPath);
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public String Oznaka 
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public String Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public String Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        
    }
}
