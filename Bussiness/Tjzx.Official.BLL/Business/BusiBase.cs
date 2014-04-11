using Tjzx.Official.BLL.ViewModels;
using Tjzx.Official.BLL.Dict;

namespace Tjzx.Official.BLL.Business
{
    public abstract class BusiBase<T>
        where T : InfoBase
    {
        
        public abstract ResultInfo Insert(T info);

        public abstract ResultInfo GetList(SearchInfo info);

        public abstract ResultInfo Update(T info);

        public ResultInfo UpdateState(int id, StateType state)
        {
            return UpdateState(new[] {id}, state);
        }

        public abstract ResultInfo UpdateState(int[] ids, StateType state);

        public abstract T GetItem(int id);

        public abstract ResultInfo Item(int id);
    }
}
