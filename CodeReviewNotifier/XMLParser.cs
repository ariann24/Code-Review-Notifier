using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using CodeReviewNotifier.Model;
using System.Windows.Forms;

namespace CodeReviewNotifier
{
    public static class XMLParser
    {
        public static string ParseXML(string xmlString)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("/Names/Name");
            foreach (XmlNode xn in xnList)
            {
                string firstName = xn["FirstName"].InnerText;
                string lastName = xn["LastName"].InnerText;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            return "";
        }

        public static List<Review> Review(string xmlString)
        {
            List<Review> ReviewList = new List<Review>();

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString); // suppose that myXmlString contains "<Names>...</Names>"

                XmlNodeList xnList = xml.SelectNodes("/reviews/reviewData");
                foreach (XmlNode xn in xnList)
                {
                    Review _review = new Review();

                    _review.Author = xn["author"]["displayName"].InnerText;
                    _review.AuthorID = xn["author"]["userName"].InnerText;
                    _review.DateCreated = xn["createDate"].InnerText;
                    _review.Moderator = xn["moderator"]["displayName"].InnerText;
                    _review.ModeratorID = xn["moderator"]["userName"].InnerText;
                    _review.Name = xn["name"].InnerText;
                    _review.PermID = xn["permaId"]["id"].InnerText;
                    _review.PermIDHistory = xn["permaIdHistory"].InnerText;
                    _review.ProjectKey = xn["projectKey"].InnerText;
                    _review.State = xn["state"].InnerText;
                    _review.Type = xn["type"].InnerText;

                    ReviewList.Add(_review);
                }
            }
            catch(XmlException e){
                MessageBox.Show(e.ToString());
            }

            return ReviewList;
        }

        //--Ariann
        public static List<ReviewComments> ReviewComment(string xmlString)
        {
            List<ReviewComments> ReviewList = new List<ReviewComments>();

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString); 

                XmlNodeList xnList = xml.SelectNodes("/reviews/reviewData");
                foreach (XmlNode xn in xnList)
                {
                    ReviewComments _review = new ReviewComments();

                    _review.ID = xn["author"]["displayName"].InnerText;
                    _review.RilID = xn["author"]["userName"].InnerText;

                    ReviewList.Add(_review);
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show(e.ToString());
            }

            return ReviewList;
        }

        public static string AuthenticationToken(string xmlString)
        {
            string token = "";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("loginResult/token");
            foreach (XmlNode xn in xnList)
            {
                token = xn.InnerText;
            }

            return token;
        }
    }
}
