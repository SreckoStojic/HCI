using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Tip tip = new Tip();
        private DataTipovi dataTipovi = new DataTipovi();
        private OpenFileDialog fileDialog = new OpenFileDialog();

        private Regex rx_oznaka = new Regex("[^a-z0-9]+");

        public Window2()
        {
            InitializeComponent();
            this.DataContext = tip;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Boolean dozvolaCuvanjaOznaka = false;
            Boolean dozvolaCuvanjaIme = false;
           

            int dozvola = -1;

            String oznaka = tbOznakaTipa.Text;
            if (oznaka != "")
            {
                dozvolaCuvanjaOznaka = true;
                if (dataTipovi.getAll().Count() != 0)
                {

                    foreach (var l in dataTipovi.getAll())
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


            if (tbNazivTipa.Text.ToString() != "")
            {
                dozvolaCuvanjaIme = true;
            }
            else
            {
                dozvolaCuvanjaIme = false;
            }


            if (dozvolaCuvanjaOznaka == true && dozvolaCuvanjaIme == true)
            {
                dataTipovi.Dodaj(tip);
                string message = "Tip lokala " + tbNazivTipa.Text + " je kreiran!";
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
                tbOznakaTipa.Focus();
            }
            else if (tbOznakaTipa.Text.ToString() == "" && tbNazivTipa.Text.ToString() == "")
            {
                string message = "Polja za oznaku i naziv tipa ne smeju biti prazni!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                tbOznakaTipa.Focus();
            }
            else if (tbNazivTipa.Text.ToString() == "" && tbOznakaTipa.Text.ToString() != "")
            {
                string message = "Naziv lokala ne sme biti prazan!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                tbNazivTipa.Focus();
            }
            else if (tbOznakaTipa.Text.ToString() == "" && tbNazivTipa.Text.ToString() != "")
            {
                string message = "Polje oznaka ne sme biti prazno!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                tbOznakaTipa.Focus();
            }
            
        }
            
        

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void tbOznakaTipa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = rx_oznaka.IsMatch(e.Text);

            if (tbOznakaTipa.Text.Count() > 20)
            {
                string message = "Oznaka tipa lokala ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                tbOznakaTipa.Clear();
                tbOznakaTipa.Focus();
            }
        }

        private void prikaziGresku(String poruka, String caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(poruka, caption, buttons, icon);
        }

        private void tbNazivTipa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (tbNazivTipa.Text.Count() > 20)
            {
                string message = "Naziv tipa lokala ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                prikaziGresku(message, caption);
                tbNazivTipa.Clear();
                tbNazivTipa.Focus();
            }
        }

        private void textBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox3.Text.Count() > 250)
            {
                string message = "Opis tipa lokala ne sme imati vise od 250 karaktera!";
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

    }
}
