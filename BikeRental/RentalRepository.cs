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

        public void RentABike(Bike bike, Person person)
        {
            var rental = new Rental(bike, person);
            Rentals.Add(rental);
        }

        public int GetRentalsCount()
        {
            return Rentals.Count;
        }
    }
}