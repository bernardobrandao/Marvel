using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Xamarin.Forms;

namespace Marvel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var personagens = new List<Personagens>();
            var networkManager = new NetworkManager();
            var hash = MarvelApiConfig.Hash;
            var ts = MarvelApiConfig.TimeStamp;
            var json = networkManager.GetJson($"https://gateway.marvel.com:443/v1/public/characters?ts={ts}&apikey=4d3de4314998e1285b426a3b3fd9fc66&hash={hash}");
            var personagensJson = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var personagem in personagensJson.data.results)
            {
                var labelItem = new Label
                {
                    Text = personagem.name.ToString(),
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };

                var frame = new Frame
                {
                    Content = labelItem,
                    CornerRadius = 10,
                    Margin = new Thickness(5),
                    Padding = new Thickness(10),
                    BackgroundColor = Color.LightGray
                };

                LISTA.Children.Add(frame);
            }
        }
    }
}
