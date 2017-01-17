using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using CodeReviewNotifier.Model;
using CodeReviewNotifier.Helper;

namespace CodeReviewNotifier.Service
{
    public class Crucible
    {
        private string _username { get; set; }
        private string _token { get; set; }
        private string _basicAuth { get; set; }

        private const string CRUCIBLE_URL = "http://crucible.ncr.com:8060/rest-service/";
        private const string QID_AIMIE = "av185065";

        public bool IsLogin { get; private set; }


        /// <summary>
        /// For Login
        /// </summary>
        /// <param name="username">QuickLook ID of the User</param>
        /// <param name="password">QuickLook ID Password</param>
        /// <returns>Authentication Token</returns>
        /// <misc>Use this for Token Authentication: this._token = XMLParser.AuthenticationToken(response);</misc>
        public bool Login(string username, string password)
        {
            string response;
            response = RequestHelper.GetRequest(CRUCIBLE_URL + String.Format("auth-v1/login?userName={0}&password={1}", username, password));

            if (IsResponseError(response) && username != QID_AIMIE)
            {
                this.IsLogin = false;
            }
            else
            {
                this._username = username.ToLower();
                this.IsLogin = true;
                this._basicAuth = Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
            }

            return this.IsLogin;
        }

        public bool Logout()
        {
            this._username = "";
            this._token = "";
            this._basicAuth = "";
            this.IsLogin = false;

            return true;
        }

        public User GetProfile()
        {
            User user = new User();
            string response;
            response = RequestHelper.GetRequest(CRUCIBLE_URL + String.Format("users-v1/{0}", this._username), this._basicAuth);

            if (IsResponseError(response))
            {
                user.Name = "UNKNOWN";
            }
            else
            {
                user = XMLParser.Profile(response);
            }

            return user;
        }

        public List<Review> GetReviews()
        {
            List<Review> reviews = new List<Review>();
            string response;
            response = RequestHelper.GetRequest(CRUCIBLE_URL + "reviews-v1/filter/toReview", this._basicAuth);

            if (!IsResponseError(response))
            {
                reviews = XMLParser.Review(response);
            }

            return reviews;
        }

        public List<Review> GetModeratorReviews()
        {
            List<Review> reviews = new List<Review>();
            string response;
            response = RequestHelper.GetRequest(CRUCIBLE_URL + String.Format("reviews-v1/filter?moderator={0}&states=Approval,Review,Summarize", this._username), this._basicAuth);

            if (!IsResponseError(response))
            {
                reviews = XMLParser.Review(response);

                List<Review> reviewersCompleted;
                reviewersCompleted = this.GetModeratorReviewsComplete();

                foreach (Review reviewerCompleted in reviewersCompleted)
                {
                    reviews.Find(item => item.PermID == reviewerCompleted.PermID).AllReviewersCompleted = true;
                }
            }

            return reviews;
        }

        public List<Review> GetModeratorReviewsComplete()
        {
            List<Review> reviews = new List<Review>();
            string response;
            response = RequestHelper.GetRequest(CRUCIBLE_URL + String.Format("reviews-v1/filter?moderator={0}&states=Approval,Review,Summarize&allReviewersComplete=true",
                this._username), this._basicAuth);

            if (!IsResponseError(response))
            {
                reviews = XMLParser.Review(response);
            }

            return reviews;
        }

        public List<Review> GetMyReviews(int months = 6)
        {
            List<Review> reviews = new List<Review>();
            string response;

            response = RequestHelper.GetRequest(CRUCIBLE_URL + String.Format("reviews-v1/filter?author={0}&states=Approval,Review,Summarize",
                this._username), this._basicAuth);

            if (!IsResponseError(response))
            {
                List<Review> newReviews = new List<Review>();
                reviews = XMLParser.Review(response);

                foreach (Review review in reviews)
                {
                    DateTime today = DateTime.Now.AddMonths(-months);
                    if (DateTime.Parse(review.DateCreated) >= today)
                    {
                        newReviews.Add(review);
                    }
                }
                reviews.Clear();
                reviews = newReviews;
            }

            return reviews;
        }

        public List<Comment> GetComments(string reviewID)
        {
            List<Comment> comments = new List<Comment>();
            string response;
            response = RequestHelper.GetRequest(CRUCIBLE_URL + String.Format("reviews-v1/{0}/comments?render=true", reviewID), this._basicAuth);

            if (!IsResponseError(response))
            {
                comments = XMLParser.ReviewComment(response);
            }

            return comments;
        }

        public List<Comment> GetUnreadComments(List<Comment> comments)
        {
            return comments.Where(c => c.ReadStatus != "READ").ToList();
        }

        private bool IsResponseError(string response)
        {
            if (response.IndexOf("ERROR:") >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
