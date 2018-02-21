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
            if (rental.Hours < 5)
            {
                return rental.Hours * _chargePerHour;
            }

            if (rental.Hours < 24)
            {
                return 20;
            }

            if (rental.Hours <= 72)
            {
                return (rental.Hours / 24) * 20;
            }

            if (rental.Hours < 168)
            {
                return 60;
            }

            return (rental.Hours / 168) * 60;
        }
    }
}