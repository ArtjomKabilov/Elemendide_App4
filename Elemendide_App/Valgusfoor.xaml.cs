using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        Label lb1, lb2, lb3;
        Grid gr1, gr2, gr3;
        Frame fr1, fr2, fr3;
        Button btn1, btn2;
        bool bl = false;
        public Valgusfoor()
        {
            this.BackgroundColor = Color.White;
            lb1 = new Label
            {
                Text = "Punane",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };
            lb2 = new Label
            {
                Text = "Kollane",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };
            lb3 = new Label
            {
                Text = "Roheline",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };
            fr1 = new Frame
            {
               Content = lb1,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            fr2 = new Frame
            {
                Content = lb2,

                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            fr3 = new Frame
            {
                Content = lb3,
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            btn1 = new Button
            {
                Text = "Sisse",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End

            };
            btn2 = new Button
            {
                Text = "Välja",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End

            };
            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
            StackLayout st = new StackLayout
            {
                Children = {fr1,fr2,fr3,btn1, btn2 }
            };
            Content = st;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            TapGestureRecognizer tap3 = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap2.Tapped += Tap2_Tapped;
            tap3.Tapped += Tap3_Tapped;
            fr1.GestureRecognizers.Add(tap);
            fr2.GestureRecognizers.Add(tap2);
            fr3.GestureRecognizers.Add(tap3);


        }

        private void Tap3_Tapped(object sender, EventArgs e)
        {
            if (bl)
            {
                if (fr3.BackgroundColor == Color.Green)
                {
                    lb3.Text = "Mine";
                }
                else if (fr3.BackgroundColor == Color.Gray)
                {
                    lb3.Text = "Roheline";
                }
                
            }
            else
            {
                lb3.Text = "Palun lülitage valgusfoor sisse";
            }
        }

        private void Tap2_Tapped(object sender, EventArgs e)
        {
            if (bl)
            {
                if (fr2.BackgroundColor == Color.Yellow)
                {
                    lb2.Text = "Oota";
                }
                else if (fr2.BackgroundColor == Color.Gray)
                {
                    lb2.Text = "Kollane";
                }
                
            }
            else
            {
                lb2.Text = "Palun lülitage valgusfoor sisse";
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (bl)
            {
                if (fr1.BackgroundColor == Color.Red)
                {
                    lb1.Text = "STOP";
                }
                else if (fr1.BackgroundColor == Color.Gray)
                {
                    lb1.Text = "Punane";
                }
                
            }
            else
            {
                lb1.Text = "Palun lülitage valgusfoor sisse";
            }
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            bl = false;
            this.BackgroundColor = Color.White;
            fr1.BackgroundColor = Color.Gray;
            fr2.BackgroundColor = Color.Gray;
            fr3.BackgroundColor = Color.Gray;
            lb1.Text = "Punane";
            lb2.Text = "Kollane";
            lb3.Text = "Roheline";
        }

        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            bl = true;
            if (bl)
            {
                lb1.Text = "Punane";
                lb2.Text = "Kollane";
                lb3.Text = "Roheline";
            }
            if (fr1.BackgroundColor == Color.Gray)
            {
                lb1.Text = "Punane";
            }
            if (fr2.BackgroundColor == Color.Gray)
            {
                lb2.Text = "Kollane";
            }
            if (fr1.BackgroundColor == Color.Gray)
            {
                lb3.Text = "Roheline";
            }
            while (bl)
            {
                
                this.BackgroundColor = Color.LightGreen;
                fr1.BackgroundColor = Color.Red;
                await Task.Delay(1000);
                fr1.BackgroundColor = Color.Gray;
                fr2.BackgroundColor = Color.Yellow;
                await Task.Delay(1000);
                fr2.BackgroundColor = Color.Gray;
                await Task.Delay(500);
                fr3.BackgroundColor = Color.Green;
                await Task.Delay(500);
                fr3.BackgroundColor = Color.Gray;
                await Task.Delay(500);
                fr3.BackgroundColor = Color.Green;
                await Task.Delay(500);
                fr3.BackgroundColor = Color.Gray;
                await Task.Delay(500);
                fr3.BackgroundColor = Color.Green;
                await Task.Delay(500);
                fr3.BackgroundColor = Color.Gray;
            }
            
        }
    }
}