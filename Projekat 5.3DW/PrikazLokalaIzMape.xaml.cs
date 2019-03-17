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
using Microsoft.Win32;
using Projekat_5._3DW.podaci;

namespace Projekat_5._3DW
{
    /// <summary>
    /// Interaction logic for PrikazLokalaIzMape.xaml
    /// </summary>
    public partial class PrikazLokalaIzMape : Window
    {
        private ObservableCollection<Lokal> listaLokala = new ObservableCollection<Lokal>();
        private ObservableCollection<Lokal> listaLokalaSearch = new ObservableCollection<Lokal>();
        private DataLokali dataLokali = new DataLokali();
        private Lokal lokali = new Lokal();
        private OpenFileDialog fileDialog = new OpenFileDialog();

        public PrikazLokalaIzMape()
        {
            InitializeComponent();
            this.DataContext = this;
            loadItems();
        }

        private void loadItems()
        {
            //DataEtikete dataEtikete = new DataEtikete();
            foreach (var l in dataLokali.getAll())
            {
                listaLokala.Add(l.Value);
            }


        }

        public ObservableCollection<Lokal> ListaLokala
        {
            get
            {
                return listaLokala;
            }

            set { }


        }

        public List<String> ListaSluzenjeAlkohola
        {
            get
            {
                return Lokal.listaSluzenjeAlkohola;
            }
            private set { }
        }


        public List<String> ListaKatCene
        {
            get
            {
                return Lokal.listaKatCene;
            }
            private set { }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
