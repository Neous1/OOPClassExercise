using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_yt_Tut
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void testApp()
        {
            Console.WriteLine("Testing app");
        }

        [Test]
        public void loginTest()
        {
            Console.WriteLine("loging test");
        }
    }
}
