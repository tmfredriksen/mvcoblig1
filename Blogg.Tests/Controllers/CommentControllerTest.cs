using Blogg.Controllers;
using Blogg.Models;
using Blogg.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blogg.Tests.Controllers
{
    [TestClass]
    public class CommentControllerTest
    {
        private Mock<IBlogRepository> repos;

        [TestInitialize]
        public void Setup()
        {
            repos = new Mock<IBlogRepository>();
        }

        [TestMethod]
        public void KommentarTestLukket()
        {
            Post closedPost = new Post { title = "test", Text = "tester", ID = 1, CommentsAllowed = false, BlogID = 3 };
            Comment comment = new Comment { ID = 2, Title = "test", Text = "test", PostID = 1 };

          //  repos.Setup(x => x.GetPostsWithComments(1)).Returns(closedPost);
         //   repos.Setup(x => x.CreateComment(comment)).Returns(true);

            var controller = new CommentController(repos.Object);

            var result = controller.Create(comment, comment.ID);

            repos.Verify(x => x.CreateComment(comment, comment.PostID));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
        [TestMethod]
        public void KommentarTestOpen()
        {
            Post åpentInnlegg = new Post { title = "test", Text = "tester", ID = 1, CommentsAllowed = true };
            Comment k = new Comment { ID = 1, Title = "test", Text = "test" };

         //   repos.Setup(x => x.GetPostsWithComments(1)).Returns(åpentInnlegg);
         //   repos.Setup(x => x.CreateKommentar(k)).Returns(true);
            
            var controller = new CommentController(repos.Object);

            var result = controller.Create(k, k.ID);

            repos.Verify(x => x.CreateComment(k, k.PostID));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

        }
    }
}
