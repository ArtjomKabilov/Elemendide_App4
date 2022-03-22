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
    public partial class Frame_Page : ContentPage
    {
        Frame fr;
        Label lbl;
        Grid gr;
        public Frame_Page()
        {
            lbl = new Label
            {
                Text = "Rammi kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            gr = new Grid
            {
                RowDefinitions =
                    {
                        new RowDefinition{Height = new GridLength(2, GridUnitType.Star)},
                        new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                        new RowDefinition{Height = new GridLength(1, GridUnitType.Star)}
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}
                    },
            };
            gr.Children.Add(new BoxView { Color = Color.Red }, 0, 0);
            gr.Children.Add(new BoxView { Color = Color.Black }, 1, 0);
            gr.Children.Add(new BoxView { Color = Color.Yellow }, 0, 1);
            gr.Children.Add(new BoxView { Color = Color.Green }, 1, 1);
            gr.Children.Add(new BoxView { Color = Color.Purple }, 0, 2);
            gr.Children.Add(new BoxView { Color = Color.Pink }, 1, 2);
            fr = new Frame
            {
                Content = gr,
                BorderColor = Color.Red,
                CornerRadius = 20,
                VerticalOptions=LayoutOptions.FillAndExpand

            };
            StackLayout st = new StackLayout
            {
                Children = { lbl, fr }
            };
            Content = st;
        }
    }
}