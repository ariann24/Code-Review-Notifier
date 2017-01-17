using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeReviewNotifier.Model
{
    public class Review
    {
        public string Author { get; set; }
        public string AuthorID { get; set; }
        public string DateCreated { get; set; }
        public string Description { get; set; }
        public string Moderator { get; set; }
        public string ModeratorID { get; set; }
        public string Name { get; set; }
        public string PermID { get; set; }
        public string PermIDHistory { get; set; }
        public string ProjectKey { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
    }
}
