using Diploma.BussinesObject;
using Diploma.Core;
using Diploma.PageStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Test
{
    internal class LeaveTest : BaseTest
    {
        [Test]
        public void LeaveList()
        {

            var user = UserBuilder.GetStandartUser();
            Steps.Login(user);
            var page = new LeavePage();
            page.LeaveNavigate();



        }
}
}
