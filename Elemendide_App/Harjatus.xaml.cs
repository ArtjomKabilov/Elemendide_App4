using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendide_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Harjatus : ContentPage
    {
        Picker p, p2;
        FlexLayout fl;
        Image img;
        StackLayout st;
        WebView webView;
        List<string> lehed = new List<string>() { "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-xaryumaa/"
            , "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-jygevamaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-xijumaa/",
            "https://triptoestonia.com/ida-virumaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-yarvamaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-lyaenemaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-lyaene-virumaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-pyarnumaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-pylvamaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-raplamaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-saaremaa/",
            "https://triptoestonia.com/et/tartumaa/",
            "https://triptoestonia.com/et/valgamaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-vilyandimaa/",
            "https://triptoestonia.com/et/uezdy-estonii/estonskij-uezd-vyrumaa/" };
        public Harjatus()
        {
            
            p = new Picker
            {
                Title = "Maakonnad",
                VerticalOptions = LayoutOptions.Start

            };
            p.Items.Add("Harjumaa");
            p.Items.Add("Jõgevamaa");
            p.Items.Add("Hiiumaa");
            p.Items.Add("Ida-Virumaa");
            p.Items.Add("Järvamaa");
            p.Items.Add("Läänemaa");
            p.Items.Add("Lääne-Viruma");
            p.Items.Add("Pärnumaa");
            p.Items.Add("Põlvamaa");
            p.Items.Add("Raplamaa");
            p.Items.Add("Saaremaa");
            p.Items.Add("Tartumaa");
            p.Items.Add("Valgamaa");
            p.Items.Add("Viljandimaa");
            p.Items.Add("Võrumaa");
            p2 = new Picker
            {
                Title = "Maakonna pealinn"
            };
            p2.Items.Add("Tallinn");
            p2.Items.Add("Jõgeva");
            p2.Items.Add("Kärdla");
            p2.Items.Add("Jõhvi");
            p2.Items.Add("Paide");
            p2.Items.Add("Haapsalu");
            p2.Items.Add("Rakvere");
            p2.Items.Add("Pärnu");
            p2.Items.Add("Põlva");
            p2.Items.Add("Rapla");
            p2.Items.Add("Kuressaare");
            p2.Items.Add("Tartu");
            p2.Items.Add("Valga");
            p2.Items.Add("Viljandi");
            p2.Items.Add("Võru");
            webView = new WebView
            { };
            st = new StackLayout { Children = { p, p2 } };
            Content = st;
            
            p.SelectedIndexChanged += P_SelectedIndexChanged;
            p2.SelectedIndexChanged += P2_SelectedIndexChanged;
        }

        

        private async void P2_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.SelectedIndex = p2.SelectedIndex;
            //bool answer = await DisplayAlert("Maakonnad?", "Kas soovite teada midagi uut ? ", "Jah", "Ei");
            //Debug.WriteLine("Vastus: " + answer);
            //if (answer == true)
            //{
               /* if (webView != null)
                {
                    st.Children.Remove(webView);
                }
                webView = new WebView
                {
                    Source = new UrlWebViewSource { Url = lehed[p2.SelectedIndex] },
                    VerticalOptions = LayoutOptions.End,
                };
                st.Children.Add(webView);*/
            //}
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[p2.SelectedIndex] },
                VerticalOptions = LayoutOptions.End,
            };
            st.Children.Add(webView);
        }
        private async void P_SelectedIndexChanged(object sender, EventArgs e)
        {

            p2.SelectedIndex = p.SelectedIndex;
            bool answer = await DisplayAlert("Maakonnad?", "Kas soovite teada midagi uut ? ", "Jah", "Ei");
            Debug.WriteLine("Vastus: " + answer);
            if (answer == true)
            {
                if (webView != null)
                {
                    st.Children.Remove(webView);
                }
                webView = new WebView
                {
                    Source = new UrlWebViewSource { Url = lehed[p.SelectedIndex] },
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };
                st.Children.Add(webView);
            }
            
        }
    }
}