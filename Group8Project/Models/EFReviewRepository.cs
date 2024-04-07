namespace Group8Project.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private MBS_DBContext context;
        public EFReviewRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }

        public void addReview(Review rw)
        {
            context.Reviews.Add(rw);
            context.SaveChanges();
        }
        public IQueryable<Review> Reviews => context.Reviews;
    }
}
