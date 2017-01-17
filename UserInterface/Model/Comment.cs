using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeReviewNotifier.Model
{
    public class Comment
    {
        public string CreateDate { get; set; }
        public bool DefectApproved { get; set; }
        public bool DefectRaised { get; set; }
        public bool Deleted { get; set; }
        public bool Draft { get; set; }
        public string Message { get; set; }
        public string MessageAsHTML { get; set; }
        public string ParentCommentID { get; set; }
        public string ReadStatus { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public string FromLineRange { get; set; }
        public string ToLineRange { get; set; }
    }
}
