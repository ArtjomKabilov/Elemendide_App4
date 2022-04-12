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
    public partial class Horoskop : ContentPage
    {
        Label lbl;
        DatePicker dp;
        StackLayout st;
        Image img;
        WebView webView;
        int a = 3;
    
        List<string> lehed = new List<string>() { "https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%B7%D0%B5%D1%80%D0%BE%D0%B3_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)"
            , "https://ru.wikipedia.org/wiki/%D0%9E%D0%B2%D0%B5%D0%BD_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D0%BB%D0%B5%D1%86_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%91%D0%BB%D0%B8%D0%B7%D0%BD%D0%B5%D1%86%D1%8B_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A0%D0%B0%D0%BA_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%9B%D0%B5%D0%B2_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%94%D0%B5%D0%B2%D0%B0_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%92%D0%B5%D1%81%D1%8B_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A1%D0%BA%D0%BE%D1%80%D0%BF%D0%B8%D0%BE%D0%BD_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A1%D1%82%D1%80%D0%B5%D0%BB%D0%B5%D1%86_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%92%D0%BE%D0%B4%D0%BE%D0%BB%D0%B5%D0%B9_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)",
            "https://ru.wikipedia.org/wiki/%D0%A0%D1%8B%D0%B1%D1%8B_(%D0%B7%D0%BD%D0%B0%D0%BA_%D0%B7%D0%BE%D0%B4%D0%B8%D0%B0%D0%BA%D0%B0)" };
        public Horoskop()
        {
            dp = new DatePicker()
            {
                Format = "D",
                TextColor = Color.Black,
                BackgroundColor = Color.White

            };
            lbl = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
            };
            img = new Image
            {

            };
            webView = new WebView
            {
               
            };
            dp.DateSelected += Dp_DateSelected;
            st = new StackLayout { Children = { dp, lbl, img } };
            Content = st;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            img.GestureRecognizers.Add(tap);
            tap.Tapped += Tap_TappedAsync;
        }

        private async void Tap_TappedAsync(object sender, EventArgs e)
        {
            await Browser.OpenAsync(lehed[index: a]);
            /*if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[index: a] },
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            st.Children.Add(webView);*/
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;
            if (m==1 && d>=1 && d<=20 || m==12 && d<=22)
            {
                a = 0;
                lbl.Text = "Козеро́г (лат. Capricornus) — десятый знак зодиака, соответствующий сектору эклиптики от 270° до 300°, считая от точки весеннего равноденствия; кардинальный знак тригона Земля. " +
                    "В западной астрологии считается, что Солнце находится в знаке Козерога с 21 декабря по 19 января. Не следует путать знак Козерога с созвездием Козерога, в котором Солнце находится с 18 января по 15 февраля." +
                    "По мнению астрологов, знаком Козерога управляет Сатурн, здесь в экзальтации Марс, в изгнании Луна и в падении Юпитер. ";  
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://cdn.custom-cursor.com/packs/3366/cute-zodiac-sign-capricornus-cursor-pack.png"),
                    
                };
                
            }
            if (m == 3 && d >= 21 && d <= 31 || m == 4 && d <= 19)
            {
                a = 1; 
                lbl.Text = "О́вен (лат. Aries, баран) — первый знак зодиака, соответствующий сектору эклиптики от 0° до 30°, считая от точки весеннего равноденствия; кардинальный знак тригона (трёх знаков) «огонь»." +
                    " В созвездии Овна Солнце находится с 19 апреля по 13 мая, однако в западной астрологии Овну отводится период с 21 марта по 20 апреля.  " +
                    "Как первый знак цикла, символизирует начало эволюции; он также последний знак цикла, выражающий возврат к началу и возрождение. Символизм животного — его первичность и роль проводника (баран идёт в голове стада), присущие ему физическая сила и функция оплодотворения (как у всех самцов-млекопитающих), а также симметричность двух рогов спиральной формы противоположного направления.";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/e/e6/RR5110-0049R.gif")
                };
            }
            if (m == 4 && d >= 21 && d <= 30 || m == 5 && d <= 20)
            {
                a = 2;
                lbl.Text = "Теле́ц (лат. Taurus) — второй знак зодиака, соответствующий сектору эклиптики от 30° до 60°, считая от точки весеннего равноденствия, и созвездию Телец; постоянный знак тригона Земля. " +
                    "В западной астрологии считается, что Солнце находится в знаке Тельца примерно с 21 апреля по 20 мая. Не следует путать знак Тельца с созвездием Тельца, в котором Солнце находится с 14 мая по 19 июня. " +
                    "Знаком Тельца управляет Венера, здесь в экзальтации Луна, в изгнании Марс и Плутон, в падении Уран. ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/7/71/RR5110-0050R.gif")
                };
            }
            if (m == 5 && d >= 21 && d <= 31 || m == 6 && d <= 20)
            {
                a = 3;
                lbl.Text = "Близнецы (лат. Gemini) — третий знак зодиака. Следует после Тельца, соответствующий сектору эклиптики от 60° до 90°, считая от точки весеннего равноденствия; мутабельный знак тригона Воздух.  " +
                    "В западной астрологии считается, что Солнце находится в знаке Близнецов приблизительно с 21 мая по 21 июня[1]. Не следует путать знак Близнецов с созвездием Близнецов, в котором Солнце находится с 20 июня по 20 июля. " +
                    "Планета, управляющая знаком — Меркурий.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/1/10/RR5110-0051R.gif")
                };
            }
            if (m == 6 && d >= 21 && d <= 30 || m == 7 && d <= 22)
            {
                a = 4;
                lbl.Text = "Рак (лат. Cancer) — четвёртый знак зодиака, соответствующий сектору эклиптики от 90° до 120°, считая от точки весеннего равноденствия; кардинальный знак тригона Вода. Правит четвёртым домом гороскопа.  " +
                    "В западной астрологии считается, что Солнце находится в знаке Рака приблизительно с 22 июня по 22 июля. Не следует путать знак Рака с созвездием Рака, в котором Солнце находится с 21 июля по 9 августа. " +
                    "наком Рака управляет Луна, здесь в экзальтации Юпитер, в изгнании Сатурн и в падении Марс.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/c/cf/RR5110-0052R.gif")
                };
            }
            if (m == 7 && d >= 23 && d <= 31 || m == 8 && d <= 20)
            {
                a = 5;

                lbl.Text = "Лев (лат. Leo) — пятый знак зодиака, соответствующий сектору эклиптики от 120° до 150°, считая от точки весеннего равноденствия; постоянный знак тригона «огонь». " +
                    "Как все зодиакальные знаки стихий огня, это мужской, положительный (движение по часовой стрелке) и активный дом Солнца. Его качества из четырёх элементарных — «горячий» и «сухой»; цвет — жёлтого золота. Это «обитель» Солнца, а «в изгнании» (обитель напротив) — планеты Уран и Сатурн. " +
                    "В схематическом делении тела человека на 12 частей — управляет сердцем, спинным мозгом, а также спиной и кровообращением.";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/b/b7/RR5110-0040R.gif")
                };
            }
            if (m == 8 && d >= 23 && d <= 31 || m == 9 && d <= 20)
            {
                a = 6;

                lbl.Text = "Дева (лат. Virgo) — шестой знак зодиака, соответствующий сектору эклиптики от 150° до 180°, считая от точки весеннего равноденствия; мутабельный знак тригона Земля." +
                    "В западной астрологии считается, что Солнце находится в знаке Девы приблизительно с 23 августа по 22 сентября." +
                    " Не следует путать знак Девы с созвездием Девы, в котором Солнце находится с 16 сентября по 30 октября." +
                    "Правящая планета Девы — Меркурий." +
                    "Знаком Девы управляет Меркурий, здесь в экзальтации также Меркурий, в изгнании Юпитер и в падении Венера.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/a/ac/RR5111-0115R.gif")
                };
            }
            if (m == 9 && d >= 22 && d <= 31 || m == 10 && d <= 21)
            {
                a = 7;
                lbl.Text = "Весы (лат. Libra) — седьмой знак зодиака, соответствующий сектору эклиптики от 180° до 210°, считая от точки весеннего равноденствия; кардинальный знак тригона Воздух. Планетой-покровительницей знака Весов считается Венера. " +
                    "Весы — единственный неодушевлённый предмет в знаках зодиака. " +
                    "В западной астрологии считается, что Солнце находится в знаке Весов приблизительно с 23 сентября по 22 октября. Не следует путать знак Весов с созвездием Весов, в котором Солнце находится с 31 октября по 22 ноября." +
                    "Знаком Весов управляет Венера, здесь в экзальтации Сатурн, в изгнании Марс и в падении Солнце.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/b/b6/Coin_of_the_Bank_of_Russia_-_Libra_2_rubles_2002_reverse.gif")
                };
            }
            if (m == 10 && d >= 22 && d <= 30 || m == 11 && d <= 20)
            {
                a = 8;
                lbl.Text = "Скорпион (лат. Scorpius) — восьмой знак зодиака, соответствующий сектору эклиптики от 210° до 240°, считая от точки весеннего равноденствия; постоянный знак тригона Вода.  " +
                    "В западной астрологии считается, что Солнце находится в знаке Скорпиона приблизительно с 23 октября по 21 ноября. Не следует путать знак Скорпиона с созвездием Скорпиона, в котором Солнце находится с 23 ноября по 29 ноября. " +
                    "Знаком Скорпиона управляет Плутон и Марс, в экзальтации здесь Уран, в изгнании Венера и в падении Луна.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://cdn.custom-cursor.com/packs/3366/cute-zodiac-sign-capricornus-cursor-pack.png")
                };
            }
            if (m == 11 && d >= 21 && d <= 31 || m == 12 && d <= 21)
            {
                a = 9;
                lbl.Text = "Стреле́ц (лат. Sagittarius) — девятый знак зодиака, соответствующий сектору эклиптики от 240° до 270°, считая от точки весеннего равноденствия; мутабельный (меняющийся) знак тригона (трёх знаков) «огня»." +
                    " В созвездии Стрельца Солнце находится с 18 декабря по 17 января, однако в западной астрологии Стрельцу отводится период с 22 ноября по 21 декабря.  " +
                    "Изображается кентавром, готовым выпустить стрелу; выражает гармонию животного тела (круп лошади), человеческой души (грудь) и духа (голова). В Стрельце выражены энергичность и целеустремлённость. " +
                    "Как все зодиакальные знаки стихии огня, это мужской, положительный (движение по часовой стрелке) и активный дом Солнца. Его качества из четырёх элементарных — «горячий» и «сухой»; цвет — фиолетовый. Это «обитель» Юпитера, а «в изгнании» (обитель напротив) — планета Меркурий. Связанные со знаком мифы — об Энкиду (из «Эпоса о Гильгамеше»), о кентавре Хироне и Орионе. " +
                    "В схематическом делении тела человека на 12 частей — управляет тазовой областью и бёдрами, а также дыхательные путями. ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/b/b2/RR5111-0119R.gif")
                };
            }
            if (m == 1 && d >= 20 && d <= 30 || m == 2 && d <= 18)
            {
                a = 10;
                lbl.Text = "Водолей (лат. Aquarius) — одиннадцатый знак зодиака, соответствующий сектору эклиптики от 300° до 330°, считая от точки весеннего равноденствия; постоянный знак тригона Воздух. Обычно изображается в виде человека мужского пола с кувшином, льющего воду.  " +
                    "В западной астрологии считается, что Солнце находится в знаке Водолея приблизительно с 20 января по 19 февраля. Хотя в наше время в созвездии Водолея Солнце находится с 16 февраля по 11 марта. " +
                    "Управляющие планеты Водолея — Уран и Сатурн.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/4/44/RR5111-0122R.gif")
                };
            }
            if (m == 2 && d >= 19 && d <= 30 || m == 3 && d <= 20)
            {
                a = 11;
                lbl.Text = "Рыбы (лат. Pisces) — двенадцатый знак зодиака, соответствующий сектору эклиптики от 330° до 360°, считая от точки весеннего равноденствия; мутабельный знак тригона Вода.  " +
                    "В западной астрологии считается, что Солнце находится в знаке Рыб приблизительно с 20 февраля по 20 марта. Не следует путать знак Рыб с созвездием Рыб, в котором Солнце находится с 12 марта по 18 апреля. " +
                    "Знаком Рыб управляют Юпитер и Нептун, здесь в экзальтации Венера, в изгнании и падении Меркурий.  ";
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/c/c7/RR5110-0048R.gif")
                };
            }
        }
    }
}