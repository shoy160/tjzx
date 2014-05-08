using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tjzx.Official.BLL;

namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class EmailTester
    {
        [TestMethod]
        public void TestMethod1()
        {
            var helper = EmailHelper.Instance();
            helper.Send("1371683491@qq.com", "邮件测试", "收到请say hi!");
        }
    }
}
