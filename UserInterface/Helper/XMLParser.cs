using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using CodeReviewNotifier.Model;
using System.Windows;

namespace CodeReviewNotifier.Helper
{
    public class XMLParser
    {
        public static string AuthenticationToken(string xmlString)
        {
            string token = "";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);

            XmlNodeList xnList = xml.SelectNodes("loginResult/token");
            foreach (XmlNode xn in xnList)
            {
                token = xn.InnerText;
            }

            return token;
        }

        public static User Profile(string xmlString)
        {
            User user = new User();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);

                XmlNodeList xnList = xml.SelectNodes("/restUserProfileData/userData");
                foreach (XmlNode xn in xnList)
                {
                    user.Name = xn["displayName"].InnerText;
                    user.UserID = xn["userName"].InnerText;
                }
            }
            catch(XmlException e)
            {
                MessageBox.Show(e.ToString());
            }

            return user;
        }

        public static List<Review> Review(string xmlString)
        {
            List<Review> ReviewList = new List<Review>();

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);

                XmlNodeList xnList = xml.SelectNodes("/reviews/reviewData");
                foreach (XmlNode xn in xnList)
                {
                    Review review = new Review();

                    review.Author = xn["author"]["displayName"].InnerText;
                    review.AuthorID = xn["author"]["userName"].InnerText;
                    review.DateCreated = xn["createDate"].InnerText;
                    review.Moderator = xn["moderator"]["displayName"].InnerText;
                    review.ModeratorID = xn["moderator"]["userName"].InnerText;
                    review.Name = xn["name"].InnerText;
                    review.PermID = xn["permaId"]["id"].InnerText;
                    review.PermIDHistory = xn["permaIdHistory"].InnerText;
                    review.ProjectKey = xn["projectKey"].InnerText;
                    review.State = xn["state"].InnerText;
                    review.Type = xn["type"].InnerText;

                    ReviewList.Add(review);
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.ToString());
            }

            return ReviewList;
        }

        public static List<Comment> ReviewComment(string xmlString)
        {
            List<Comment> CommentList = new List<Comment>();

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);

                XmlNodeList xnList = xml.SelectNodes("comments/generalCommentData");
                foreach (XmlNode xn in xnList)
                {
                    Comment comment = new Comment();

                    comment.CreateDate = xn["createDate"].InnerText;
                    comment.DefectApproved = Boolean.Parse(xn["defectApproved"].InnerText);
                    comment.DefectRaised = Boolean.Parse(xn["defectRaised"].InnerText);
                    comment.Deleted = Boolean.Parse(xn["deleted"].InnerText);
                    comment.Draft = Boolean.Parse(xn["draft"].InnerText);
                    comment.Message = xn["message"].InnerText;
                    comment.MessageAsHTML = xn["messageAsHtml"].InnerText;
                    comment.ParentCommentID = xn["parentCommentId"].InnerText;
                    comment.ReadStatus = xn["readStatus"].InnerText;
                    comment.AvatarUrl = xn["user"]["avatarUrl"].InnerText;
                    comment.DisplayName = xn["user"]["displayName"].InnerText;
                    comment.Username = xn["user"]["userName"].InnerText;

                    // Child comments and replies
                    if (xn["replies"] != null)
                    {
                        List<Comment> list = CommentParser(xn["replies"]);
                        CommentList.AddRange(list);
                    }

                    CommentList.Add(comment);
                }

                xnList = xml.SelectNodes("comments/versionedLineCommentData");
                foreach (XmlNode xn in xnList)
                {
                    Comment comment = new Comment();

                    comment.CreateDate = xn["createDate"].InnerText;
                    comment.DefectApproved = Boolean.Parse(xn["defectApproved"].InnerText);
                    comment.DefectRaised = Boolean.Parse(xn["defectRaised"].InnerText);
                    comment.Deleted = Boolean.Parse(xn["deleted"].InnerText);
                    comment.Draft = Boolean.Parse(xn["draft"].InnerText);
                    comment.Message = xn["message"].InnerText;
                    comment.MessageAsHTML = xn["messageAsHtml"].InnerText;
                    comment.ParentCommentID = xn["parentCommentId"].InnerText;
                    comment.ReadStatus = xn["readStatus"].InnerText;
                    comment.AvatarUrl = xn["user"]["avatarUrl"].InnerText;
                    comment.DisplayName = xn["user"]["displayName"].InnerText;
                    comment.Username = xn["user"]["userName"].InnerText;

                    // Child comments and replies
                    if (xn["replies"] != null)
                    {
                        List<Comment> list = CommentParser(xn["replies"]);
                        CommentList.AddRange(list);
                    }

                    CommentList.Add(comment);
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.ToString());
            }

            return CommentList;
        }

        private static List<Comment> CommentParser(XmlNode xn)
        {
            List<Comment> childComment = new List<Comment>();
            XmlNodeList xnList = xn.SelectNodes("generalCommentData");
            foreach (XmlNode xnLocal in xnList)
            {
                Comment comment = new Comment()
                {
                    CreateDate = xnLocal["createDate"].InnerText,
                    DefectApproved = Boolean.Parse(xnLocal["defectApproved"].InnerText),
                    DefectRaised = Boolean.Parse(xnLocal["defectRaised"].InnerText),
                    Deleted = Boolean.Parse(xnLocal["deleted"].InnerText),
                    Draft = Boolean.Parse(xnLocal["draft"].InnerText),
                    Message = xnLocal["message"].InnerText,
                    MessageAsHTML = xnLocal["messageAsHtml"].InnerText,
                    ParentCommentID = xnLocal["parentCommentId"].InnerText,
                    ReadStatus = xnLocal["readStatus"].InnerText,
                    AvatarUrl = xnLocal["user"]["avatarUrl"].InnerText,
                    DisplayName = xnLocal["user"]["displayName"].InnerText,
                    Username = xnLocal["user"]["userName"].InnerText
                };

                childComment.Add(comment);

                if (xnLocal["replies"] != null)
                {
                    childComment.AddRange(CommentParser(xnLocal["replies"]));
                }
            }

            return childComment;
        }
    }
}
