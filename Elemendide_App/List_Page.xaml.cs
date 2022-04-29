using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        Entry en;
        MediaFile file;
        string imageName;
        string filePath;
        public List_Page()
        {
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon {Nimetus="Samsung Galaxy 22 Ultra", Tootja="Samsung",Hind="1349", Pilt="sam.jpg"},
                new Telefon {Nimetus="Xiaomi Mi 11 Lite", Tootja="Xiaomi",Hind="339"},
                new Telefon {Nimetus="Iphone 13 Pro Max", Tootja="Apple",Hind="1400"},
                new Telefon {Nimetus="Samsung Galaxy A52s 5G", Tootja="Samsung",Hind="450"}
            };
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            List = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Minu oma kolektion",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon filmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    Binding a = new Binding { Path = "Hind", StringFormat = "Hind: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, a);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;

                })
            };
            lisa = new Button { Text = "Lisa Telefon" };
            kustuta = new Button { Text = "Kustuta telefon" };
            List.ItemTapped += List_ItemTapped;
            kustuta.Clicked += Kustuta_Clicked;
            lisa.Clicked += Lisa_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, List, lisa, kustuta } };
        }

        private ObservableCollection<MediaFile> _images;
        public ObservableCollection<MediaFile> Images {
            get { return _images ?? (_images = new ObservableCollection<MediaFile>()); }
            set {
                if (_images != value)
                {
                    _images = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Allows the user to pick a photo on their device using the native photo handlers and returns a stream, which we save to disk.
        /// </summary>
        /// <returns>string, the name of the image if everything went ok, 'false' if an exception was generated, and 'notfalse' if they simply canceled.</returns>
        public async Task<string> PickPictureAsync()
        {

            file = null;
            filePath = string.Empty;
            imageName = string.Empty;

            try
            {
                file = await CrossMedia.Current.PickPhotoAsync();

                #region Null Check

                if (file == null) { return null; }                                                                                 //Not returning false here so we do not show an error if they simply hit cancel from the device image picker

                #endregion

                imageName = "SomeImageName.jpg";
                
    }
            catch (Exception ex)
            {
                Debug.WriteLine("\nIn PictureViewModel.PickPictureAsync() - Exception:\n{0}\n", ex);                           //TODO: Do something more useful
                return null;
            }
            finally { if (file != null) { file.Dispose(); } }


           
            return imageName;
        }
        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            
            //telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
            string site = await DisplayPromptAsync("Kakoi telefon ti hotes dobavit?", "Napishi ego", keyboard: Keyboard.Text);

            string site2 = await DisplayPromptAsync("Kakoi telefon ti hotes dobavit?", "Napishi ego", keyboard: Keyboard.Text);

            string site3 = await DisplayPromptAsync("Kakoi tsena?", "Napishi ego", keyboard: Keyboard.Numeric);
            PickPictureAsync();
            string site4 = imageName;
            telefons.Add(item: new Telefon { Nimetus = site, Tootja = site2, Hind = site3, Pilt = site4});

        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = List.SelectedItem as Telefon;
            if (phone != null)
            {
                telefons.Remove(phone);
                List.SelectedItem = null;
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja}-{selectedPhone.Nimetus}", "OK");
        }


    }
}