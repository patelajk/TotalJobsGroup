using PairingTest.Web.Models;

namespace PairingTest.Web.RestClient
{
    public interface IQuestionDataRestClient
    {
        QuestionnaireViewModel GetAll();
    }
}