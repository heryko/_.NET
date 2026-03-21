using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1; 

namespace TestProject1
{
    [TestClass] 
    public class KnapsackTests
    {
        [TestMethod] 
        public void Test_ShouldReturnSomething_WhenCapacityIsLarge()
        {
            var problem = new Problem(n: 10, seed: 1);
            int capacity = 50;

            var result = problem.Solve(capacity);

            Assert.IsTrue(result.ItemsInBag.Count > 0, "Lista nie powinna być pusta!");
        }

        [TestMethod]
        public void Test_ShouldBeEmpty_WhenCapacityIsZero()
        {
            var problem = new Problem(10, 1);

            var result = problem.Solve(0);

            Assert.AreEqual(0, result.ItemsInBag.Count);
            Assert.AreEqual(0, result.SumWeight);
        }

        [TestMethod]
        public void Test_WeightShouldNotExceedCapacity()
        {
            int capacity = 10;
            var problem = new Problem(20, 123);

            var result = problem.Solve(capacity);

            Assert.IsTrue(result.SumWeight <= capacity, "Waga przekroczyła udźwig plecaka!");
        }

        [TestMethod]

        public void Test_InfiniteCapacity()
        {
            int capacity = 1000;
            int n = 30;
            var problem = new Problem(n, 40);

            var result = problem.Solve(capacity);

            Assert.IsTrue(n == result.ItemsInBag.Count, "W plecaku nie znajduje się wystarczająca ilość przedmiodów!");

        }

        [TestMethod]

        public void Test_SpecificInstance_Seed1_N10_Cap20()
        { 
            int n = 10;
            int seed = 1;
            int capacity = 20;
            var problem = new Problem(n, seed);


            var result = problem.Solve(capacity);

            Assert.AreEqual(18, result.SumValue, "Dla seed=1 suma wag powinna wynosić 18");

        }
    }
}