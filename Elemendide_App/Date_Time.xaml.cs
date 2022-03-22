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

    public partial class Date_Time : ContentPage
    {
        Label lbl;
        DatePicker dp;
        TimePicker tp;
        Button btn;
        
        
        public Date_Time()
        {
            btn = new Button()
            {
                Text = "Naita info",
                BackgroundColor =Color.Red,
                
            };
            btn.Clicked += Btn_Clicked;
            lbl = new Label()
            {
                Text = "Vali mingi kuupäev",
                BackgroundColor = Color.Red
            };
            dp = new DatePicker()
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-30),
                MaximumDate = DateTime.Now.AddDays(30),
                TextColor = Color.Black,
                BackgroundColor = Color.White
                
            };
            dp.DateSelected += Dp_DateSelected;
            tp = new TimePicker()
            {
                Time = new TimeSpan(12,0,0)

            };
            tp.PropertyChanged += Tp_PropertyChanged;
            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { lbl, dp, tp, btn }
            };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1,0.2,200,50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.1, 0.5, 300, 50));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.5, 0.7, 300, 50));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (on_off)
            {
                on_off = false;
            }
            else
            {
                on_off = true;
                ShowTimee();
            }
        }

        bool on_off = true;
        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud aeg " + tp.Time;
            
        }
        private async void ShowTimee()
        {
            
            while (on_off)
            {
                btn.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
                
            }
            if (btn.Text == tp.Time.ToString())
            {
                try
                {
                    // Use default vibration length
                    Vibration.Vibrate();

                    // Or use specified time
                    var duration = TimeSpan.FromSeconds(0.5);
                    Vibration.Vibrate(duration);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Feature not supported on device
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text = "Oli valitud kuupäev "+ e.NewDate.ToString("G");
        }
    }
}