using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeReviewNotifier.Model
{
    public class ReviewListItem
    {
        public string PermID { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public string State { get; set; }
        public int Comments { get; set; }
        public int UnreadComments { get; set; }
        public string CommentCountDisplay { get; set; }
        public string ReviewsStatus { get; set; }
    }
}
