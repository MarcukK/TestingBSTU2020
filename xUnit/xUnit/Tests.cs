using NUnit.Framework;

namespace xUnit
{
    [TestFixture]
    public class CreateTriangleTests
    {
        [TestCase]
        public void NegativeInput()
        {
            Assert.IsFalse(Triangle.CreateTriangle(-5, 10, 10), "Error in NotNegativeInput CreateTriangle X");
            Assert.IsFalse(Triangle.CreateTriangle(5, -10, 10), "Error in NotNegativeInput CreateTriangle Y");
            Assert.IsFalse(Triangle.CreateTriangle(5, 10, -10), "Error in NotNegativeInput CreateTriangle Z");

            Assert.IsFalse(Triangle.IsTwoSidesEqual(-10, 5, -10), "Error in NotNegativeInput IsTwoSidesEqual X");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(5, -10, -10), "Error in NotNegativeInput IsTwoSidesEqual Y");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(-10, -10, 5), "Error in NotNegativeInput IsTwoSidesEqual Z");

            Assert.IsFalse(Triangle.IsAllSidesEqual(-10, -10, -10), "Error in NotNegativeInput IsAllSidesEqual XYZ");
        }
        [TestCase]
        public void NotLine()
        {
            Assert.IsFalse(Triangle.CreateTriangle(5, 5, 10), "Error in NotLine CreateTriangle 1");
            Assert.IsFalse(Triangle.CreateTriangle(5, 10, 5), "Error in NotLine CreateTriangle 2");
            Assert.IsFalse(Triangle.CreateTriangle(10, 5, 5), "Error in NotLine CreateTriangle 3");

            Assert.IsFalse(Triangle.IsTwoSidesEqual(5, 5, 10), "Error in NotLine IsTwoSidesEqual 1");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(5, 10, 5), "Error in NotLine IsTwoSidesEqual 2");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(10, 5, 5), "Error in NotLine IsTwoSidesEqual 3");

            Assert.IsFalse(Triangle.IsAllSidesEqual(5, 5, 10), "Error in NotLine IsAllSidesEqual 1");
            Assert.IsFalse(Triangle.IsAllSidesEqual(5, 10, 5), "Error in NotLine IsAllSidesEqual 2");
            Assert.IsFalse(Triangle.IsAllSidesEqual(10, 5, 5), "Error in NotLine IsAllSidesEqual 3");

        }
        [TestCase]
        public void CorrectEntries()
        {
            Assert.IsTrue(Triangle.CreateTriangle(5, 5, 5), "Error in CorrectEntries CreateTriangle 1");
            Assert.IsTrue(Triangle.CreateTriangle(5, 6, 7), "Error in CorrectEntries CreateTriangle 2");
            Assert.IsTrue(Triangle.CreateTriangle(5, 10, 10), "Error in CorrectEntries CreateTriangle 3");

            Assert.IsTrue(Triangle.IsTwoSidesEqual(5, 5, 6), "Error in CorrectEntries IsTwoSidesEqual 1");
            Assert.IsTrue(Triangle.IsTwoSidesEqual(5, 6, 5), "Error in CorrectEntries IsTwoSidesEqual 2");
            Assert.IsTrue(Triangle.IsTwoSidesEqual(6, 5, 5), "Error in CorrectEntries IsTwoSidesEqual 3");

            Assert.IsTrue(Triangle.IsAllSidesEqual(5, 5, 5), "Error in CorrectEntries IsAllSidesEqual");
        }
        [TestCase]
        public void ZeroInput()
        {
            Assert.IsFalse(Triangle.IsTwoSidesEqual(0, 5, 5), "Error in ZeroInput IsTwoSidesEqual X");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(5, 0, 5), "Error in ZeroInput IsTwoSidesEqual Y");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(5, 5, 0), "Error in ZeroInput IsTwoSidesEqual Z");

            Assert.IsFalse(Triangle.IsAllSidesEqual(0, 0, 0), "Error in ZeroInput IsAllSidesEqual");
        }
        [TestCase]
        public void AreEnoughLineLengths()
        {
            Assert.IsFalse(Triangle.CreateTriangle(10, 1, 1), "Error in AreEnoughLineLengths CreateTriangle 1");
            Assert.IsFalse(Triangle.CreateTriangle(1, 10, 1), "Error in AreEnoughLineLengths CreateTriangle 2");
            Assert.IsFalse(Triangle.CreateTriangle(1, 1, 10), "Error in AreEnoughLineLengths CreateTriangle 3");

            Assert.IsFalse(Triangle.IsTwoSidesEqual(10, 1, 1), "Error in AreEnoughLineLengths IsTwoSidesEqual 1");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(1, 10, 1), "Error in AreEnoughLineLengths IsTwoSidesEqual 2");
            Assert.IsFalse(Triangle.IsTwoSidesEqual(1, 1, 10), "Error in AreEnoughLineLengths IsTwoSidesEqual 3");

        }

    }
}
