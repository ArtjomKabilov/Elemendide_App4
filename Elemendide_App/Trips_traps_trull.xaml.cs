using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Trips_traps_trull : ContentPage
    {
        public bool esimene;
        int tulemus = 2;
        int[,] Tulemused = new int[3, 3] { { 5, 5, 5 }, { 5, 5, 5 }, { 5, 5, 5 } };
        Grid g, g2;
        Button uus_mang, button;
        Image img;
        bool x = false;
        List<Image> newList=new List<Image>();

        public Trips_traps_trull()
        {
            g = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };

            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            button = new Button()
            {
                Text = "Muutke taustavärvi"
            };
            g.Children.Add(uus_mang, 0, 1);
            g.Children.Add(button, 0, 2);
            uus_mang.Clicked += Uus_mang_Clicked;
            button.Clicked += Button_Clicked;
            Content = g;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int i=0;
            Random r = new Random();
            g.BackgroundColor = Color.FromRgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 225));
            g2.BackgroundColor = Color.FromRgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 225));
            i++;
            try
            {
               
                Vibration.Vibrate();

                
                var duration = TimeSpan.FromSeconds(0.1);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                
            }
            catch (Exception ex)
            {
               
            }

        }

        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Krestik-1 või Nolik-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (esimene_valik == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();
            
        }

        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                Kes_on_esimene();
                int[,] Tulemused = new int[3, 3];
                tulemus = 2;
                g2 = new Grid
                {
                    BackgroundColor = Color.White,
                    RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                    ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        img = new Image();
                        img.Source = ImageSource.FromFile("index.png");
                        g2.Children.Add(img, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        img.GestureRecognizers.Add(tap);
                    }
                }
                g.Children.Add(g2, 0, 0);
            }

        }

        public int Kontroll()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }

            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }

            else if (Tulemused[0, 0] == 0 && Tulemused[1, 0] == 0 && Tulemused[2, 0] == 0 || Tulemused[0, 1] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 1] == 0 || Tulemused[0, 2] == 0 && Tulemused[1, 2] == 0 && Tulemused[2, 2] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[0, 1] == 0 && Tulemused[0, 2] == 0 || Tulemused[1, 0] == 0 && Tulemused[1, 1] == 0 && Tulemused[1, 2] == 0 || Tulemused[2, 0] == 0 && Tulemused[2, 1] == 0 && Tulemused[2, 2] == 0)
            {
                tulemus = 0;
            }
            else if (Tulemused[0, 0] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 2] == 0 || Tulemused[0, 2] == 0 && Tulemused[1, 1] == 0 && Tulemused[2, 0] == 0)
            {
                tulemus = 0;
            }


            return tulemus;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Krestik on võitja!", "Ok");
            }
            else if (tulemus == 0)
            {
                DisplayAlert("Võit", "Nolik on võitja!", "Ok");
            }
            /*else if(tulemus != 0 && tulemus != 1)
            {
                DisplayAlert("Võit", "See on viit!", "Ok");
            }*/
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var img = (Image)sender;
            var r = Grid.GetRow(img);
            var c = Grid.GetColumn(img);
            if (esimene == true)
            {
                img.Source = ImageSource.FromFile("krestik.png");
                img.GestureRecognizers.Clear();
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                img.Source = ImageSource.FromFile("nolik.png");
                img.GestureRecognizers.Clear();
                esimene = true;
                Tulemused[r, c] = 0;
            }
            g2.Children.Add(img, c, r);
            Lopp();

        } 

    }
}
