using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_yt_Tut
{
    [TestFixture] 
    [Parallelizable]
    [Ignore("Skip test")]
    public class YahooNewsTest
    {
        [Test]
        public void testNews()
        {
            Console.WriteLine("Test news");
        }
    }
}
