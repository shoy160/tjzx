using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tjzx.Official.BLL.Business;

namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class SpiderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var html = NewsSpider.GetHtml();
            Console.Write(html);
        }
    }
}
