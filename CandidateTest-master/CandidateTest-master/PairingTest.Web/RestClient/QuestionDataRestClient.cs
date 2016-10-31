using System;
using PairingTest.Web.AppSettings;
using PairingTest.Web.Models;
using RestSharp;

namespace PairingTest.Web.RestClient
{
    public class QuestionDataRestClient : IQuestionDataRestClient
    {
        private readonly IAppSettings _appSettings;
        private readonly IRestClient _restClient;

        public QuestionDataRestClient(IRestClient restClient, IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _restClient = restClient;
        }

        public QuestionDataRestClient() : this(new RestSharp.RestClient(), new AppSettings.AppSettings())
        {
        }

        public QuestionnaireViewModel GetAll()
        {
            _restClient.BaseUrl = new Uri(_appSettings.QuestionnaireServiceBaseUri());
            // chnage to config location
            var request = new RestRequest(_appSettings.QuestionnaireServiceResourceGet(), Method.GET) {RequestFormat = DataFormat.Json};

            var response = _restClient.Execute<QuestionnaireViewModel>(request);

            if (response.Data == null)
            {
                throw new Exception(response.ErrorMessage);
            }

            return response.Data;
        }
    }
}