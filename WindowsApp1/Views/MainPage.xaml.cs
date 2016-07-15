using System;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI;

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

            // load element UI
            ANumberTB.Text = clicado.ANumber;
            ANumberTB1.Text = clicado.AMass;
            ANumberTB2.Text = clicado.MP;
            ANumberTB3.Text = clicado.BP;
            ANumberTB4.Text = clicado.NoPE;
            ANumberTB5.Text = clicado.Classification;
            ANumberTB6.Text = clicado.Density;
            ANumberTB7.Text = clicado.Color;
            ANumberTB8.Text = clicado.CrystalGeo; 
        }

        private void AddPropertyInlines(TextBlock tb, string name, string content)
        {
            Run _name = NameTemplate;
            Run _content = ContentTemplate;

            _name.Text = name;
            _content.Text = content;

            AddPropertyInlines(tb, _name, _content);
        }

        private void AddPropertyInlines(TextBlock tb, Run name, Run content)
        {
            AddInlines(tb, new Run[] { name, content });
        }

        private void AddInlines(TextBlock tb, params Run[] data)
        {
            tb.Inlines.Clear();

            for (int i = 0; i < data.Length; ++i)
                tb.Inlines.Add(data[i]);
        }
    }
}
