/**
 * Student ID: 1778666
 * Program #: 1B
 * Due Date: 10/8/21
 * Course Section: 50
 * Description: Simple test program for Parcel classes using LINQ
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog1B
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ", 
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", 
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", 
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Bill Gates", "1998 Microsoft Ave.",
                "Redmond", "WA", 98657); // Test Address 5
            Address a6 = new Address("Steve Jobs", "593 Apple St.",
                "Cupertino", "CA", 86549); // Test Address 6
            Address a7 = new Address("Random Guy", "2293 South St.",
                "Nowhere", "KS", 65984); // Test Address 7
            Address a8 = new Address("Michael Scott", "423 Paper Pl.",
                "Scranton", "PA", 26594); // Test Address 8

            Letter l1 = new Letter(a1, a3, 0.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.20M); // Test Letter 2

            GroundPackage gp1 = new GroundPackage(a1, a2, 12, 34, 5, 20); // Test GroundPackage 1
            GroundPackage gp2 = new GroundPackage(a5, a6, 37, 57, 21, 54); // Test GroundPackage 2

            NextDayAirPackage ndap1 = new NextDayAirPackage(a3, a4, 36, 37, 38, 80, 8.35M); // Test NextDayAirPackage 1
            NextDayAirPackage ndap2 = new NextDayAirPackage(a7, a8, 25, 58, 12, 29, 12.2M); // Test NextDayAirPackage 2

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a2, a3, 12, 24, 6, 14, TwoDayAirPackage.Delivery.Saver); // Test TwoDayAirPackage 1
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8, a6, 21, 51, 32, 93, TwoDayAirPackage.Delivery.Early); // Test TwoDayAirPackage 2

            List<Parcel> parcels = new List<Parcel> { l1, l2, gp1, gp2, ndap1, ndap2, tdap1, tdap2 }; // Test list of parcels

            // Display Parcel List
            DisplayParcels(parcels, "List of Parcels");

            // All Parcels by destination zip descending
            var parcelsByZip =
                from parcel in parcels
                orderby parcel.DestinationAddress.Zip descending
                select parcel;

            DisplayParcels(parcelsByZip, "All Parcels by destination zip descending");

            // All Parcels by cost ascending
            var parcelsByCost =
                from parcel in parcels
                orderby parcel.CalcCost()
                select parcel;

            DisplayParcels(parcelsByCost, "All Parcels by cost ascending");

            // All Parcels by type (asc) then cost (desc)
            var parcelsByTypeAndCost =
                from parcel in parcels
                orderby parcel.GetType().Name, parcel.CalcCost() descending
                select parcel;

            DisplayParcels(parcelsByTypeAndCost, "All Parcels by type (asc) then cost (desc)");

            // All AirPackages where heavy by weight (desc)
            var heavyAirPackagesByWeight =
                from parcel in parcels
                let airPackage = parcel as AirPackage
                where airPackage != null && airPackage.IsHeavy()
                orderby airPackage.Weight descending
                select airPackage;

            DisplayParcels(heavyAirPackagesByWeight, "All AirPackages where heavy by weight (desc)");

            ReadLine();
        }

        private static void DisplayParcels(IEnumerable<Parcel> parcels, string header)
        {
            WriteLine($"Program 1B - {header}\n");

            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("--------------------");
            }

            ReadLine();
        }
    }
}
