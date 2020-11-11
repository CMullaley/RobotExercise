using System;
using System.Collections.Generic;
using System.Text;

namespace RobotExercise.State
{
    public class RobotState
    {
        public RobotState(int x, int y, Facing facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public int X { get; }

        public int Y { get; }

        public Facing Facing { get; }

        public override string ToString()
        {
            return $"{X},{Y},{Facing.ToString().ToUpper()}";
        }
    }
}
