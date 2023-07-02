namespace spacebattle
{
    public class Spaceship
    {
        private int[]? coordinates = null;
        private int[]? speedvector = null;
        private bool сanAction = true;
        private double fuel = double.NaN;
        private double fuelflow = double.NaN;
        private int? angle = null;
        private int? anglespeed = null;
        private bool canAngleAction = true;

        public void SetCoordinates(int x, int y)
        {
            coordinates = new int[] { x, y };
        }

        public void SetSpeedVector(int x, int y)
        {
            speedvector = new int[] { x, y };
        }

        public void SetFuel(double fuel)
        {
            this.fuel = fuel;
        }

        public void SetFuelFlow(double fuel_f)
        {
            this.fuelflow = fuel_f;
        }

        public void SetAngle(int? angle)
        {
            this.angle = angle;
        }

        public void SetAngleSpeed(int? anglespeed)
        {
            this.anglespeed = anglespeed;
        }

        public void CannotAction()
        {
            сanAction = false;
        }

        public int[] MovingAction()
        {
            if (coordinates is not null & speedvector is not null & сanAction)
            {
                return new int[] { coordinates[0] + speedvector[0], coordinates[1] + speedvector[1] };
            }

            else { throw new Exception("coordinates or speed vector was null"); }
        }

        public double FuelAfterAction()
        {
            if (fuel < fuelflow)
            {
                throw new Exception("Not enougt fuel");
            }
            return fuel - fuelflow;
        }

        public void CannotAngleAction()
        {
            canAngleAction = false;
        }

        public int? AngleCalculation()
        {
            if (angle is not null & anglespeed is not null & canAngleAction)
            {
                return angle + anglespeed;
            }
            throw new Exception("Enter angle or angle speed");
        }
    }
}