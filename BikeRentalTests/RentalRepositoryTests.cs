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
            var rental = _repo.RentABikePerHour(_bike, _person, 1);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(5, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor2Hours()
        {
            var rental = _repo.RentABikePerHour(_bike, _person, 2);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(10, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor23Hours()
        {
            var rental = _repo.RentABikePerHour(_bike, _person, 23);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(20, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor25Hours()
        {
            Assert.ThrowsException<System.Exception>(() => _repo.RentABikePerHour(_bike, _person, 25));
        }

        [TestMethod]
        public void RentABikeToAPersonFor1Day()
        {
            var rental = _repo.RentABikePerDay(_bike, _person, 1);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(20, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor3Days()
        {
            var rental = _repo.RentABikePerDay(_bike, _person, 3);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(60, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor4Days()
        {
            var rental = _repo.RentABikePerDay(_bike, _person, 4);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(60, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor7Days()
        {
            Assert.ThrowsException<System.Exception>(() => _repo.RentABikePerDay(_bike, _person, 168));
        }

        [TestMethod]
        public void RentABikeToAPersonFor1Week()
        {
            var rental = _repo.RentABikePerWeek(_bike, _person, 1);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(60, rental.Charge);
        }

        [TestMethod]
        public void RentABikeToAPersonFor3Weeks()
        {
            var rental = _repo.RentABikePerWeek(_bike, _person, 3);

            Assert.AreEqual(1, _repo.GetRentalsCount());
            Assert.AreEqual(180, rental.Charge);
        }
    }
}
