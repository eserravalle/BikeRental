using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeRental;

namespace RentalRepositoryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RentABikeToAPerson()
        {
            var repo = new RentalRepository();
            var bike = new Bike();
            var person = new Person();

            repo.RentABike(bike, person);

            Assert.AreEqual(1, repo.GetRentalsCount());
        }
    }
}
