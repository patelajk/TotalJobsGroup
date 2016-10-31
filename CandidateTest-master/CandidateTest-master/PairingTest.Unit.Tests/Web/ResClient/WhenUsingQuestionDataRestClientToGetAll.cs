using Moq;
using NUnit.Framework;
using PairingTest.Web.AppSettings;
using PairingTest.Web.Models;
using PairingTest.Web.RestClient;
using RestSharp;

namespace PairingTest.Unit.Tests.Web.ResClient
{
    public class WhenUsingQuestionDataRestClientToGetAll : WhenUsingQuestionDataRestClient
    {
        public override void When_Using_Question_Data_Rest_Client()
        {
            var rest = new RestResponse<QuestionnaireViewModel>()
            {
                Data = new QuestionnaireViewModel()
            };

            MockAppSettings = new Mock<IAppSettings>();
            MockAppSettings.Setup(x => x.QuestionnaireServiceBaseUri()).Returns("http://localhost");
            MockAppSettings.Setup(x => x.QuestionnaireServiceResourceGet()).Returns("api/");

            MockRestClient = new Mock<IRestClient>();
            MockRestClient.Setup(x => x.Execute<QuestionnaireViewModel>(It.IsAny<RestRequest>())).Returns(rest);

            QuestionDataRestClient = new QuestionDataRestClient(MockRestClient.Object, MockAppSettings.Object);
            Model = QuestionDataRestClient.GetAll();
        }

        [Test]
        public void Must_Get_Base_Url_From_App_Settings()
        {
            MockAppSettings.Verify(x => x.QuestionnaireServiceBaseUri(), Times.Once);
        }

        [Test]
        public void Must_Get_Resource_From_App_Settings()
        {
            MockAppSettings.Verify(x => x.QuestionnaireServiceResourceGet(), Times.Once);
        }
    }
}