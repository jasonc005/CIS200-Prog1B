/**
 * Student ID: 1778666
 * Program #: 1A
 * Due Date: 9/27/21
 * Course Section: 50
 * Description: GroundPackage is a concrete derived class of Package.
 *      GroundPackages have a zone distance used to calculate cost.
**/

using System;

namespace Prog1B
{
    public class GroundPackage : Package
    {
        // The positive difference between the first digit of the origin zip code
        // and the first digit of the destination zip code
        public int ZoneDistance { get; }

        // Precondition: None
        // Postcondition: The ground package is created with the specified values and ZoneDistance is set
        public GroundPackage (Address originAddress, Address destinationAddress, double length, double width, double height, double weight)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
            ZoneDistance = Math.Abs(GetFirstDigit(OriginAddress.Zip) - GetFirstDigit(DestinationAddress.Zip));
        }

        // Precondition:  None
        // Postcondition: The ground package's cost is returned
        public override decimal CalcCost()
        {
            const double DIMENSION_MULTIPLIER = 0.15;
            const double ZONE_WEIGHT_MULTIPLIER = 0.07;

            return (decimal)(DIMENSION_MULTIPLIER * (Length + Width + Height) + ZONE_WEIGHT_MULTIPLIER * (ZoneDistance + 1) * Weight);
        }

        // Precondition:  None
        // Postcondition: A String with the ground package's data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Ground Package{NL}{base.ToString()}{NL}Zone Distance: {ZoneDistance}";
        }

        // Precondition: None
        // Postcondition: The first digit of argument number is returned as int
        private static int GetFirstDigit(int number)
        {
            number = Math.Abs(number);

            while(number >= 10)
            {
                number /= 10;
            }

            return number;
        }
    }
}
