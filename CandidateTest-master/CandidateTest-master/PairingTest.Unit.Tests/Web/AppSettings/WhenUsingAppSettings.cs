using System.Configuration;
using Moq;
using NUnit.Framework;
using PairingTest.Web.AppSettings;

namespace PairingTest.Unit.Tests.Web.AppSettings
{
    [TestFixture]
    [Category("Unit")]
    public abstract class WhenUsingAppSettings
    {
        [SetUp]
        public void SetUp()
        {
            When_Using_App_Settings();
        }

        protected Mock<IAppSettings> MockAppSettings;
        protected IAppSettings AppSettings;

        public abstract void When_Using_App_Settings();

        public void RemoveAppSetting(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public string GetAppSetting(string value)
        {
          return  ConfigurationManager.AppSettings.Get(value);
        }


    }
}