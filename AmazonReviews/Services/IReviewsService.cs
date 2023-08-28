using AmazonReviews.Models;

namespace AmazonReviews.Services
{
    public interface IReviewsService
    {
        //Interface for dependency injection
        IEnumerable<Reviews> GetReviewList();
    }
}
