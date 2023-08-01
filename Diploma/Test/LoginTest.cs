using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;

namespace Diploma.Test
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void Login_StandartUser()
        {
            Browser.Instance.NavigateToUrl("orangehrmlive");

            //Steps.GivenEnterUsername(driver);

            var page = new LoginPage(driver);
            page.EnterUsername();

        }

        [Test]
        public void LoginFailTest()
        {
            var page = new LoginPage(driver);

            page.OpenPage();
            var user = new UserModel()
            {
                Name = "Test",
                Password = "test"
            };

            page.TryToLogin(user);
            page.VerifyErrorMessage();

        }

    }
 }
