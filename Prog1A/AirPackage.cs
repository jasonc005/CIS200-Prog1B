/**
 * Student ID: 1778666
 * Program #: 1A
 * Due Date: 9/27/21
 * Course Section: 50
 * Description: This class is the abstract base class for AirPackage heirarchy. 
 *      AirPackage adds methods IsHeavy and IsLarge to Package.
**/

using System;

namespace Prog1B
{
    public abstract class AirPackage : Package
    {
        private const int HEAVY_WEIGHT = 75;
        private const int LARGE_DIMENSION_TOTAL = 100;

        // Precondition: None
        // Postcondition: The air package is created with the specified values
        public AirPackage(Address originAddress, Address destinationAddress, double length, double width, double height, double weight)
            : base(originAddress, destinationAddress, length, width, height, weight)
        { }

        // Precondition: None
        // Postcondition: Boolean representing if an air package is heavy or not is returned
        public bool IsHeavy() => Weight >= HEAVY_WEIGHT;

        // Precondition: None
        // Postcondition: Boolean representing if an air package is large or not is returned
        public bool IsLarge() => (Length + Width + Height) >= LARGE_DIMENSION_TOTAL;

        // Precondition:  None
        // Postcondition: A String with the air package's data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            string result = base.ToString() +
                $"{NL}Heavy: {(IsHeavy() ? "Yes" : "No")}" +
                $"{NL}Large: {(IsLarge() ? "Yes" : "No")}";

            return result;
        }
    }
}
