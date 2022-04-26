using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List_Page : ContentPage
    {
        public ObservableCollection<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView List;
        Button lisa, kustuta;
        public List_Page()
        {
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy 22 Ultra", Tootja="Samsung",Hind=1349, Pilt="sam.jpg"},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite", Tootja="Xiaomi",Hind=339},
                new Telefon {Nimetus="Iphone 13 Pro Max", Tootja="Apple",Hind=1400},
                new Telefon {Nimetus="Samsung Galaxy A52s 5G", Tootja="Samsung",Hind=450}
            };
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            List = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon filmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;

                })
            };
            lisa = new Button { Text = "Lisa felefon" };
            kustuta = new Button { Text = "Kustuta telefn" };
            List.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, List, lisa, kustuta } };
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja}-{selectedPhone.Nimetus}", "OK");
        }


    }
}