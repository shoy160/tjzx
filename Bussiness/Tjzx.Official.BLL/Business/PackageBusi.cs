using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tjzx.Official.BLL.ViewModels;

namespace Tjzx.Official.BLL.Business
{
    public class PackageBusi:BusiBase<PackageInfo>
    {
        public override ResultInfo Insert(PackageInfo info)
        {
            throw new NotImplementedException();
        }

        public override ResultInfo GetList(SearchInfo info)
        {
            throw new NotImplementedException();
        }

        public override ResultInfo Update(PackageInfo info)
        {
            throw new NotImplementedException();
        }

        public override ResultInfo UpdateState(int[] ids, Dict.StateType state)
        {
            throw new NotImplementedException();
        }

        public override PackageInfo GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public override ResultInfo Item(int id)
        {
            throw new NotImplementedException();
        }
    }
}
