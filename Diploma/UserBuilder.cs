using Diploma.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma
{
    public class UserBuilder
    {
        public static UserModel GetStandartUser()
        {
            return new UserModel
            {
                Name = TestContext.Parameters.Get("StandartUserName"),
                Password = TestContext.Parameters.Get("StandartUserPassword")
            };
        }
        public static UserModel GetUnknownUser()
        {
            return new UserModel
            {
                Name = "Test",
                Password = "Test"

            };
        }
    }
}
