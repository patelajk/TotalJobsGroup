using Moq;
using NUnit.Framework;
using PairingTest.Web.AppSettings;
using PairingTest.Web.RestClient;
using RestSharp;

namespace PairingTest.Unit.Tests.Web.ResClient
{
    [TestFixture]
    [Category("Unit")]
    public abstract class WhenUsingQuestionDataRestClient
    {
        [SetUp]
        public void SetUp()
        {
            When_Using_Question_Data_Rest_Client();
        }

        protected Mock<IAppSettings> MockAppSettings;
        protected Mock<IRestClient> MockRestClient;
        protected QuestionDataRestClient QuestionDataRestClient;
        protected dynamic Model;
        public abstract void When_Using_Question_Data_Rest_Client();
    }
}