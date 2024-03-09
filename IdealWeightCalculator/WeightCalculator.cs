using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator
{
    public class WeightCalculator
    {
        private readonly IWeightRepository _repository;

        public double Height { get; set; }
        public char Type { get; set; } // Male (M) , Female (F)

        public WeightCalculator()
        {

        }
        public WeightCalculator(IWeightRepository repository)
        {
            _repository = repository;
        }

        public double GetIdealBodyWeight()
        {
            switch(Type)
            {
                //=================================== Lorentz Formula for calculating body weight ===================================
                case 'M' or 'm':
                    return (Height - 100) - ((Height - 150) / 4);

                case 'F' or 'f' or 'W' or 'w':
                    return (Height - 100) - ((Height - 150) / 2);
                default:
                    throw new ArgumentException("The user type is not valid. it should be 'm' or 'M' for males, and 'f', 'F', 'w', 'W' for females/women");
            }
        }

        public List<double> GetIdealBodyWeightFromDataSource()
        {
            var results = new List<double>();


            var weights = _repository.GetWeightCalculators(); // return some wights 

            foreach(var weight in weights)
            {
                results.Add(weight.GetIdealBodyWeight()); // calculates the ideal weight for each weight object 
            }

            return results;
        }

        public bool ValidateGender()
        {
            if (Type == 'm' || Type == 'M' || Type == 'f' || Type == 'F' || Type == 'w' || Type == 'W')
                return true;
            
            return false;
        }
    }
}
