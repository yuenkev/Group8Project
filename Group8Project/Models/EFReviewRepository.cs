namespace Group8Project.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private MBS_DBContext context;
        public EFReviewRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }

        public Review addReview(Review rw)
        {
            var existingReview = context.Reviews.FirstOrDefault(r => r.RatingId == rw.RatingId);

            if (existingReview != null)
            {
                // Update existing user properties
                existingReview.RatingId = rw.RatingId;
                existingReview.MovieId = rw.MovieId;
                existingReview.UserRating = rw.UserRating;
                existingReview.ReviewDescription = rw.ReviewDescription;
                existingReview.DateRated = rw.DateRated;
                existingReview.Rater = rw.Rater;  

                // Save changes to the existing user
                context.SaveChanges();

                return existingReview;
            }
            else
            {
                context.Reviews.Add(rw);
                context.SaveChanges();

                return rw;
            }
        }
        public IQueryable<Review> Reviews => context.Reviews;

        public Review UpdateReview(Review review)
        {
            return addReview(review);
        }

        public void removeReview(int id)
        {
            var reviewToRemove = context.Reviews.FirstOrDefault(r => r.RatingId == id);

            if (reviewToRemove != null)
            {
                context.Reviews.Remove(reviewToRemove);
                context.SaveChanges();
            }
        }

        public Review GetReviewById(int id)
        {
            return context.Reviews.FirstOrDefault(r => r.RatingId == id);
        }

    }
}
