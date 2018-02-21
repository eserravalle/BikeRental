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

        public Rental RentABike(Bike bike, Person person, int hours)
        {
            var rental = new Rental(bike, person, hours);
            rental.Charge = RentalChargeService.GetInstance().CalculateCharge(rental);
            
            Rentals.Add(rental);
            
            return rental;
        }

        public int GetRentalsCount()
        {
            return Rentals.Count;
        }
    }
}