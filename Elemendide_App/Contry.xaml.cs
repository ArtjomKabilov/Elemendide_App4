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
    public partial class Contry : ContentPage
    {
        public ObservableCollection<Country> Countrys { get; set; }
        Label lbl_list;
        ListView List;
        Button lisa, kustuta;
        Entry en;
        MediaFile file;
        string imageName;
        string filePath;
        public Contry()
        {
            Countrys = new ObservableCollection<Country>
            {
                new Country {Nimetus="Eesti", Kapitali="Tallinn",Elanikkonnast="1328439", lipp="eesti.jpg"}
            };
            lbl_list = new Label
            {
                Text = "Riikide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            List = new ListView
            {
                SeparatorColor = Color.AliceBlue,
                Header = "Riik",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = Countrys,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.White, DetailColor = Color.White };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Kapitali", StringFormat = " {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    Binding a = new Binding { Path = "Elanikkonnast", StringFormat = "Elanikkonnast: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, a);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "lipp");
                    return imageCell;

                })
            };
            lisa = new Button { Text = "Lisa riik" };
            kustuta = new Button { Text = "Kustuta riik" };
            List.ItemTapped += List_ItemTapped;
            kustuta.Clicked += Kustuta_Clicked;
            lisa.Clicked += Lisa_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, List, lisa, kustuta } };
        }
        public List<string> Uris;
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
            string site = await DisplayPromptAsync("Kakoi stranu ti hotes dobavit?", "Napishi ego", keyboard: Keyboard.Text);

            string site2 = await DisplayPromptAsync("Kakoi u nee stolitsa?", "Napishi ego", keyboard: Keyboard.Text);

            string site3 = await DisplayPromptAsync("Kakoi kolitestvo naroda tam zivot?", "Napishi ego", keyboard: Keyboard.Numeric);
            PickPictureAsync();
            var site4 = Images;

            Countrys.Add(item: new Country { Nimetus = site, Kapitali = site2, Elanikkonnast = site3, lipp = site4.ToString() });

        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Country country = List.SelectedItem as Country;
            if (country != null)
            {
                Countrys.Remove(country);
                List.SelectedItem = null;
            }
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Country selectedPhone = e.Item as Country;
            if (selectedPhone != null)
                await DisplayAlert("Riik", $"{selectedPhone.Kapitali}-{selectedPhone.Nimetus}", "OK");
        }


    }
}