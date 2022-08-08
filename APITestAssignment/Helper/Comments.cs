using System;
using System.Collections.Generic;
using System.Text;

namespace APITestAssignment.Helper
{
    public class Comments
    {
        public string PostId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }


        public class CommentsList
        {
            public List<Comments> Comments { get; set; }
        }
    }
}
