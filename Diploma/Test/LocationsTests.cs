using Allure.Commons;
using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.Helpers;
using Diploma.PageStep;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Test
{
    [TestFixture]
    public class LocationsTests : BaseTest
    {

        [Test]

        public void AddLocation()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new LocationPage();
            page.LocationTitle();
            page.AddNewLocation();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.successMessage));

        }

        [Test]

        public void CheckLocation()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new LocationPage();
            page.LocationTitle();
            page.CheckNewLocation();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.iconPencil));
        }

        [Test]

        public void DeleteLocation()
        {
            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new LocationPage();
            page.LocationTitle();
            page.CheckNewLocation();
            page.DeleteNewLocation();
            Assert.IsNotNull(Browser.Instance.Driver.FindElement(page.deleteMessage));
        }
    }
}
