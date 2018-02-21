using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeRental;
using System.Collections.Generic;

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

        [TestMethod]
        public void RentABikeToAFamilyOf3()
        {
            var rentalsList = new List<Rental>();

            var bike1 = new Bike();
            var person1 = new Person();
            var rental1 = _repo.RentABikePerHour(bike1, person1, 4);
            rentalsList.Add(rental1);

            var bike2 = new Bike();
            var person2 = new Person();
            var rental2 = _repo.RentABikePerDay(bike2, person2, 1);
            rentalsList.Add(rental2);

            var bike3 = new Bike();
            var person3 = new Person();
            var rental3 = _repo.RentABikePerWeek(bike3, person3, 1);
            rentalsList.Add(rental3);

            var familyRental = _repo.AddToAFamilyRental(rentalsList);

            Assert.AreEqual(3, _repo.GetRentalsCount());
            Assert.AreSame(familyRental, rental1.FamilyRental);
            Assert.AreSame(familyRental, rental2.FamilyRental);
            Assert.AreSame(familyRental, rental3.FamilyRental);
            Assert.AreEqual(70, familyRental.GetTotalChargeWithDiscount());
        }

        [TestMethod]
        public void RentABikeToAFamilyOf5()
        {
            var rentalsList = new List<Rental>();

            var bike1 = new Bike();
            var person1 = new Person();
            var rental1 = _repo.RentABikePerHour(bike1, person1, 4);
            rentalsList.Add(rental1);

            var bike2 = new Bike();
            var person2 = new Person();
            var rental2 = _repo.RentABikePerDay(bike2, person2, 1);
            rentalsList.Add(rental2);

            var bike3 = new Bike();
            var person3 = new Person();
            var rental3 = _repo.RentABikePerWeek(bike3, person3, 1);
            rentalsList.Add(rental3);

            var bike4 = new Bike();
            var person4 = new Person();
            var rental4 = _repo.RentABikePerDay(bike4, person4, 2);
            rentalsList.Add(rental4);

            var bike5 = new Bike();
            var person5 = new Person();
            var rental5 = _repo.RentABikePerWeek(bike5, person5, 1);
            rentalsList.Add(rental5);

            var familyRental = _repo.AddToAFamilyRental(rentalsList);

            Assert.AreEqual(5, _repo.GetRentalsCount());
            Assert.AreSame(familyRental, rental1.FamilyRental);
            Assert.AreSame(familyRental, rental2.FamilyRental);
            Assert.AreSame(familyRental, rental3.FamilyRental);
            Assert.AreSame(familyRental, rental4.FamilyRental);
            Assert.AreSame(familyRental, rental5.FamilyRental);
            Assert.AreEqual(140, familyRental.GetTotalChargeWithDiscount());
        }

        [TestMethod]
        public void RentABikeToAFamilyOf2()
        {
            var rentalsList = new List<Rental>();

            var bike1 = new Bike();
            var person1 = new Person();
            var rental1 = _repo.RentABikePerHour(bike1, person1, 4);
            rentalsList.Add(rental1);
            rentalsList.Add(rental1);

            Assert.ThrowsException<System.Exception>(() => _repo.AddToAFamilyRental(rentalsList));
        }

        [TestMethod]
        public void RentABikeToAFamilyOf6()
        {
            var rentalsList = new List<Rental>();

            var bike1 = new Bike();
            var person1 = new Person();
            var rental1 = _repo.RentABikePerHour(bike1, person1, 4);
            rentalsList.Add(rental1);
            rentalsList.Add(rental1);
            rentalsList.Add(rental1);
            rentalsList.Add(rental1);
            rentalsList.Add(rental1);
            rentalsList.Add(rental1);

            Assert.ThrowsException<System.Exception>(() => _repo.AddToAFamilyRental(rentalsList));
        }
    }
}
