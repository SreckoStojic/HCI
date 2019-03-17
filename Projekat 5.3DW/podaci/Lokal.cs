using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projekat_5._3DW.podaci
{
    [Serializable]
    public class Lokal : INotifyPropertyChanged
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
        private String _tipLokala;
        private String _sluzenjeAlkohola;
        private bool _hend;
        private bool _pusenje;
        private bool _rezervacije;
        private String _katCena;
        private int _kapacitet;

        private String _datum;

        private String _opis;

        public ObservableCollection<String> _etikete = new ObservableCollection<String>();

        private Uri _ikonicaPath;

        [field: NonSerialized]
        private BitmapImage _ikonica;


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

        public String TipLokala
        {
            get
            {
                return _tipLokala;
            }
            set
            {
                if (value != _tipLokala)
                {
                    _tipLokala = value;
                    OnPropertyChanged("TipLokala");
                }
            }
        }

        public String SluzenjeAlkohola
        {
            get
            {
                return _sluzenjeAlkohola;
            }
            set
            {
                if (value != _sluzenjeAlkohola)
                {
                    _sluzenjeAlkohola = value;
                    OnPropertyChanged("SluzenjeAlkohola");
                }
            }
        }

        public bool HendTrue
        {
            get
            {
                return _hend;
            }
            set
            {
                if (value == _hend)
                {
                    return;
                }
                
                _hend = value;
                OnPropertyChanged("HendTrue");
                OnPropertyChanged("HendFalse");

                
            }
        }

        public bool HendFalse
        {
            get
            {
                return !HendTrue;
            }
            set
            {
                HendTrue = !value;   
            }
        }

        public bool PusenjeTrue
        {
            get
            {
                return _pusenje;
            }
            set
            {
                if (value == _pusenje)
                {
                    return;
                }

                _pusenje = value;
                OnPropertyChanged("PusenjeTrue");
                OnPropertyChanged("PusenjeFalse");


            }
        }

        public bool PusenjeFalse
        {
            get
            {
                return !PusenjeTrue;
            }
            set
            {
                PusenjeTrue = !value;
            }
        }

        public bool RezervacijeTrue
        {
            get
            {
                return _rezervacije;
            }
            set
            {
                if (value == _rezervacije)
                {
                    return;
                }

                _rezervacije = value;
                OnPropertyChanged("RezervacijeTrue");
                OnPropertyChanged("RezervacijeFalse");


            }
        }

        public bool RezervacijeFalse
        {
            get
            {
                return !RezervacijeTrue;
            }
            set
            {
                RezervacijeTrue = !value;
            }
        }

        public String KatCena
        {
            get
            {
                return _katCena;
            }
            set
            {
                if (value != _katCena)
                {
                    _katCena = value;
                    OnPropertyChanged("KatCena");
                }
            }
        }

        public int Kapacitet
        {
            get
            {
                return _kapacitet;
            }
            set
            {
                if (value != _kapacitet)
                {
                    _kapacitet = value;
                    OnPropertyChanged("Kapacitet");
                }
            }
        }

        
        public String Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
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

        public BitmapImage Ikonica {
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


        public ObservableCollection<String> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete.Clear();
                    foreach (String et in value)
                    {
                        _etikete.Add(et);
                    }
                    
                    OnPropertyChanged("Etikete");
                }
            }
        }
        public String etiketa2 { get; set; }
        public ObservableCollection<String> ListaEtiketa2 { get; set; }

        public ObservableCollection<Tip> ListaTipova { get; set; }

        public ObservableCollection<String> ListaEtiketa { get; set; }

        public Lokal()
        { 
            ListaTipova = new ObservableCollection<Tip>();
            DataTipovi dataTipovi = new DataTipovi();

            foreach (var dt in dataTipovi.getAll())
            {
                ListaTipova.Add(dt.Value);
            }

            ListaEtiketa = new ObservableCollection<String>();
            DataEtikete dataEtikete = new DataEtikete();

            foreach (var dt in dataEtikete.getAll())
            {
                ListaEtiketa.Add(dt.Value.Oznaka);
            }

            
        }

        public static List<String> listaSluzenjeAlkohola = new List<String> (new string[] { "Ne služi", "Služi samo do 23h", "Služi i kasno noću" });

        public static List<String> listaKatCene = new List<String> (new string[] { "Niske cene", "Srednje cene", "Visoke cene", "Izuzetno visoke cene" });

        public List<String> ListaSluzenjeAlkohola
        {
            get
            {
                return listaSluzenjeAlkohola;
            }
            private set { }
        }

        public List<String> ListaKatCene
        {
            get
            {
                return listaKatCene;
            }
            private set { }
        }
    }
}
