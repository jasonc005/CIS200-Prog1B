/**
 * Student ID: 1778666
 * Program #: 1A
 * Due Date: 9/27/21
 * Course Section: 50
 * Description: NextDayAirPackage is a concrete derived class of AirPackage.
 *      NextDayAirPackages have an express fee used to calculate cost.
**/

using System;

namespace Prog1B
{
    public class NextDayAirPackage : AirPackage
    {
        private decimal _expressFee; // Fee added for next day express service
        
        // Precondition: None
        // Postcondition: The next day air package is created with the specified values
        public NextDayAirPackage(Address originAddress, Address destinationAddress, double length, double width, double height, double weight, decimal expressFee)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        public decimal ExpressFee
        {
            // Precondition:  None
            // Postcondition: The next day air package's express fee is returned
            get
            {
                return _expressFee;
            }
            // Precondition:  value must not be negative
            // Postcondition: The next day air package's express fee is set
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(ExpressFee)}", value,
                        $"{nameof(ExpressFee)} must not be negative");

                _expressFee = value;
            }
        }

        // Precondition:  None
        // Postcondition: The next day air package's cost is returned
        public override decimal CalcCost()
        {
            const double DIMENSION_MULTIPLIER = 0.35;
            const double WEIGHT_MULTIPLIER = 0.25;
            const double HEAVY_MULTIPLIER = 0.20;
            const double LARGE_MULTIPLIER = 0.22;

            decimal cost = (decimal)(DIMENSION_MULTIPLIER * (Length + Width + Height) + WEIGHT_MULTIPLIER * Weight) + ExpressFee;

            if (IsHeavy())
                cost += (decimal)(HEAVY_MULTIPLIER * Weight);

            if (IsLarge())
                cost += (decimal)(LARGE_MULTIPLIER * (Length + Width + Height));

            return cost;
        }

        // Precondition:  None
        // Postcondition: A String with the next day air package's data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Next Day Air Package{NL}{base.ToString()}{NL}Express Fee: {ExpressFee:C}";
        }
    }
}
