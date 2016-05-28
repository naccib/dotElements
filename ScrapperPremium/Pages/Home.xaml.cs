using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Drawing;

namespace ScrapperPremium.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private BackgroundWorker BGWorker;
        public string SourceCode = null;
        public string URLFormat = "http://www.chemicalelements.com/elements/{0}.html";
        public string elementString = "h";
        public bool SearchByName = true;
        private Elemento returnElement = null;
        private string IsotopesString;

        public Home()
        {
            InitializeComponent();
            InitializeWorker();

            
        }

        public void InitializeWorker()
        {
            BGWorker = new BackgroundWorker();
            BGWorker.WorkerReportsProgress = true;

            BGWorker.DoWork += delegate
            {
                this.returnElement = AgilityParser.Parse(new System.Net.WebClient().DownloadString(string.Format(URLFormat, elementString)));
            };

            BGWorker.RunWorkerCompleted += BGWorker_RunWorkerCompleted;
            BGWorker.ProgressChanged += BGWorker_ProgressChanged;
        }

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(this.returnElement.GetBasicElemString());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            BGWorker.RunWorkerAsync();
        }

        private void ImageToChange_MouseEnter(object sender, MouseEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 1);

            ImageToChange.ChangeSource(new BitmapImage(new Uri(@"Resources/search_hover.png")), ts, ts);
        }
    }

    public static class ImageChanger
    {
        public static void ChangeSource(
    this System.Windows.Controls.Image image, ImageSource source, TimeSpan fadeOutTime, TimeSpan fadeInTime)
        {
            var fadeInAnimation = new DoubleAnimation(1d, fadeInTime);

            if (image.Source != null)
            {
                var fadeOutAnimation = new DoubleAnimation(0d, fadeOutTime);

                fadeOutAnimation.Completed += (o, e) =>
                {
                    image.Source = source;
                    image.BeginAnimation(System.Windows.Controls.Image.OpacityProperty, fadeInAnimation);
                };

                image.BeginAnimation(System.Windows.Controls.Image.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                image.Opacity = 0d;
                image.Source = source;
                image.BeginAnimation(System.Windows.Controls.Image.OpacityProperty, fadeInAnimation);
            }
        }
    }
}
