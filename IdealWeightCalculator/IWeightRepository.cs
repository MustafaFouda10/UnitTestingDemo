using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator
{
    public interface IWeightRepository
    {
        IEnumerable<WeightCalculator> GetWeightCalculators();

    }
}
