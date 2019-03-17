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
using Projekat_5._3DW.podaci;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace Projekat_5._3DW
{
    /// <summary>
    /// Interaction logic for TabelaWindow.xaml
    /// </summary>
    public partial class TabelaLokala : Window
    {
        private ObservableCollection<Lokal> listaLokala = new ObservableCollection<Lokal>();
        private ObservableCollection<Lokal> listaLokalaSearch = new ObservableCollection<Lokal>();
        private DataLokali dataLokali = new DataLokali();
        private Lokal lokali = new Lokal();
        private OpenFileDialog fileDialog = new OpenFileDialog();

        private Regex rx_datum = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])\-(0?[1-9]|1[012])\-\d{4}$"); 

        public TabelaLokala()
        {
            InitializeComponent();
            this.DataContext = this;
            textBox2.IsReadOnly = true;
            //textBox3.IsReadOnly = true;
           // datePicker1.IsReadOnly = true;
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

        public ObservableCollection<Lokal> ListaLokalaSearch
        {
            get
            {
                return listaLokalaSearch;
            }

            set { }


        }

        public ObservableCollection<Lokal> ListaLokala 
        {
            get
            {
                return listaLokala;
            }

            set {}
        
 
        }

        public List<String> ListaSluzenjeAlkohola
        {
            get
            {
                return Lokal.listaSluzenjeAlkohola;
            }
            private set{}
        }


        public List<String> ListaKatCene
        {
            get
            {
                return Lokal.listaKatCene;
            }
            private set { }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window1 lokal = new Window1();
            lokal.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Da li želite da obrišete selektovani lokal?";
            string caption = "Potvrda";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);

            if (result == MessageBoxResult.Yes)
            {

                listaLokala.Remove((Lokal)dataGridLokal.SelectedItem);
            
            }
            
            
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Boolean dozvolaCuvanjaIme = false;
            Boolean dozvolaDatum = false;

            if (rx_datum.Match(datePicker1.Text).ToString() == datePicker1.Text.ToString())
            {
                dozvolaDatum = true;
            }
            else
            {
                dozvolaDatum = false;
            }

            if (textBox3.Text.ToString() != "")
            {
                dozvolaCuvanjaIme = true;
            }
            else
            {
                dozvolaCuvanjaIme = false;
            }

            if (dozvolaCuvanjaIme == true && dozvolaDatum == true)
            {
                dataLokali.ObrisiSve();
                foreach (Lokal l in ListaLokala)
                {
                    dataLokali.Dodaj(l);
                }

                Close();
            }
            else if (textBox3.Text.ToString() == "")
            {
                string message = "Naziv lokala ne sme biti prazan!";
                string caption = "Obavestenje!"; 
                prikaziGresku(message, caption);
                textBox3.Focus();
            }
             else if(dozvolaDatum == false)
            {
                string message = "Datum mora biti u obliku: dd-mm-yyyy";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                datePicker1.Focus();
            }

            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fileDialog.ShowDialog() == true)
            {
                string fname = fileDialog.FileName;
                image1.Source = new BitmapImage(new Uri(fname));
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           /* String naziv = tbSearch.Text.ToString(); 

            foreach (var l in dataLokali.getAll())
            {
                if (naziv.Equals(l.Value.Naziv.ToString()))
                {
                    listaLokalaSearch.Add(l.Value);
                }
            }*/
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*DataLokali dataLokali = new DataLokali();
            if (comboBox2.Text.Equals("Oznaka"))
            {
                dataGridLokal.cl
                foreach (Lokal l in ListaLokala)
                {
                    if (l.Oznaka.Contains(tbSearch.Text))
                    {
                        dataGridLokal.Items.Add(l);
                        //dgwTipovi.Rows[dgwTipovi.Rows.Count - 1].Tag = l;
                    }
                }

                //if (dgwTipovi.Rows.Count != 0) dgwTipovi.CurrentCell = dgwTipovi.Rows[0].Cells[0];
                //dgwTipovi_SelectionChanged(dgwTipovi, EventArgs.Empty);
            }*/
        }

        private void prikaziGresku(String poruka, String caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(poruka, caption, buttons, icon);
        }

    }
}
