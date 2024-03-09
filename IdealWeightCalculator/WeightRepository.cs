using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator
{
    public class WeightRepository
    {
        IEnumerable<WeightCalculator> Weights;

        public WeightRepository()
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
