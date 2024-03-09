using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Test
{
    [TestClass]
    public class TestInitializer
    {
        [AssemblyInitialize] // will be executed only one time before other methods in all Test Classes are executed
        public static void AssemblyInitialize(TestContext context)
        {
            context.WriteLine("In Assembly Initialize");
        }

        [AssemblyCleanup] // will be executed after other all Test assemblies are executed
        public static void AssemblyCleanup()
        {

        }
    }
}
