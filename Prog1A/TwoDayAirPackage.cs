/**
 * Student ID: 1778666
 * Program #: 1A
 * Due Date: 9/27/21
 * Course Section: 50
 * Description: TwoDayAirPackage is a concrete derived class of AirPackage.
 *      TwoDayAirPackages have a delivery type used to discount cost.
**/

using System;

namespace Prog1B
{
    public class TwoDayAirPackage : AirPackage
    {
        public enum Delivery { Early, Saver }; // Enum defining possible delivery types

        private Delivery _deliveryType; // Type of delivery for the two day air package

        // Precondition: None
        // Postcondition: The two day air package is created with the specified values
        public TwoDayAirPackage(Address originAddress, Address destinationAddress, double length, double width, double height, double weight, Delivery deliveryType)
            : base(originAddress, destinationAddress, length, width, height, weight)
        {
            DeliveryType = deliveryType;
        }

        public Delivery DeliveryType
        {
            // Precondition:  None
            // Postcondition: The two day air package's delivery type is returned
            get
            {
                return _deliveryType;
            }
            // Precondition:  value must be defined by Delivery enum
            // Postcondition: The two day air package's delivery type is set
            private set
            {
                if (!Enum.IsDefined(typeof(Delivery), value))
                    throw new ArgumentOutOfRangeException($"{nameof(DeliveryType)}", value,
                        $"{nameof(DeliveryType)} must not be defined by Delivery enum");

                _deliveryType = value;
            }
        }

        // Precondition:  None
        // Postcondition: The two day air package's cost is returned
        public override decimal CalcCost()
        {
            const double DIMENSION_MULTIPLIER = 0.18;
            const double WEIGHT_MULTIPLIER = 0.20;
            const double SAVER_DISCOUNT = 0.15;

            decimal cost = (decimal)(DIMENSION_MULTIPLIER * (Length + Width + Height) + WEIGHT_MULTIPLIER * Weight);

            if (DeliveryType == Delivery.Saver)
                cost *= (decimal)(1 - SAVER_DISCOUNT);

            return cost;
        }

        // Precondition:  None
        // Postcondition: A String with the two day air package's data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Two Day Air Package{NL}{base.ToString()}{NL}Delivery Type: {DeliveryType}";
        }
    }
}
