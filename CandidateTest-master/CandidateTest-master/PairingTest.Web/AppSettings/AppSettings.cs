using System.Configuration;

namespace PairingTest.Web.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public string QuestionnaireServiceBaseUri()
        {
            var key = ConfigurationManager.AppSettings.Get("QuestionnaireServiceBaseUri");

            if (key != null)
            {
                return key;
            }
            throw new ConfigurationErrorsException("QuestionnaireServiceBaseUri key in config file is null");
        }


        public string QuestionnaireServiceResourceGet()
        {
            var key = ConfigurationManager.AppSettings.Get("QuestionnaireServiceResourceGet");

            if (key != null)
            {
                return key;
            }
            throw new ConfigurationErrorsException("QuestionnaireServiceResourceGet key in config file is null");
        }
    }
}