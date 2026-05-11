using ExamLibrary;
namespace ExamTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrderCalculator calculator = new OrderCalculator();
           

            Assert.AreEqual(18, calculator.CalculateDiscount(2, 10, 10));
        }


        [TestMethod]
        public void TestMethod2()
        {
            OrderCalculator calculator = new OrderCalculator();
            

            Assert.ThrowsException<ArgumentException>(() => calculator.CalculateDiscount(2, 0, 10));
        }
    }
}
