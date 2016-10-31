using System.Web.Mvc;
using PairingTest.Web.RestClient;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionDataRestClient _questionDataRestClient;

        public QuestionnaireController(IQuestionDataRestClient questionDataRestClient)
        {
            _questionDataRestClient = questionDataRestClient;
        }

        public QuestionnaireController() : this(new QuestionDataRestClient())
        {
        }

        public ViewResult Index()
        {
            var model = _questionDataRestClient.GetAll();
            return View(model);
        }
    }
}