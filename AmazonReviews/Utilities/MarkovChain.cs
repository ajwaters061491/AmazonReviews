using AmazonReviews.Models;
using AmazonReviews.Services;
using Markov;

namespace AmazonReviews.Utilities
{
    public class MarkovChain
    {
        private readonly IReviewsService _reviewsService;
        public MarkovChain(IReviewsService reviewsService)
        {  
            _reviewsService = reviewsService;
        }

        public string GenerateMarkovChain()
        {
            //Creation of a new Markov Chain
            var chain = new MarkovChain<string>(1);

            //populating a IEnumerable List of Reviews using the List injested on startup
            IEnumerable<Reviews> reviewList  = _reviewsService.GetReviewList();

            //rolls through the list of reviews
            foreach (Reviews review in reviewList)
            {
                //checks for empty reviews for sanity
                if (!string.IsNullOrEmpty(review.reviewText))
                {
                    //chops up reviews by work (checking for whitespace) and adding to the array to be added to the chain
                    string[] reviewWords = review.reviewText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                    chain.Add(reviewWords);
                }
            }

            var rand = new Random();
            var reviewLength = rand.Next(10, 50); //decided that all generated reviews would be 10-50 words long.
            string fullReview = String.Empty;

            //review creation essentially strings together random words into something almost like a normal paragraph. Hilarious results.
            for (int i = 0; i < reviewLength; i++)
            {
                fullReview = string.Join(" ", chain.Chain(rand));
            }

            return fullReview;
        } 
    }
}
