﻿// Author: Murtaza Mian
// Description: Interface for the Review Repository

namespace Group8Project.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        public Review addReview(Review rw);
        public void removeReview(int id);
        Review UpdateReview(Review rw);
        Review GetReviewById(int id);
        IEnumerable<Review> GetReviewsById(int id);
    }
}
