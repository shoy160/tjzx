using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFMedicalPackagesRepository : EFRepositoryBase<MedicalPackage>
    {
        public override IEnumerable<MedicalPackage> GetValues()
        {
            return Context.MedicalPackages;
        }
    }
}
