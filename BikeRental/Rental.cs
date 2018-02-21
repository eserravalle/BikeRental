using System;

namespace BikeRental
{
    public class Rental
    {
        public Rental(Bike bike, Person person, int hours)
        {
            Bike = bike;
            Person = person;
            Hours = hours;
        }

        public Bike Bike { get; set; }
        public Person Person { get; set; }
        public int Hours { get; set; }
        public int Charge { get; set; }
        public FamilyRental FamilyRental { get; set; }
    }
}
