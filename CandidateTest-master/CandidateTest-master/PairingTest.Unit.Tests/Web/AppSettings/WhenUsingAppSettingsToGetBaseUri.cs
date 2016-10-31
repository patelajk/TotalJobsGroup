using System.Configuration;
using NUnit.Framework;

namespace PairingTest.Unit.Tests.Web.AppSettings
{
    public class WhenUsingAppSettingsToGetBaseUri : WhenUsingAppSettings
    {
        public override void When_Using_App_Settings()
        {
            AppSettings = new PairingTest.Web.AppSettings.AppSettings();
        }


        [Test]
        public void Must_Get_Value_If_Not_Null()
        {
            var setting = GetAppSetting("QuestionnaireServiceBaseUri");

            Assert.NotNull(setting);
        }

        [Test]
        public void Must_Throw_Exception_If_Null()
        {
            RemoveAppSetting("QuestionnaireServiceBaseUri");
            
            Assert.Throws<ConfigurationErrorsException>(() => { AppSettings.QuestionnaireServiceBaseUri(); });
        }
    }
}