using System.Configuration;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web.Controllers
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var questionnaireController = new QuestionnaireController();
            AddKey();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            
        }

        [Test]
        public void QuestionShouldHaveCountGreaterThan0()
        {
   
            var questionnaireController = new QuestionnaireController();
            AddKey();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
      
            Assert.That(result.QuestionsText.Count, Is.GreaterThan(0));
        }

        private static void AddKey()
        {
           if (ConfigurationManager.AppSettings.Get("QuestionnaireServiceBaseUri") != null) return;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("QuestionnaireServiceBaseUri", "http://localhost:50014/");
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}