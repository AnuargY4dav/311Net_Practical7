
using System.Collections.Generic;
using System.Web.Mvc;

namespace Feedback_Management.Controllers
{
    public class FeedbackController : Controller
    {
        // Store feedback entries in memory
        private static List<FeedbackData> feedback =
            new List<FeedbackData>();

        // Display the home page
        public ActionResult Index()
        {
            return View();
        }

        // Display the feedback form
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Process submitted feedback
        [HttpPost]
        public ActionResult Create(
            int enrollment,
            string name,
            string subject,
            int rating,
            string comment)
        {
            FeedbackData data = new FeedbackData();

            data.Enrollment = enrollment;
            data.Name = name;
            data.Subject = subject;
            data.Rating = rating;
            data.Comment = comment;

            feedback.Add(data);

            return RedirectToAction("List");
        }

        // Display all feedback entries
        public ActionResult List()
        {
            return View(feedback);
        }
    }

    // Feedback data class
    public class FeedbackData
    {
        public int Enrollment { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
