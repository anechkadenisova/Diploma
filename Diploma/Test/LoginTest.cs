using Diploma.BussinesObject;
using Diploma.Core;


namespace Diploma.Test
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void Login_StandartUser()
        {
            Browser.Instance.NavigateToUrl("orangehrmlive");
            var page = new LoginPage(driver);
            page.EnterUsername();

        }

        [Test]
        public void LoginFailTest()
        {
            Browser.Instance.NavigateToUrl("orangehrmlive");
            var user = new UserModel()
            {
                Name = "Test",
                Password = "test"
            };

           var page = new LoginPage(driver);

            page.OpenPage();
            page.TryToLogin(user);
            page.VerifyErrorMessage();

        }

    }
}
