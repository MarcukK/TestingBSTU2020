namespace Aircompany
{
    using System.Collections.Generic;
    using System.Linq;
    using Aircompany.Models;
    using Aircompany.Planes;

    public class Airport
    {
        private readonly List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            passengerPlanes.AddRange(planes.Where(p => p.GetType() == typeof(PassengerPlane)).Select(p => (PassengerPlane)p));
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            militaryPlanes.AddRange(planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Select(p => (MilitaryPlane)p));
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().OrderByDescending(item => item.GetPassengersCapacity()).First();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().FindAll(p => p.GetMilitaryPlaneType().Equals(MilitaryType.TRANSPORT)).ToList();
        }

        public List<PassengerPlane> GetSecretPassengerPlanes()
        {
            return GetPassengersPlanes().FindAll(p => p.GetModelClass().Equals(ClassificationLevel.SECRET)).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(planes.OrderBy(w => w.GetMAXFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(w => w.GetMAXSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(w => w.GetMAXLoadCapacity()));
        }

        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public virtual bool IsEqualsToBase(object obj)
        {
            List<Plane> airport = obj as List<Plane>;
            bool equality = true;
            if (planes.Count == airport.Count)
            {
                for (int i = 0; i < planes.Count; i++)
                {
                    equality &= planes[i].GetHashCode() == airport[i].GetHashCode();
                }
            }
            return equality;
        }

        public override string ToString()
        {
            return "Airport{ planes=" + string.Join(", ", planes.Select(x => x.GetModel())) + '}';
        }
    }
}
