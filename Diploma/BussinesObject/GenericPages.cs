using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BussinesObject
{
    public static class GenericPages
    {

        public static LoginPage LoginPage => GetPage<LoginPage>();

        public static T GetPage<T>() where T : new() => new T();
    }
}