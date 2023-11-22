using System.Collections.Generic;
using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int _x;
        public int _y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        public readonly string[] _obstacles;
        public bool _obstacleFound;
        private readonly MoveEast _moveEast;
        private readonly MoveNorth _moveNorth;
        private readonly MoveWest _moveWest;
        private readonly MoveSouth _moveSouth;
        private Dictionary<char, IMove> movements = new Dictionary<char, IMove>();
        

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _obstacles = obstacles;
            _moveEast = new MoveEast(this);
            _moveNorth = new MoveNorth(this);
            _moveWest = new MoveWest(this);
            _moveSouth = new MoveSouth(this);
            movements.Add('E',_moveEast);
            movements.Add('N',_moveNorth);
            movements.Add('S',_moveSouth); 
            movements.Add('W',_moveWest);
            
        }
        
        public string GetState()
        {
            return !_obstacleFound ? $"{_x}:{_y}:{_direction}" : $"O:{_x}:{_y}:{_direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    IMove movement = movements[_direction];
                    movement.Move();
                }
                else if(command == 'L')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 0)
                    {
                        _direction = _availableDirections[currentDirectionPosition-1];
                    }
                    else
                    {
                        _direction = _availableDirections[3];
                    }
                } else if (command == 'R')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 3)
                    {
                        _direction = _availableDirections[currentDirectionPosition+1];
                    }
                    else
                    {
                        _direction = _availableDirections[0];
                    }
                }
            }
        }
    }
}