using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using CodeReviewNotifier.Model;

//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

namespace CodeReviewNotifier
{
    public class Crucible
    {
        private string _username { get; set; }
        private string _password { get; set; }
        private string _token { get; set; }
        private string _basicAuth { get; set; }
        public int ReviewCount { get; private set; }
        public bool IsLogin { get; private set; }
        public int AuthoredReviewCount { get; private set; }
        public int DraftReviewCount { get; private set; }

        public string Login(string username, string password)
        {
            string reponseAsString = "";
            this._username = username;
            this._password = password;
            this._basicAuth = Convert.ToBase64String(Encoding.Default.GetBytes(this._username + ":" + this._password));

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/auth-v1/login?userName=" + username + "&password=" + password);
                request.Method = "GET";
                request.ContentType = "application/json";
                //request.Accept = "application/json";

                var response = (HttpWebResponse)request.GetResponse();
                reponseAsString = ConvertResponseToString(response);
                this._token = XMLParser.AuthenticationToken(reponseAsString);
                if (!String.IsNullOrWhiteSpace(this._token))
                {
                    this.IsLogin = true;
                }
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return reponseAsString;
        }

        public void Logout()
        {
            this._username = "";
            this._password = "";
            this._token = "";
            this.ReviewCount = 0;
            this._basicAuth = "";
            this.IsLogin = false;
            this.DraftReviewCount = 0;
            this.AuthoredReviewCount = 0;
        }

        public List<Review> GetReviews()
        {
            List<Review> _reviews = new List<Review>();
            string reponseAsString = "";
            try
            {
                this._basicAuth = "Y3MyNTAyNDU6MGgqP1gwZGs=";
                // Using Token
                //var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/filter/toReview?FEAUTH=" + token + "&state=Review");

                // Using Basic Authentication
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/filter/toReview?FEAUTH=");
                request.Method = "GET";
                request.ContentType = "application/json";
                //request.Accept = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + this._basicAuth);

                var response = (HttpWebResponse)request.GetResponse();
                reponseAsString = ConvertResponseToString(response);
                _reviews = XMLParser.Review(reponseAsString);
                ReviewCount = _reviews.Count;
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return _reviews;
        }

        public string GetReviewsString()
        {
            string reponseAsString = "";
            try
            {
                this._basicAuth = "Y3MyNTAyNDU6MGgqP1gwZGs=";
                // Using Token
                //var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/filter/toReview?FEAUTH=" + token + "&state=Review");

                // Using Basic Authentication
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/filter/toReview");
                request.Method = "GET";
                request.ContentType = "application/json";
                //request.Accept = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + this._basicAuth);

                var response = (HttpWebResponse)request.GetResponse();
                reponseAsString = ConvertResponseToString(response);
                List<Review> _reviews = XMLParser.Review(reponseAsString);
                ReviewCount = _reviews.Count;
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return reponseAsString;
        }

        //--Ariann
        public List<ReviewComments> GetComments()
        {
            this._basicAuth = "Y3MyNTAyNDU6MGgqP1gwZGs=";
            List<ReviewComments> _reviews = new List<ReviewComments>();
            string reponseAsString = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/{id}/reviewitems/{riId}/comments/toReview?render=");
    
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + this._basicAuth);

                var response = (HttpWebResponse)request.GetResponse();
                reponseAsString = ConvertResponseToString(response);
                _reviews = XMLParser.ReviewComment(reponseAsString);
                ReviewCount = _reviews.Count;
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return _reviews;
        }

        public string GetCommentReviewsString()
        {
            this._basicAuth = "Y3MyNTAyNDU6MGgqP1gwZGs=";
            string reponseAsString = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/{id}/reviewitems/{riId}/comments/toReview");
                request.Method = "GET";
                request.ContentType = "application/json";
                //request.Accept = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + this._basicAuth);

                var response = (HttpWebResponse)request.GetResponse();
                reponseAsString = ConvertResponseToString(response);
                List<Review> _reviews = XMLParser.Review(reponseAsString);
                ReviewCount = _reviews.Count;
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return reponseAsString;
        }

        string ConvertResponseToString(HttpWebResponse response)
        {
            //string result = "Status code: " + (int)response.StatusCode + " " + response.StatusCode + "\r\n";
            string result = "";
            //foreach (string key in response.Headers.Keys)
            //{
            //    result += string.Format("{0}: {1} \r\n", key, response.Headers[key]);
            //}

            //result += "\r\n";
            result += new StreamReader(response.GetResponseStream()).ReadToEnd();

            return result;
        }

        public List<Review> GetAuthoredReviews()
        {
            this._basicAuth = "Y3MyNTAyNDU6MGgqP1gwZGs=";
            List<Review> _authoredReviews = new List<Review>();
            string responseAsString = "";
            
            try {
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/filter/outForReview");
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic" + this._basicAuth);

                var response = (HttpWebResponse)request.GetResponse();
                responseAsString = ConvertResponseToString(response);
                _authoredReviews = XMLParser.Review(responseAsString);
                AuthoredReviewCount = _authoredReviews.Count;
            }
            catch (Exception ex)
            {
                responseAsString += "ERROR: " + ex.Message;
            }

            return _authoredReviews;
        }

        public List<Review> GetDraftReviews()
        {
            List<Review> _draftReviews = new List<Review>();
            string responseAsString = "";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://crucible.ncr.com:8060/rest-service/reviews-v1/filter/draft");
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic" + this._basicAuth);

                var response = (HttpWebResponse)request.GetResponse();
                responseAsString = ConvertResponseToString(response);
                _draftReviews = XMLParser.Review(responseAsString);
                DraftReviewCount = _draftReviews.Count;
            }
            catch (Exception ex)
            {
                responseAsString += "ERROR: " + ex.Message;
            }

            return _draftReviews;
        }
    }
}
