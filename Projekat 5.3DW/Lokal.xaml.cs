using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using Projekat_5._3DW.podaci;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace Projekat_5._3DW
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Lokal lokal = new Lokal();
        private DataLokali dataLokali = new DataLokali();
        //private ObservableCollection<String> tipovi = new ObservableCollection<String>();
        private OpenFileDialog fileDialog = new OpenFileDialog();
        private Regex rx_oznaka = new Regex("[^a-z0-9]+");
        private Regex rx_ime = null;
        private Regex rx_datum = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])\-(0?[1-9]|1[012])\-\d{4}$");

        public Window1()
        {
            InitializeComponent();
            this.DataContext = lokal;
        }


  

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            Boolean dozvolaCuvanjaOznaka = false;
            Boolean dozvolaCuvanjaIme = false;
            Boolean dozvolaDatum = false;

            int dozvola = -1;

            String oznaka = textBox1.Text;
            if (oznaka != "")
            {
                dozvolaCuvanjaOznaka = true;
                if (dataLokali.getAll().Count() != 0)
                {

                    foreach (var l in dataLokali.getAll())
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

            if (rx_datum.Match(textBox6.Text).ToString() == textBox6.Text.ToString())
            {
                dozvolaDatum = true;
            }
            else 
            {
                dozvolaDatum = false;
            }

            if (ime_lokala.Text.ToString() != "")
            {
                dozvolaCuvanjaIme = true;
            }
            else
            {
                dozvolaCuvanjaIme = false;
            }

            
            if (dozvolaCuvanjaOznaka == true && dozvolaCuvanjaIme == true && dozvolaDatum == true)
            {
                dataLokali.Dodaj(lokal);
                string message = "Lokal " + ime_lokala.Text + " je kreiran!";
                string caption = "Obavestenje!";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
                Close();
            }
            else if (dozvola == 1)
            {
                string message = "Oznaka lokala koju ste uneli je zauzeta!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Focus();
            }
            else if (textBox1.Text.ToString() == ""  && ime_lokala.Text.ToString() == "")
            {
                string message = "Polja za oznaku i naziv ne smeju biti prazni!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Focus();
            }
            else if (ime_lokala.Text.ToString() == "" && textBox1.Text.ToString() != "")
            {
                string message = "Naziv lokala ne sme biti prazan!";
                string caption = "Obavestenje!"; 
                prikaziGresku(message, caption);
                ime_lokala.Focus();
            }
            else if (textBox1.Text.ToString() == "" && ime_lokala.Text.ToString() != "")
            {
                string message = "Polje oznaka ne sme biti prazno!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Focus();
            }
            else if(dozvolaDatum == false)
            {
                string message = "Datum mora biti u obliku: dd-mm-yyyy";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox6.Focus();
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (fileDialog.ShowDialog() == true)
            {
                string fname = fileDialog.FileName;
                image1.Source = new BitmapImage(new Uri(fname));
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /*private void novi_tip_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 tip = new Window2();
            tip.Show();
             
            textBox4.Items.Refresh();

        }*/

        /*private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window3 etiketa = new Window3();
            etiketa.Show();
        }*/

       

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = rx_oznaka.IsMatch(e.Text);

            if (textBox1.Text.Count() > 20)
            {
                string message = "Oznaka lokala ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox1.Clear();
                textBox1.Focus();
            }
           
        }

    
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach (String v in e.AddedItems)
            {
                lokal._etikete.Add(v);   
            }

            foreach (String v in e.RemovedItems)
            {
                lokal._etikete.Remove(v);
            }
        }

        private void prikaziGresku(String poruka, String caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(poruka, caption, buttons, icon);
        }

        private void ime_lokala_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (ime_lokala.Text.Count() > 20)
            {
                string message = "Naziv lokala ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                ime_lokala.Clear();
                ime_lokala.Focus();
            }
        }

        private void textBox5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox5.Text.Count() > 5)
            {
                string message = "Kapacitet lokala ne sme imati vise od 5 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox5.Clear();
                textBox5.Focus();
            }
        }

        private void textBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox3.Text.Count() > 250)
            {
                string message = "Opis lokala ne sme imati vise od 250 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                textBox3.Clear();
                textBox3.Focus();
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }
        public void doThings(string param)
        {
            //btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }

    }
}
