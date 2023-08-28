namespace AmazonReviews.Models
{
    public class Reviews
    {
        //Model used for Reviews. I THINK the reviewText does not need to be nullable,
        //but I saw a lot of inconsistencies and used a fraction of the total data.
        public double? overall { get; set; }
        public string? vote { get; set; }
        public bool? verified { get; set; }
        public string? reviewTime { get; set; }
        public string? reviewerID { get; set; }
        public string? asin { get; set; }
        public object? style { get; set; } 
        public string? reviewerName { get; set; }
        public string? reviewText { get; set; }
        public string? summary { get; set; }
        public string? helpful { get; set; }
        public int? unixReviewTime { get; set; }

    }
}
