using System.Collections;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveSouth: IMove
    {
        private MarsRover _marsRover;

        public MoveSouth(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Move()
        {
            _marsRover._obstacleFound = ((IList)_marsRover._obstacles).Contains($"{_marsRover._x}:{_marsRover._y + 1}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover._y = _marsRover._y < 9 && !_marsRover._obstacleFound ? _marsRover._y += 1 : _marsRover._y;
        }
    }
}