﻿using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    public interface IConsultingRepository
    {
        IEnumerable<Consulting> Consultings { get; }
    }
}
