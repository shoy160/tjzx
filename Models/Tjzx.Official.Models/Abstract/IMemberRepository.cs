using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    public interface IMemberRepository
    {
        IEnumerable<Member> Members { get; }
    }
}
