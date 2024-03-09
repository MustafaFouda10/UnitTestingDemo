using IdealWeightCalculator;


var weightCalc = new WeightCalculator()
{
    Height = 182,
    Type = 'm'
};

var weight = weightCalc.GetIdealBodyWeight();

Console.WriteLine("==========================================");
Console.WriteLine("The Ideal Weight Is: "+ weight);
Console.WriteLine("==========================================");

