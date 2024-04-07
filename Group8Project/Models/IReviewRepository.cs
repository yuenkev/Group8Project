namespace Group8Project.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        public void addReview(Review rw);
    }
}
