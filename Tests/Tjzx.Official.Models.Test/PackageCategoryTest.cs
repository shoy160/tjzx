using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Test
{
    /// <summary>
    /// PackageCategoryTest 的摘要说明
    /// </summary>
    [TestClass]
    public class PackageCategoryTest
    {
        public PackageCategoryTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InsertTest()
        {
            using (var db = new EFDbContext())
            {
                if (!db.PackageCategories.Any())
                {
                    db.PackageCategories.Add(new PackageCategory
                        {
                            Name = "常规体检",
                            Sort = 0,
                            State = 1
                        });
                    db.SaveChanges();
                }
                Assert.AreEqual(1, db.PackageCategories.Count());
            }
        }
    }
}
