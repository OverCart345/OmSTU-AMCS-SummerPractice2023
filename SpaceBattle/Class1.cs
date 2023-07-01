namespace spacebattle
{
    public class Spaceship
    {
        private int[]? coordinates = null;
        private int[]? speedvector = null;
        private bool сanAction = true;

        public void SetCoordinates(int x, int y)
        {
            coordinates = new int[] { x, y };
        }

        public void SetSpeedVector(int x, int y)
        {
            speedvector = new int[] { x, y };
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
    }
}