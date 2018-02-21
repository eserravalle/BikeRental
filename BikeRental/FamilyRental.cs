using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRental
{
    public class FamilyRental
    {
        protected List<Rental> Rentals { get; set; }
        
        public FamilyRental()
        {
            Rentals = new List<Rental>();
        }

        public void AddARental(Rental rental)
        {
            Rentals.Add(rental);
        }

        public double GetTotalChargeWithDiscount()
        {
            int totalCharge = Rentals.Sum(x => x.Charge);

            return totalCharge * 0.7;
        }
    }
}