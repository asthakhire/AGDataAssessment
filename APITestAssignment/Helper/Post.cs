using System;
using System.Collections.Generic;
using System.Text;

namespace APITestAssignment.Helper
{
    public class Post
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public class PostsList
        {
            public List<Post> Posts { get; set; }
        }
    }
}
