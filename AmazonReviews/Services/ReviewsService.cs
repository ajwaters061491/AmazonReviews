using AmazonReviews.Models;

namespace AmazonReviews.Services
{
    public class ReviewsService : IReviewsService
    {
        //Data was tricky to work with, I included the full data file in the project,
        //but used the shortened version with some edits to make it easier to work with
        private static string fileName = "Home_and_KitchenSHORTENED.json";
        public IEnumerable<Reviews> ReviewList = JsonReader.ReadFileToEnd(fileName);
        public IEnumerable<Reviews> GetReviewList()
        {
            return ReviewList;
        }
    }
}
