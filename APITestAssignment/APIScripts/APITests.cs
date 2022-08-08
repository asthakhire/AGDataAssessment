using APITestAssignment.Helper;
using APITestAssignment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APITestAssignment.APIScripts
{
    [TestClass]
    public class APITests:TestBase
    {
        [TestMethod]
        [TestProperty("Id", "100")]
        [TestProperty("Title", "AGdata test API")]
        public async Task GetAllPosts()
        {
            PostServices postSvc= new PostServices();
            try
            {
                var result = await postSvc.GetAllPosts(HttpStatusCode.OK);
                Assert.AreEqual(result.Count, 100);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        [TestMethod]
        [TestProperty("Id", "101")]
        [TestProperty("Title", "AGdata test API")]
        public async Task VerifySavePost()
        {
            PostServices postSvc = new PostServices();
            var post = new Post
            {
                UserId = "1",
                Title = "New post",
                Body = "Test Post Body"
            };
            
            try
            {
                //POST call
                var resultSave = await postSvc.SavePost(post, HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        [TestMethod]
        [TestProperty("Id", "101")]
        [TestProperty("Title", "AGdata test API")]
        public async Task VerifyUpdatePost()
        {
            PostServices postSvc = new PostServices();
            
            try
            {
                Post result = await postSvc.GetPost("1", HttpStatusCode.OK);
                //PUT call
                result.Body = "Test Post Body - Updated";
                var updatePost = await postSvc.PutPost(result.Id, result, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        [TestMethod]
        [TestProperty("Id", "101")]
        [TestProperty("Title", "AGdata test API")]
        public async Task VerifyDeletePost()
        {
            PostServices postSvc = new PostServices();
            try
            {
                //DELETE a post with existing Post ID
                var deletePost = await postSvc.DeletePost("1", HttpStatusCode.OK);

            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        [TestMethod]
        [TestProperty("Id", "102")]
        [TestProperty("Title", "AGdata test API")]
        public async Task SavePostComments()
        {
            PostServices postSvc = new PostServices();
            var comments = new Comments
            {
                PostId = "1",
                Id = "1",
                Name = "John Dier",
                Email="test@test.com",
                Body = "quo deleniti praesentium dicta non quod\naut est molestias\nmolestias et officia quis nihil\nitaque dolorem quia"
            };

            try
            {
                //POST call
                var resultSave = await postSvc.SavePostComment(comments, HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        [TestMethod]
        [TestProperty("Id", "103")]
        [TestProperty("Title", "AGdata test API")]
        public async Task GetCommentsForPost()
        {
            PostServices postSvc = new PostServices();

            try
            {
                //GET call
                var resultComments = await postSvc.GetAllPostsComments(1,HttpStatusCode.OK);
                Assert.AreEqual(resultComments.Count, 5);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }
    }
}
