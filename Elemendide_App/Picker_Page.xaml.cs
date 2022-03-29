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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        Button btn, btn2,btn3,btn4;
        StackLayout st,sb;
        List<string> lehed = new List<string>() { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.google.ee" };
        //string[] lehed = new string[4] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.google.ee" };
        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };
            picker.Items.Add("tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Google");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView
            { };
            btn = new Button
            {
                Text = "Uus webilehed",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };
            btn2 = new Button
            {
                Text = "kodu",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };
            btn3 = new Button
            {
                Text = "<-",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            btn4 = new Button
            {
                Text = "->",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            webView.GestureRecognizers.Add(swipe);
            btn2.Clicked += Btn2_Clicked;
            btn.Clicked += Btn_Clicked;
            btn3.Clicked += Btn3_Clicked;
            btn4.Clicked += Btn4_Clicked;
            st = new StackLayout { Children = { picker, btn, btn2,btn3,btn4 } };
            //sb = new StackLayout { Children = { btn2 } };
            Content = st;
            //Content = sb;
        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoForward();
            }
        }

        public async void Btn3_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                
                webView.GoBack();
            }
        }

        public async void Btn2_Clicked(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://www.google.ee" },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        public async void Btn_Clicked(object sender, EventArgs e)
        {
            string site = await DisplayPromptAsync("Kakoi sait ti hotes?", "Napishi ego", initialValue: "https://", keyboard: Keyboard.Text);
            lehed.Add(site);
            string site2 = await DisplayPromptAsync("Kakoi sait ti hotes?", "Napishi ego nazanie", initialValue: "", keyboard: Keyboard.Text);
            picker.Items.Add(site2);
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = site },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
           
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[4] };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView!=null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,     
            };
            st.Children.Add(webView);
        }
    }
}