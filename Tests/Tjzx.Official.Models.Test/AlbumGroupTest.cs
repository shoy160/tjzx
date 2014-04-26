using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tjzx.Official.BLL.Business;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class AlbumGroupTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var busi = new AlbumGroupBusi();

            if (busi.GetItem(1) == null)
            {
                busi.Insert(new AlbumGroupInfo
                    {
                        GroupName = "首页展示",
                        State = (byte) StateType.Display
                    });
                busi.Insert(new AlbumGroupInfo
                    {
                        GroupName = "中心环境",
                        State = (byte) StateType.Display
                    });
                busi.Insert(new AlbumGroupInfo
                    {
                        GroupName = "团队风采",
                        State = (byte) StateType.Display
                    });
            }
            Assert.AreEqual(1, busi.GetList(new SearchInfo()).state);
        }
    }
}
