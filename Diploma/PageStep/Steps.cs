using Diploma.BussinesObject;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Diploma.Core;
using Diploma.PageStep;
using Diploma.User;
using NUnit.Framework;

namespace Diploma.PageStep
{
    public class Steps
    {
        public static LoginPage Login(UserModel user)
        {
            new LoginPage().
                OpenPage().
                TryToLogin(user);
            return new LoginPage();
        }

        }

    }


