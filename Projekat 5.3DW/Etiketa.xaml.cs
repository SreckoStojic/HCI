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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.DataGrid;
using Projekat_5._3DW.podaci;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace Projekat_5._3DW
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private Etiketa etiketa = new Etiketa();
        private DataEtikete dataEtikete = new DataEtikete();
        private Regex rx_oznaka = new Regex("[^a-z0-9]+");
        

        public Window3()
        {

            InitializeComponent();
            this.DataContext = etiketa;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            Boolean dozvolaCuvanjaOznaka = false;
            
            int dozvola = -1;

            String oznaka = textBox1.Text;
            if (oznaka != "")
            {
                dozvolaCuvanjaOznaka = true;
                if (dataEtikete.getAll().Count() != 0)
                {

                    foreach (var l in dataEtikete.getAll())
                    {
                        if (oznaka.Equals(l.Value.Oznaka.ToString()))
                        {
                            dozvolaCuvanjaOznaka = false;
                            dozvola = 1;
                            break;
                        }

                    }
                }
            }


            if (dozvolaCuvanjaOznaka == true)
            {
                dataEtikete.Dodaj(etiketa);
                string message = "Etiketa sa oznakom " + textBox1.Text + " je kreirana!";
                string caption = "Obavestenje!";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);
                Close();
            }
            else if (dozvola == 1)
            {
                string message = "Oznaka lokala koju ste uneli je zauzeta!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Focus();
            }
            else if (textBox1.Text.ToString() == "")
            {
                string message = "Polje oznaka ne sme biti prazno!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Focus();
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
            MessageBoxResult result = System.Windows.MessageBox.Show(poruka, caption, buttons, icon);
        }

        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox2.Text.Count() > 250)
            {
                string message = "Opis etikete ne sme imati vise od 250 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void textBox1_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = rx_oznaka.IsMatch(e.Text);

            if (textBox1.Text.Count() > 20)
            {
                string message = "Oznaka etikete ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Clear();
                textBox1.Focus();
            }
        }

      

      
    }
}
