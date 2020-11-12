namespace Aircompany.Planes
{
    using Aircompany.Models;

    public class PassengerPlane : Plane
    {
        private const int HashCodeBasePart = 751774561;
        private const int HashCodeAdditionalPart = -1521134295;

        private readonly ClassificationLevel modelClass;
        private readonly int passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity, ClassificationLevel modelClass)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.passengersCapacity = passengersCapacity;
            this.modelClass = modelClass;
        }

        public int GetPassengersCapacity()
        {
            return this.passengersCapacity;
        }

        public ClassificationLevel GetModelClass()
        {
            return this.modelClass;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   passengersCapacity == plane.passengersCapacity &&
                   modelClass == plane.modelClass;
        }

        public override bool IsEqualsToBase(object obj)
        {
            var plane = obj as Plane;
            return plane.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = HashCodeBasePart;
            hashCode = (hashCode * HashCodeAdditionalPart) + base.GetHashCode();
            hashCode = (hashCode * HashCodeAdditionalPart) + passengersCapacity.GetHashCode();
            hashCode = (hashCode * HashCodeAdditionalPart) + modelClass.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", passengersCapacity=" + passengersCapacity + ", modelClass=" + modelClass + '}');
        }
    }
}
