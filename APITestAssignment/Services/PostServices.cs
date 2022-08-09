using APITestAssignment.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APITestAssignment.Services
{
    public class PostServices:BaseService
    {
        #region POST
        public async Task<string> SavePost(Post post, HttpStatusCode expectedStatusCode)
        {
            Dictionary<string, object> newPost = new Dictionary<string, object>();

            newPost.Add("userId", post.UserId);
            newPost.Add("title", post.Title);
            newPost.Add("body", post.Body);

            var poststring = JsonConvert.SerializeObject(newPost, Formatting.Indented);
            var formValues = new StringContent(poststring, Encoding.UTF8, "application/json");
            var response = await Post(
                $"{TestUri}/posts", formValues);
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode, "Expected and Actual Status Codes");
            return responseAsString;
        }
        public async Task<string> SavePostComment(Comments postComment, HttpStatusCode expectedStatusCode)
        {
            Dictionary<string, object> newPostComment = new Dictionary<string, object>();

            newPostComment.Add("postId", postComment.PostId);
            newPostComment.Add("id", postComment.Id);
            newPostComment.Add("name", postComment.Name);
            newPostComment.Add("email", postComment.Email);
            newPostComment.Add("body", postComment.Body);

            var poststring = JsonConvert.SerializeObject(newPostComment, Formatting.Indented);
            var formValues = new StringContent(poststring, Encoding.UTF8, "application/json");
            var response = await Post(
                $"{TestUri}/posts/{postComment.Id}/comments", formValues);
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode, "Expected and Actual Status Codes");
            return responseAsString;
        }

        #endregion

        #region GET
        public async Task<Post> GetPost(string postId, HttpStatusCode expectedStatusCode)
        {
            var response = await Get($"{TestUri}/posts/{postId}");
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode);
            return JsonConvert.DeserializeObject<Post>(responseAsString);
        }
        public async Task<List<Post>> GetAllPosts(HttpStatusCode expectedStatusCode)
        {
            var response = await Get($"{TestUri}/posts");
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode);
            return JsonConvert.DeserializeObject<List<Post>>(responseAsString);
        }
        public async Task<List<Post>> GetAllPostsComments(int postId, HttpStatusCode expectedStatusCode)
        {
            var response = await Get($"{TestUri}/comments?postId={postId}");
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode);
            return JsonConvert.DeserializeObject<List<Post>>(responseAsString);
        }
        #endregion

        #region PUT
        public async Task<string> PutPost(string postId, Post post, HttpStatusCode expectedStatusCode)
        {
            Dictionary<string, object> newPost = new Dictionary<string, object>();

            newPost.Add("userId", post.UserId);
            //newPost.Add("id", post.Id);
            newPost.Add("title", post.Title);
            newPost.Add("body", post.Body);

            var poststring = JsonConvert.SerializeObject(newPost, Formatting.Indented);
            var formValues = new StringContent(poststring, Encoding.UTF8, "application/json");
            var response = await Put(
                $"{TestUri}/posts/{postId}", formValues);
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode, "Expected and Actual Status Codes");
            return responseAsString;
        }
        #endregion

        #region DELETE
        public async Task<string> DeletePost(string postId, HttpStatusCode expectedStatusCode)
        {
            var response = await Delete($"{TestUri}/posts/{postId}");
            var responseAsString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(response.StatusCode, expectedStatusCode, "Expected and Actual Status Codes");
            return responseAsString;
        }
        #endregion
    }
}
