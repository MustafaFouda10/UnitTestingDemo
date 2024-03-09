using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Test
{
    public class FakeWeightRepository : IWeightRepository
    {
        IEnumerable<WeightCalculator> Weights;

        public FakeWeightRepository()
        {
            Weights = new List<WeightCalculator>()
            {
                new WeightCalculator() {Height = 130, Type = 'm'},
                new WeightCalculator() {Height = 190, Type = 'm'},
                new WeightCalculator() {Height = 130, Type = 'f'},
                new WeightCalculator() {Height = 190, Type = 'f'}
            };
        }

        public IEnumerable<WeightCalculator> GetWeightCalculators()
        {
            return Weights;
        }
    }
}
