using HarryStore;
using NUnit.Framework;

namespace HarryStoreTests
{
    [TestFixture]
    public class BasketTests
    {
        private Program mainProgram;

        [OneTimeSetUp]
        public void TotalBasketCosts()
        {
            mainProgram = new Program();
        }

        [TestCase(new int[] { 1 }, ExpectedResult = 8)]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 15.2)]
        //...
        [TestCase(new int[] { 1, 1, 2, 2, 3, 3, 4, 5 }, ExpectedResult = 51.20)]

        public decimal TestCase(int[] skus)
        {
            //Act and Assert
            return mainProgram.CalculateTotalBasket(skus);
        }
    }
}
