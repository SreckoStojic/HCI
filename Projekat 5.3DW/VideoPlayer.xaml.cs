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
using System.Windows.Threading;

namespace Projekat_5._3DW.ikonice
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : Window
    {
        DispatcherTimer timer;
        

        public VideoPlayer()
        {
            InitializeComponent();
            mediaElement1.Source = new Uri(@"C:\Users\Srecko\Desktop\Projekat 5.3DW\Projekat 5.3DW\ikonice\evidencija lokala.mp4");
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            slider2.Value = mediaElement1.Position.TotalSeconds;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            

            //mediaElement1.LoadedBehavior = MediaState.Manual;
           // mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)slider1.Value;
            
            VideoPreview.Visibility = Visibility.Collapsed;
            mediaElement1.Visibility = Visibility.Visible;
            mediaElement1.LoadedBehavior = MediaState.Play;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            VideoPreview.Visibility = Visibility.Collapsed;
            mediaElement1.LoadedBehavior = MediaState.Pause;
            //mediaElement1.Pause();
  
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            VideoPreview.Visibility = Visibility.Collapsed;
            mediaElement1.Visibility = Visibility.Visible;
            mediaElement1.LoadedBehavior = MediaState.Stop;
            
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement1.Volume = (double)slider1.Value;
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement1.Position = TimeSpan.FromSeconds(slider2.Value); 
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string filename = (string)((DataObject)e.Data).GetFileDropList()[0];
            mediaElement1.Source = new Uri(filename);

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)slider1.Value;
            mediaElement1.Play();
        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mediaElement1.NaturalDuration.TimeSpan;
            slider2.Maximum = ts.TotalSeconds;
            timer.Start();
        }
    }
}
