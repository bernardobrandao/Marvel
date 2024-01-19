using System;
using System.Text;
using System.Net;
using System.Security.Cryptography;


namespace Marvel.Service
{
    public class MarvelService
    {

        static void Main(string[] args)
        {
            MarvelApi marvelApi = new MarvelApi();
            foreach (var personagens in marvelApi.GetCharacters())
            {
               Console.WriteLine($"{personagens.Name}\n{personagens.ImageUrl}\n{personagens.Id}");
                Console.WriteLine("----------------------------------");
            }
            foreach (Comics comics in marvelApi.GetComics())
            {
                Console.WriteLine($"{comics.Title}\n{comics.ImageUrl}");
                Console.WriteLine("______________________________________________");
            }
            long TimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string PublicKey = "4d3de4314998e1285b426a3b3fd9fc66";
            string PrivateKey = "1362e5f4fd298c5baea26ea9d63c070d3739b36d";
            string Hash =
            BitConverter.ToString(
                              MD5
                             .Create()
                             .ComputeHash(Encoding.Default.GetBytes($"{TimeStamp}{PrivateKey}{PublicKey}"))
                          )
                     .ToLower()
                     .Replace("-", "");

            string url = $"http://gateway.marvel.com/v1/public/characters?ts={TimeStamp}&apikey={PublicKey}&hash={Hash}&offset={1}&limit={20}";
         string json = new WebClient().DownloadString(url);
         Console.WriteLine(json);
         Console.ReadKey();
        
        }   

    }
}
    

