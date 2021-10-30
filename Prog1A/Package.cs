/**
 * Student ID: 1778666
 * Program #: 1A
 * Due Date: 9/27/21
 * Course Section: 50
 * Description: This class is the abstract base class for Package heirarchy. 
 *      Package adds dimensions and weight to Parcel.
**/

using System;

namespace Prog1B
{
    public abstract class Package : Parcel
    {
        private double _length; // Length of the package in inches
        private double _width; // Width of the package in inches
        private double _height; // Height of the package in inches
        private double _weight; // Weight of the package in pounds

        // Precondition:  None
        // Postcondition: The package is created with the specified values
        public Package(Address originAddress, Address destinationAddress, double length, double width, double height, double weight)
            : base(originAddress, destinationAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public double Length
        {
            // Precondition:  None
            // Postcondition: The package's length is returned
            get
            {
                return _length;
            }
            // Precondition:  value must be greater than 0
            // Postcondition: The package's length is set
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(Length)}", value, 
                        $"{nameof(Length)} must not be less than or equal to 0");

                _length = value;
            }
        }

        public double Width
        {
            // Precondition:  None
            // Postcondition: The package's width is returned
            get
            {
                return _width;
            }
            // Precondition:  value must be greater than 0
            // Postcondition: The package's width is set
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(Width)}", value,
                        $"{nameof(Width)} must not be less than or equal to 0");

                _width = value;
            }
        }

        public double Height
        {
            // Precondition:  None
            // Postcondition: The package's height is returned
            get
            {
                return _height;
            }
            // Precondition:  value must be greater than 0
            // Postcondition: The package's height is set
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(Height)}", value,
                        $"{nameof(Height)} must not be less than or equal to 0");

                _height = value;
            }
        }

        public double Weight
        {
            // Precondition:  None
            // Postcondition: The package's weight is returned
            get
            {
                return _weight;
            }
            // Precondition:  value must be greater than 0
            // Postcondition: The package's weight is set
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(Weight)}", value,
                        $"{nameof(Weight)} must not be less than or equal to 0");

                _weight = value;
            }
        }

        // Precondition:  None
        // Postcondition: A String with the package's data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            string result = base.ToString() +
                $"{NL}Length: {Length} in." +
                $"{NL}Width: {Width} in." +
                $"{NL}Height: {Height} in." +
                $"{NL}Weight: {Weight} lb";

            return result;
        }
    }
}
