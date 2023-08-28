using AmazonReviews.Models;
using AmazonReviews.Services;
using AmazonReviews.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmazonReviews.api
{
    [Route("api/ReviewsController")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        //[HttpGet("Generate")]
        [HttpGet("Generate")] //GET api/ReviewsController/Generate
        public async Task<ActionResult<string>> Generate()
        {

            IEnumerable<Reviews> reviews = _reviewsService.GetReviewList();

            //Creates a new Markov Chain using the data injested on startup.
            MarkovChain markovChain = new MarkovChain(_reviewsService);

            //Creates a new review using the Markov chain class
            string review = markovChain.GenerateMarkovChain();
           
            Reviews fullReview = new Reviews();

            Random random = new Random();

            fullReview.reviewText = review;
            fullReview.overall = random.Next(0, 6); //Based on observations with data, overall is the x/5 star rating.

            //returns relevant review information as a json formatted string.
            return JsonConvert.SerializeObject(fullReview, Formatting.Indented);
        }
    }
}
