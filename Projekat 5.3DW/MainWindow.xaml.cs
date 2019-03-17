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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Projekat_5._3DW.podaci;
using Projekat_5._3DW.ikonice;

namespace Projekat_5._3DW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window1 lokal;
        private Window2 tip;
        private Window3 etiketa;
        private TabelaLokala tabelaLokala;  //lokali
        private TabelaTipova tabelaTipova;
        private TabelaEtiketa tabelaEtiketa;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Lokal_Click(object sender, RoutedEventArgs e)
        {
            lokal = new Window1();
            lokal.Show();
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            tip = new Window2();
            tip.Show();
        }

        private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            etiketa = new Window3();
            etiketa.Show();
        }

        private void Mapa_Click(object sender, RoutedEventArgs e)
        {
            Mapa mapa = new Mapa();
            //ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "ikonice/mapaNS.PNG")));
            //mapa.Background = myBrush;
            mapa.Show();
        }

        private void Tabela_lokala_Click(object sender, RoutedEventArgs e)
        {
            tabelaLokala = new TabelaLokala();
            tabelaLokala.Show();
        }

        private void Tabela_tipova_Click(object sender, RoutedEventArgs e)
        {
            tabelaTipova = new TabelaTipova();
            tabelaTipova.Show();
        }

        private void Tabela_etiketa_Click(object sender, RoutedEventArgs e)
        {
            tabelaEtiketa = new TabelaEtiketa();
            tabelaEtiketa.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayer vp = new VideoPlayer();
            vp.Show();
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
