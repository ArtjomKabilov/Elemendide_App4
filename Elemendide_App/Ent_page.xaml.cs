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
    public partial class Ent_page : ContentPage
    {
        Editor ed;
        Label lb;
        public Ent_page()
        {
            //InitializeComponent();
            //StackLayout st = new StackLayout();
            ed = new Editor()
            {
                Placeholder = "Sisesta siis teksti",
                BackgroundColor = Color.Gray,
                TextColor = Color.Blue
            };

            ed.TextChanged += Ed_TextChanged;

            lb = new Label()
            {
                Text = "Mingi tekst",
                TextColor = Color.Orange
            };


            Button tagasi = new Button()
            {
                Text = "Tagasi"
            };

            tagasi.Clicked += Tagasi_Clicked;

            StackLayout st = new StackLayout()
            {
                Children = { ed, lb, tagasi }
            };

            st.Children.Add(ed);
            st.Children.Add(lb);
            st.Children.Add(tagasi);

            st.BackgroundColor = Color.Aqua;
            Content = st;
        }
        int i = 0;
        int a = 0;
        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'A')
            {
                i++;
                lb.Text = key.ToString() + ": " + i;
            }
            /*else if (lb.Text == )
            {
                a++;
                lb.Text = lb.ToString() + ": " + a;
            }
            ed.TextChanged += Ed_TextChanged;*/
           
        }
        

        private async void Tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
    
}