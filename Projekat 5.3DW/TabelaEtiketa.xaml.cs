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
    /// Interaction logic for TabelaEtiketa.xaml
    /// </summary>
    public partial class TabelaEtiketa : Window
    {
        private ObservableCollection<Etiketa> listaEtiketa = new ObservableCollection<Etiketa>();
        private DataEtikete dataEtikete = new DataEtikete();
        private Etiketa etiketa = new Etiketa();
        

        public TabelaEtiketa()
        {
            InitializeComponent();
            this.DataContext = this;
            textBox1.IsReadOnly = true;
            loadItems();
        }

        private void loadItems()
        {
            //DataEtikete dataEtikete = new DataEtikete();
            foreach (var et in dataEtikete.getAll())
            {
                listaEtiketa.Add(et.Value);
            }

            
        }

        public ObservableCollection<Etiketa> ListaEtiketa 
        {
            get
            {
                return listaEtiketa;
            }

            set {}
        
 
        }


        private void button4_Click(object sender, RoutedEventArgs e)
        {
            dataEtikete.ObrisiSve();
            foreach (Etiketa et in ListaEtiketa)
            {
                dataEtikete.Dodaj(et);
            }
            Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Da li želite da obrišete selektovani etiketu?";
            string caption = "Potvrda";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);

            if (result == MessageBoxResult.Yes)
            {

                listaEtiketa.Remove((Etiketa)dataGrid1.SelectedItem);
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window3 et = new Window3();
            et.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
