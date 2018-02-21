using System;
using System.Collections.Generic;

namespace BikeRental
{
    public class RentalRepository
    {
        public RentalRepository()
        {
            Rentals = new List<Rental>();
        }

        protected List<Rental> Rentals { get; set; }

        public Rental RentABikePerHour(Bike bike, Person person, int hours)
        {
            if (hours > 23)
                throw new Exception("Cannot rent a bike per hour for more than 23 hours");

            var rental = new Rental(bike, person, hours);
            rental.Charge = RentalChargeService.GetInstance().CalculateCharge(rental);
            
            Rentals.Add(rental);
            
            return rental;
        }

        public Rental RentABikePerDay(Bike bike, Person person, int days)
        {
            if (days > 23)
                throw new Exception("Cannot rent a bike per day for more than 6 days");

            var rental = new Rental(bike, person, days * 24);
            rental.Charge = RentalChargeService.GetInstance().CalculateCharge(rental);
            
            Rentals.Add(rental);
            
            return rental;
        }

        public Rental RentABikePerWeek(Bike bike, Person person, int weeks)
        {
            var rental = new Rental(bike, person, weeks * 168);
            rental.Charge = RentalChargeService.GetInstance().CalculateCharge(rental);
            
            Rentals.Add(rental);
            
            return rental;
        }

        public FamilyRental AddToAFamilyRental(List<Rental> rentals)
        {
            FamilyRental familyRental = new FamilyRental();

            if (rentals.Count < 3 || rentals.Count > 5)
            {
                throw new Exception("Family Rentals only apply to 3 to 5 family members");
            }

            foreach(var rental in rentals)
            {
                familyRental.AddARental(rental);
                rental.FamilyRental = familyRental;
            }
            
            return familyRental;
        }

        public int GetRentalsCount()
        {
            return Rentals.Count;
        }
    }
}