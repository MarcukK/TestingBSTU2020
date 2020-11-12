namespace Aircompany.Planes
{
    using Aircompany.Models;

    public class MilitaryPlane : Plane
    {
        private const int HashCodeBasePart = 1701194404;
        private const int HashCodeAdditionalPart = -1521134295;

        private readonly MilitaryType type;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.type = type;
        }

        public MilitaryType GetMilitaryPlaneType()
        {
            return this.type;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   type == plane.type;
        }

        public override bool IsEqualByHash(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = HashCodeBasePart;
            hashCode = (hashCode * HashCodeAdditionalPart) + base.GetHashCode();
            hashCode = (hashCode * HashCodeAdditionalPart) + type.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", type=" + type + '}');
        }
    }
}
