using System;

namespace BikeRental
{
    public class Rental
    {
        public Rental(Bike bike, Person person)
        {
            Bike = bike;
            Person = person;
        }

        public Bike Bike { get; set; }
        public Person Person { get; set; }
    }
}
