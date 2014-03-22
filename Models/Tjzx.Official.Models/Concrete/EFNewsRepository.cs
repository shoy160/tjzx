using System.Collections.Generic;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFNewsRepository:INewsesRepository
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IEnumerable<News> Newses
        {
            get { return _context.Newses; }
        }
    }
}
