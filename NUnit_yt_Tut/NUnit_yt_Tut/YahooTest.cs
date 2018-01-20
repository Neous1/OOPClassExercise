using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_yt_Tut
{
    [TestFixture]
    [Parallelizable] //using Parallelizable to run test cases concurrently
    public class YahooTest
    {
        [Test]
        public void testReceiveMail()
        {
            Console.WriteLine("testing receiving mail");
        }
        [Test]
        public void testSendMail()
        {
            Console.WriteLine("testing Sending mail");
        }

        [SetUp] //called before executing every test case

        public void setup()
        {
            //setup can be used to open browser with selenium
            Console.WriteLine("opening browser");
        }

        [TearDown] //called after executing every test case

        public void tearDown()
        {
            Console.WriteLine("Closing Browser");
        }
    }
}
