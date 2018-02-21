using System;

namespace BikeRental
{
    public class RentalChargeService
    {
        private readonly int _chargePerHour;

        private static RentalChargeService _singleton;

        protected RentalChargeService()
        {
            _chargePerHour = 5;
        }

        public static RentalChargeService GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new RentalChargeService();
            }

            return _singleton;
        }

        public int CalculateCharge(Rental rental)
        {
            int charge = 0;

            if (rental.Hours < 24)
            {
                charge = rental.Hours * _chargePerHour;
            }

            return charge;
        }
    }
}