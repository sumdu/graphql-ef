﻿namespace GraphqlApi.Models
{
    public class Movie
    {
        public IList<Review> Reviews { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }
    }
}
