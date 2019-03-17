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
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa : Window
    {
        private ObservableCollection<Lokal> listaLokala = new ObservableCollection<Lokal>();
        private DataLokali dataLokali = new DataLokali();
        Point startPoint = new Point();
        Point endPoint = new Point();

        public static string lokalOznaka;
        public static Button bu = new Button();
        public static Image ukloniSliku;

        public static ObservableCollection<Lokal> ListaLokalaCopy
        {
            get;
            set;
        }

        public Mapa()
        {
            InitializeComponent();
            this.DataContext = this;
            loadItems();
        }

        private void loadItems()
        {
            //DataEtikete dataEtikete = new DataEtikete();
            ListaLokalaCopy = new ObservableCollection<Lokal>();
            foreach (var l in dataLokali.getAll())
            {
                listaLokala.Add(l.Value);
                ListaLokalaCopy.Add(l.Value);
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

       
        private void DragImage(object sender, MouseButtonEventArgs e)
        {
            
            Image image = e.Source as Image;
            lokalOznaka = image.Tag.ToString();
            if (image != null)
            {
                DataObject data = new DataObject(typeof(ImageSource), image.Source);
                DragDrop.DoDragDrop(image, data, DragDropEffects.All);
            }
           
        }

        private void DropImage(object sender, DragEventArgs e)
        {
            Vector diff = startPoint - endPoint;

            Image imageControl = new Image();
            if (imageControl != null)
            {
                if ((e.Data.GetData(typeof(ImageSource)) != null))
                {
                    ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
                    imageControl = new Image() { Width = 50, Height = 30, Source = image };
                }
                else
                {
                    if ((e.Data.GetData(typeof(Image)) != null))
                    {
                        Image image = e.Data.GetData(typeof(Image)) as Image;
                        imageControl = image;
                       
                    }

                }

                if (this.Canvas.Children.Contains(imageControl))
                {
                    imageControl.MouseLeftButtonDown -= imageControl_MouseLeftButtonDown;
                    this.Canvas.Children.Remove(imageControl);
                }


                foreach (Lokal l in ListaLokala)
                {
                    if (l.Oznaka.Equals(lokalOznaka))
                    {
                        ListaLokala.Remove(l);
                        break;
                    }
                }

                imageControl.Tag = lokalOznaka;


                Canvas.SetLeft(imageControl, e.GetPosition(this.Canvas).X);
                Canvas.SetTop(imageControl, e.GetPosition(this.Canvas).Y);
                imageControl.MouseLeftButtonDown += imageControl_MouseLeftButtonDown;
                this.Canvas.Children.Add(imageControl);



            }
        }


        void imageControl_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            Point endPoint = e.GetPosition(null);
            Vector diff = startPoint - endPoint;
            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image image = e.Source as Image;
                if (image != null)
                {
                
                    DataObject data = new DataObject(typeof(Image), image);
                    DragDrop.DoDragDrop(image, data, DragDropEffects.All);
                }
            }
           
        }


        private void LeftDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            if (Canvas.Children.Contains(bu))
            {
                Canvas.Children.Remove(bu);
            }
        }

        private void LeftUp(object sender, MouseButtonEventArgs e)
        {
            endPoint = e.GetPosition(null);
        }

        private void RightMouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            if (image != null)
            {
                ukloniSliku = image;
                bu.Height = 30;
                bu.Width = 100;
                bu.FontSize = 14;
                bu.Content = "Ukloni sa mape";
                bu.Click += leftDownUkloni;
                if (Canvas.Children.Contains(bu))
                {
                    Canvas.Children.Remove(bu);
                    bu.Click -= leftDownUkloni;
                }
                Canvas.SetLeft(bu, e.GetPosition(this.Canvas).X);
                Canvas.SetTop(bu, e.GetPosition(this.Canvas).Y);
                Canvas.Children.Add(bu);

            }
        }

        void leftDownUkloni(object sender, RoutedEventArgs e)
        {
            lokalOznaka = ukloniSliku.Tag.ToString();
            this.Canvas.Children.Remove(ukloniSliku);
            foreach (Lokal r in ListaLokalaCopy)
            {
                if (r.Oznaka == lokalOznaka)
                {
                    if (!ListaLokala.Contains(r))
                        ListaLokala.Add(r);
                }
            }
            Canvas.Children.Remove(bu);
        }
     

        private void mouseDownImage(object sender, MouseButtonEventArgs e)
        {
           /* Image image = e.Source as Image;
           
            if (e.ClickCount == 2 && image != null)
            {
                PrikazLokalaIzMape prikazLokalaIzMape = new PrikazLokalaIzMape();
                prikazLokalaIzMape.Show();
            }*/
        }

    }
}
