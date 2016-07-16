using System;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsApp1.Views
{
    public sealed partial class MainPage : Page
    {
        List<Elemento> allItems;
        private Run NameTemplate = new Run()
        {
            Foreground = new SolidColorBrush(Color.FromArgb(0, 0, 0, 80)),
            FontStyle = Windows.UI.Text.FontStyle.Oblique
        };

        private Run ContentTemplate = new Run()
        {
            Foreground = new SolidColorBrush(Color.FromArgb(0, 0, 0, 60)),
            FontStyle = Windows.UI.Text.FontStyle.Normal
        };

        public MainPage()
        {
            InitializeComponent();
            Parser.Initialize();
            ElementLV.IsItemClickEnabled = true;
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // populate list
            ObservableCollection<Elemento> list = new ObservableCollection<Elemento>(Parser.Elementos);
            allItems = new List<Elemento>(list);
            ElementLV.ItemsSource = list;
        }

        private void InputTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = InputTB.Text;

            Predicate<Elemento> matchPredicate = x =>
            {
                return x.Name.ToLower().Contains(text.ToLower()) || x.Symbol.ToLower().Contains(text.ToLower()) || x.ANumber == text;
            };

            List<Elemento> filteredItems = allItems.FindAll(matchPredicate);
            this.ElementLV.ItemsSource = filteredItems;
        }

        private void ElementLV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Elemento clicado = (Elemento)e.ClickedItem;
            ElementLB.Text = String.Format("{0} ({1})", clicado.Name, clicado.Symbol.Replace(" ", ""));

            // load UI elements
            PropLV.Items.Clear();
            IsotopesLV.Items.Clear();
            AtomImageLV.Items.Clear();

            PropLV.Items.Add(new ElementProperty("Atomic Number:", clicado.ANumber));
            PropLV.Items.Add(new ElementProperty("Atomic Mass:", clicado.AMass));
            PropLV.Items.Add(new ElementProperty("Boiling Point:", clicado.BP));
            PropLV.Items.Add(new ElementProperty("Melting Point:", clicado.MP));
            PropLV.Items.Add(new ElementProperty("Protons and Electrons:", clicado.NoPE));
            PropLV.Items.Add(new ElementProperty("Classification: ", clicado.Classification));
            PropLV.Items.Add(new ElementProperty("Density:", clicado.Density));
            PropLV.Items.Add(new ElementProperty("Color:", clicado.Color));
            PropLV.Items.Add(new ElementProperty("Crystal Structure:", clicado.CrystalGeo));

            // update isotopes
            IsotopesLV.Items.Add(new ElementProperty("Isotopes", clicado.Name));
            foreach(KeyValuePair<string, string> kv in clicado.Isotopes)
            {
                ElementProperty prop = new ElementProperty(kv.Key, " " + kv.Value);
                IsotopesLV.Items.Add(prop);
            }

            // update image
            ImageProperty ip = new ImageProperty(new BitmapImage(
   new Uri(clicado.AtomicStructureImage, UriKind.Absolute)));
            AtomImageLV.Items.Add(ip);
        }
    }
}
