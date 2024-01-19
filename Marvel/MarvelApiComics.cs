using Marvel.Service.Modelo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;


namespace Marvel
{
    public class MarvelApi
    {
        NetworkManager networkManager;

        public MarvelApi()
        {
            networkManager = new NetworkManager();
        }

        public List<Character> GetCharacters(int offset = 0, int count = 5)
        {

            long ts = MarvelApiConfig.TimeStamp;
            string apikey = MarvelApiConfig.PublicKey;
            string hash = MarvelApiConfig.Hash;
            string url = $"http://gateway.marvel.com/v1/public/characters?ts={ts}&apikey={apikey}&hash={hash}&offset={offset}&limit={count}";
            List<Character> charactrs = new List<Character>();
            try
            {
                string json = networkManager.GetJson(url);

                JObject marvelSearch = JObject.Parse(json);

                IList<JToken> results = marvelSearch["data"]["results"].Children().ToList();
                foreach (JToken result in results)
                {
                    charactrs.Add(new Character
                    {
                        Id = Convert.ToInt32(result["id"].ToString()),
                        Name = result["name"].ToString(),
                        ImageUrl = $"{result["thumbnail"]["path"]}.{result["thumbnail"]["extension"]}"
                    });
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
            return charactrs;
        }

        public List<Comics> GetComics(int charactrid = 1011334)
        {
            long ts = MarvelApiConfig.TimeStamp;
            string apikey = MarvelApiConfig.PublicKey;
            string hash = MarvelApiConfig.Hash;

            string url = $"http://gateway.marvel.com/v1/public/characters/{charactrid}/comics?ts={ts}&apikey={apikey}&hash={hash}&";

            List<Comics> comics = new List<Comics>();
            try
            {
                string json = networkManager.GetJson(url);
                JObject marvelSearch = JObject.Parse(json);
                IList<JToken> results = marvelSearch["data"]["results"].Children().ToList();

                foreach (JToken result in results)
                {
                    comics.Add(new Comics
                    {
                        Title = result["title"].ToString(),
                        ImageUrl = $"{result["thumbnail"]["path"]}.{result["thumbnail"]["extension"]}"
                    });
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
            return comics;
        }
    }
}