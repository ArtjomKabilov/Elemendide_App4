using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elemendide_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //InitializeComponent();

            Button Ent_btn = new Button()
            {
                Text = "Entry",
                BackgroundColor = Color.LightGreen,
            };

            Button Timer_btn = new Button()
            {
                Text = "Timer",
                BackgroundColor = Color.LightGreen,
            };
            Button cliker = new Button()
            {
                Text = "Clicker",
                BackgroundColor = Color.LightGreen,
            };
            Button Date_btn = new Button()
            {
                Text = "Date/Time",
                BackgroundColor = Color.LightGreen,
            };
            Button SS_btn = new Button()
            {
                Text = "Stepper/Slider",
                BackgroundColor = Color.LightGreen,
            };
            Button frame_btn = new Button()
            {
                Text = "Frame_Page",
                BackgroundColor = Color.LightGreen,
            };
            frame_btn.Clicked += Frame_btn_Clicked;
            Button image_btn = new Button()
            {
                Text = "Image",
                BackgroundColor = Color.LightGreen,
            };
            image_btn.Clicked += Image_btn_Clicked;
            Button Valgusfoor_btn = new Button()
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.LightGreen,
            };
            Button RGB_Btn = new Button()
            {
                Text = "RGB",
                BackgroundColor = Color.LightGreen,
            };
            Button TTT = new Button()
            {
                Text = "Trips Traps Trull",
                BackgroundColor = Color.LightGreen,
            };
            Button PP = new Button()
            {
                Text = "Picker Page",
                BackgroundColor = Color.LightGreen,
            };
            Button TP = new Button()
            {
                Text = "Table Page",
                BackgroundColor = Color.LightGreen,
            };
            Button H = new Button()
            {
                Text = "Harjatus Page",
                BackgroundColor = Color.LightGreen,
            };
            Button horos = new Button()
            {
                Text = "Horoskop Page",
                BackgroundColor = Color.LightGreen,
            };
            RGB_Btn.Clicked += RGB_Btn_Clicked;
            Valgusfoor_btn.Clicked += Valgusfoor_btn_Clicked;
            TTT.Clicked += TTT_Clicked;
            PP.Clicked += PP_Clicked;
            TP.Clicked += TP_Clicked;
            StackLayout st = new StackLayout()
            {
                Children = { Ent_btn , Timer_btn , cliker , Date_btn , SS_btn , frame_btn , image_btn, Valgusfoor_btn, RGB_Btn, TTT, PP, TP, H, horos }
            };

            st.BackgroundColor = Color.AntiqueWhite;
            Content = st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;
            cliker.Clicked += Cliker_Clicked;
            Date_btn.Clicked += Date_btn_Clicked;
            SS_btn.Clicked += SS_btn_Clicked;
            H.Clicked += H_Clicked;
            horos.Clicked += Horos_Clicked;
        }

        private async void Horos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Horoskop());
        }

        private async void H_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Harjatus());
        }

        private async void TP_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table_Page());
        }

        private async void PP_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Picker_Page());
        }

        private async void TTT_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TTT_Start());
        }

        private async void RGB_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RGB());
        }

        private async void Valgusfoor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoor());
        }

        private async void Image_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Image_page());
        }

        private async void Frame_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Frame_Page());
        }

        private async void SS_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperSlider_page());
        }

        private async void Date_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Date_Time());
        }

        private async void Cliker_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new cliker());
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ent_page());
        }
    }
    
}
