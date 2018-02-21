using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeRental;

namespace RentalRepositoryTests
{
    [TestClass]
    public class UnitTest1
    {
        private RentalRepository _repo;
        private Bike _bike;
        private Person _person;

        [TestInitialize]
        public void TestSetup()
        {
            _repo = new RentalRepository();
            _bike = new Bike();
            _person = new Person();
        }

        [TestMethod]
        public void RentABikeToAPersonFor1Hour()
        {
            var rental = _repo.RentABike(_bike, _person, 1);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(5, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor2Hours()
        {
            var rental = _repo.RentABike(_bike, _person, 2);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(10, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor23Hours()
        {
            var rental = _repo.RentABike(_bike, _person, 23);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(115, rental.Charge);
        }    }
}
