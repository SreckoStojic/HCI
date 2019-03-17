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

namespace Projekat_5._3DW
{
    /// <summary>
    /// Interaction logic for TabelaTipova.xaml
    /// </summary>
    public partial class TabelaTipova : Window
    {
        private ObservableCollection<Tip> listaTipova = new ObservableCollection<Tip>();
        private DataTipovi dataTipovi = new DataTipovi();
        private Tip tip = new Tip();

        public TabelaTipova()
        {
            InitializeComponent();
            this.DataContext = this;
            textBox1.IsReadOnly = true;
            loadItems();
        }

        private void loadItems()
        {
            //DataEtikete dataEtikete = new DataEtikete();
            foreach (var t in dataTipovi.getAll())
            {
                listaTipova.Add(t.Value);
            }

            
        }

        public ObservableCollection<Tip> ListaTipova 
        {
            get
            {
                return listaTipova;
            }

            set {}
        
 
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

            Boolean dozvolaCuvanjaIme = false;

            if (textBox3.Text.ToString() != "")
            {
                dozvolaCuvanjaIme = true;
            }
            else
            {
                dozvolaCuvanjaIme = false;
            }

            if (dozvolaCuvanjaIme == true)
            {
                dataTipovi.ObrisiSve();
                foreach (Tip t in ListaTipova)
                {
                    dataTipovi.Dodaj(t);
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
            
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window2 tip = new Window2();
            tip.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Da li želite da obrišete selektovani tip lokala?";
            string caption = "Potvrda";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);

            if (result == MessageBoxResult.Yes)
            {

                listaTipova.Remove((Tip)dataGridTip.SelectedItem);
            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void prikaziGresku(String poruka, String caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(poruka, caption, buttons, icon);
       } 
    }
}
