using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using TourSearchCommon.Model;

namespace TourSearchOtherProvider.Storages
{
    public class MemoryTourStorage
    {
        public MemoryTourStorage(ImmutableArray<Tour> tours)
        {
            this.Tours = tours;
        }

        public readonly ImmutableArray<Tour> Tours;
    }

}