// Author: Murtaza Mian 
// Description:API Controller for the Review Entity

using Microsoft.AspNetCore.Mvc;
using Group8Project.Models;
using System.Collections.Generic;

namespace Group8Project.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewAPIController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewAPIController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/ReviewAPI
        [HttpGet]
        public IEnumerable<Models.Review> Get() => _reviewRepository.Reviews;

        // GET: api/ReviewAPI/{id}
        [HttpGet("{id}")]
        public ActionResult<Models.Review> GetReviewById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Movie ID cannot be null or empty.");
            }

            var review = _reviewRepository.GetReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }


        [HttpPost]
        public Models.Review Post([FromBody] Models.Review review) =>
            _reviewRepository.addReview(new Models.Review
            {
                RatingId = review.RatingId,
                MovieId = review.MovieId,
                UserRating = review.UserRating,
                ReviewDescription = review.ReviewDescription,
                DateRated = review.DateRated,
                Rater = review.Rater
            });

        [HttpPut]
        public Models.Review Put([FromBody] Models.Review review) =>
            _reviewRepository.UpdateReview(review);

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reviewRepository.removeReview(id);
        }

    }

}
