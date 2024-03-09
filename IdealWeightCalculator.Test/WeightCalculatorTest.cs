using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IdealWeightCalculator.Test
{
    [TestClass]
    public class WeightCalculatorTest
    {
        //public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            context.WriteLine("In Class Initialize");
        }

        //[ClassCleanup]
        //public static void ClassCleanup()
        //{

        //}

        //[TestInitialize]
        //public static void TestInitialize(TestContext context)
        //{
        //    context.WriteLine("In Test Initialize");
        //}

        //[TestCleanup]
        //public static void TestCleanup()
        //{

        //}

        //=========================================================================================================================================

        [TestMethod]
        [Description("GetIdealBodyWeight_WhenTypeIsMaleAndHeightIs182_Return74")]
        [Owner("Mustafa Fouda")]
        [Priority(1)]
        [TestCategory("Weight Category")]
        public void GetIdealBodyWeight_WhenTypeIsMaleAndHeightIs182_Return74() // The Name of Test Functionv should be like --> Given_When_Then/Return
        {
            //======================= AAA =========================

            //----- 1.Arrange -----
            var systemUnderTest = new WeightCalculator()
            {
                Height = 182,
                Type = 'm'
            };

            //----- 2.Act -----
            double actualValue = systemUnderTest.GetIdealBodyWeight();
            double expectedValue = 74;

            //----- 3.Assert -----
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [Description("GetIdealBodyWeight_WhenTypeIsFemaleAndHeightIs182_Return66")]
        [Owner("Mustafa Fouda")]
        [Priority(1)]
        [TestCategory("Weight Category")]
        public void GetIdealBodyWeight_WhenTypeIsFemaleAndHeightIs182_Return66() // The Name of Test Functionv should be like --> Given_When_Then/Return
        {
            //======================= AAA =========================

            //----- 1.Arrange -----
            var systemUnderTest = new WeightCalculator()
            {
                Height = 182,
                Type = 'f'
            };

            //----- 2.Act -----
            double actualValue = systemUnderTest.GetIdealBodyWeight();
            double expectedValue = 66;

            //----- 3.Assert -----
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("GetIdealBodyWeight_WhenTypeIsWrongAndHeightIs182_ThrowException")]
        [Owner("Mustafa Fouda")]
        [Priority(1)]
        [TestCategory("Weight Category")]
        public void GetIdealBodyWeight_WhenTypeIsWrongAndHeightIs182_ThrowException() // The Name of Test Functionv should be like --> Given_When_Then/Return
        {
            //======================= AAA =========================

            //----- 1.Arrange -----
            var systemUnderTest = new WeightCalculator()
            {
                Height = 182,
                Type = 'z'
            };

            //----- 2.Act -----
            double actualValue = systemUnderTest.GetIdealBodyWeight();
            double expectedValue = 0;

            //----- 3.Assert -----
            Assert.AreEqual(expectedValue, actualValue);
        }

        //=========================================================================================================================================

        [TestMethod]
        [Description("Assert Testing")]
        [Owner("Mustafa Fouda")]
        [Priority(2)]
        [TestCategory("Assert Category")]
        public void Assert_Test()
        {
            Assert.AreEqual(100, 90 + 10);

            Assert.AreNotEqual(100, 90);

            var calc1 = new WeightCalculator();
            var calc2 = calc1;
            var nullableVar = "hello";
            nullableVar = null;

            Assert.AreSame(calc1, calc2);

            Assert.IsInstanceOfType(calc2, typeof(WeightCalculator));

            Assert.IsNull(nullableVar);

            Assert.IsTrue(100 > 90);

            Assert.IsFalse(90 > 100);
        }

        [TestMethod]
        [Description("Assert Testing")]
        [Owner("Mustafa Fouda")]
        [Priority(2)]
        [TestCategory("Assert Category")]
        public void StringAssert_Test()
        {
            string name = "Khalid";

            /*(1)*/
            StringAssert.Contains(name, "lid");

            /*(2)*/
            name.Should().Contain("lid"); //Should() ===> from FluentAssertions NuGet Package

            /*[1]*/
            StringAssert.EndsWith(name, "lid");

            /*[2]*/
            name.Should().EndWith("lid"); //Should() ===> from FluentAssertions NuGet Package

            /*{1}*/
            StringAssert.StartsWith(name, "Khal");

            /*{2}*/
            name.Should().StartWith("Khal"); //Should() ===> from FluentAssertions NuGet Package
        }

        [TestMethod]
        [Description("Assert Testing")]
        [Owner("Mustafa Fouda")]
        [Priority(2)]
        [TestCategory("Assert Category")]
        [Ignore] // this test will be ignored while running
        public void CollectionAssert_Test()
        {
            List<string> names = new List<string>() { "khalid", "kamal", "said", "ali" };

            CollectionAssert.AllItemsAreNotNull(names);

            CollectionAssert.Contains(names, "said");

            CollectionAssert.AllItemsAreInstancesOfType(names, typeof(string));
        }

        [TestMethod]
        [Description("Assert Testing")]
        [Owner("Mustafa Fouda")]
        [Priority(3)]
        [TestCategory("Assert Category")]
        [Timeout(3000)]
        public void FluentAssertions_Test()
        {
            List<string> names = new List<string>() { "khalid", "kamal", "said", "ali" };

            names.Should().HaveCount(4);

            names.Should().NotBeNullOrEmpty();

            int number = 8;

            number.Should().BeGreaterThan(3);

            number.Should().BeInRange(5, 10);

            string person = "Mustafa";

            person.Should().StartWith("M").And.EndWith("a");
        }

        //=========================================================================================================================================

        [TestMethod]
        [Description("GetIdealBodyWeightFromDataSource_WhenValidInputs_ReturnTrue")]
        [Owner("Mustafa Fouda")]
        [Priority(1)]
        [TestCategory("Weight Category")]
        public void GetIdealBodyWeightFromDataSource_WhenValidInputs_ReturnTrue()
        {
            WeightCalculator weightCalc = new WeightCalculator(new FakeWeightRepository());

            var actualValues = weightCalc.GetIdealBodyWeightFromDataSource(); // {35 , 80 , 40 , 70}

            double[] expectedValues = { 35, 80, 40, 70 };

            actualValues.Should().BeEquivalentTo(expectedValues);
        }

        //============================================================================ Moq Package =============================================================

        [TestMethod]
        [Description("GetIdealBodyWeightFromDataSource_UsingMoq")]
        [Owner("Mustafa Fouda")]
        [Priority(1)]
        [TestCategory("Weight Category")]
        public void GetIdealBodyWeightFromDataSource_UsingMoq()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                new WeightCalculator() {Height = 130, Type = 'm'}, //35
                new WeightCalculator() {Height = 190, Type = 'm'}, //80
                new WeightCalculator() {Height = 130, Type = 'f'}, //40
                new WeightCalculator() {Height = 190, Type = 'f'} //70
            };

            Mock<IWeightRepository> repo = new Mock<IWeightRepository>();

            repo.Setup(w => w.GetWeightCalculators()).Returns(weights);

            var weightCalculator = new WeightCalculator(repo.Object);

            var actualValues = weightCalculator.GetIdealBodyWeightFromDataSource();

            double[] expectedValues = { 35, 80, 40, 70 };

            actualValues.Should().Equal(expectedValues);

        }

        //============================================================================ FakeItEasy Package =============================================================

        [TestMethod]
        [Description("GetIdealBodyWeightFromDataSource_UsingFakeItEasy")]
        [Owner("Mustafa Fouda")]
        [Priority(1)]
        [TestCategory("Weight Category")]
        public void GetIdealBodyWeightFromDataSource_UsingFakeItEasy()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                new WeightCalculator() {Height = 130, Type = 'm'}, //35
                new WeightCalculator() {Height = 190, Type = 'm'}, //80
                new WeightCalculator() {Height = 130, Type = 'f'}, //40
                new WeightCalculator() {Height = 190, Type = 'f'} //70
            };

            IWeightRepository repo = A.Fake<IWeightRepository>();

            A.CallTo( () => repo.GetWeightCalculators()).Returns(weights);

            var weightCalculator = new WeightCalculator(repo);

            var actualValues = weightCalculator.GetIdealBodyWeightFromDataSource();

            double[] expectedValues = { 35, 80, 40, 70 };

            actualValues.Should().Equal(expectedValues);

        }

        //============================================================================ Data Driven Testing =============================================================

        [DataTestMethod]
        [DataRow(130, 'm', 35)]
        [DataRow(190, 'm', 80)]
        [DataRow(130, 'f', 40)]
        [DataRow(190, 'f', 70)]
        public void DataDriven_Test(double height, char type, double expectedValue)
        {
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Type = type
            };

            var actualValues = weightCalculator.GetIdealBodyWeight();

            actualValues.Should().Be(expectedValue);
        }

        //============================================================================ Dynamic Data Attribute =============================================================

        public static List<object[]> DynamicData()
        {
            return new List<object[]>
            {
                new object[] { 130, 'm', 35 },
                new object[] { 190, 'm', 80 },
                new object[] { 130, 'w', 40 },
                new object[] { 190, 'w', 70 },
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(DynamicData), DynamicDataSourceType.Method)]
        public void DynamicData_Test(double height, char type, double expectedValue)
        {
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = height,
                Type = type
            };

            var actualValues = weightCalculator.GetIdealBodyWeight();

            actualValues.Should().Be(expectedValue);
        }

        //============================================================================ Test Driven Development (TDD) =============================================================

        [TestMethod]
        public void Validate_WhenBadGender_ReturnFalse()
        {
            WeightCalculator weightCalculator = new WeightCalculator();

            weightCalculator.Type = 't';

            bool isActual = weightCalculator.ValidateGender();

            isActual.Should().BeFalse();
        }
    }
}