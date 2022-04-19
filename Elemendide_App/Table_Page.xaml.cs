using Plugin.Messaging;
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
    public partial class Table_Page : ContentPage
    {
        TableView tableview;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        Button btn1 = new Button
        {
            Text = "Email"
        };
        Button btn2 = new Button
        {
            Text = "Phone sms"
        };
        Button btn3 = new Button
        {
            Text = "Phone call"
        };
        StackLayout st;
        EntryCell telefon = new EntryCell
                        {
                            Label="Telefon",
                            Placeholder="Sissesta tel. number",
                            Keyboard=Keyboard.Telephone
    };
         EntryCell email = new EntryCell
         {
             Label = "Email",
             Placeholder = "Sissesta email",
             Keyboard = Keyboard.Email
         };
        
        public Table_Page()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("urod.png"),
                Text = "Foto nimetus",
                Detail = "Foto kirjeldus"
            };

            fotosection = new TableSection();
            tableview = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        new EntryCell
                        {
                            Label="Nimi: ",
                            Placeholder="Sissesta oma sõbra nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed: ")
                    {
                        email,telefon,

                        sc

                    },
                    new TableSection("lisavoimalused: ")
                    {
                        new ViewCell
                        {
                            View = new StackLayout{Children = {btn1,btn2,btn3}, Orientation = StackOrientation.Horizontal }
                            

                        }
                    },
                    fotosection,
                }


            };
            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
            btn3.Clicked += Btn3_Clicked;

            
            Content = tableview;
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
            {
                phoneDialer.MakePhoneCall(telefon.Text);
            }
                
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
            {
                smsMessenger.SendSms(telefon.Text, "Hello World!");
            }
                
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(email.Text, "тема письма", "текст письма");
            }
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Add(ic);
                sc.Text = "Näita veel";
            }
        }
    }
}