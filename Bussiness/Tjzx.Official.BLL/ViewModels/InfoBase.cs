using Tjzx.Official.BLL.Business;

namespace Tjzx.Official.BLL.ViewModels
{
    public abstract class InfoBase
    {
    }

    public static class InfoExtend
    {
        public static T Convert<T>(this InfoBase info, out ResultInfo resultInfo)
            where T : InfoBase
        {
            resultInfo = null;
            var result = info as T;
            if (result == null)
            {
                resultInfo = new ResultInfo(0, "传入类型不匹配");
                return null;
            }
            return result;
        }
    }
}
