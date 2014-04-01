using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFMembersRepository:EFRepositoryBase<Member>
    {
        public override IEnumerable<Member> GetValues()
        {
            return Context.Members;
        }
    }
}
