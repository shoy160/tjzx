using System.Collections.Generic;
using System.ComponentModel;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class TestMembersRepository : IRepository<Member>
    {
        public IEnumerable<Member> Values
        {
            get { return new BindingList<Member>(); }
        }
    }
}
