namespace Aircompany.Planes
{
    public abstract class Plane
    {
        private const int HashCodeBasePart = -1043886837;
        private const int HashCodeAdditionalPart = -1521134295;

        private readonly string model;
        private readonly int maxSpeed;
        private readonly int maxFlightDistance;
        private readonly int maxLoadCapacity;

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            this.model = model;
            this.maxSpeed = maxSpeed;
            this.maxFlightDistance = maxFlightDistance;
            this.maxLoadCapacity = maxLoadCapacity;
        }

        public string GetModel()
        {
            return model;
        }

        public int GetMAXSpeed()
        {
            return maxSpeed;
        }

        public int GetMAXFlightDistance()
        {
            return maxFlightDistance;
        }

        public int GetMAXLoadCapacity()
        {
            return maxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane{ model='" + model + "', maxSpeed=" + maxSpeed + ", maxFlightDistance=" + maxFlightDistance + ", maxLoadCapacity=" + maxLoadCapacity + '}';
        }

        public override bool Equals(object obj)
        {
            var plane = obj as Plane;
            return plane != null &&
                   model == plane.model &&
                   maxSpeed == plane.maxSpeed &&
                   maxFlightDistance == plane.maxFlightDistance &&
                   maxLoadCapacity == plane.maxLoadCapacity;
        }

        public virtual bool IsEqualsToBase(object obj)
        {
            var plane = obj as Plane;
            return plane.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = HashCodeBasePart;
            hashCode = (hashCode * HashCodeAdditionalPart) + model.GetHashCode();
            hashCode = (hashCode * HashCodeAdditionalPart) + maxSpeed.GetHashCode();
            hashCode = (hashCode * HashCodeAdditionalPart) + maxFlightDistance.GetHashCode();
            hashCode = (hashCode * HashCodeAdditionalPart) + maxLoadCapacity.GetHashCode();
            return hashCode;
        }
    }
}
