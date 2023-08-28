using AmazonReviews.Models;
using AmazonReviews.Pages;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AmazonReviews
{
    public static class JsonReader
    {
        //helper class to parse the JSON file
        public static IEnumerable<Reviews> ReadFileToEnd(string fileName)
        {
            IEnumerable<Reviews> reviewList = new List<Reviews>();

            try
            {
                string jsonString = File.ReadAllText(fileName);
                reviewList = JsonConvert.DeserializeObject<List<Reviews>>(jsonString);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return reviewList;
        }
    }
}
