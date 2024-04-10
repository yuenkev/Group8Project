// Author: Kevin Yuen   
// Description: Tests for the Home

using Group8Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using Group8Project.Controllers;
using Microsoft.AspNetCore.Mvc;
using Group8Project.Models.ViewModels;

namespace Group8Project.Tests
{
    public class HomeControllerTest
    {

        [Fact]
        public void CanCreateUser()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(mock => mock.Users).Returns(new User[]
            {
                new User{UserId=1, FName="Bob", LName="Jones", Email="bj@gmail.com", Password="123", PNumber="111-111-1111"},
                new User{UserId=2, FName="Joe", LName="Larry", Email="jl@gmail.com", Password="123", PNumber="222-222-2222"}
            }.AsQueryable<User>());

            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            mock1.Setup(mock => mock.Movies).Returns(new Movie[]
            {
                new Movie{MovieId=1, Title="Lord of the Rings", Description="The Lord of the Rings is a trilogy of epic fantasy adventure.", Genre="Fantasy", Director="Peter Jackson", ReleaseDate = new DateTime(2001, 02, 02), Runtime=  TimeSpan.FromHours(3)},
                new Movie{MovieId=2, Title="Dune 2", Description="The film follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis", Genre="Sci-Fi", Director="Denis Villeneuve", ReleaseDate = new DateTime(2024, 03, 01), Runtime=  TimeSpan.FromHours(2/46)}
            }.AsQueryable<Movie>());

            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.Reviews).Returns(new Review[]
            {
                new Review{RatingId=1, MovieId=1, UserRating=10, ReviewDescription="Amazing!", DateRated=new DateTime(2024, 04, 06), Rater="Bob Jones"},
                new Review{RatingId=2, MovieId=2, UserRating=6, ReviewDescription="Subpar...", DateRated=new DateTime(2024, 04, 08), Rater="Joe Larry"},

            }.AsQueryable<Review>());

            // Arrange
            HomeController controller = new HomeController(mock.Object, mock1.Object, mock2.Object);
            var user = new User
            {
                Email = "bj@gmail.com",
                Password = "123"
            };

            // Act
            var result = controller.SignUpPage(user) as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("LoginPage", result.ViewName);
        }

        [Fact]
        public void CanLogin()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(mock => mock.Users).Returns(new User[]
            {
                new User{UserId=1, FName="Bob", LName="Jones", Email="bj@gmail.com", Password="123", PNumber="111-111-1111"},
                new User{UserId=2, FName="Joe", LName="Larry", Email="jl@gmail.com", Password="123", PNumber="222-222-2222"}
            }.AsQueryable<User>());

            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            mock1.Setup(mock => mock.Movies).Returns(new Movie[]
            {
                new Movie{MovieId=1, Title="Lord of the Rings", Description="The Lord of the Rings is a trilogy of epic fantasy adventure.", Genre="Fantasy", Director="Peter Jackson", ReleaseDate = new DateTime(2001, 02, 02), Runtime=  TimeSpan.FromHours(3)},
                new Movie{MovieId=2, Title="Dune 2", Description="The film follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis", Genre="Sci-Fi", Director="Denis Villeneuve", ReleaseDate = new DateTime(2024, 03, 01), Runtime=  TimeSpan.FromHours(2/46)}
            }.AsQueryable<Movie>());

            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.Reviews).Returns(new Review[]
            {
                new Review{RatingId=1, MovieId=1, UserRating=10, ReviewDescription="Amazing!", DateRated=new DateTime(2024, 04, 06), Rater="Bob Jones"},
                new Review{RatingId=2, MovieId=2, UserRating=6, ReviewDescription="Subpar...", DateRated=new DateTime(2024, 04, 08), Rater="Joe Larry"},

            }.AsQueryable<Review>());

            //Arrange
            HomeController controller = new HomeController(mock.Object, mock1.Object, mock2.Object);
            var user = new User
            {
                Email = "jl@gmail.com",
                Password = "123"
            };

            //Act
            var result = controller.LoginPage(user) as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void CanUseIndex()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(mock => mock.Users).Returns(new User[]
            {
                new User{UserId=1, FName="Bob", LName="Jones", Email="bj@gmail.com", Password="123", PNumber="111-111-1111"},
                new User{UserId=2, FName="Joe", LName="Larry", Email="jl@gmail.com", Password="123", PNumber="222-222-2222"}
            }.AsQueryable<User>());

            Mock<IMovieRepository> mock1 = new Mock<IMovieRepository>();
            mock1.Setup(mock => mock.Movies).Returns(new Movie[]
            {
                new Movie{MovieId=1, Title="Lord of the Rings", Description="The Lord of the Rings is a trilogy of epic fantasy adventure.", Genre="Fantasy", Director="Peter Jackson", ReleaseDate = new DateTime(2001, 02, 02), Runtime=  TimeSpan.FromHours(3)},
                new Movie{MovieId=2, Title="Dune 2", Description="The film follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis", Genre="Sci-Fi", Director="Denis Villeneuve", ReleaseDate = new DateTime(2024, 03, 01), Runtime=  TimeSpan.FromHours(2/46)}
            }.AsQueryable<Movie>());

            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.Reviews).Returns(new Review[]
            {
                new Review{RatingId=1, MovieId=1, UserRating=10, ReviewDescription="Amazing!", DateRated=new DateTime(2024, 04, 06), Rater="Bob Jones"},
                new Review{RatingId=2, MovieId=2, UserRating=6, ReviewDescription="Subpar...", DateRated=new DateTime(2024, 04, 08), Rater="Joe Larry"},

            }.AsQueryable<Review>());

            //Arrange
            HomeController controller = new HomeController(mock.Object, mock1.Object, mock2.Object);

            //Act
            IActionResult result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CanChangeUserFName()
        {
            //Arrange
            var u = new User { UserId = 1, FName = "Bob", LName = "Jones", Email = "bj@gmail.com", Password = "123", PNumber = "111-111-1111" };

            //Act
            u.FName = "David";

            //Assert
            Assert.Equal("David", u.FName);
        }

        [Fact]
        public void CanChangeMovieTitle()
        {
            //Arrange
            var m = new Movie { MovieId = 1, Title = "Lord of the Rings", Description = "The Lord of the Rings is a trilogy of epic fantasy adventure.", Genre = "Fantasy", Director = "Peter Jackson", ReleaseDate = new DateTime(2001, 02, 02), Runtime = TimeSpan.FromHours(3) };

            //Act
            m.Title = "Lord of the Rings 2";

            //Assert
            Assert.Equal("Lord of the Rings 2", m.Title);
        }

        [Fact]
        public void CanChangeReviewRating()
        {
            //Arrange
            var r = new Review { RatingId = 1, MovieId = 1, UserRating = 10, ReviewDescription = "Amazing!", DateRated = new DateTime(2024, 04, 06), Rater = "Bob Jones" };

            //Act
            r.UserRating = 8.8;

            //Assert
            Assert.Equal(8.8, r.UserRating);
        }

        }
    }
