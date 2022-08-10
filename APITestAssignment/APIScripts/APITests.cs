using APITestAssignment.Configurations;
using APITestAssignment.Helper;
using APITestAssignment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static APITestAssignment.Helper.Post;

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
                report.StartTest("AGData", "GetAllPosts");
                report.LogInfo("Get all the Posts");
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
                report.StartTest("AGData", "VerifySavePost");
                report.LogInfo("Create a new Post");
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
                report.StartTest("AGData", "VerifyUpdatePost");
                Post result = await postSvc.GetPost("1", HttpStatusCode.OK);
                report.LogInfo("Update an existing post");
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
                report.StartTest("AGData", "VerifyDeletePost");
                report.LogInfo("Delete an existing Post");
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
                report.StartTest("AGData", "SavePostComments");
                report.LogInfo("Create a Post comment");
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
                report.StartTest("AGData", "GetCommentsForPost");
                report.LogInfo("Get comment for a Post");
                var resultComments = await postSvc.GetAllPostsComments(1,HttpStatusCode.OK);
                Assert.AreEqual(resultComments.Count, 5);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        [TestMethod]
        [TestProperty("Id", "101")]
        [TestProperty("Title", "AGdata test API")]
        [DataTestMethod]
        [DynamicData(nameof(GetDataForPost), DynamicDataSourceType.Method)]
        public async Task VerifySavePostUsingTDD(Post post)
        {
            PostServices postSvc = new PostServices();
            try
            {
                report.StartTest("AGData", "VerifySavePost");
                report.LogInfo("Create a new Post");
                var resultSave = await postSvc.SavePost(post, HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        private static IEnumerable<object[]> GetDataForPost()
        {
            var postList = TestConfig.GetObjectData<PostsList>(Directory.GetCurrentDirectory() + "\\Data\\PostData.json");
            foreach (var post in postList.Posts)
            {
                yield return new[] { post };
            }
        }
    }
}
