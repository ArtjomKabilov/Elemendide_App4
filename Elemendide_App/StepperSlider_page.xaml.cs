
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
    public partial class StepperSlider_page : ContentPage
    {
        Label lb;
        Slider sld;
        Stepper stp;
        public StepperSlider_page()
        {
            lb = new Label
            {
                TextColor = Color.Black,
                FontSize = 18,
                FontFamily = "Comic Sans MS",
                HorizontalOptions = LayoutOptions.Center,
            };
            sld = new Slider
            {
                Minimum=0,
                Maximum=100,
                Value=30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red

            };
            sld.ValueChanged += Sld_ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp.ValueChanged += Stp_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { lb, sld, stp }
            };
            Content = st;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lb.Text = String.Format("Valitud: {0:F1}", e.NewValue);
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lb.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            lb.FontSize = e.NewValue;
            lb.Rotation = e.NewValue;
        }
    }
}