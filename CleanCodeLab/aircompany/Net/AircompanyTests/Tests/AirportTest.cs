using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        [Test]
        public void IsEqualsPlane()
        {
            Plane actualResultPlane = planeSimilarToPlaneWithMaxPassengersCapacity.First();
            Plane expectedResultPlane = planeWithMaxPassengersCapacity.First();
            Assert.IsTrue(actualResultPlane.Equals(expectedResultPlane));
        }

        [Test]
        public void IsEqualsPassengerPlane()
        {
            PassengerPlane actualResultPlane = planeSimilarToPlaneWithMaxPassengersCapacity.First() as PassengerPlane;
            PassengerPlane expectedResultPlane = planeWithMaxPassengersCapacity.First() as PassengerPlane;
            Assert.IsTrue(actualResultPlane.Equals(expectedResultPlane));
        }

        [Test]
        public void IsEqualsMilitaryPlane()
        {
            MilitaryPlane actualResultPlane = planeSimilarToTransportMilitaryPlane.First() as MilitaryPlane;
            MilitaryPlane expectedResultPlane = transportMilitaryPlane.First() as MilitaryPlane;
            Assert.IsTrue(actualResultPlane.Equals(expectedResultPlane));
        }

        [Test]
        public void HasCorrectPassengerPlaneWithMaxPassengersCapacity()
        {
            Airport airport = new Airport(planes);
            PassengerPlane actualResultPlane = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            PassengerPlane expectedResultPlane = (PassengerPlane)planeWithMaxPassengersCapacity.First();
            Assert.IsTrue(actualResultPlane.IsEqualByHash(expectedResultPlane));
        }

        [Test]
        public void HasMilitaryTransportPlane()
        {
            Airport airport = new Airport(planes);
            MilitaryPlane actualResultPlane = airport.GetTransportMilitaryPlanes().First();
            MilitaryPlane expectedResultPlane = transportMilitaryPlane.First();
            Assert.IsTrue(actualResultPlane.IsEqualByHash(expectedResultPlane));
        }

        [Test]
        public void HasTopSecretPassengerPlane()
        {
            Airport airport = new Airport(planes);
            PassengerPlane actualResultPlane = airport.GetSecretPassengerPlanes().First();
            PassengerPlane expectedResultPlane = planeWithMaxPassengersCapacity.First() as PassengerPlane;
            Assert.IsTrue(actualResultPlane.IsEqualByHash(expectedResultPlane));
        }

        [Test]
        public void SortByMaxDistance()
        {
            Airport airport = new Airport(planes);
            airport = airport.SortByMaxDistance();
            Assert.IsTrue(airport.IsEqualByHash(planesSortedByMaxDistance));
        }

        [Test]
        public void SortByMaxLoadCapacity()
        {
            Airport airport = new Airport(planes);
            airport = airport.SortByMaxLoadCapacity();
            Assert.IsTrue(airport.IsEqualByHash(planesSortedByMaxLoadCapacity));
        }

        [Test]
        public void SortByMaxSpeed()
        {
            Airport airport = new Airport(planes);
            airport = airport.SortByMaxSpeed();
            Assert.IsTrue(airport.IsEqualByHash(planesSortedByMaxSpeed));
        }

        [Test]
        public void ToStringAirportWithPlaneWithMaxPassengersCapacity()
        {
            Airport airport = new Airport(planeWithMaxPassengersCapacity);
            string actualResultPlane = airport.ToString();
            string expectedResultPlane = airportWithPlaneWithMaxPassengersCapacityAsString;
            Assert.AreEqual(actualResultPlane, expectedResultPlane);
        }

        [Test]
        public void ToStringPlaneWithMaxPassengersCapacity()
        {
            string actualResultPlane = planeWithMaxPassengersCapacity.First().ToString();
            string expectedResultPlane = planeWithMaxPassengersCapacityAsString;
            Assert.AreEqual(actualResultPlane, expectedResultPlane);
        }

        [Test]
        public void ToStringTransportMilitaryPlane()
        {
            string actualResultPlane = transportMilitaryPlane.First().ToString();
            string expectedResultPlane = transportMilitaryPlaneAsString;
            Assert.AreEqual(actualResultPlane, expectedResultPlane);
        }




        private readonly List<Plane> planes = new List<Plane>(){
           new PassengerPlane("Boeing-737", 900, 12700, 60500, 164, ClassificationLevel.UNCLASSIFIED),
           new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Boeing-747", 980, 16100, 70500, 242, ClassificationLevel.SECRET),
           new PassengerPlane("Airbus A320", 930, 11800, 65500, 188, ClassificationLevel.TOP_SECRET),
           new PassengerPlane("Airbus A330", 990, 14800, 80500, 222, ClassificationLevel.SECRET),
           new PassengerPlane("Embraer 190", 875, 8100, 30800, 64, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196, ClassificationLevel.UNCLASSIFIED),
           new MilitaryPlane("B-1B Lancer", 1050, 21000, 83000, MilitaryType.BOMBER),
           new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
           new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
           new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
           new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
           new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
   };
        private readonly List<MilitaryPlane> transportMilitaryPlane = new List<MilitaryPlane>(){
           new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
   };
        private readonly List<MilitaryPlane> planeSimilarToTransportMilitaryPlane = new List<MilitaryPlane>(){
           new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
   };
        private readonly List<Plane> planeWithMaxPassengersCapacity = new List<Plane>(){
           new PassengerPlane("Boeing-747", 980, 16100, 70500, 242, ClassificationLevel.SECRET)
   };
        private readonly List<Plane> planeSimilarToPlaneWithMaxPassengersCapacity = new List<Plane>(){
           new PassengerPlane("Boeing-747", 980, 16100, 70500, 242, ClassificationLevel.SECRET)
   };
        private readonly List<Plane> planesSortedByMaxDistance = new List<Plane>(){
           new MilitaryPlane("C-130 Hercules",       650,  5000,  110000, MilitaryType.TRANSPORT),
           new PassengerPlane("Embraer 190",         875,  8100,  30800,  64,  ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Bombardier CS300",    920,  11000, 60700,  196, ClassificationLevel.UNCLASSIFIED),
           new PassengerPlane("Sukhoi Superjet 100", 870,  11500, 50500,  140, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Airbus A320",         930,  11800, 65500,  188, ClassificationLevel.TOP_SECRET),
           new MilitaryPlane("F-15",                 1500, 12000, 10000,  MilitaryType.FIGHTER),
           new PassengerPlane("Boeing-737-800",      940,  12300, 63870,  192, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Boeing-737",          900,  12700, 60500,  164, ClassificationLevel.UNCLASSIFIED),
           new MilitaryPlane("F-22",                 1550, 13000, 11000,  MilitaryType.FIGHTER),
           new PassengerPlane("Airbus A330",         990,  14800, 80500,  222, ClassificationLevel.SECRET),
           new PassengerPlane("Boeing-747",          980,  16100, 70500,  242, ClassificationLevel.SECRET),
           new MilitaryPlane("B-52 Stratofortress",  1000, 20000, 80000,  MilitaryType.BOMBER),
           new MilitaryPlane("B-1B Lancer",          1050, 21000, 83000,  MilitaryType.BOMBER),
           new MilitaryPlane("B-2 Spirit",           1030, 22000, 70000,  MilitaryType.BOMBER)
   };
        private readonly List<Plane> planesSortedByMaxLoadCapacity = new List<Plane>(){
           new MilitaryPlane("F-15",                 1500, 12000, 10000,  MilitaryType.FIGHTER),
           new MilitaryPlane("F-22",                 1550, 13000, 11000,  MilitaryType.FIGHTER),
           new PassengerPlane("Embraer 190",         875,  8100,  30800,  64,  ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Sukhoi Superjet 100", 870,  11500, 50500,  140, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Boeing-737",          900,  12700, 60500,  164, ClassificationLevel.UNCLASSIFIED),
           new PassengerPlane("Bombardier CS300",    920,  11000, 60700,  196, ClassificationLevel.UNCLASSIFIED),
           new PassengerPlane("Boeing-737-800",      940,  12300, 63870,  192, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Airbus A320",         930,  11800, 65500,  188, ClassificationLevel.TOP_SECRET),
           new MilitaryPlane("B-2 Spirit",           1030, 22000, 70000,  MilitaryType.BOMBER),
           new PassengerPlane("Boeing-747",          980,  16100, 70500,  242, ClassificationLevel.SECRET),
           new MilitaryPlane("B-52 Stratofortress",  1000, 20000, 80000,  MilitaryType.BOMBER),
           new PassengerPlane("Airbus A330",         990,  14800, 80500,  222, ClassificationLevel.SECRET),
           new MilitaryPlane("B-1B Lancer",          1050, 21000, 83000,  MilitaryType.BOMBER),
           new MilitaryPlane("C-130 Hercules",       650,  5000,  110000, MilitaryType.TRANSPORT)
   };
        private readonly List<Plane> planesSortedByMaxSpeed = new List<Plane>(){
           new MilitaryPlane("C-130 Hercules",       650,  5000,  110000, MilitaryType.TRANSPORT),
           new PassengerPlane("Sukhoi Superjet 100", 870,  11500, 50500,  140, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Embraer 190",         875,  8100,  30800,  64,  ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Boeing-737",          900,  12700, 60500,  164, ClassificationLevel.UNCLASSIFIED),
           new PassengerPlane("Bombardier CS300",    920,  11000, 60700,  196, ClassificationLevel.UNCLASSIFIED),
           new PassengerPlane("Airbus A320",         930,  11800, 65500,  188, ClassificationLevel.TOP_SECRET),
           new PassengerPlane("Boeing-737-800",      940,  12300, 63870,  192, ClassificationLevel.CONFIDENTIAL),
           new PassengerPlane("Boeing-747",          980,  16100, 70500,  242, ClassificationLevel.SECRET),
           new PassengerPlane("Airbus A330",         990,  14800, 80500,  222, ClassificationLevel.SECRET),
           new MilitaryPlane("B-52 Stratofortress",  1000, 20000, 80000,  MilitaryType.BOMBER),
           new MilitaryPlane("B-2 Spirit",           1030, 22000, 70000,  MilitaryType.BOMBER),
           new MilitaryPlane("B-1B Lancer",          1050, 21000, 83000,  MilitaryType.BOMBER),
           new MilitaryPlane("F-15",                 1500, 12000, 10000,  MilitaryType.FIGHTER),
           new MilitaryPlane("F-22",                 1550, 13000, 11000,  MilitaryType.FIGHTER)

   };
        private readonly string planeWithMaxPassengersCapacityAsString = "Plane{ model='Boeing-747', maxSpeed=980, maxFlightDistance=16100, maxLoadCapacity=70500, passengersCapacity=242, modelClass=SECRET}";

        private readonly string transportMilitaryPlaneAsString = "Plane{ model='C-130 Hercules', maxSpeed=650, maxFlightDistance=5000, maxLoadCapacity=110000, type=TRANSPORT}";

        private readonly string airportWithPlaneWithMaxPassengersCapacityAsString = "Airport{ planes=Boeing-747}";
    }

}